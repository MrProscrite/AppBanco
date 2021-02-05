using System;
using System.Collections.Generic;
using System.Text;

namespace AppBanco
{
    public class ContaInvestimento : Conta
    {
        public string TipoInvestimento { get; set; }
        public int IdCarteira { get; set; }
        public string PerfilInvestidor { get; set; }
    }

    /*public enum TipoInvestimento
    {
        RendaVariavel = 1,
        RendaFixa = 2,
        Previdencia = 3
    }

    public enum PerfilInvestidor
    {
        Conservador = 1,
        Moderado = 2,
        Agressivo = 3
    }*/
}
