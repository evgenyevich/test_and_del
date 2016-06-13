using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace triangle
{
    class CalculateTheArea
    {
        private static bool CheckTriangle(double a,double b,double c)
        {
            //проверка на то, что треугольник является прямоугольным
            return  Math.Round(c,6) == Math.Round((Math.Sqrt((Math.Pow(a, 2)) + (Math.Pow(b, 2)))),6);
        }
        private static bool CheckValues(double a, double b, double c)
        {
            //проверка, что введены все значения
            return !(a <= 0) && !(b <= 0) && !(c <= 0);
        }

        private static string CalcTriangle(double a, double b, double c)
        {
            //считаем площадь
            double p = (a + b + c) / 2;
            return Math.Sqrt((p * (p - a) * (p - b) * (p - c))).ToString();
        }

        private static double Side(string s)
        {
            //преобразуем текст в double
            try
            {
                return double.Parse(String.IsNullOrEmpty(s) ? "0" : s);
            }
            catch 
            {
                return 0;
            }
        }
        public static string SetResult(string catet_a, string catet_b, string hypo_c)
        {
            //возвращаем результат
            double a = Side(catet_a);
            double b = Side(catet_b);
            double c = Side(hypo_c);
            if (!CheckValues(a, b, c))
            {
                return "Недостаточно данных для расчета";
            }
            if (!CheckTriangle(a, b, c))
            {
                return "   Данная фигура не является \r\n прямоугольным треугольником";
            }
            if (CheckTriangle(a, b, c))
            {
                return "Площадь треугольника равна : " +CalcTriangle(a, b, c);
            }
            return null;
        }
    }
}
