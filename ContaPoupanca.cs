using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CorrecaoBanco
{
    class ContaPoupanca : Conta
    {
        private decimal TaxaRendimento { get; set; }

        public ContaPoupanca(Cliente cliente) : base(cliente, "6868", 20)
        {
            TipoConta = "Poupança";
            TaxaRendimento = 0.05m;
            TaxaRendimento = Saldo + (Saldo * (decimal)TaxaRendimento);
        }

        public override void Transferir()
        {
            Console.WriteLine("Insira o valor desejado: ");
            decimal valor = decimal.Parse(Console.ReadLine());
            if (Saldo < valor + TaxaRendimento)
            {
                Console.WriteLine($"Você não tem saldo suficiente para essa transferência!\nSaldo: R${Saldo}");
                Console.WriteLine("\nVoltando ao menu principal!\n");
                Thread.Sleep(5000);
            }
            else
            {
                Saldo -= valor + TaxaRendimento;
                base.ClassificarCliente();
                Console.WriteLine($"Você transferiu dinheiro da conta poupança!\nSaldo após o transferência: R${Saldo}");
                Console.WriteLine("Dados gravados com sucesso!\n");
                Console.WriteLine("Voltando ao menu principal!\n");
                Thread.Sleep(5000);
            }
        }

        public override void Depositar()
        {
            Console.WriteLine("Insira o valor desejado: ");
            decimal valor = decimal.Parse(Console.ReadLine());
            Saldo += valor + TaxaRendimento;
            ClassificarCliente();
            Console.WriteLine($"Você depositou dinheiro na conta poupança!\nSaldo após depósito: R${Saldo}");
            Console.WriteLine("Dados gravados com sucesso!\n");
            Console.WriteLine("Voltando ao menu principal!\n");
            Thread.Sleep(5000);
        }

        public override void ConsultarSaldo()
        {
            Cliente p = new Cliente(1);
            p.Nome = Cliente.Nome;
            p.Cpf = Cliente.Cpf;
            p.DataNascimento = Cliente.DataNascimento;
            p.Endereco = Cliente.Endereco;
            p.Tipo = Cliente.Tipo;

            Console.WriteLine($"ID Conta Poupança: {Id}");
            Console.WriteLine($"Esta conta pertence a : {Cliente.Nome} - CPF: {Cliente.Cpf}");
            Console.WriteLine($"Data de Nascimento: {Cliente.DataNascimento}");
            Console.WriteLine($"Endereço: {Cliente.Endereco}");
            Console.WriteLine($"Número da conta poupança: {Numero}");
            Console.WriteLine($"O saldo atual da conta poupança é de R$ {Saldo}");
            Console.WriteLine($"O cliente é do tipo {Cliente.Tipo}");
            Console.WriteLine("\n");
            Console.WriteLine(p);
            Console.WriteLine("\nVoltando ao menu principal!\n");
            Thread.Sleep(10000);
        }
    }
}
