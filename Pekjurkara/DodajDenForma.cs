using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Pekjurkara {
    public partial class DodajDenForma : Form {
        public DodajDenForma() {
            InitializeComponent();

            fillData();
        }

        private void fillData() {
            Day d = SQLPort.getDaysFromPrimaryKey(DateTime.Now.AddDays(-1), 0);
            if (d == null)
                return;

            kup1kl.Text = d.kupovna_cena_1_klasa + "";
            prod1kl.Text = d.prodazhna_cena_1_klasa + "";
            kup2kl.Text = d.kupovna_cena_2_klasa + "";
            prod2kl.Text = d.prodazhna_cena_2_klasa + "";
            kup3kl.Text = d.kupovna_cena_3_klasa + "";
            prod3kl.Text = d.prodazhna_cena_3_klasa + "";
            kupLis.Text = d.kupovna_cena_lisichari + "";
            prodLis.Text = d.prodazhna_cena_lisichari + "";
            kupOvcho.Text = d.kupovna_cena_ovchoshapche + "";
            prodOvcho.Text = d.prodazhna_cena_ovchoshapche + "";
            kupRuj.Text = d.kupovna_cena_rujnica + "";
            prodRuj.Text = d.prodazhna_cena_rujnica + "";
            promenaCena.Text = d.promena_cena + "";
        }

        private void btnSubmit_Click(object sender, EventArgs e) {
            int[] li = new int[13];
            int.TryParse(kup1kl.Text, out li[0]);
            int.TryParse(prod1kl.Text, out li[1]);
            int.TryParse(kup2kl.Text, out li[2]);
            int.TryParse(prod2kl.Text, out li[3]);
            int.TryParse(kupLis.Text, out li[4]);
            int.TryParse(prodLis.Text, out li[5]);
            int.TryParse(kupOvcho.Text, out li[6]);
            int.TryParse(prodOvcho.Text, out li[7]);
            int.TryParse(kupRuj.Text, out li[8]);
            int.TryParse(prodRuj.Text, out li[9]);
            int.TryParse(kup3kl.Text, out li[10]);
            int.TryParse(prod3kl.Text, out li[11]);
            int.TryParse(promenaCena.Text, out li[12]);

            Day d = new Day(DateTime.Now, li[12], li[0], li[1], li[2], li[3], li[4], li[5], li[6], li[7], li[8], li[9], li[10],
                li[11], 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, false);

            SQLPort.insertIntoDays(d);

            this.Close();
        }
    }
}
