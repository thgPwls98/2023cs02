using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _011.scoreCalc
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void btnCalc_Click(object sender, EventArgs e)
        {
            double sum = double.Parse(txtKor.Text) + double.Parse(txtmath.Text) + double.Parse(txtEng.Text);

            double avg = sum / 3;
            txtSum.Text = sum.ToString();    //ToString() ->모두 문자열로 바꿔달라는 명령어
            txtAvg.Text = avg.ToString("0.0");    //소수점 한자리   

        }
    }
}
