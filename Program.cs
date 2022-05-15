using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;

namespace CorrecaoBanco
{
    class Program
    {
        static void Main(string[] args)
        {
            EscolherConta();
        }

        public static int EscolherConta()
        {
            var cliente = new Cliente();
            Conta cc = new ContaCorrente(cliente);
            Conta cp = new ContaPoupanca(cliente);
            Console.WriteLine("Selecione uma opção: 1 para conta corrente, 2 para conta poupança ou 3 para sair");
            int opc = int.Parse(Console.ReadLine());
            bool isValido;
            do
            {
                if (opc == 1)
                {
                    Console.WriteLine("Acessando menu conta corrente, aguarde!\n");
                    Thread.Sleep(3000);
                    ChamarMenu(cc);
                }
                else if (opc == 2)
                {
                    Console.WriteLine("Acessando menu conta poupanca, aguarde!\n");
                    Thread.Sleep(3000);
                    ChamarMenuCP(cp);
                }
                else if (opc == 3)
                {
                    Environment.Exit(0);
                }
                isValido = opc > 1 && opc <= 2;
                if (!isValido)
                {
                    Console.WriteLine("Você digitou uma opção inválida! Tente novamente!");
                    EscolherConta();
                }
            } while (!isValido);

            return opc;
        }

        public static int GuardarOpcao(Conta conta)
        {
            bool isValido;
            string opcao;
            do
            {
                Console.WriteLine("Menu - escolha a opção desejada de acordo com o número: ");
                Console.WriteLine(@$"
                        1- Cadastrar Cliente
                        2- Depositar dinheiro na conta corrente
                        3- Transferir dinheiro da conta corrente
                        4- Consultar Saldo/Dados da Conta {conta.TipoConta}
                        5- Cadastrar Chave Pix
                        6- Visualizar Chaves Pix Cadastradas
                        7- Sair");
                opcao = Console.ReadLine();
                isValido = int.Parse(opcao) > 0 && int.Parse(opcao) <= 7;
                if (!isValido)
                {
                    Console.WriteLine("Você digitou uma opção inválida! Tente novamente!");
                }
            } while (!isValido);

            return int.Parse(opcao);
        }

        public static int GuardarOpcaoCP(Conta conta)
        {
            bool isValido;
            string opcao;
            do
            {
                Console.WriteLine("Menu - escolha a opção desejada de acordo com o número: ");
                Console.WriteLine(@$"
                        1- Cadastrar Cliente
                        2- Depositar dinheiro na conta poupança
                        3- Transferir dinheiro da conta poupança
                        4- Consultar Saldo/Dados da Conta {conta.TipoConta}
                        5- Cadastrar Chave Pix
                        6- Visualizar Chaves Pix Cadastradas
                        7- Sair");
                opcao = Console.ReadLine();
                isValido = int.Parse(opcao) > 0 && int.Parse(opcao) <= 7;
                if (!isValido)
                {
                    Console.WriteLine("Você digitou uma opção inválida! Tente novamente!");
                }
            } while (!isValido);

            return int.Parse(opcao);
        }

        public static void ChamarMenu(Conta conta)
        {
            Pix pixCc = new Pix(conta);


            
            int opcao = GuardarOpcao(conta);
            do
            {
                string caminho = @"C:\Users\danie\OneDrive\Desktop\trabalhos four\C#\Projetos C#\ProjetoBancoGit\ProjetoBancoG4\Outros\ChavesPix.csv";
                Cliente cliente = new Cliente();
                Conta cc = new ContaCorrente(cliente);

                switch (opcao)
                {
                    case 1:
                        conta.Cliente.CadastrarDados();
                        opcao = GuardarOpcao(conta);
                        break;
                    case 2:
                        conta.Depositar();
                        opcao = GuardarOpcao(conta);
                        break;
                    case 3:
                        conta.Transferir();
                        opcao = GuardarOpcao(conta);
                        break;
                    case 4:
                        conta.ConsultarSaldo();
                        opcao = GuardarOpcao(conta);
                        break;
                    case 5:
                        pixCc.AtivarChave();
                        IGravacao gravacao = new Pix(cc);
                        string valor = gravacao.ConverterDados(pixCc.ChavesCadastradas);
                        gravacao.Salvar(caminho, valor);
                        ChamarMenu(conta);
                        break;
                    case 6:

                        string[] lista;
                        using (StreamReader leitor = new StreamReader(caminho))
                        {
                            lista = leitor.ReadToEnd().Split(";");
                            pixCc.CarregarDados(lista);
                            ILeitura leitura = new Pix(cc);
                            var csv = leitura.Decodificar(caminho);
                            ChamarMenu(conta);
                        }
                        break;
                    case 7:
                        Console.WriteLine("Voltando ao menu de contas!\n");
                        Thread.Sleep(3000);
                        EscolherConta();
                        break;
                }
            } while (opcao != 7);

        }
        public static void ChamarMenuCP(Conta conta)
        {
            Pix pixCc = new Pix(conta);

            int opcao = GuardarOpcaoCP(conta);
            do
            {
                string caminho = @"C:\Users\danie\OneDrive\Desktop\trabalhos four\C#\Projetos C#\ProjetoBancoGit\ProjetoBancoG4\Outros\ChavesPix.csv";
                Cliente cliente = new Cliente();
                Conta cc = new ContaPoupanca(cliente);

                switch (opcao)
                {
                    case 1:
                        conta.Cliente.CadastrarDados();
                        opcao = GuardarOpcaoCP(conta);
                        break;
                    case 2:
                        conta.Depositar();
                        opcao = GuardarOpcaoCP(conta);
                        break;
                    case 3:
                        conta.Transferir();
                        opcao = GuardarOpcaoCP(conta);
                        break;
                    case 4:
                        conta.ConsultarSaldo();
                        opcao = GuardarOpcaoCP(conta);
                        break;
                    case 5:
                        pixCc.AtivarChave();
                        IGravacao gravacao = new Pix(cc);
                        string valor = gravacao.ConverterDados(pixCc.ChavesCadastradas);
                        gravacao.Salvar(caminho, valor);
                        ChamarMenuCP(conta);
                        break;
                    case 6:

                        string[] lista;
                        using (StreamReader leitor = new StreamReader(caminho))
                        {
                            lista = leitor.ReadToEnd().Split(";");
                            pixCc.CarregarDados(lista);
                            ILeitura leitura = new Pix(cc);
                            var csv = leitura.Decodificar(caminho);
                            ChamarMenuCP(conta);
                        }
                        break;
                    case 7:
                        Console.WriteLine("Voltando ao menu de contas!\n");
                        Thread.Sleep(3000);
                        EscolherConta();
                        break;
                }
            } while (opcao != 7);
        }
    }
}
