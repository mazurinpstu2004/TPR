using System;

namespace TRP
{
    public class Program
    {
        const double epsilon = 1e-6;
        const double delta = epsilon / 2;
        static int iter_count = 0;
        static void Main()
        {
            double a = -0.5;
            double b = 0.25;
            double x_min1 = Program.first_method(a, b);
            double min_f1 = Program.function(x_min1);
            Console.WriteLine("Минимум функции f(x) = -x^3 + 3(1+x)(ln(x+1)-1). Метод деления пополам.");
            Console.WriteLine("Xmin = " + x_min1);
            Console.WriteLine("Минимальное значение функции: " + min_f1);
            Console.WriteLine("Количество итераций: " + iter_count);

            Console.WriteLine();

            double x_min2 = Program.second_method(a, b);
            double min_f2 = Program.function(x_min2);
            Console.WriteLine("Минимум функции f(x) = -x^3 + 3(1+x)(ln(x+1)-1). Метод касательных.");
            Console.WriteLine("Xmin = " + x_min2);
            Console.WriteLine("Минимальное значение функции: " + min_f2);
            Console.WriteLine("Количество итераций: " + iter_count);

            Console.WriteLine();

            double x_min3 = Program.third_method(a);
            double min_f3 = Program.function(x_min2);
            Console.WriteLine("Минимум функции f(x) = -x^3 + 3(1+x)(ln(x+1)-1). Метод Ньютона.");
            Console.WriteLine("Xmin = " + x_min3);
            Console.WriteLine("Минимальное значение функции: " + min_f3);
            Console.WriteLine("Количество итераций: " + iter_count);

        }
        public static double function(double x)
        {
            return -Math.Pow(x, 3) + 3 * (1 + x) * (Math.Log(x + 1) - 1);
        }
        public static double dev_function(double x)
        {
            return 3 * (Math.Log(x + 1)) - 3 * Math.Pow(x, 2);
        }
        public static double dev_sec_function(double x)
        {
            return 3 / (x + 1) - 6 * x;
        }
        public static double first_method(double a, double b)
        {
            iter_count = 0;
            while (Math.Abs(b - a) > epsilon)
            {
                double x1 = (a + b - delta) / 2;
                double x2 = (a + b + delta) / 2;

                if (function(x1) >= function(x2))
                {
                    a = x1;
                }
                else
                {
                    b = x2;
                }
                iter_count++;
            }
            return (a + b) / 2;
        }
        public static double second_method(double a, double b)
        {
            iter_count = 0;
            double xm = 0;
            while (Math.Abs(b - a) > epsilon)
            {
                xm = (a * dev_function(a) - b * dev_function(b) - function(a) + function(b)) / (dev_function(a) - dev_function(b));
                if (dev_function(xm) > 0)
                {
                    b = xm;
                }
                else
                {
                    a = xm;
                }

                iter_count++;
            }

            return xm;
        }
        public static double third_method(double a)
        {
            iter_count = 0;
            double x0 = a;
            double xk;

            while (true)
            {
                xk = x0 - dev_function(x0) / dev_sec_function(x0);
                if (Math.Abs(xk - x0) < epsilon && Math.Abs(function(xk) - function(x0)) < epsilon)
                {
                    break;
                }
                x0 = xk;
                iter_count++;
            }
            return xk;
        }
    }
}


