using System;
using System.Windows.Forms;


namespace Lab5
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            double Xa = Convert.ToInt32(txbxa.Text);
            double Ya = Convert.ToInt32(txbya.Text);
            double Xb = Convert.ToInt32(txbxb.Text);
            double Yb = Convert.ToInt32(txbyb.Text);
            double Xc = Convert.ToInt32(txbxc.Text);
            double Yc = Convert.ToInt32(txbyc.Text);
            double Xd = Convert.ToInt32(txbxd.Text);
            double Yd = Convert.ToInt32(txbyd.Text);

            double AB = Long(Xa, Xb, Ya, Yb);
            double BC = Long(Xb, Xc, Yb, Yc);
            double CD = Long(Xc, Xd, Yc, Yd);
            double DA = Long(Xd, Xa, Yd, Ya);
            double AC = Long(Xa, Xc, Ya, Yc);

            C(AB, BC, CD, DA);
            Per(AB, BC, CD, DA);
            Sq(AB, BC);
            ChosingSecond(AB, BC, CD, AC);
        }
        static double Long(double x1, double x2, double y1, double y2)   // просчитывает длины сторон. 
        {
            double ABx = y2 - y1;
            double ABy = x2 - x1;
            double AB = Math.Sqrt(Math.Pow(ABx, 2) + Math.Pow(ABy, 2));
            return AB;
        }
        static double C(double A, double B, double C, double D) //проверка на коректность данных. 
        {
            if (A < B || A < C || A < D || B < C || B < D || D < C)
            {
                
            }
            else
            {
                label10.Text = "Фигура не та";
            } 
            

            return A;
        }
        static double Per(double A, double B, double C, double D) //подсчёт преиметра фигуры 
        {
            double Per = A + B + C + D;
            label11.Text = Per;
            return Per;
        }

        static double Sq(double A, double B) //площадь фигуры 
        {
            double Sq = A * B;
            label14.Text = Sq;
            return Sq;
        }

        static double ChosingSecond(double A, double B, double C, double D) //проверка фигуры являеться ли она ромбом
        {
            double AC = Math.Sqrt(Math.Pow(A, 2) + Math.Pow(C, 2));
            double BD = Math.Sqrt(Math.Pow(B, 2) + Math.Pow(D, 2));


            if (AC == BD)
            { label15.Text = $"Фигура: квадрат"; }

            else
            { label15.Text = "Фигура: ромб"; }
            return 0;
        }
    }
}
