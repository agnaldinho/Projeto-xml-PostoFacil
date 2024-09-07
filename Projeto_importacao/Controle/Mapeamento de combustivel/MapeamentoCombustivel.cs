using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PortaFacil.Controle.Mapeamento_de_combustivel
{
    internal class MapeamentoCombustivel
    {
        public string[] palavrasChaveCombustivel { get; private set; }

        public MapeamentoCombustivel()
        {
            palavrasChaveCombustivel = new string[] { "COMBUSTÍVEL", "GASOLINA", "ETANOL", "DIESEL", "GNV", "BS500", "S500", "S10", "ALCOOL" };
        }

        public string GetPalavrasChaveCombustivel(string key)
        {
            return null;
        }
    }
}
