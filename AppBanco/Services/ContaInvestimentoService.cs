using System;
using System.Collections.Generic;
using System.Text;

namespace AppBanco
{
    public class ContaInvestimentoService
    {
        public void DadosContaInvestimento(ContaInvestimento containvestimento)
        {
            Console.WriteLine();
            Console.WriteLine("Aqui estão os dados da sua Conta Investimento:");
            Console.WriteLine($"Titular da conta: {containvestimento.Titular}");
            Console.WriteLine($"CPF: {containvestimento.CPF}");
            Console.WriteLine($"Email: {containvestimento.Email}");
            Console.WriteLine($"Número da conta: {containvestimento.Numero}" + "-" + $"{containvestimento.Agencia}");
            Console.WriteLine($"Banco:{containvestimento.Banco}");
            Console.WriteLine($"Saldo: {containvestimento.Saldo}");
            Console.WriteLine($"Tipo de Investimento: {containvestimento.TipoInvestimento}");
            Console.WriteLine($"Perfil de Investidor: {containvestimento.PerfilInvestidor}");

            Console.WriteLine("Aperte alguma tecla para continuar..." + "\n");
            Console.ReadLine();
            Console.Clear();
        }

        public void EscolherTipoInvestimento(ContaInvestimento containvestimento)
        {
            Console.WriteLine();
            Console.WriteLine($"Seu tipo de investimento atual é {containvestimento.TipoInvestimento}");
            System.Threading.Thread.Sleep(2000);
            Console.WriteLine("Escolha o seu tipo de investimento" + "\n");
            Console.WriteLine("1 - Renda variável");
            Console.WriteLine("2 - Renda fixa");
            Console.WriteLine("3 - Previdência");
            var escolha = Console.ReadLine();
            EscolhaTipoInvestimento(containvestimento, escolha);
            Console.WriteLine($"Seu tipo de investimento agora é: {containvestimento.TipoInvestimento}");
            System.Threading.Thread.Sleep(2000);
            Console.Clear();
        }

        public void EscolherPerfilInvestidor(ContaInvestimento containvestimento)
        {
            Console.WriteLine();
            Console.WriteLine($"Seu perfil investidor atual é {containvestimento.PerfilInvestidor}");
            System.Threading.Thread.Sleep(2000);
            Console.WriteLine("Escolha o seu perfil de investidor" + "\n");
            Console.WriteLine("1 - Conservador");
            Console.WriteLine("2 - Moderado");
            Console.WriteLine("3 - Agressivo");
            var escolha = Console.ReadLine();
            EscolhaPerfilInvestidor(containvestimento, escolha);
            Console.WriteLine($"Seu perfil investidor atual é: {containvestimento.PerfilInvestidor}");
            System.Threading.Thread.Sleep(2000);
            Console.Clear();
        }

        private void EscolhaTipoInvestimento(ContaInvestimento containvestimento, string escolha)
        {           
            if (escolha == "1")
            {
                containvestimento.TipoInvestimento = TipoInvestimento.RendaVariavel;
            }
            else if (escolha == "2")
            {
                containvestimento.TipoInvestimento = TipoInvestimento.RendaFixa;
            }
            else if (escolha == "3")
            {
                containvestimento.TipoInvestimento = TipoInvestimento.Previdencia;
            }

            else
            {
                Console.WriteLine("Escolha uma opção válida");
                System.Threading.Thread.Sleep(2000);
                EscolhaTipoInvestimento(containvestimento, escolha);
            }

        }

        private void EscolhaPerfilInvestidor(ContaInvestimento containvestimento, string escolha)
        { 
            if (escolha == "1")
            {
                containvestimento.PerfilInvestidor = PerfilInvestidor.Conservador;
            }
            else if (escolha == "2")
            {
                containvestimento.PerfilInvestidor = PerfilInvestidor.Moderado;
            }
            else if (escolha == "3")
            {
                containvestimento.PerfilInvestidor = PerfilInvestidor.Agressivo;
            }

            else
            {
                Console.WriteLine("Escolha uma opção válida");
                System.Threading.Thread.Sleep(2000);
                EscolhaPerfilInvestidor(containvestimento, escolha);
            }

        }

    }
}
