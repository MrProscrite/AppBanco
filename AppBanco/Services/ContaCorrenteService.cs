using System;
using System.Collections.Generic;
using System.Text;

namespace AppBanco
{
    public class ContaCorrenteService
    {
        public void OperacaoSaque(AppBanco.ContaCorrente conta)
        {
            Console.WriteLine();
            Console.WriteLine("Informe um valor que deseja sacar: " + "\n");

            Sacar(conta);
            Console.WriteLine($"Seu novo saldo é: {conta.Saldo}.");
            System.Threading.Thread.Sleep(2000);
            Console.Clear();

        }

        public void OperacaoDeposito(AppBanco.ContaCorrente conta)
        {
            Console.WriteLine();
            Console.WriteLine("Informe um valor que deseja depositar: " + "\n");

            Depositar(conta);
            Console.WriteLine($"Seu novo saldo é: {conta.Saldo}.");
            System.Threading.Thread.Sleep(2000);
            Console.Clear();

        }

        public void OperacaoTransferencia(AppBanco.ContaCorrente conta)
        {
            Console.WriteLine();

            Transferir(conta);
            Console.WriteLine($"Seu novo saldo é: {conta.Saldo}.");
            System.Threading.Thread.Sleep(2000);
            Console.Clear();

        }

        public void DadosContaCorrente(AppBanco.ContaCorrente conta)
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


        private void Sacar(AppBanco.ContaCorrente conta)
        {
            var Saque = Console.ReadLine();
            double SaqueConvertido = Convert.ToDouble(Saque);
            double Valor = SaqueConvertido;
            if (conta.Saldo < Valor)
            {
                Console.WriteLine("Não foi possível realizar o saque pois seu saldo é insuficiente.");
            }

            if (conta.Saldo >= Valor)
            {
                conta.Saldo -= Valor;
            }
        }

        private void Depositar(AppBanco.ContaCorrente conta)
        {
            var Deposito = Console.ReadLine();
            double DepositoConvertido = Convert.ToDouble(Deposito);
            double Valor = DepositoConvertido;
            conta.Saldo += Valor;
        }

        private void Transferir(AppBanco.ContaCorrente conta)
        {
            Console.WriteLine("Informe um valor que deseja transferir: " + "\n");
            var Transferencia = Console.ReadLine();
            double TransferenciaConvertida = Convert.ToDouble(Transferencia);
            double Valor = TransferenciaConvertida;

            if (conta.Saldo >= Valor) 
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
                        conta.Saldo -= Valor;
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
                            Console.WriteLine($"Valor da transferência: {Valor}.");
                        }

                        else { }
                    }
                    else
                    {
                        Transferir(conta);
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
                    Console.WriteLine($"Valor: {Valor}");
                    Console.WriteLine($"Mensagem: {MensagemPIX}");
                    Console.WriteLine("Os dados conferem?" + "\n");
                    var ConfirmarDadosPIX = Console.ReadLine();
                    ConfirmarDadosPIX = ConfirmarDadosPIX.ToLower();
                    string PrimeiraLetraCDP = ConfirmarDadosPIX.Substring(0, 1);
                    
                    if(ConfirmarDadosPIX == "s")
                    {
                        conta.Saldo -= Valor;
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
                            Console.WriteLine($"Valor da transferência: {Valor}.");
                            Console.WriteLine($"Mensagem: {MensagemPIX}");
                        }
                        
                        else { }

                    }

                    else
                    {
                        Transferir(conta);
                    }

                }
            }

            if(conta.Saldo < Valor)
            {
                Console.WriteLine("Não foi possível realizar a transferência pois seu saldo é insuficiente.");
            }
        }
    }
}
