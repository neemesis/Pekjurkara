using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pekjurkara {
    public class CustomerDay {
        public int berach { get; set; }
        public DateTime den_datum { get; set; }
        public int den_promena_cena { get; set; }
        public DateTime vreme { get; set; }
        public double kg_1_klasa { get; set; }
        public double kg_2_klasa { get; set; }
        public double kg_3_klasa { get; set; }
        public double kg_lisichari { get; set; }
        public double kg_ovchoshapche { get; set; }
        public double kg_rujnica { get; set; }
        public int kolku_plateno { get; set; }
        public int dolzhi { get; set; }
        public int dolzhime { get; set; }

        public CustomerDay() { }

        public CustomerDay(int berach, DateTime den_datum, int den_promena_cena, DateTime vreme, double kg_1_klasa,
            double kg_2_klasa, double kg_3_klasa, double kg_lisichari, double kg_ovchoshapche, double kg_rujnica, 
            int kolku_plateno, int dolzhi, int dolzhime) {
            this.berach = berach;
            this.den_datum = den_datum;
            this.den_promena_cena = den_promena_cena;
            this.vreme = vreme;
            this.kg_1_klasa = kg_1_klasa;
            this.kg_2_klasa = kg_2_klasa;
            this.kg_3_klasa = kg_3_klasa;
            this.kg_lisichari = kg_lisichari;
            this.kg_ovchoshapche = kg_ovchoshapche;
            this.kg_rujnica = kg_rujnica;
            this.kolku_plateno = kolku_plateno;
            this.dolzhi = dolzhi;
            this.dolzhime = dolzhime;
        }

        public override string ToString() {
            string str = "";

            str += "Berach: " + berach + "\n";
            str += "Datum: " + den_datum + "\n";
            str += "Promena cena: " + den_promena_cena + "\n";
            str += "Vreme: " + vreme + "\n";
            str += "KG 1k: " + kg_1_klasa + "\n";
            str += "KG 2k: " + kg_2_klasa + "\n";
            str += "KG 3k: " + kg_3_klasa + "\n";
            str += "KG lis: " + kg_lisichari + "\n";
            str += "KG ovcho: " + kg_ovchoshapche + "\n";
            str += "KG ruj: " + kg_rujnica + "\n";
            str += "Kolku plateno: " + kolku_plateno + "\n";
            str += "Dolzhi: " + dolzhi + "\n";
            str += "Dolzhime: " + dolzhime + "\n";

            return str;
        }
    }
}
