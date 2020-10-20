using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using System.Reflection;
using System.Windows.Forms;

namespace laba2_1
{
    class Program
    {

        [DllImport("Lib2-1.dll", CallingConvention = CallingConvention.Cdecl)]
        public static extern double TheFunc(string name, double x);
        static public double[] GetABC(string surname)
        {
            double[] abc = new double[3];
            double c = TheFunc(surname, 0.0);
            abc[0] = Math.Round((TheFunc(surname, 2.0) - c) / 2 - (TheFunc(surname, 1.0) - c) / 1, 1);
            abc[1] = Math.Round(TheFunc(surname, 1.0) - abc[0] - c, 1);
            abc[2] = c;

            return abc;
        }

        static void Main(string[] args)
        {
            double x, y;
            Console.Write("Введите фамилию: ");
            string surname = Console.ReadLine();
            Console.WriteLine("Функция имеет вид y=a*x^2+b*x+c.");

            for(x=0; x<=10; x++)
            {
                y = Math.Round(TheFunc(surname, x), 1);
                Console.WriteLine($"X={x}  Y={y}");                
            }

            double a, b, c;
            a = GetABC(surname)[0];            
            b = GetABC(surname)[1];
            c = GetABC(surname)[2];
            Console.WriteLine($"{Environment.NewLine}a={a} b={b} c={c}");

            Application.Run(new Graph(surname));

            Console.ReadLine();
        }
    }
}
