using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BEE1002___Área_de_um_círculo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Digite um valor de raio");
            double R = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("A=" + (R * R * 3.14159));
            Console.ReadLine();
        }
    }
}
