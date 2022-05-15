using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CorrecaoBanco
{
    interface ILeitura
    {
        public string[] Decodificar(string c);


        public void CarregarDados(string[] s);

    }
}
