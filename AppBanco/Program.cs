using System;

namespace AppBanco
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Bem-vindo ao app do banco genérico! Escreva seu nome abaixo." + "\n");
            var nome = Console.ReadLine();
            Console.WriteLine("Agora o seu sobrenome" + "\n");
            var sobrenome = Console.ReadLine();
            Console.WriteLine("Pedimos que digite seu CPF agora. (apenas números): " + "\n");
            var CPF = Convert.ToInt64(Console.ReadLine());
            Console.WriteLine("Por fim, pedimos o seu e-mail: " + "\n");
            var Email = Console.ReadLine();
            Console.WriteLine($"Muito bem, {nome}! Como é sua primeira vez, vou gerar sua conta!");
            Random GerarNumeroConta = new Random();
            int NumeroConta = GerarNumeroConta.Next(10000, 99999);
            Random GerarIdCarteira = new Random();
            int IdCarteira = GerarIdCarteira.Next(10000, 99999);
            ContaCorrente conta = new ContaCorrente()
            {
                Agencia = 1,
                Banco = "Banco Genérico",
                ChavePix = "pixgenerico@pix.com",
                Numero = NumeroConta,
                Titular = nome + ' ' + sobrenome,
                Saldo = 0,
                Email = Email,
                CPF = CPF
            };

            ContaInvestimento containvestimento = new ContaInvestimento()
            {
                Agencia = 1,
                Banco = "Banco Genério",
                CPF = CPF,
                Email = Email,
                IdCarteira = IdCarteira,
                Numero = NumeroConta,
                Saldo = 0,
                Titular = nome + ' ' + sobrenome,
                PerfilInvestidor = "Indefinido.",
                TipoInvestimento = "Indefinido."
            };


            new ContaCorrenteService().DadosContaCorrente(conta);
            new ContaInvestimentoService().DadosContaInvestimento(containvestimento);
            Console.WriteLine("Agora você está cadastrado!");
            Console.WriteLine("Redirecionando para o menu...");
            System.Threading.Thread.Sleep(5000);
            Console.Clear();
            menu(conta, containvestimento);

        }

        private static void menu(AppBanco.ContaCorrente conta, AppBanco.ContaInvestimento containvestimento)
        {
            Console.WriteLine("Escolha uma das opções abaixo: ");
            Console.WriteLine("1 - Depósito");
            Console.WriteLine("2 - Saque");
            Console.WriteLine("3 - Transferência");
            Console.WriteLine("4 - Definir meu perfil de investidor");
            Console.WriteLine("5 - Definir meu tipo de investimento");
            Console.WriteLine("6 - Ver meus dados bancários");

            var opcao = Console.ReadKey();

            switch (opcao.KeyChar)
            {
                case '1':
                    new ContaCorrenteService().OperacaoDeposito(conta);
                    menu(conta, containvestimento);
                    break;
                
                case '2':
                    new ContaCorrenteService().OperacaoSaque(conta);
                    menu(conta, containvestimento);
                    break;

                case '3':
                    new ContaCorrenteService().OperacaoTransferencia(conta);
                    menu(conta, containvestimento);
                    break;

                case '4':
                    new ContaInvestimentoService().EscolherPerfilInvestidor(containvestimento);
                    menu(conta, containvestimento);
                    break;

                case '5':
                    new ContaInvestimentoService().EscolherTipoInvestimento(containvestimento);
                    menu(conta, containvestimento);
                    break;

                case '6':
                    new ContaCorrenteService().DadosContaCorrente(conta);
                    new ContaInvestimentoService().DadosContaInvestimento(containvestimento);
                    menu(conta, containvestimento);
                    break;

            }

        }
    }
}
