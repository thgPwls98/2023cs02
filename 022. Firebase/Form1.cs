using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FireSharp.Interfaces;     //밑의 3개 추가하기
using FireSharp.Config;
using FireSharp.Response;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace _021.Firebase
{
    public partial class Form1 : Form
    {
        DataTable dt = new DataTable();
        IFirebaseConfig config = new FirebaseConfig
        {
            AuthSecret = "U1XJnaJ4HGIsXcactHPmOfD3PHNtqXDlN76F42JO",
            BasePath = "https://fir-hyejin-default-rtdb.firebaseio.com/"
        };

        IFirebaseClient client;    //database와 c#을 이어주는 매개체
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            client = new FireSharp.FirebaseClient(config);
            if (client != null)  //제대로 만들어진거면 null이 아니므로 코드가 실행됨! 나와야 한다!!
                MessageBox.Show("Connection 성공!");

            // DataGridView에서 사용하는 필드
            dt.Columns.Add("Id");
            dt.Columns.Add("학번");
            dt.Columns.Add("이름");
            dt.Columns.Add("전화번호");

            dataGridView1.DataSource = dt;
            export();
        }

        private async void btnInsert_Click(object sender, EventArgs e)
        {
            // Firebase에서 cnt 값을 가져온다
            //Firebase에서 값을 가져오는 것을 GetaSync
            FirebaseResponse resp
              = await client.GetAsync("VP02_Counter/nPhone");
            Counter c = resp.ResultAs<Counter>();

            // Data 클래스를 만들 것
            var data = new Data
            {
                //Id = txtId.Text,
                Id = (c.cnt + 1).ToString(),
                SId = txtSId.Text,
                Name = txtName.Text,
                Phone = txtPhone.Text
            };

            SetResponse response = await
              client.SetAsync("VP02_Phonebook/" + data.Id, data);
            Data result = response.ResultAs<Data>();
            MessageBox.Show("Data Inserted : Id = " + result.Id);

            // Firebase에 있는 cnt를 증가시켜서 저장
            var obj = new Counter
            {
                cnt = c.cnt + 1
            };
            SetResponse resp1
              = await client.SetAsync("VP02_Counter/nPhone", obj);

            export();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtId.Text = "";
            txtSId.Text = "";
            txtName.Text = "";
            txtPhone.Text = "";
        }

        private async void btnSearch_Click(object sender, EventArgs e)
        {
            FirebaseResponse response = await
              client.GetAsync("VP02_Phonebook/" + txtId.Text);
            Data obj = response.ResultAs<Data>();

            txtId.Text = obj.Id;
            txtSId.Text = obj.SId;
            txtName.Text = obj.Name;
            txtPhone.Text = obj.Phone;

            MessageBox.Show("Data retrieved successfully!");
        }

        private async void btnUpdate_Click(object sender, EventArgs e)
        {
            var data = new Data
            {
                Id = txtId.Text,
                SId = txtSId.Text,
                Name = txtName.Text,
                Phone = txtPhone.Text
            };

            FirebaseResponse response = await
              client.UpdateAsync("VP02_Phonebook/" + txtId.Text, data);
            Data result = response.ResultAs<Data>();
            MessageBox.Show("Data Updated at " + result.Id);

            export();
        }

        private async void btnDelete_Click(object sender, EventArgs e)
        {
            FirebaseResponse response = await
              client.DeleteAsync("VP02_Phonebook/" + txtId.Text);
            MessageBox.Show("Deleted! : id = " + txtId.Text);
            txtId.Text = "";
            txtSId.Text = "";
            txtName.Text = "";
            txtPhone.Text = "";

            export();
        }

        // 모두 삭제 : 메시지박스에서 확인 필요
        private async void btnDeleteAll_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show(
              "저장된 데이터가 모두 삭제됩니다. 계속할까요?",
              "Warning!", MessageBoxButtons.YesNo,
              MessageBoxIcon.Warning);

            if (result == DialogResult.No)
                return;

            FirebaseResponse response = await
              client.DeleteAsync("VP02_Phonebook");
            MessageBox.Show("All Data deleted /VP02_Phonebook");

            export();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnViewAll_Click(object sender, EventArgs e)
        {
            export();
        }

        // Firebase에서 데이터를 읽고 dataGridView1에 표시
        private async void export()
        {
            dt.Rows.Clear();

            int i = 0;
            FirebaseResponse response =
              await client.GetAsync("VP02_Counter/nPhone");
            Counter obj = response.ResultAs<Counter>();
            int cnt = obj.cnt;
            MessageBox.Show(cnt.ToString());
            while (i != cnt)
            {
                i++;
                FirebaseResponse r
                  = await client.GetAsync("VP02_Phonebook/" + i);

                Data d = r.ResultAs<Data>();

                if (d != null)  // 중간에 삭제된 데이터가 있을 수 있으므로
                {
                    DataRow row = dt.NewRow();
                    row["Id"] = d.Id;
                    row["학번"] = d.SId;
                    row["이름"] = d.Name;
                    row["전화번호"] = d.Phone;

                    dt.Rows.Add(row);
                }
            }
        }
        //cell을 클릭해서 수정하기 용이함! 속성창에서 마우스의 event란에서 CellClick을 더블클릭하면 뜬다!

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridView dgv = (DataGridView)sender;

            txtId.Text = dgv.Rows[e.RowIndex].Cells[0].Value.ToString();
            txtSId.Text = dgv.Rows[e.RowIndex].Cells[1].Value.ToString();
            txtName.Text = dgv.Rows[e.RowIndex].Cells[2].Value.ToString();
            txtPhone.Text = dgv.Rows[e.RowIndex].Cells[3].Value.ToString();

        }
    }
}
