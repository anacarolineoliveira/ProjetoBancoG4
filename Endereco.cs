using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CorrecaoBanco
{
    public class Endereco
    {
        private string Cidade { get; set; }
        private string Estado { get; set; }
        private string Pais { get; set; }
        private string Rua { get; set; }
        private string Bairro { get; set; }
        private string Complemento { get; set; }
        private int Cep { get; set; }
        private int Numero { get; set; }

        public Endereco(string cidade, string estado, string pais, string rua, string bairro, string complemento, int numero, int cep)
        {
            this.Cidade = cidade;
            this.Estado = estado;
            this.Pais = pais;
            this.Rua = rua;
            this.Bairro = bairro;
            this.Complemento = complemento;
            this.Numero = numero;
            this.Cep = cep;
        }


    }
    
}
