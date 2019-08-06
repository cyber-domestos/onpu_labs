using System;
using System.IO;
using System.Diagnostics;
using System.Threading;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{




    class Program
    {


        static void Main(string[] args)
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

            double AB = Long(Xa, Xb, Ya, Yb);
            Console.WriteLine($"Длина стороны АВ = {AB}");
            double BC = Long(Xb, Xc, Yb, Yc);
            Console.WriteLine($"Длина стороны BC = {BC}");
            double CD = Long(Xc, Xd, Yc, Yd);
            Console.WriteLine($"Длина стороны CD = {CD}");
            double DA = Long(Xd, Xa, Yd, Ya);
            Console.WriteLine($"Длина стороны DA = {DA}");
            double AC = Long(Xa, Xc, Ya, Yc);
            Console.WriteLine($"Диагональ = {AC}");
            Console.WriteLine($"     ");
            Console.WriteLine($"     ");
            Console.WriteLine($"     ");
            Console.WriteLine($"     ");

            C(AB, BC, CD, DA);
            Per(AB, BC, CD, DA);
            Sq(AB, BC);
            ChosingSecond(AB, BC, CD, AC);
            Console.ReadKey();
        }


        static double Long(int x1, int x2, int y1, int y2)   // просчитывает длины сторон. 
        {
            double ABx = y2 - y1;
            double ABy = x2 - x1;
            double AB = Math.Sqrt(Math.Pow(ABx, 2)+ Math.Pow(ABy,2));
            return AB;
        }
        
        static double C(double A, double B, double C, double D) //проверка на коректность данных. 
        {
            if (A < B || A < C || A < D || B < C || B < D || D < C)
            {
                Console.WriteLine($"Четырёхугольник ни квадрат ни ромб");
            }
            else
                Console.WriteLine($"Фигура: ромб либо квадрат");

            return A;

        }

        static double Per(double A, double B, double C, double D) //подсчёт преиметра фигуры 
        {
            double Per = A + B + C + D;
            Console.WriteLine($"Периметр фигуры = {Per}");
                return Per;
        }

        static double Sq(double A, double B) //площадь фигуры 
        {
            double Sq = A * B;
            Console.WriteLine($"Площадь фигуры = {Sq}");
            return Sq; 
        }

        static double ChosingSecond(double A, double B, double C, double D) //проверка фигуры являеться ли она ромбом
        {
            double AC = Math.Sqrt(Math.Pow(A, 2) + Math.Pow(C, 2));
            double BD = Math.Sqrt(Math.Pow(B, 2) + Math.Pow(D, 2));


            if (AC == BD)
            { Console.WriteLine($"Фигура: квадрат"); }

            else
            { Console.WriteLine($"Фигура: ромб"); }
            return 0;
        }



    }
}
