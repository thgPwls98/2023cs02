using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _002.BMI_계산기
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            double weight, height;

            height = double.Parse(txtH.Text);
            weight = double.Parse(txtW.Text);

            double bmi = weight / (height / 100 * height / 100);
            //label3.Text = "BMI=" +bmi+ "입니다.";
            lblBMI.Text
                = String.Format("BMI = {0,10:F2} 입니다.", bmi);

            string a;
            if (bmi < 20)
            {
                a = "저체중";
                pictureBox1.BackColor = Color.Blue;
            }
            else if (bmi >= 20 && bmi < 25)
            {
                a = "정상체중";
                pictureBox1.BackColor = Color.Green;

            }
            else if (bmi >= 25 && bmi < 30)
            {
                a = "경도비만";
                pictureBox1.BackColor = Color.Yellow;

            }
            else if (bmi >= 30 && bmi < 40)
            {
                a = "비만";
                pictureBox1.BackColor = Color.Red;

            }
            else
            {
                a = "고도비만";
                pictureBox1.BackColor = Color.DarkRed;

            }

            lblresult.Text = String.Format("당신은 {0} 입니다.", a);
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void lblresult_Click(object sender, EventArgs e)
        {

        }

        private void txtW_TextChanged(object sender, EventArgs e)
        {

        }

        private void lblBMI_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}

