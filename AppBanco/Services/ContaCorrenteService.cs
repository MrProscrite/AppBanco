using System;
using System.Collections.Generic;
using System.Text;

namespace AppBanco
{
    public class ContaCorrenteService
    {
        public void OperacaoSaque(ContaCorrente conta)
        {
            Console.WriteLine();
            Console.WriteLine("Informe um valor que deseja sacar: " + "\n");
            var valor = Convert.ToDouble(Console.ReadLine());
            Sacar(conta, valor);
            Console.WriteLine($"Seu saldo atual é: {conta.Saldo}.");
            System.Threading.Thread.Sleep(2000);
            Console.Clear();

        }

        public void OperacaoDeposito(ContaCorrente conta)
        {
            Console.WriteLine();
            Console.WriteLine("Informe um valor que deseja depositar: " + "\n");
            var valor = Convert.ToDouble(Console.ReadLine());
            Depositar(conta, valor);
            Console.WriteLine($"Seu saldo atual é: {conta.Saldo}.");
            System.Threading.Thread.Sleep(2000);
            Console.Clear();

        }

        public void OperacaoTransferencia(ContaCorrente conta)
        {
            Console.WriteLine();

            Console.WriteLine("Informe um valor que deseja transferir: " + "\n");
            var valor = Convert.ToDouble(Console.ReadLine());
            Transferir(conta, valor);
            Console.WriteLine($"Seu saldo atual é: {conta.Saldo}.");
            System.Threading.Thread.Sleep(2000);
            Console.Clear();

        }

        public void DadosContaCorrente(ContaCorrente conta)
        {
            Console.WriteLine();
            Console.WriteLine("Aqui estão os dados da sua Conta Corrente:");
            Console.WriteLine($"Titular da conta: {conta.Titular}");
            Console.WriteLine($"CPF: {conta.CPF}");
            Console.WriteLine($"Email: {conta.Email}");
            Console.WriteLine($"Número da conta: {conta.Numero}" + "-" + $"{conta.Agencia}");
            Console.WriteLine($"Banco:{conta.Banco}");
            Console.WriteLine($"Saldo: {conta.Saldo}");

            Console.WriteLine("Aperte alguma tecla para continuar..." + "\n");
            Console.ReadLine();
            Console.Clear();
        }


        private void Sacar(ContaCorrente conta, double valor)
        {
            if (conta.Saldo < valor)
            {
                Console.WriteLine("Não foi possível realizar o saque pois seu saldo é insuficiente.");
            }

            else if(conta.Saldo >= valor)
            {
                conta.Saldo -= valor;
            }
        }

        private void Depositar(ContaCorrente conta, double valor)
        {
            conta.Saldo += valor;
        }

        private void Transferir(ContaCorrente conta, double valor)
        {
            if (conta.Saldo >= valor) 
            {
                Console.WriteLine("Qual método você deseja transferir?" + "\n");
                Console.WriteLine("1 - TED");
                Console.WriteLine("2 - PIX");
                var TipoTransferencia = Console.ReadLine();

                if (TipoTransferencia == "1")
                {
                    Console.WriteLine("Você escolheu transferir via TED.");
                    Console.WriteLine("Por favor, digite o nome completo do titular que você deseja transferir: " + "\n");
                    var TitularTransferencia = Console.ReadLine();
                    Console.WriteLine("Por favor, digite o CPF (apenas números) do titular que você deseja transferir: " + "\n");
                    var CPFTransferencia = Convert.ToInt64(Console.ReadLine());
                    Console.WriteLine("Por favor, digite o número da conta do titular que você deseja transferir: " + "\n");
                    var NumeroContaTransferencia = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("Por favor, digite o dígito da agência do Banco do titular que você deseja transferir: " + "\n");
                    var AgenciaTransferencia = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("Por favor, digite o Banco do titular que você deseja transferir: " + "\n");
                    var BancoTransferencia = Console.ReadLine();
                    ContaCorrente contaTED = new ContaCorrente()
                    {
                        Agencia = AgenciaTransferencia,
                        Banco = BancoTransferencia,
                        Numero = NumeroContaTransferencia,
                        Saldo = 0,
                        Titular = TitularTransferencia,
                        CPF = CPFTransferencia
                    };

                    Console.WriteLine("Estes são os dados para transferência: ");
                    Console.WriteLine($"Titular da conta: {contaTED.Titular}");
                    Console.WriteLine($"CPF: {contaTED.CPF}");
                    Console.WriteLine($"Número da conta: {contaTED.Numero}" + "-" + $"{contaTED.Agencia}");
                    Console.WriteLine($"Banco:{contaTED.Banco}");
                    Console.WriteLine("Os dados conferem?" + "\n");
                    var ConfirmarDadosTED = Console.ReadLine();
                    ConfirmarDadosTED = ConfirmarDadosTED.ToLower();
                    string PrimeiraLetraCDT = ConfirmarDadosTED.Substring(0, 1);
                    if (PrimeiraLetraCDT == "s")
                    {
                        conta.Saldo -= valor;
                        Console.WriteLine($"Transferência para {contaTED.Titular} agendada com sucesso!");
                        Console.WriteLine("Deseja emitir comprovante?" + "\n");
                        var EmitirComprovante = Console.ReadLine();
                        EmitirComprovante = EmitirComprovante.ToLower();
                        string PrimeiraLetraEC = EmitirComprovante.Substring(0, 1);
                        if (PrimeiraLetraEC == "s")
                        {
                            Console.WriteLine("============ Comprovante de Transferência ============");
                            Console.WriteLine("De:");
                            Console.WriteLine($"{conta.Titular}");
                            Console.WriteLine($"CPF: {conta.CPF}");
                            Console.WriteLine($"Número da conta: {conta.Numero}" + "-" + $"{conta.Agencia}");
                            Console.WriteLine($"Banco: {conta.Banco}");
                            Console.WriteLine("Para:");
                            Console.WriteLine($"{contaTED.Titular}");
                            Console.WriteLine($"CPF: {contaTED.CPF}");
                            Console.WriteLine($"Número da conta: {contaTED.Numero}" + "-" + $"{contaTED.Agencia}");
                            Console.WriteLine($"Banco: {contaTED.Banco}");
                            Console.WriteLine($"Valor da transferência: {valor}.");
                        }

                        else { }
                    }
                    else
                    {
                        Console.WriteLine("Transferência cancelada.");
                        System.Threading.Thread.Sleep(2000);
                        Transferir(conta, valor);
                    }
                };

                if (TipoTransferencia == "2")
                {
                    Console.WriteLine("Você escolheu transferir via PIX.");
                    Console.WriteLine("Digite a Chave PIX para qual você deseja transferir: " + "\n");
                    var ChavePIX = Console.ReadLine();
                    ContaCorrente contaPIX = new ContaCorrente()
                    {
                        ChavePix = ChavePIX
                    };
                    Console.WriteLine("Digite a mensagem que deseja enviar (aperte enter caso queria em branco): " + "\n");
                    var MensagemPIX = Console.ReadLine();
                    Console.WriteLine("===== Dados da Transferência =====");
                    Console.WriteLine($"Para: {contaPIX.ChavePix}.");
                    Console.WriteLine($"Valor: {valor}");
                    Console.WriteLine($"Mensagem: {MensagemPIX}");
                    Console.WriteLine("Os dados conferem?" + "\n");
                    var ConfirmarDadosPIX = Console.ReadLine();
                    ConfirmarDadosPIX = ConfirmarDadosPIX.ToLower();
                    string PrimeiraLetraCDP = ConfirmarDadosPIX.Substring(0, 1);
                    
                    if(PrimeiraLetraCDP == "s")
                    {
                        conta.Saldo -= valor;
                        Console.WriteLine("Transferência feita com sucesso!");
                        Console.WriteLine("Deseja emitir comprovante?" + "\n");
                        var EmitirComprovante = Console.ReadLine();
                        EmitirComprovante = EmitirComprovante.ToLower();
                        string PrimeiraLetraEC = EmitirComprovante.Substring(0, 1);
                        if (PrimeiraLetraEC == "s")
                        {
                            Console.WriteLine("============ Comprovante de Transferência ============");
                            Console.WriteLine("De:");
                            Console.WriteLine($"{conta.ChavePix}");
                            Console.WriteLine("Para:");
                            Console.WriteLine($"{contaPIX.ChavePix}");
                            Console.WriteLine($"Valor da transferência: {valor}.");
                            Console.WriteLine($"Mensagem: {MensagemPIX}");
                        }
                        
                        else 
                        {
                            Console.WriteLine("Transferência cancelada.");
                            System.Threading.Thread.Sleep(2000);
                            Transferir(conta, valor);
                        }

                    }

                    else
                    {
                        Console.WriteLine("Transferência cancelada.");
                        System.Threading.Thread.Sleep(2000);
                        Transferir(conta, valor);
                    }

                }
            }

            if(conta.Saldo < valor)
            {
                Console.WriteLine("Não foi possível realizar a transferência pois seu saldo é insuficiente.");
            }
        }
    }
}
