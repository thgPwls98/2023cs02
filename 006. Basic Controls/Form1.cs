﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _006.Basic_Controls
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnClick_Click(object sender, EventArgs e)
        {
            if (txtName.Text != "")
                lblHello.Text = txtName.Text + "님! 안녕하세요!";
            else
                MessageBox.Show("이름을 입력하세요", "Warning");  //MessageBox.Show("내용", "창의 타이틀");
        }
    }
}
