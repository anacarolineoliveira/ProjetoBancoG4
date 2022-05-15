using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CorrecaoBanco
{
    class Pix : IGravacao, ILeitura
    {
        public Dictionary<string, TipoChavePix> ChavesCadastradas { get; set; }
        public DateTime Data { get; private set; }
        public bool IsAtivado { get; private set; }
        public Conta Conta { get; }

        public Pix (Conta conta)
        {
            Conta = conta;
        }

        public void CarregarDados(string[] s)
        {
            
            //var lista = new List<string>();
            for (int i = 0; i < s.Length; i++)
            {
                //lista.Add(s[i]);
                Console.WriteLine(s[i]);
            }
            //return lista;
        }

        public string ConverterDados(Dictionary<string, TipoChavePix> lista)
        {
            List<string> l = new List<string>();
            foreach (var item in lista)
            {
                
                l.Add(item.Key);
                l.Add(item.Value.ToString());
                l.Add(Conta.Numero);
            }
            return string.Join<string>(";", l);
        }

        public string[] Decodificar(string c)
        {
            StreamReader sr = new StreamReader(c);
            string linha = sr.ReadLine() + ",";
            string csv = "";
            do
            {
                linha = sr.ReadLine() + ";";
                csv = csv + linha;
            } while (!(linha == ";"));
            var array_csv = csv.Split(";");
            sr.Close();
            return array_csv;
        }

        public void Salvar(string c, string v)
        {
            try
            {
                StreamWriter sw = new StreamWriter(c, true);
                sw.WriteLine(v);
                sw.Close();
                Console.WriteLine("Dados salvos com sucesso!\n");
                Console.WriteLine("Voltando ao menu principal!\n");
                Thread.Sleep(5000);
            }
            catch (System.Exception ex)
            {
                Console.WriteLine($"Um erro ocorreu. \nMensagem: {ex.Message} \nRastreamento de pilha: {ex.StackTrace}\nTipo: {ex.GetType().Name}");
            }
        }
        public void AtivarChave()
        {
            string[] pix = new string[2];
            var chavesPix = new Dictionary<string, TipoChavePix>();
            if (chavesPix.Keys.Count > 4)
            {
                throw new PixException("Número máximo de chaves cadastradas.");
            }
            else
            {
                pix = InserirChave();
                chavesPix.Add(pix[0], (TipoChavePix)int.Parse(pix[1]));
                ChavesCadastradas = chavesPix;
                Data = DateTime.Now;
                IsAtivado = true;
            }
        }
        private static string[] InserirChave()
        {
            bool res;
            string chave = "";
            int valor;
            bool intervaloValido;

            do
            {
                Console.WriteLine(@$"Escolha as chaves Pix disponiveis digitando os números correspondentes:" +
                                $"\n{(int)TipoChavePix.CPF} : {TipoChavePix.CPF}" +
                                $"\n{(int)TipoChavePix.Email} : {TipoChavePix.Email}" +
                                $"\n{(int)TipoChavePix.Telefone} : {TipoChavePix.Telefone}" +
                                $"\n{(int)TipoChavePix.Aleatorio} : {TipoChavePix.Aleatorio}");
                res = int.TryParse(Console.ReadLine(), out valor);
                intervaloValido = valor >= 0 && valor <= 3;
                if (!(res && intervaloValido))
                {
                    Console.WriteLine("O número digitado não está dentro do intervalo ou foi digitado um caracter não númerio. Tente novamente!");
                }
            } while (!(res && intervaloValido));

            do
            {
                Console.WriteLine($"Digite o valor da chave {(TipoChavePix)valor}");
                chave = Console.ReadLine();
                if (chave == "")
                {
                    Console.WriteLine("Não foi possível deixar o valor vazio! Tente novamente!");
                }
            } while (chave == "");

            string[] pix = { chave, valor.ToString() };
            return pix;

            
        }
    }
}
