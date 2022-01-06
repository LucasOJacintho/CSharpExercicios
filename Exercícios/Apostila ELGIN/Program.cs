using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Apostila_ELGIN
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string msg = "  Olá Mundo!  ";
            Console.WriteLine($"Aprendendo a escrever com o método de Interpolação de Strings: {msg}");

            Console.WriteLine(msg.Length);
            //msg = msg.Trim();
            Console.WriteLine(msg.Trim().Length); //O trim remove apenas os espaços que estão antes ou depois da frase, ele não remove o espaço entre palavras
            Console.WriteLine(msg.Trim().Remove(3)); // Nessa formatação aparecerá apenas os 3 primeiros caractéres
            Console.WriteLine(msg.Trim().Remove(5,3)); // Nessa formatação aparecerá o número de caracteres presentes no primeiro valor,
                                                       // pulará o número de caracteres do segundo valor e apresentará o restante

            Console.WriteLine(msg.Trim().Substring(4, 5)); // Similar ao Remove porém ele não começa da primeira casa a esquerda
                                                           // e sim da primeira casa após a posição indicada no primeiro valor no método,
                                                           // e o segundo valor indica quantas casas serão exibidas

            string eMail = "lucas.jacintho@Iteris.com.br";
            Console.WriteLine($"O seu e-mail sem o domínio é {eMail.Remove(14)}");
            eMail = eMail.Split('@')[1]; // O valor será divido em um array e cada array será determinada entre os valores antes e depois do simbolo presente dentre dos parenteses
                                         // O número que fica dentro do conchetes diz respeito a que valor será adotado/visualizado;
            Console.WriteLine("Esse é o valor que você quer verificar" + eMail);

            string primeiroSobrenome = "oliveira";
            string segundoSobrenome = "jacintho";

            eMail = "lucas.jacintho@Iteris.com.br";
            string novoEmail = eMail.Replace("jacintho", primeiroSobrenome); // A função localiza o primeiro valor e altera pelo segundo,
                                                                             // pode ser usado texto ou variavél para essa manipulação
            Console.WriteLine(novoEmail);

            DateTime data = DateTime.Today; // DateTime -> É um tipo dado para manipular esse tipo de valor, DateTime sozinho retorna ano, mês, dia, hora, minuto, segundo,
                                            // é possível adiconar Today para apresentar apenas ano, mês, dia,
                                            // Now para apresentar horas, minutos e segundos

            Console.WriteLine(DateTime.Now);


            int[] primeiraArray = new int[] { 1, 3, 5, 7, 9 };
            for (int i = 0; i < primeiraArray.Length; i++)
            {
                Console.WriteLine(primeiraArray[i]);
            }
            

            List<string> primeiroList = new List<string>();
            primeiroList.Add("Lucas");
            primeiroList.Add("Oliveira");
            primeiroList.Add("Jacintho");

            foreach(string primeiro in primeiroList)
            {
                Console.WriteLine(primeiro);
            }

            Console.WriteLine(primeiroList[1]);


            string hoje = Convert.ToString(DateTime.Now);
            //hoje = hoje.Split('T')[0];
            DateTime amanha = Convert.ToDateTime(DateTime.Now.Date);
            Console.WriteLine(amanha.ToString("d"));
            Console.ReadLine();
        }

        

    }
}
