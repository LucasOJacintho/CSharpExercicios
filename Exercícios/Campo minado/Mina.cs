using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Campo_minado
{
    internal class Mina
    {
        public string Id { get; set; }
        public Char Valor { get; set; }
        public bool Visualizador { get; set; } = false;
        public bool Analizar {get; set; } = false;
        public bool Analizado { get; set; } = false;
        public bool Marcado { get; set; } = false;  

        public Mina(string i, char v1, bool v2, bool v3,bool v4,bool v5)
        {
            this.Id = i;
            this.Valor = v1;
            this.Visualizador = v2;
            this.Analizar = v3;
            this.Analizado = v4;
            this.Marcado = v5;  
        }
    }
}
