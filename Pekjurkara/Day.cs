using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pekjurkara {
    class Day {
        public DateTime date;
        public int promena_cena { get; set; }
        public int kupovna_cena_1_klasa { get; set; }
        public int prodazhna_cena_1_klasa { get; set; }
        public int kupovna_cena_2_klasa { get; set; }
        public int prodazhna_cena_2_klasa { get; set; }
        public int kupovna_cena_lisichari { get; set; }
        public int prodazhna_cena_lisichari { get; set; }
        public int kupovna_cena_ovchoshapche { get; set; }
        public int prodazhna_cena_ovchoshapche { get; set; }
        public int kupovna_cena_rujnica { get; set; }
        public int prodazhna_cena_rujnica { get; set; }
        public int kupovna_cena_3_klasa { get; set; }
        public int prodazhna_cena_3_klasa { get; set; }
        public double isprateno_kg_1_klasa { get; set; }
        public double isprateno_kg_2_klasa { get; set; }
        public double isprateno_kg_3_klasa { get; set; }
        public double isprateno_kg_lisichari { get; set; }
        public double isprateno_kg_ovchoshapche { get; set; }
        public double isprateno_kg_rujnica { get; set; }
        public double prodadeno_kg_1_klasa { get; set; }
        public double prodadeno_kg_2_klasa { get; set; }
        public double prodadeno_kg_3_klasa { get; set; }
        public double prodadeno_kg_lisichari { get; set; }
        public double prodadeno_kg_ovchoshapche { get; set; }
        public double prodadeno_kg_rujnica { get; set; }
        public bool zavrshen_den { get; set; }

        public Day() {

        }

        public Day(DateTime date, int promena_cena, int kupovna_cena_1_klasa, int prodazhna_cena_1_klasa,
            int kupovna_cena_2_klasa, int prodazhna_cena_2_klasa, int kupovna_cena_lisichari, int prodazhna_cena_lisichari,
            int kupovna_cena_ovchoshapche, int prodazhna_cena_ovchoshapche, int kupovna_cena_rujnica, int prodazhna_cena_rujnica,
            int kupovna_cena_3_klasa, int prodazhna_cena_3_klasa, double isprateno_kg_1_klasa, double isprateno_kg_2_klasa,
            double isprateno_kg_3_klasa, double isprateno_kg_lisichari, double isprateno_kg_ovchoshapche,
            double isprateno_kg_rujnica, double prodadeno_kg_1_klasa, double prodadeno_kg_2_klasa, double prodadeno_kg_3_klasa,
            double prodadeno_kg_lisichari, double prodadeno_kg_ovchoshapche, double prodadeno_kg_rujnica, bool zavrshen_den) {
            this.date = date;
            this.promena_cena = promena_cena;
            this.kupovna_cena_1_klasa = kupovna_cena_1_klasa;
            this.prodazhna_cena_1_klasa = prodazhna_cena_1_klasa;
            this.kupovna_cena_2_klasa = kupovna_cena_2_klasa;
            this.prodazhna_cena_2_klasa = prodazhna_cena_2_klasa;
            this.kupovna_cena_lisichari = kupovna_cena_lisichari;
            this.prodazhna_cena_lisichari = prodazhna_cena_lisichari;
            this.kupovna_cena_ovchoshapche = kupovna_cena_ovchoshapche;
            this.prodazhna_cena_ovchoshapche = prodazhna_cena_ovchoshapche;
            this.kupovna_cena_rujnica = kupovna_cena_rujnica;
            this.prodazhna_cena_rujnica = prodazhna_cena_rujnica;
            this.kupovna_cena_3_klasa = kupovna_cena_3_klasa;
            this.prodazhna_cena_3_klasa = prodazhna_cena_3_klasa;
            this.isprateno_kg_1_klasa = isprateno_kg_1_klasa;
            this.isprateno_kg_2_klasa = isprateno_kg_2_klasa;
            this.isprateno_kg_3_klasa = isprateno_kg_3_klasa;
            this.isprateno_kg_lisichari = isprateno_kg_lisichari;
            this.isprateno_kg_ovchoshapche = isprateno_kg_ovchoshapche;
            this.isprateno_kg_rujnica = isprateno_kg_rujnica;
            this.prodadeno_kg_1_klasa = prodadeno_kg_1_klasa;
            this.prodadeno_kg_2_klasa = prodadeno_kg_2_klasa;
            this.prodadeno_kg_3_klasa = prodadeno_kg_3_klasa;
            this.prodadeno_kg_lisichari = prodadeno_kg_lisichari;
            this.prodadeno_kg_ovchoshapche = prodadeno_kg_ovchoshapche;
            this.prodadeno_kg_rujnica = prodadeno_kg_rujnica;
            this.zavrshen_den = zavrshen_den;
        }

        public override string ToString() {
            string str = "";
            str += "Datum: " + date + "\n";
            str += "Kupovna 1k: " + kupovna_cena_1_klasa + "\n";
            str += "Prodazhna 1k: " + prodazhna_cena_1_klasa + "\n";
            str += "Kupovna 2k: " + kupovna_cena_2_klasa + "\n";
            str += "Prodazhna 2k: " + prodazhna_cena_2_klasa + "\n";
            str += "Kupovna lis:" + kupovna_cena_lisichari + "\n";
            str += "Prodazhna lis: " + prodazhna_cena_lisichari + "\n";
            str += "Kupovna ovcho: " + kupovna_cena_ovchoshapche + "\n";
            str += "Prodazhna ovcho: " + prodazhna_cena_ovchoshapche + "\n";
            str += "Kupovna rujnica: " + kupovna_cena_rujnica + "\n";
            str += "Prodazhna rujnica:" + prodazhna_cena_rujnica + "\n";
            str += "Kupovna 3k: " + kupovna_cena_3_klasa + "\n";
            str += "Prodazhna 3k: " + prodazhna_cena_3_klasa + "\n";
            str += "Isprateno 1k: " + isprateno_kg_1_klasa + "\n";
            str += "Isprateno 2k: " + isprateno_kg_2_klasa + "\n";
            str += "Isprateno 3k: " + isprateno_kg_3_klasa + "\n";
            str += "Isprateno lis: " + isprateno_kg_lisichari + "\n";
            str += "Isprateno ovcho: " + isprateno_kg_ovchoshapche + "\n";
            str += "Isprateno rujnica: " + isprateno_kg_rujnica + "\n";
            str += "Prodadeno 1k: " + prodadeno_kg_1_klasa + "\n";
            str += "Prodadeno 2k: " + prodadeno_kg_2_klasa + "\n";
            str += "Prodadeno 3k: " + prodadeno_kg_3_klasa + "\n";
            str += "Prodadeno lis: " + prodadeno_kg_lisichari + "\n";
            str += "Prodadeno ovcho: " + prodadeno_kg_ovchoshapche + "\n";
            str += "Prodadeno rujnica:" + prodadeno_kg_rujnica + "\n";
            str += "Zavrshen den: " + (zavrshen_den ? "da" : "ne") + "\n"; 

            return str;
        }

    }
}
