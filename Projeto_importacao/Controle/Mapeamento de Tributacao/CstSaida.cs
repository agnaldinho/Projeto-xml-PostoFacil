using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PortaFacil.Mapeamento_de_Tributacao
{
    internal class CstSaida
    {
        public Dictionary<string, string> CstSaidaNomes { get; private set; }

        public CstSaida()
        {
          
            CstSaidaNomes = new Dictionary<string, string>
            {
                {"01", "01 - OPERAÇÃO TRIBUTÁVEL COM ALÍQUOTA BÁSICA"},
                {"02", "02 - OPERAÇÃO TRIBUTÁVEL COM ALÍQUOTA DIFERENCIADA"},
                {"04", "04 - OPERAÇÃO TRIBUTÁVEL MONOFÁSICA - REVENDA A ALÍQUOTA ZERO"},
                {"05", "05 - OPERAÇÃO TRIBUTÁVEL POR SUBSTITUIÇÃO TRIBUTÁRIA"},
                {"06", "06 - OPERAÇÃO TRIBUTÁVEL A ALÍQUOTA ZERO"},
                {"07", "07 - OPERAÇÃO ISENTA DA CONTRIBUIÇÃO"},
                {"08", "08 - OPERACAO SEM INCIDENCIA DA CONTRIBUICÃO"},
                {"49", "49 - OUTRAS OPERAÇÕES DE SAÍDA"},
                {"99", "99 - OUTRAS OPERAÇÕES"},
            };
        }

        public string GetCstSaidaNome(string key)
        {
            return CstSaidaNomes.ContainsKey(key) ? CstSaidaNomes[key] : "CST não encontrada";
        }
    }
}
