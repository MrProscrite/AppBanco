using System;
using System.Collections.Generic;
using System.Text;

namespace AppBanco
{
    public class ContaInvestimentoService
    {
        public void DadosContaInvestimento(AppBanco.ContaInvestimento containvestimento)
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

        public void EscolherTipoInvestimento(AppBanco.ContaInvestimento containvestimento)
        {
            Console.WriteLine();
            Console.WriteLine($"Seu tipo de investimento atual é {containvestimento.TipoInvestimento}");
            System.Threading.Thread.Sleep(2000);
            EscolhaTipoInvestimento(containvestimento);
            System.Threading.Thread.Sleep(2000);
            Console.Clear();
        }

        public void EscolherPerfilInvestidor(AppBanco.ContaInvestimento containvestimento)
        {
            Console.WriteLine();
            Console.WriteLine($"Seu perfil investidor atual é {containvestimento.PerfilInvestidor}");
            System.Threading.Thread.Sleep(2000);
            EscolhaPerfilInvestidor(containvestimento);
            System.Threading.Thread.Sleep(2000);
            Console.Clear();
        }

        private void EscolhaTipoInvestimento(AppBanco.ContaInvestimento containvestimento)
        {
            Console.WriteLine("Escolha o seu tipo de investimento" + "\n");
            Console.WriteLine("1 - Renda variável");
            Console.WriteLine("2 - Renda fixa");
            Console.WriteLine("3 - Previdência");
            var TipoInvestimento = Console.ReadLine();
            
            if (TipoInvestimento == "1")
            {
                containvestimento.TipoInvestimento = "Renda Variável";
            }
            else if (TipoInvestimento == "2")
            {
                containvestimento.TipoInvestimento = "Renda Fixa";
            }
            else if (TipoInvestimento == "3")
            {
                containvestimento.TipoInvestimento = "Previdência.";
            }

            else
            {
                Console.WriteLine("Escolha uma opção válida");
                System.Threading.Thread.Sleep(2000);
                EscolhaTipoInvestimento(containvestimento);
            }

            Console.WriteLine($"Seu tipo de investimento agora é: {containvestimento.TipoInvestimento}");
        }

        private void EscolhaPerfilInvestidor(AppBanco.ContaInvestimento containvestimento)
        {
            Console.WriteLine("Escolha o seu perfil de investidor" + "\n");
            Console.WriteLine("1 - Conservador");
            Console.WriteLine("2 - Moderado");
            Console.WriteLine("3 - Agressivo");
            var PerfilInvestidor = Console.ReadLine();

            if (PerfilInvestidor == "1")
            {
                containvestimento.PerfilInvestidor = "Conservador";
            }
            else if (PerfilInvestidor == "2")
            {
                containvestimento.PerfilInvestidor = "Moderador";
            }
            else if (PerfilInvestidor == "3")
            {
                containvestimento.PerfilInvestidor = "Agressivo";
            }

            else
            {
                Console.WriteLine("Escolha uma opção válida");
                System.Threading.Thread.Sleep(2000);
                EscolhaPerfilInvestidor(containvestimento);
            }

            Console.WriteLine($"Seu perfil investidor atual é: {containvestimento.PerfilInvestidor}");
        }

    }
}
