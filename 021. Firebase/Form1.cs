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

namespace _021.Firebase
{
    public partial class Form1 : Form
    {
        IFirebaseConfig config = new FirebaseConfig
        {
            AuthSecret = "U1XJnaJ4HGIsXcactHPmOfD3PHNtqXDlN76F42JO",
            BasePath = "https://fir-hyejin-default-rtdb.firebaseio.com/"
        };
        IFirebaseClient client;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            client = new FireSharp.FirebaseClient(config);
            if (client != null)  //제대로 만들어진거면 null이 아니므로 코드가 실행됨! 나와야 한다!!
            {
                MessageBox.Show("Connection 성공!");
            }
        }
    }
}
