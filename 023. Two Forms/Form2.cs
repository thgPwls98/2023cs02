﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _023.Two_Forms
{
    public partial class Form2 : Form
    {
        Form1 f = null;
        public Form2(Form1 form, string s)
        {
            InitializeComponent();
            f = form;
            MessageBox.Show(s, "이곳은 Form2");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            f.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            f.Text = textBox1.Text;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            f.label1.Text = textBox1.Text;

        }
    }
}
