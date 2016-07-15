using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using System.Reflection;

namespace Pekjurkara {
    public partial class Form1 : Form {
        Day curDay;
        public Form1() {
            InitializeComponent();
            //this.WindowState = FormWindowState.Maximized;
            fillData();
        }

        private void fillData() {
            curDay = SQLPort.getLastDay();
            if (curDay == null) {
                dataGrid.Enabled = false;
                return;
            } else {
                dataGrid.Enabled = true;
            }

            string str = "Cena: || 1 Klasa: " + curDay.kupovna_cena_1_klasa +
                " || 2 Klasa: " + curDay.kupovna_cena_2_klasa;
            if (curDay.kupovna_cena_3_klasa > 0)
                str += " || 3 Klasa: " + curDay.kupovna_cena_3_klasa;
            if (curDay.kupovna_cena_lisichari > 0)
                str += " || Lisichari: " + curDay.kupovna_cena_lisichari;
            if (curDay.kupovna_cena_ovchoshapche > 0)
                str += " || OvchoSh.: " + curDay.kupovna_cena_ovchoshapche;
            if (curDay.kupovna_cena_rujnica > 0)
                str += " || Rujnica: " + curDay.kupovna_cena_rujnica;
            lblStatus.Text = str;

            List <CustomerDay> cd = SQLPort.getCustomerDayFromDateAndPriceChange(curDay.date, curDay.promena_cena);
            DataTable dt = ToDataTable(cd);

            double vkupno1kl = 0;
            double vkupno2kl = 0;
            double vkupno3kl = 0;
            double vkupnoLis = 0;
            double vkupnoOvc = 0;
            double vkupnoRuj = 0;
            int vkupnoPla = 0;
            int vkupnoDolzhi = 0;
            int vkupnoDolzhime = 0;

            for (int i = 0; i < cd.Count; ++i) {
                vkupno1kl += cd[i].kg_1_klasa;
                vkupno2kl += cd[i].kg_2_klasa;
                vkupno3kl += cd[i].kg_3_klasa;
                vkupnoLis += cd[i].kg_lisichari;
                vkupnoOvc += cd[i].kg_ovchoshapche;
                vkupnoRuj += cd[i].kg_rujnica;
                vkupnoPla += cd[i].kolku_plateno;
                vkupnoDolzhi += cd[i].dolzhi;
                vkupnoDolzhime += cd[i].dolzhime;

                dt.Rows[i].SetField(0, SQLPort.getNameForCustomer(cd[i].berach));
                dt.Rows[i].SetField(3, cd[i].vreme.Hour.ToString("00") + ":" + cd[i].vreme.Minute.ToString("00") + 
                    ":" + cd[i].vreme.Second.ToString("00"));
            }


            dt.Rows.Add("Vkupno: ", "", "", "", vkupno1kl, vkupno2kl, vkupno3kl, vkupnoLis, vkupnoOvc, vkupnoRuj, vkupnoPla,
                vkupnoDolzhi, vkupnoDolzhime);
            dt.AcceptChanges();
            dataGrid.DataSource = dt;

            if (curDay.kupovna_cena_lisichari == 0)
                dataGrid.Columns["kg_lisichari"].Visible = false;
            if (curDay.kupovna_cena_ovchoshapche == 0)
                dataGrid.Columns["kg_ovchoshapche"].Visible = false;
            if (curDay.kupovna_cena_rujnica == 0)
                dataGrid.Columns["kg_rujnica"].Visible = false;
            if (curDay.kupovna_cena_3_klasa == 0)
                dataGrid.Columns["kg_3_klasa"].Visible = false;

            dataGrid.Columns["den_datum"].Visible = false;
            dataGrid.Columns["berach"].HeaderText = "Berach";
            dataGrid.Columns["den_promena_cena"].HeaderText = "Promena na Cena";
            dataGrid.Columns["kg_1_klasa"].HeaderText = "1 Klasa";
            dataGrid.Columns["kg_2_klasa"].HeaderText = "2 Klasa";
            dataGrid.Columns["kg_3_klasa"].HeaderText = "3 Klasa";
            dataGrid.Columns["kg_lisichari"].HeaderText = "Lisichari";
            dataGrid.Columns["kg_ovchoshapche"].HeaderText = "Ovcho Sh.";
            dataGrid.Columns["kg_rujnica"].HeaderText = "Rujnica";
            dataGrid.Columns["kolku_plateno"].HeaderText = "Plateno";
            dataGrid.Columns["dolzhi"].HeaderText = "Dolzhi";
            dataGrid.Columns["dolzhime"].HeaderText = "Dolzhime";
            dataGrid.Columns["vreme"].HeaderText = "Vreme";
        }

        public static DataTable ToDataTable<T>(List<T> items) {
            DataTable dataTable = new DataTable(typeof(T).Name);

            //Get all the properties
            PropertyInfo[] Props = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance);
            foreach (PropertyInfo prop in Props) {
                //Setting column names as Property names
                dataTable.Columns.Add(prop.Name);
            }
            foreach (T item in items) {
                var values = new object[Props.Length];
                for (int i = 0; i < Props.Length; i++) {
                    //inserting property values to datatable rows
                    values[i] = Props[i].GetValue(item, null);
                }
                dataTable.Rows.Add(values);
            }
            //put a breakpoint here and check datatable
            return dataTable;
        }

        private void denToolStripMenuItem_Click(object sender, EventArgs e) {
            PrikazhiDenForma pdf = new PrikazhiDenForma();
            pdf.Show();
        }

        private void mesecToolStripMenuItem_Click(object sender, EventArgs e) {
            PrikazhiMesecForma pmf = new PrikazhiMesecForma();
            pmf.Show();
        }

        private void zatvoriDenToolStripMenuItem_Click(object sender, EventArgs e) {
            ZatvoriDenForma zdf = new ZatvoriDenForma();
            zdf.Show();
        }

        private void berachToolStripMenuItem_Click(object sender, EventArgs e) {
            PrikazhiBerachForma pbf = new PrikazhiBerachForma();
            pbf.Show();
        }

        private void imeNaBerachToolStripMenuItem_Click(object sender, EventArgs e) {
            PromeniImeForma pif = new PromeniImeForma();
            pif.Show();
        }

        private void novDenToolStripMenuItem_Click(object sender, EventArgs e) {
            DodajDenForma ddf = new DodajDenForma();
            ddf.Show();
        }

        private void novBerachToolStripMenuItem_Click(object sender, EventArgs e) {
            NovVlezForma nvf = new NovVlezForma();
            nvf.Show();
        }

        private void toolStripSplitButton1_ButtonClick(object sender, EventArgs e) {
            fillData();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e) {
            fillData();
        }

        private void Form1_Activated(object sender, EventArgs e) {
            fillData();
        }
    }
}
