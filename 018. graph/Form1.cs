﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace _018.graph
{
    public partial class Form1 : Form
    {
        //생성자 함수: 클래스와 이름이 같은 함수인데 return 값이 없는 함수
        public Form1()
        {
            InitializeComponent();
            this.Text = "Graph using Chart Control";   //Form창의 타이틀의 텍스트
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            ChartSetting();
            DataSetting();
        }

        private void DataSetting()
        {
            //throw new NotImplementedException();
            for (double x = -20; x <= 20; x += 0.1)
            {
                double s = Math.Sin(x) / x;
                double c = Math.Cos(x) / x;
                chart1.Series[0].Points.AddXY(x, s);
                chart1.Series[1].Points.AddXY(x, c);

            }


        }

        private void ChartSetting()
        {
            //배경색
            chart1.ChartAreas[0].BackColor = Color.DarkBlue;
            //throw new NotImplementedException();  //아직 구현되지 않은 에러를 던져라   //함수를 만들었는데 아직 아무것도 안 만들었다는 소리임
            //ChartArea의 x축
            chart1.ChartAreas[0].AxisX.Minimum = -20;
            chart1.ChartAreas[0].AxisX.Maximum = 20;
            chart1.ChartAreas[0].AxisX.Interval = 2;
            chart1.ChartAreas[0].AxisX.MajorGrid.LineColor = Color.Gray;
            chart1.ChartAreas[0].AxisX.MajorGrid.LineDashStyle = ChartDashStyle.Dash;

            //ChartArea의 y축
            chart1.ChartAreas[0].AxisY.Minimum = -2;
            chart1.ChartAreas[0].AxisY.Maximum = 2;
            chart1.ChartAreas[0].AxisY.Interval = 0.5;
            chart1.ChartAreas[0].AxisY.MajorGrid.LineColor = Color.Gray;
            chart1.ChartAreas[0].AxisY.MajorGrid.LineDashStyle = ChartDashStyle.Dash;

            //Series[0] 설정, 디폴트로 제공되는 시리즈
            chart1.Series[0].ChartType = SeriesChartType.Line;
            chart1.Series[0].Color = Color.LightGreen;
            chart1.Series[0].BorderWidth = 2;
            chart1.Series[0].LegendText = "sin(x)/x";

            //series[1]을 추가
            chart1.Series.Add("Series2");

            //Series[1] 설정,추가된 시리즈
            chart1.Series[1].ChartType = SeriesChartType.Line;
            chart1.Series[1].Color = Color.Orange;
            chart1.Series[1].BorderWidth = 2;
            chart1.Series[1].LegendText = "cos(x)/x";    //alt키를 누른 상태에서 마우스로 포함시키면 편하다


        }

    }
}
