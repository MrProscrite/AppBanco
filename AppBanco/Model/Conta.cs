using System;
using System.Collections.Generic;
using System.Text;

namespace AppBanco
{
    public class Conta
    {
        public string Titular { get; set; }
        public int Agencia { get; set; }
        public int Numero { get; set; }
        public string Banco { get; set; }
        public double Saldo { get; set; }
        public long CPF { get; set; }
        public string Email { get; set; }
    }
}