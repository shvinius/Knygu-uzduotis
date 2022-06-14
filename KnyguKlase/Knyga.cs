using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KnyguKlase
{
    internal class Knyga
    {
        private string isbn;
        private string pavadinimas;
        private string autorius;
        private int leidimoMetai;
        private string leidejas;
        private string salis;
        private decimal kaina;

      
        public Knyga(string isbn, string pavadinimas, string autorius, int leidimoMetai, string leidejas, string salis, decimal kaina)
        {
            this.isbn = isbn;
            this.pavadinimas = pavadinimas;
            this.autorius = autorius;
            this.leidimoMetai = leidimoMetai;
            this.leidejas = leidejas;
            this.salis = salis;
            this.kaina = kaina;
        }

        public Knyga()
        {
        }
        public string Isbn { get => isbn; set => isbn = value; }
        public string Pavadinimas { get => pavadinimas; set => pavadinimas = value; }
        public string Autorius { get => autorius; set => autorius = value; }
        public int LeidimoMetai { get => leidimoMetai; set => leidimoMetai = value; }
        public string Leidejas { get => leidejas; set => leidejas = value; }
        public string Salis { get => salis; set => salis = value; }
        public decimal Kaina { get => kaina; set => kaina = value; }

        public override string ToString()
        {
            string tekstas = "isbn: " + isbn + "; pavadinimas: " + pavadinimas + "; autorius: " + autorius + "; leidimo metai: " + leidimoMetai + "; leidėjas: " + leidejas + "; šalis: " + salis + "; kaina: " + kaina ;
            return tekstas;
        }

    }

}
