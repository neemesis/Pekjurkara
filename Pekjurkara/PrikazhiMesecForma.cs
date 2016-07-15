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
    public partial class PrikazhiMesecForma : Form {
        public PrikazhiMesecForma() {
            InitializeComponent();
            dateTimePicker1.CustomFormat = "MM/yyyy";
        }

        private void fillIn(List<Day> d) {
            dataGridView1.DataSource = d;

            double total1Klasa = 0;
            double total2Klasa = 0;
            double total3Klasa = 0;
            for (int i = 0; i < d.Count; ++i) {
                total1Klasa += d[i].isprateno_kg_1_klasa;
                total2Klasa += d[i].isprateno_kg_2_klasa;
                total3Klasa += d[i].isprateno_kg_3_klasa;
            }
            vkupno1Klasa.Text = "1Klas: " + total1Klasa + " || 2Klas: " + total2Klasa + " || 3Klas: " + total3Klasa;

            for (int i = 0; i < dataGridView1.ColumnCount; ++i) {
                dataGridView1.Columns[i].Width = 150;
            }
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e) {
            List<Day> d = SQLPort.getAllDaysForMonth(dateTimePicker1.Value);
            fillIn(d);
        }
    }
}
