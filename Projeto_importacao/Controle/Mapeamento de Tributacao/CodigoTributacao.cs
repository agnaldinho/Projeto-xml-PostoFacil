using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PortaFacil.Mapeamento_de_Tributacao
{
    internal class CodigoTributacao
    {
        public Dictionary<string, string> CstNomes { get; private set; }

        public CodigoTributacao()
        {
            CstNomes = new Dictionary<string, string>
            {
                {"00", "00 - Produto Tributado"},
                {"10", "10 - Substituição tributária"},
                {"20", "20 - Redução de base de cálculo"},
                {"30", "30 - Não incidência"},
                {"40", "40 - Produto Isento"},
                {"41", "41 - Produto Isento"},
                {"50", "50 - Não incidência"},
                {"51", "51 - Não incidência"},
                {"60", "60 - Substituição tributária"},
                {"61", "61 - Monofásica"},
                {"70", "70 - Redução de base de cálculo"},
                {"90", "90 - Não incidência"},
            };
        }

        public string GetCstNome(string key)
        {
            return CstNomes.ContainsKey(key) ? CstNomes[key] : "Codigo de tributação não localizada.";
        }
    }
}

