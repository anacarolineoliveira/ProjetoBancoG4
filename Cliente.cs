using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CorrecaoBanco
{
    class Cliente
    {
        public int Id { get; private set; }
        public string Cpf { get; set; }
        public string Nome { get; set; }
        public TipoCliente Tipo { get; set; }
        public DateTime DataNascimento { get; set; }
        public Endereco Endereco { get; set; }

        public Cliente()
        {
            Tipo = TipoCliente.Comum;
        }

        public Cliente(int id)
        {
            Id = id;
        }

        public override string ToString()
        {
            return "ID Cliente: " + Id + "\n" + "Nome: " + Nome + "\n" + "CPF: " + Cpf + "\n" + "Tipo de Conta: " + Tipo + "\n" + "Data de Nascimento: " + DataNascimento + "\n" + "Endereço: " + Endereco;
        }

        public Cliente(string inCpf, string inNome)
        {
            Cpf = inCpf;
            Nome = inNome;
            Tipo = TipoCliente.Comum;
        }


        public void CadastrarDados()
        {
            string cidade,
                estado,
                pais,
                rua,
                bairro,
                complemento;
            int numero,
                cep;

            string inCpf;
            string inNome;
            string inDataNascimento;
            bool validaDigitos;

            Console.WriteLine("Digite seu nome:");
            inNome = Console.ReadLine();

            Console.WriteLine("Digite sua cidade:");
            cidade = Console.ReadLine();

            Console.WriteLine("Digite seu estado:");
            estado = Console.ReadLine();

            Console.WriteLine("Digite seu país:");
            pais = Console.ReadLine();

            Console.WriteLine("Digite sua rua:");
            rua = Console.ReadLine();

            Console.WriteLine("Digite seu bairro:");
            bairro = Console.ReadLine();

            Console.WriteLine("Digite seu complemento:");
            complemento = Console.ReadLine();

            Console.WriteLine("Digite o número da sua residência:");
            numero = Int32.Parse(Console.ReadLine());

            Console.WriteLine("Digite seu CEP sem pontos ou traços:");
            cep = Int32.Parse(Console.ReadLine());

            Endereco _Endereco = new Endereco(cidade, estado, pais, rua, bairro, complemento, numero, cep);

            bool continua = true;
            while (continua)
            {
                try
                {
                    continua = false;
                    Console.WriteLine("Digite sua data de nascimento:");
                    inDataNascimento = Console.ReadLine();
                    DataNascimento = DateTime.ParseExact(inDataNascimento, "dd/MM/yyyy", System.Globalization.CultureInfo.InvariantCulture);
                }
                catch (FormatException)
                {
                    continua = true;
                    Console.WriteLine("Termo inválido inserido, insira sua data de nascimento da seguinte forma: 01/01/0001\n");
                }
            }

            do
            {
                Console.WriteLine("Digite seu CPF sem pontos ou traços (11 dígitos): ");
                inCpf = Console.ReadLine();
                validaDigitos = inCpf.Length != 11;
                //Console.WriteLine("\n");

                if (validaDigitos)
                {
                    Console.WriteLine("CPF não tem 11 dígitos!");
                }
            } while (validaDigitos);


            Cpf = inCpf;
            Nome = inNome;
            // Endereco = atribuir as variaveis ao get set
        }

    }
}
