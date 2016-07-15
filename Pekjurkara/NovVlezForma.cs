using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Pekjurkara {
    public partial class NovVlezForma : Form {

        Day day;
        Customer cust;
        List<CustomerDay> cdList;
        int dolzhi;
        int dolzhime;

        public NovVlezForma() {
            InitializeComponent();
            fillAutoSuggestion();
        }

        private void fillAutoSuggestion() {
            List<Customer> cust = SQLPort.getAllCustomers();
            AutoCompleteStringCollection acsc = new AutoCompleteStringCollection();
            foreach (Customer c in cust) {
                acsc.Add(c.ime);
            }
            txtCustomer.AutoCompleteCustomSource = acsc;

            day = SQLPort.getLastDay();

            lbl1kl.Text += day.kupovna_cena_1_klasa + " den.";
            lbl2kl.Text += day.kupovna_cena_2_klasa + " den.";
            lbl3kl.Text += day.kupovna_cena_3_klasa + " den.";
            lblLis.Text += day.kupovna_cena_lisichari + " den.";
            lblOvc.Text += day.kupovna_cena_ovchoshapche + " den.";
            lblRuj.Text += day.kupovna_cena_rujnica + " den.";
        }

        private void calculateTotal() {
            double[] ld = new double[6];
            double.TryParse(txt1Kl.Text, System.Globalization.NumberStyles.AllowDecimalPoint, System.Globalization.NumberFormatInfo.InvariantInfo, out ld[0]);
            double.TryParse(txt2Kl.Text, System.Globalization.NumberStyles.AllowDecimalPoint, System.Globalization.NumberFormatInfo.InvariantInfo, out ld[1]);
            double.TryParse(txt3Kl.Text, System.Globalization.NumberStyles.AllowDecimalPoint, System.Globalization.NumberFormatInfo.InvariantInfo, out ld[2]);
            double.TryParse(txtLis.Text, System.Globalization.NumberStyles.AllowDecimalPoint, System.Globalization.NumberFormatInfo.InvariantInfo, out ld[3]);
            double.TryParse(txtRuj.Text, System.Globalization.NumberStyles.AllowDecimalPoint, System.Globalization.NumberFormatInfo.InvariantInfo, out ld[4]);
            double.TryParse(txtOvcho.Text, System.Globalization.NumberStyles.AllowDecimalPoint, System.Globalization.NumberFormatInfo.InvariantInfo, out ld[5]);

            double total = ld[0] * day.kupovna_cena_1_klasa +
                ld[1] * day.kupovna_cena_2_klasa +
                ld[2] * day.kupovna_cena_3_klasa +
                ld[3] * day.kupovna_cena_lisichari +
                ld[4] * day.kupovna_cena_rujnica +
                ld[5] * day.kupovna_cena_ovchoshapche;

            lblSum.Text = "= " + ((int) total - dolzhi + dolzhime) + " den.";

            lbl1kl.Text = "x " + day.kupovna_cena_1_klasa + " = " + (ld[0] * day.kupovna_cena_1_klasa);
            lbl2kl.Text = "x " + day.kupovna_cena_2_klasa + " = " + (ld[1] * day.kupovna_cena_2_klasa);
            lbl3kl.Text = "x " + day.kupovna_cena_3_klasa + " = " + (ld[2] * day.kupovna_cena_3_klasa);
            lblLis.Text = "x " + day.kupovna_cena_lisichari + " = " + (ld[3] * day.kupovna_cena_lisichari);
            lblOvc.Text = "x " + day.kupovna_cena_ovchoshapche + " = " + (ld[5] * day.kupovna_cena_ovchoshapche);
            lblRuj.Text = "x " + day.kupovna_cena_rujnica + " = " + (ld[4] * day.kupovna_cena_rujnica);

            lblDolzhi.Text = "- " + dolzhi + " = " + (total - dolzhi);
            lblDolzhime.Text = "+ " + dolzhime + " = " + (total - dolzhi + dolzhime);

            
        }

        private void fillData() {
            cust = new Customer(SQLPort.getIDForCustomer(txtCustomer.Text), txtCustomer.Text);
            cdList = SQLPort.getCustomerDayForCustomerUnfinished(cust);

            dolzhi = 0;
            dolzhime = 0;

            foreach (CustomerDay cd1 in cdList) {
                dolzhi += cd1.dolzhi;
                dolzhime += cd1.dolzhime;
            }
        }

        private void txt_Leave(object sender, EventArgs e) {
            calculateTotal();
        }

        private void txtCustomer_Leave(object sender, EventArgs e) {
            fillData();
        }

        private void btnDolzhi_Click(object sender, EventArgs e) {
            KadeDolzhimeForm kdf = new KadeDolzhimeForm(cdList);
            kdf.Show();
        }

        private void button1_Click(object sender, EventArgs e) {
            CustomerDay cd = new CustomerDay();

            int id = SQLPort.getIDForCustomer(txtCustomer.Text);
            if (id == -1)
                SQLPort.insertIntoCustomers(new Customer(-1, txtCustomer.Text));
            cd.berach = SQLPort.getIDForCustomer(txtCustomer.Text);

            double[] ld = new double[6];
            double.TryParse(txt1Kl.Text, System.Globalization.NumberStyles.AllowDecimalPoint, System.Globalization.NumberFormatInfo.InvariantInfo, out ld[0]);
            double.TryParse(txt2Kl.Text, System.Globalization.NumberStyles.AllowDecimalPoint, System.Globalization.NumberFormatInfo.InvariantInfo, out ld[1]);
            double.TryParse(txt3Kl.Text, System.Globalization.NumberStyles.AllowDecimalPoint, System.Globalization.NumberFormatInfo.InvariantInfo, out ld[2]);
            double.TryParse(txtLis.Text, System.Globalization.NumberStyles.AllowDecimalPoint, System.Globalization.NumberFormatInfo.InvariantInfo, out ld[3]);
            double.TryParse(txtRuj.Text, System.Globalization.NumberStyles.AllowDecimalPoint, System.Globalization.NumberFormatInfo.InvariantInfo, out ld[4]);
            double.TryParse(txtOvcho.Text, System.Globalization.NumberStyles.AllowDecimalPoint, System.Globalization.NumberFormatInfo.InvariantInfo, out ld[5]);

            cd.kg_1_klasa = ld[0];
            cd.kg_2_klasa = ld[1];
            cd.kg_3_klasa = ld[2];
            cd.kg_lisichari = ld[3];
            cd.kg_rujnica = ld[4];
            cd.kg_ovchoshapche = ld[5];

            cd.den_datum = DateTime.Now;
            cd.vreme = DateTime.Now;

            cd.den_promena_cena = day.promena_cena;

            int[] li = new int[3];
            int.TryParse(txtDolzhi.Text, out li[0]);
            int.TryParse(txtDolzhime.Text, out li[1]);
            int.TryParse(txtPlateno.Text, out li[2]);

            cd.dolzhi = li[0];
            cd.dolzhime = li[1];
            cd.kolku_plateno = li[2];

            SQLPort.updateCustomerDayRemoveUnfinished(SQLPort.getCustomerFromID(cd.berach));
            SQLPort.insertIntoCustomerDay(cd);

            MessageBox.Show("Uspeshno vneseno.", "");

            this.Close();
        }

        private void txtPlateno_TextChanged(object sender, EventArgs e) {
            int plateno = 0;
            int.TryParse(txtPlateno.Text, out plateno);

            double[] ld = new double[6];
            double.TryParse(txt1Kl.Text, System.Globalization.NumberStyles.AllowDecimalPoint, System.Globalization.NumberFormatInfo.InvariantInfo, out ld[0]);
            double.TryParse(txt2Kl.Text, System.Globalization.NumberStyles.AllowDecimalPoint, System.Globalization.NumberFormatInfo.InvariantInfo, out ld[1]);
            double.TryParse(txt3Kl.Text, System.Globalization.NumberStyles.AllowDecimalPoint, System.Globalization.NumberFormatInfo.InvariantInfo, out ld[2]);
            double.TryParse(txtLis.Text, System.Globalization.NumberStyles.AllowDecimalPoint, System.Globalization.NumberFormatInfo.InvariantInfo, out ld[3]);
            double.TryParse(txtRuj.Text, System.Globalization.NumberStyles.AllowDecimalPoint, System.Globalization.NumberFormatInfo.InvariantInfo, out ld[4]);
            double.TryParse(txtOvcho.Text, System.Globalization.NumberStyles.AllowDecimalPoint, System.Globalization.NumberFormatInfo.InvariantInfo, out ld[5]);

            double total = ld[0] * day.kupovna_cena_1_klasa +
                ld[1] * day.kupovna_cena_2_klasa +
                ld[2] * day.kupovna_cena_3_klasa +
                ld[3] * day.kupovna_cena_lisichari +
                ld[4] * day.kupovna_cena_rujnica +
                ld[5] * day.kupovna_cena_ovchoshapche
                - dolzhi + dolzhime;

            if (total - plateno > 0) {
                txtDolzhime.Text = (total - plateno) + "";
                txtDolzhi.Text = "";
            } else if (total - plateno < 0) {
                txtDolzhi.Text = (plateno - total) + "";
                txtDolzhime.Text = "";
            }
        }
    }
}
