﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WORK1_16_
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("16.Реализовать функцию возведения в квадрат произведения двух вещественных чисел");
            double num1, num2;
            Console.WriteLine("Введите первое число");
            num1 = Convert.ToInt64(Console.ReadLine());
            Console.WriteLine("Введите второе число");
            num2 = Convert.ToInt64(Console.ReadLine());
            Console.WriteLine($"Первое число =  {num1}, а второе = {num2}");

            double res = SquareSum(num1, num2);
            Console.WriteLine($"Результат подсчёта = { res}");

            Console.ReadKey();


        }

        static double SquareSum(double x, double y)
        {
            double sum = x * y;
            double result = Math.Pow(sum, 2);

            return result;
        }



    }
}
