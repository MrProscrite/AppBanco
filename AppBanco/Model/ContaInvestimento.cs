using System;
using System.Collections.Generic;
using System.Text;

namespace AppBanco
{
    public class ContaInvestimento : Conta
    {
        public TipoInvestimento TipoInvestimento { get; set; }
        public int IdCarteira { get; set; }
        public PerfilInvestidor PerfilInvestidor { get; set; }
        public List<string> PerfilTeste { get; set; }
    }

    public enum TipoInvestimento
    {
        RendaVariavel = 1,
        RendaFixa = 2,
        Previdencia = 3,
        Definir = 4
    }

    public enum PerfilInvestidor
    {
        Conservador = 1,
        Moderado = 2,
        Agressivo = 3,
        Definir = 4
    }

}
