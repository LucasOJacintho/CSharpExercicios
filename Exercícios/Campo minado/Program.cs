using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Campo_minado;

namespace Campo_minado
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Variáveis iniciais
            int casaAux = 0;
            int linhaAux = 1;
            int colunaAux = 1;
            Random aleatorio = new Random();
            char valor = '-';
            int numBombas = 0;
            int numBombasAux = numBombas;
            int numCasas = 0;
            List<Mina> mapa = new List<Mina>();
            string casa = "";
            string casaAux2 = "";
            int linha = 0;
            int coluna = 0;
            int[,] matrizHoraria = new int[,] { { -1, 0 }, { -1, 1 }, { 0, 1 }, { 1, 1 }, { 1, 0 }, { 1, -1 }, { 0, -1 }, { -1, -1 } };
            List<string> opcoes = new List<string> { "m", "marcar", "r", "reiniciar", "restart", "resposta", "resp", "i", "inicio", "h", "help", "a", "ajuda", "e", "exit" };
            int linhaAux2 = 1;
            int colunaAux2 = 1;
            bool marcar = false;
            bool resposta = false;
            int bandeiras = 0;

            selecaoMapa();

            //Função espera as dimensões do campo
            void selecaoMapa()
            {
                linha = 0;
                coluna = 0;
                while (linha < 5 || linha > 10)
                {
                    Console.Clear();
                    Console.WriteLine("Digite um valor de 5 a 10: ");
                    linha = int.Parse(Console.ReadLine());
                }
                while (coluna < 5 || coluna > 10)
                {
                    Console.Clear();
                    Console.WriteLine("Digite um valor de 5 a 10: ");
                    Console.WriteLine(linha);
                    Console.WriteLine("Digite um valor de 5 a 10: ");
                    coluna = int.Parse(Console.ReadLine());
                }

                //Definição do número de bombas

                numCasas = coluna * linha;
                casaAux = 0;

                criacaoMapa();
            }

            //Cria a lista de minas no campo e adiciona o valor para cara uma das células
            void criacaoMapa()
            {
                numBombas = Convert.ToInt32((Math.Floor((coluna * linha) * 0.20)));
                numBombasAux = numBombas;
                bandeiras = numBombas;
                for (int j = 1; j <= linha; j++)
                {
                    for (int i = 1; i <= coluna; i++)
                    {
                        casa = Convert.ToString(j) + Convert.ToString(i);
                        valor = '0';
                        if (numBombas > 0)
                        {
                            aleatorio.Next(0, 4);
                            int AleatorioAux = aleatorio.Next(1, 5);
                            if (AleatorioAux == 4)
                            {
                                valor = 'B';
                                numBombas--;
                            }
                        }
                        mapa.AddRange(new List<Mina>
                        {
                            new Mina(casa, valor, false, false, false, false),
                        });
                        opcoes.Add(casa);
                    }
                }

                Console.WriteLine();
                if (numBombas > 0)
                {
                    limpar();
                }
                AvaliarMapa();
            }

            //Função para limpar o tabuleiro
            void limpar()
            {
                Console.Clear();
                mapa.RemoveRange(0, coluna * linha);
                opcoes.RemoveRange(14, opcoes.Count-14);
                criacaoMapa();
            }

            // Função para impressão do mapa
            void ImprimirMapa()
            {
                int fimDeJogo = 0;
                
                //Imprimir linhas Superiores
                Console.Clear();
                linhaAux = 1;
                casaAux = 0;
                Console.Write($"     ");
                for (int i = 1; i <= coluna; i++)
                {
                    if (i < 10)
                        Console.Write($" {i} ");
                    else
                        Console.Write($"{i} ");
                }
                Console.WriteLine();
                Console.Write($"     ");
                for (int i = 1; i <= coluna; i++)
                {
                    Console.Write($" | ");
                }

                //Imprimir demais linhas
                Console.WriteLine();
                Console.Write($" {linhaAux} - ");
                linhaAux++;
                foreach (var endereco in mapa)
                {
                    casaAux++;
                    if (resposta == true)
                        Console.Write($" {endereco.Valor} ");
                    else
                    {
                        if (endereco.Visualizador == true)
                            Console.Write($" {endereco.Valor} ");
                        else if (endereco.Marcado == true)
                            Console.Write($" M ");
                        else
                            Console.Write($" - ");
                    }

                    if (casaAux == coluna && linhaAux <= linha)
                    {
                        Console.WriteLine();
                        if (linhaAux < 10)
                            Console.Write($" {linhaAux} - ");
                        else
                            if (linhaAux < linha + 1)
                            Console.Write($"{linhaAux} - ");
                        linhaAux++;
                        casaAux = 0;
                    }
                }
                Console.WriteLine("\n");
                Console.WriteLine($" Bombas = {numBombasAux}  - Bandeiras = {bandeiras}");
                if (resposta == true)
                {
                    resposta = false;
                    Console.WriteLine("\n" +
                        "\nPressione qualquer tecla para continuar");
                    Console.ReadLine();
                    criacaoMapa();
                }

                foreach (var item in mapa)
                {
                    if (item.Visualizador == true)
                    {
                        fimDeJogo++;
                    }
                }
                if (fimDeJogo == (coluna * linha) - numBombasAux)
                {
                    Console.WriteLine("\n\n\n");
                    Console.WriteLine("#-----------------------------#");
                    Console.WriteLine("| Parabéns você venceu o jogo |");
                    Console.WriteLine("#-----------------------------#\n");
                    Console.WriteLine("\n\n\n\n\n\n Pressione qualquer tecla para continuar");
                    Console.ReadLine();
                    mapa.RemoveRange(0, coluna * linha);
                    opcoes.RemoveRange(14, opcoes.Count - 14);
                    selecaoMapa();
                }

                menu();
            }

            //Função para modificação do valor das casas
            void AvaliarMapa()
            {
                Console.WriteLine();
                for (int i = 0; i < mapa.Count; i++)
                {
                    casa = mapa[i].Id;
                    if (casa.Length <= 3 && casa[1] != '0')
                    {
                        linhaAux = Convert.ToInt32(casa.Remove(1));
                        colunaAux = Convert.ToInt32(casa.Substring(1));
                    }
                    else if (casa.Length <= 3 && casa[1] == '0')
                    {
                        linhaAux = Convert.ToInt32(casa.Remove(2));
                        colunaAux = Convert.ToInt32(casa.Substring(2));
                    }
                    else
                    {
                        linhaAux = Convert.ToInt32(casa.Remove(1, 2));
                        colunaAux = Convert.ToInt32(casa.Substring(2));
                    }
                    if (mapa[i].Valor == 'B')
                        continue;
                    else
                    {
                        for (int j = 0; j <= 7; j++)
                        {
                            linhaAux2 = linhaAux + matrizHoraria[j, 0];
                            if (linhaAux2 > linha || linhaAux2 < 1)
                            {
                                continue;
                            }
                            colunaAux2 = colunaAux + matrizHoraria[j, 1];
                            if (colunaAux2 > coluna || colunaAux2 < 1)
                            {
                                continue;
                            }
                            casaAux2 = Convert.ToString(linhaAux2) + Convert.ToString(colunaAux2);
                            for (int k = 0; k < mapa.Count; k++)
                            {
                                if (mapa[k].Id == casaAux2 && mapa[k].Valor == 'B')
                                {
                                    mapa[i].Valor = Convert.ToChar(Convert.ToInt32(mapa[i].Valor) + 1);
                                }
                            }
                        }
                    }
                }
                ImprimirMapa();
            }

            // Menu para as jogadas
            void menu()
            {
                Console.WriteLine();
                Console.WriteLine();
                if (marcar == false)
                    Console.WriteLine("Informe a linha e coluna separado por espaço, ou uma opção: ");
                else
                    Console.WriteLine("Para efetuar a marcação, Informe a linha e a coluna separado por espaço");
                string mapaJogo = Console.ReadLine().Trim();
                mapaJogo = mapaJogo.ToLower();
                mapaJogo = mapaJogo.Replace(" ","");
                Console.WriteLine();
                if (opcoes.Contains(mapaJogo))
                {
                    if (mapaJogo == "h" || mapaJogo == "a" || mapaJogo == "help" || mapaJogo == "ajuda")
                    {
                        Console.WriteLine("Menu AJuda:" +
                            "\nNo momento o jogo está aguardando que você insira o valor da linha e da coluna exemplo -> '6 8'" +
                            "\nSendo portanto a Linha 6 e a Coluna 8 selecionada." +
                            "\nCaso prefira você poderá entrar com outros termos como:" +
                            "\nM ou Marcar -> Serve para marcar uma determinada casa onde possívelmente existe uma bomba" +
                            "\nR, Reiniciar, Restart -> O jogo atual será encerrado e a seguir será gerado um novo jogo com as mesmas características dimensionais" +
                            "\nI, Iniciar, Inicio -> Você será direcionado ao menu inicial do jogo, podendo iniciar um novo jogo" +
                            "\n" +
                            "\nPressione qualquer tecla para continuar");
                        Console.ReadLine();
                        ImprimirMapa();
                    }
                    if (mapaJogo == "r" || mapaJogo == "reiniciar" || mapaJogo == "restart")
                    {
                        Console.WriteLine("Será gerado um novo campo" +
                            "\nPressione S para continuar ou N para continuar com o jogo atual");
                        while (true)
                        {
                            string simNao = Console.ReadLine();
                            if (simNao == "s" || simNao == "y" || simNao == "sim" || simNao == "yes")
                            {
                                marcar = false;
                                limpar();
                            }
                            else if (simNao == "n" || simNao == "nao" || simNao == "não" || simNao == "no")
                            {
                                ImprimirMapa();
                            }
                        }
                    }
                    if (mapaJogo == "i" || mapaJogo == "iniciar" || mapaJogo == "inicio")
                    {
                        Console.WriteLine("Você voltará ao menu inicial" +
                            "\nPressione S para continuar ou N para continuar com o jogo atual");
                        while (true)
                        {
                            string simNao = Console.ReadLine();
                            if (simNao == "s" || simNao == "y" || simNao == "sim" || simNao == "yes")
                            {
                                marcar = false;
                                mapa.RemoveRange(0, coluna * linha);
                                opcoes.RemoveRange(14, opcoes.Count-14);
                                selecaoMapa();
                            }
                            else if (simNao == "n" || simNao == "nao" || simNao == "não" || simNao == "no")
                            {
                                ImprimirMapa();
                            }
                        }
                        Console.Clear();
                        mapa.RemoveRange(0, coluna * linha);
                        for (int i = 15; i < opcoes.Count - 1; i++)
                        {
                            opcoes[i] = "";
                        }
                        selecaoMapa();
                    }
                    if (mapaJogo == "resposta" || mapaJogo == "resp")
                    {
                        Console.WriteLine("Será exibido a resposta do jogo atual e o jogo será encerrado em seguida" +
                            "\nPressione S para continuar ou N para continuar com o jogo atual");
                        while (true)
                        {
                            string simNao = Console.ReadLine();
                            if (simNao == "s" || simNao == "y" || simNao == "sim" || simNao == "yes")
                            {
                                marcar = false;
                                resposta = true;
                                ImprimirMapa();
                            }
                            else if (simNao == "n" || simNao == "nao" || simNao == "não" || simNao == "no")
                            {
                                ImprimirMapa();
                            }
                        }
                    }
                    if (mapaJogo == "m" || mapaJogo == "marcar")
                    {
                        if (bandeiras <=0)
                            Console.WriteLine("Não é possível marcar mais casas, pressione qualquer tecla para continuar");
                        else
                        {
                            marcar = !marcar;
                            Console.WriteLine("Marque a posição onde é possível que exista uma bomba");
                            ImprimirMapa();
                        } 
                    }
                    else
                    {
                        for (int i = 0; i < mapa.Count; i++)
                        {
                            if (mapa[i].Id == mapaJogo)
                            {
                                if (mapa[i].Marcado == false)
                                {
                                    if (marcar == false)
                                    {
                                        mapa[i].Visualizador = true;
                                        if (mapa[i].Valor == '0')
                                        {
                                            mapa[i].Analizar = true;
                                            analizar();
                                        }
                                        else if(mapa[i].Valor == 'B')
                                        {
                                            Console.Clear();
                                            Console.WriteLine("#------------------------#");
                                            Console.WriteLine("| Você pisou em uma mina |");
                                            Console.WriteLine("#------------------------#\n");
                                            Console.WriteLine("\n\n\n\n\n\n Pressione qualquer tecla para continuar");
                                            Console.ReadLine();
                                            mapa.RemoveRange(0, coluna * linha);
                                            opcoes.RemoveRange(14, opcoes.Count - 14);
                                            selecaoMapa();
                                        }
                                    }
                                    else
                                    {
                                        mapa[i].Marcado = true;
                                        marcar = false;
                                        bandeiras--;
                                    }
                                }
                                else
                                {
                                    if (marcar == true)
                                    {
                                        mapa[i].Marcado = false;
                                        marcar = false;
                                    }
                                }
                            }
                        }
                    }
                }
                else
                {
                    Console.WriteLine("Comando inválido, favor insira um comando válido");
                }
                ImprimirMapa();
            }

            //Função tem por objetivo exibir a cadeia de zeros
            void analizar()
            {
                for (int l = 0; l < 15; l++)
                {
                    for (int i = 0; i < mapa.Count; i++)
                    {
                        if (mapa[i].Analizar == true && mapa[i].Analizado == false)
                        {
                            casa = mapa[i].Id;
                            //estudar como colocar isso em uma função
                            if (casa.Length <= 3 && casa[1] != '0')
                            {
                                linhaAux = Convert.ToInt32(casa.Remove(1));
                                colunaAux = Convert.ToInt32(casa.Substring(1));
                            }
                            else if (casa.Length <= 3 && casa[1] == '0')
                            {
                                linhaAux = Convert.ToInt32(casa.Remove(2));
                                colunaAux = Convert.ToInt32(casa.Substring(2));
                            }
                            else
                            {
                                linhaAux = Convert.ToInt32(casa.Remove(1, 2));
                                colunaAux = Convert.ToInt32(casa.Substring(2));
                            }
                            for (int j = 0; j <= 7; j++)
                            {
                                linhaAux2 = linhaAux + matrizHoraria[j, 0];
                                if (linhaAux2 > linha || linhaAux2 < 1)
                                {
                                    continue;
                                }
                                colunaAux2 = colunaAux + matrizHoraria[j, 1];
                                if (colunaAux2 > coluna || colunaAux2 < 1)
                                {
                                    continue;
                                }
                                casaAux2 = Convert.ToString(linhaAux2) + Convert.ToString(colunaAux2);
                                for (int k = 0; k < mapa.Count; k++)
                                {
                                    if (mapa[k].Id == casaAux2)
                                    {
                                        mapa[k].Visualizador = true;
                                        if (mapa[k].Valor == '0')
                                            mapa[k].Analizar = true;
                                    }
                                }
                            }
                            mapa[i].Analizado = true;
                        }
                    }
                }
                ImprimirMapa();
            }
        }
    }
}
