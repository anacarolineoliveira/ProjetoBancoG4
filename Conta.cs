using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CorrecaoBanco
{
    abstract class Conta
    {
        public int Id { get; set; }
        public string Numero { get; set; }
        public decimal Saldo { get; protected set; }
        public Cliente Cliente { get; set; }
        public string TipoConta { get; set; }


        public Conta(Cliente cliente, string numero, int id)
        {
            Cliente = cliente;
            Saldo = 0;
            Numero = numero;
            Id = id;
        }
        

        protected TipoCliente ClassificarCliente()
        {
            if(Saldo >= 15000)
            {
                return Cliente.Tipo = TipoCliente.Premium;
            }

            else if (Saldo >= 5000 && Saldo <= 14999)
            {
                return Cliente.Tipo = TipoCliente.Super;
            }
            else
            {
                return Cliente.Tipo = TipoCliente.Comum;
            }
        }

        public abstract void Transferir();

        public abstract void Depositar();

        public abstract void ConsultarSaldo();
        


    }
}

