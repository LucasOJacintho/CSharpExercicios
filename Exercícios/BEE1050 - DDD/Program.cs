using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BEE1050___DDD
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] DDD = new int[8] { 61, 71, 11, 21, 32, 19, 27, 31 };
            string[] destino = new string[8] { "Brasília", "Salvador", "São Paulo", "Rio de Janeiro", "Juiz de Fora", "Campinas", "Vitoria", "Belo Horizonte" };
            Console.WriteLine("Entre com um valor de DDD Válido");
            int DDDEntrada = Convert.ToInt32(Console.ReadLine());
            for (int i = 0; i < DDD.Length; i++)
            {
                if (DDD[i] == DDDEntrada)
                {
                    Console.WriteLine(destino[i]);
                    Console.ReadLine();
                }
                else
                {
                    if (i == DDD.Length - 1)
                    {
                        Console.WriteLine(DDDEntrada);
                        Console.ReadLine();
                        break;
                    }
                }
            }
        }
    }
}
