using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;



namespace Lab42
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFile = new OpenFileDialog();
            if (openFile.ShowDialog() == DialogResult.OK)
            {
                richTextBox1.Text = File.ReadAllText(openFile.FileName);
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Вы хотите выйти из програмы?");
            Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            richTextBox1.Clear();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            string[] file_name = File.ReadAllLines("text.txt");
            int Xa = Convert.ToInt32(file_name[1]);
            int Ya = Convert.ToInt32(file_name[2]);
            int Xb = Convert.ToInt32(file_name[4]);
            int Yb = Convert.ToInt32(file_name[5]);
            int Xc = Convert.ToInt32(file_name[7]);
            int Yc = Convert.ToInt32(file_name[8]);
            int Xd = Convert.ToInt32(file_name[10]);
            int Yd = Convert.ToInt32(file_name[11]);



            double LongAB = Math.Sqrt(Math.Pow(Xb - Xa, 2) + Math.Pow(Yb - Ya, 2));
            double LongBC = Math.Sqrt(Math.Pow(Xc - Xb, 2) + Math.Pow(Yc - Yb, 2));
            double LongCD = Math.Sqrt(Math.Pow(Xc - Xd, 2) + Math.Pow(Yc - Yd, 2));
            double LongDA = Math.Sqrt(Math.Pow(Xa - Xd, 2) + Math.Pow(Ya - Yd, 2));

            
            
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
