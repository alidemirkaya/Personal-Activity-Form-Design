using LiveCharts;
using LiveCharts.Wpf;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Forms;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using LiveCharts;
using LiveCharts.Wpf;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            cartesianChart1.Series = new SeriesCollection
            {
                new ColumnSeries
                {
                    Title = "2015",
                    Values = new ChartValues<double> { 10, 50, 39, 50 },       
                    Fill=new SolidColorBrush(System.Windows.Media.Color.FromRgb(201, 104, 220))
                }
            };

            //adding series will update and animate the chart automatically
            cartesianChart1.Series.Add(new ColumnSeries
            {
                Title = "2016",
                Values = new ChartValues<double> { 11, 56, 42 },
                Fill = new SolidColorBrush(System.Windows.Media.Color.FromRgb(74, 46, 182))
            });

            //also adding values updates and animates the chart automatically
            cartesianChart1.Series[1].Values.Add(48d);

            cartesianChart1.AxisX.Add(new Axis
            {
                Title = "Sales Man",
                Labels = new[] { "Maria", "Susan", "Charles", "Frida" },
                
            });

            cartesianChart1.AxisY.Add(new Axis
            {
                Title = "Sold Apps",
                LabelFormatter = value => value.ToString("N")
            });
            //
            cartesianChart2.Series = new SeriesCollection
            {
                new ColumnSeries
                {
                    Title = "2015",
                    Values = new ChartValues<double> { 10, 50, 39, 50 },
                    Fill=new SolidColorBrush(System.Windows.Media.Color.FromRgb(201, 104, 220))
                }
            };

            //adding series will update and animate the chart automatically
            cartesianChart2.Series.Add(new ColumnSeries
            {
                Title = "2016",
                Values = new ChartValues<double> { 11, 56, 42 },
                Fill = new SolidColorBrush(System.Windows.Media.Color.FromRgb(74, 46, 182))
            });

            //also adding values updates and animates the chart automatically
            cartesianChart2.Series[1].Values.Add(48d);

            cartesianChart2.AxisX.Add(new Axis
            {
                Title = "Sales Man",
                Labels = new[] { "Maria", "Susan", "Charles", "Frida" },

            });

            cartesianChart2.AxisY.Add(new Axis
            {
                Title = "Sold Apps",
                LabelFormatter = value => value.ToString("N")
            });
        }

        DataClasses1DataContext dc = new DataClasses1DataContext();
        Resimleme Resimleme = new Resimleme();
        List<Kullanicilar> TIl = new List<Kullanicilar>();

        private void bunifuImageButton1_Click(object sender, EventArgs e)
        {
            panel1.BackColor = System.Drawing.Color.WhiteSmoke;
            panel2.BackColor = System.Drawing.Color.Transparent;
            panel3.BackColor = System.Drawing.Color.Transparent;
            panel4.BackColor = System.Drawing.Color.Transparent;
            panel5.BackColor = System.Drawing.Color.Transparent;
        }

        private void bunifuImageButton2_Click(object sender, EventArgs e)
        {
            panel1.BackColor = System.Drawing.Color.Transparent;
            panel2.BackColor = System.Drawing.Color.WhiteSmoke;
            panel3.BackColor = System.Drawing.Color.Transparent;
            panel4.BackColor = System.Drawing.Color.Transparent;
            panel5.BackColor = System.Drawing.Color.Transparent;
        }

        private void bunifuImageButton3_Click(object sender, EventArgs e)
        {
            panel1.BackColor = System.Drawing.Color.Transparent;
            panel2.BackColor = System.Drawing.Color.Transparent;
            panel3.BackColor = System.Drawing.Color.WhiteSmoke;
            panel4.BackColor = System.Drawing.Color.Transparent;
            panel5.BackColor = System.Drawing.Color.Transparent;
        }

        private void bunifuImageButton4_Click(object sender, EventArgs e)
        {
            panel1.BackColor = System.Drawing.Color.Transparent;
            panel2.BackColor = System.Drawing.Color.Transparent;
            panel3.BackColor = System.Drawing.Color.Transparent;
            panel4.BackColor = System.Drawing.Color.WhiteSmoke;
            panel5.BackColor = System.Drawing.Color.Transparent;
        }

        private void bunifuImageButton5_Click(object sender, EventArgs e)
        {
            panel1.BackColor = System.Drawing.Color.Transparent;
            panel2.BackColor = System.Drawing.Color.Transparent;
            panel3.BackColor = System.Drawing.Color.Transparent;
            panel4.BackColor = System.Drawing.Color.Transparent;
            panel5.BackColor = System.Drawing.Color.WhiteSmoke;
        }

        private void bunifuFlatButton1_Click(object sender, EventArgs e)
        {
            panel6.BackColor = System.Drawing.Color.Moccasin;
            panel7.BackColor = System.Drawing.Color.Transparent;
            panel8.BackColor = System.Drawing.Color.Transparent;
            panel9.BackColor = System.Drawing.Color.Transparent;           
        }

        private void bunifuFlatButton2_Click(object sender, EventArgs e)
        {
            panel6.BackColor = System.Drawing.Color.Transparent;
            panel7.BackColor = System.Drawing.Color.Moccasin;
            panel8.BackColor = System.Drawing.Color.Transparent;
            panel9.BackColor = System.Drawing.Color.Transparent;
        }

        private void bunifuFlatButton3_Click(object sender, EventArgs e)
        {
            panel6.BackColor = System.Drawing.Color.Transparent;
            panel7.BackColor = System.Drawing.Color.Transparent;
            panel8.BackColor = System.Drawing.Color.Moccasin;
            panel9.BackColor = System.Drawing.Color.Transparent;
        }

        private void bunifuFlatButton4_Click(object sender, EventArgs e)
        {
            panel6.BackColor = System.Drawing.Color.Transparent;
            panel7.BackColor = System.Drawing.Color.Transparent;
            panel8.BackColor = System.Drawing.Color.Transparent;
            panel9.BackColor = System.Drawing.Color.Moccasin;
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            foreach(var deg in dc.Personal)
            {
                Yerlestir(Resimleme.ResimGetirme(deg.Personel_Picture.ToArray()), deg.Personal_Name + " " + deg.Personal_Surname, deg.Telefon, deg.Personal_University, deg.Personal_Job);
            }
        }
        public void Yerlestir(System.Drawing.Image resim,string isim,string telefon,string univer,string meslek)
        {
            Kullanicilar item = new Kullanicilar();
            item.bunifuPictureBox1.Image = resim;
            item.label1.Text = isim;
            item.label2.Text = telefon;
            item.label3.Text = univer;
            item.label4.Text = meslek;
            item.Dock = DockStyle.Top;
            TIl.Add(item);
            bunifuGradientPanel4.Controls.Add(item);

        }
    }
}
