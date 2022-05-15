using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CorrecaoBanco
{
    interface IGravacao
    {
        public string ConverterDados(Dictionary<string, TipoChavePix> dados);


        public void Salvar(string c, string v);
    }
}
