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
    public partial class PrikazhiDenForma : Form {
        public PrikazhiDenForma() {
            InitializeComponent();
            this.WindowState = FormWindowState.Maximized;
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e) {
            DateTime dt = dateTimePicker1.Value;
            List<CustomerDay> cd = SQLPort.getCustomerDayFromDate(dt);
            fillIn(cd);
            
        }

        private void fillIn(List<CustomerDay> cd) {
            dataGridView1.DataSource = cd;
            dataGridView1.Columns["berach"].Visible = false;
            dataGridView1.Columns["den_datum"].Visible = false;
            dataGridView1.Columns["den_promena_cena"].HeaderText = "Prom.Cena";
            dataGridView1.Columns["vreme"].HeaderText = "Vreme";
            dataGridView1.Columns["kg_1_klasa"].HeaderText = "1 Klasa";
            dataGridView1.Columns["kg_2_klasa"].HeaderText = "2 Klasa";
            dataGridView1.Columns["kg_3_klasa"].HeaderText = "3 Klasa";
            dataGridView1.Columns["kg_lisichari"].HeaderText = "Lisichari";
            dataGridView1.Columns["kg_ovchoshapche"].HeaderText = "Ovcho Sh.";
            dataGridView1.Columns["kg_rujnica"].HeaderText = "Rujnica";
            dataGridView1.Columns["kolku_plateno"].HeaderText = "Plateno";
            dataGridView1.Columns["dolzhi"].HeaderText = "Dolzhi";
            dataGridView1.Columns["dolzhime"].HeaderText = "Dolzhime";
            for (int i = 0; i < dataGridView1.RowCount; ++i) {
                int id;
                int.TryParse(dataGridView1[1, i].Value.ToString(), out id);
                string name = SQLPort.getNameForCustomer(id);
                dataGridView1[0, i].Value = name;
            }

            double t1k = 0;
            double t2k = 0;
            double t3k = 0;
            double lis = 0;
            double ovc = 0;
            double ruj = 0;
            int kop = 0;
            int dol = 0;
            int dlm = 0;
            
            for (int i = 0; i < cd.Count; ++i) {
                t1k += cd[i].kg_1_klasa;
                t2k += cd[i].kg_2_klasa;
                t3k += cd[i].kg_3_klasa;
                lis += cd[i].kg_lisichari;
                ovc += cd[i].kg_ovchoshapche;
                ruj += cd[i].kg_rujnica;
                kop += cd[i].kolku_plateno;
                dol += cd[i].dolzhi;
                dlm += cd[i].dolzhime;
            }
            string str = "";
            if (t1k > 0)
                str += "1Klasa: " + t1k;
            if (t2k > 0)
                str += " | 2Klasa: " + t2k;
            if (t3k > 0)
                str += " | 3Klasa: " + t3k;
            if (lis > 0)
                str += " | Lis: " + lis;
            if (ovc > 0)
                str += " | Ovcho: " + ovc;
            if (ruj > 0)
                str += " | Ruj: " + ruj;
            str += " | Plateno: " + kop + " | Dolzhi: " + dol + " | Dolzhime: " + dlm;
            label1.Text = str;
        }
    }
}
