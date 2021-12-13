using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BEE1074___Par_ou_Impar
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int N = Convert.ToInt32(Console.ReadLine());

            if (N == 0)
            {
                Console.WriteLine("Nulo");
            }
            else 
            {
                if (N % 2 == 0)
                {
                    Console.Write("Par");
                }
                else
                {
                    Console.Write("Impar");
                }
                if (N > 0)
                {
                    Console.Write(" Positivo");
                }
                else
                {
                    Console.Write(" Negativo");
                }
            }
            Console.ReadLine();
        }
    }
}
