using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _023_Two_Forms
{
    public partial class Form1 : Form
    {
        Form2 f;
        public Form1()
        {
            InitializeComponent();
        }


        private void button1_Click(object sender, EventArgs e)
        {
            if (f == null)    //Form2가 없을 때
                f = new Form2(this, "나는 Form1 이야");
            f.Show();
            this.Hide();   //this=Form1
        }

        private void button2_Click(object sender, EventArgs e)
        {
            label1.Text = f.textBox1.Text;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            MessageBox.Show(Common.str + "\n" + Common.value);
        }
    }
    public static class Common
    {
        public static string str = "";
        public static int value = 0;
    }

}
