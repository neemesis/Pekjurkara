using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Pekjurkara {
    public partial class ZatvoriDenForma : Form {

        List<Day> days;

        public ZatvoriDenForma() {
            InitializeComponent();
            fillInData();
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

        private void fillInData() {
            days = SQLPort.getUnfinishedDays();
            dataGridView1.DataSource = ToDataTable(days);
            if (dataGridView1.SelectedRows.Count > 0)
                fillTextBoxes(dataGridView1.SelectedRows[0].Index);
        }

        private void fillTextBoxes(int rowId) {
            Debug.WriteLine(rowId);
            kup1kl.Text = dataGridView1[1, rowId].Value.ToString();
            prod1kl.Text = dataGridView1[2, rowId].Value.ToString();
            kup2kl.Text = dataGridView1[3, rowId].Value.ToString();
            prod2kl.Text = dataGridView1[4, rowId].Value.ToString();
            kupLis.Text = dataGridView1[5, rowId].Value.ToString();
            prodLis.Text = dataGridView1[6, rowId].Value.ToString();
            kupOvcho.Text = dataGridView1[7, rowId].Value.ToString();
            prodOvcho.Text = dataGridView1[8, rowId].Value.ToString();
            kupRuj.Text = dataGridView1[9, rowId].Value.ToString();
            prodRuj.Text = dataGridView1[10, rowId].Value.ToString();
            kup3kl.Text = dataGridView1[11, rowId].Value.ToString();
            prod3kl.Text = dataGridView1[12, rowId].Value.ToString();
            ispr1kl.Text = dataGridView1[13, rowId].Value.ToString();
            ispr2kl.Text = dataGridView1[14, rowId].Value.ToString();
            ispr3kl.Text = dataGridView1[15, rowId].Value.ToString();
            isprLis.Text = dataGridView1[16, rowId].Value.ToString();
            isprOvcho.Text = dataGridView1[17, rowId].Value.ToString();
            isprRuj.Text = dataGridView1[18, rowId].Value.ToString();
            prodad1kl.Text = dataGridView1[19, rowId].Value.ToString();
            prodad2kl.Text = dataGridView1[20, rowId].Value.ToString();
            prodad3kl.Text = dataGridView1[21, rowId].Value.ToString();
            prodadLis.Text = dataGridView1[22, rowId].Value.ToString();
            prodadOvcho.Text = dataGridView1[23, rowId].Value.ToString();
            prodadRuj.Text = dataGridView1[24, rowId].Value.ToString();
        }

        private void dataGridView1_RowEnter(object sender, DataGridViewCellEventArgs e) {
            if (dataGridView1.SelectedRows.Count > 0)
                fillTextBoxes(dataGridView1.SelectedRows[0].Index);
        }

        private void btnSubmit_Click(object sender, EventArgs e) {
            int[] li = new int[12];
            double[] ld = new double[12];
            int.TryParse(kup1kl.Text, System.Globalization.NumberStyles.AllowDecimalPoint, System.Globalization.NumberFormatInfo.InvariantInfo, out li[0]);
            int.TryParse(prod1kl.Text, System.Globalization.NumberStyles.AllowDecimalPoint, System.Globalization.NumberFormatInfo.InvariantInfo, out li[1]);
            int.TryParse(kup2kl.Text, System.Globalization.NumberStyles.AllowDecimalPoint, System.Globalization.NumberFormatInfo.InvariantInfo, out li[2]);
            int.TryParse(prod2kl.Text, System.Globalization.NumberStyles.AllowDecimalPoint, System.Globalization.NumberFormatInfo.InvariantInfo, out li[3]);
            int.TryParse(kupLis.Text, System.Globalization.NumberStyles.AllowDecimalPoint, System.Globalization.NumberFormatInfo.InvariantInfo, out li[4]);
            int.TryParse(prodLis.Text, System.Globalization.NumberStyles.AllowDecimalPoint, System.Globalization.NumberFormatInfo.InvariantInfo, out li[5]);
            int.TryParse(kupOvcho.Text, System.Globalization.NumberStyles.AllowDecimalPoint, System.Globalization.NumberFormatInfo.InvariantInfo, out li[6]);
            int.TryParse(prodOvcho.Text, System.Globalization.NumberStyles.AllowDecimalPoint, System.Globalization.NumberFormatInfo.InvariantInfo, out li[7]);
            int.TryParse(kupRuj.Text, System.Globalization.NumberStyles.AllowDecimalPoint, System.Globalization.NumberFormatInfo.InvariantInfo, out li[8]);
            int.TryParse(prodRuj.Text, System.Globalization.NumberStyles.AllowDecimalPoint, System.Globalization.NumberFormatInfo.InvariantInfo, out li[9]);
            int.TryParse(kup3kl.Text, System.Globalization.NumberStyles.AllowDecimalPoint, System.Globalization.NumberFormatInfo.InvariantInfo, out li[10]);
            int.TryParse(prod3kl.Text, System.Globalization.NumberStyles.AllowDecimalPoint, System.Globalization.NumberFormatInfo.InvariantInfo, out li[11]);
            double.TryParse(ispr1kl.Text, System.Globalization.NumberStyles.AllowDecimalPoint, System.Globalization.NumberFormatInfo.InvariantInfo, out ld[0]);
            double.TryParse(ispr2kl.Text, System.Globalization.NumberStyles.AllowDecimalPoint, System.Globalization.NumberFormatInfo.InvariantInfo, out ld[1]);
            double.TryParse(ispr3kl.Text, System.Globalization.NumberStyles.AllowDecimalPoint, System.Globalization.NumberFormatInfo.InvariantInfo, out ld[2]);
            double.TryParse(isprLis.Text, System.Globalization.NumberStyles.AllowDecimalPoint, System.Globalization.NumberFormatInfo.InvariantInfo, out ld[3]);
            double.TryParse(isprOvcho.Text, System.Globalization.NumberStyles.AllowDecimalPoint, System.Globalization.NumberFormatInfo.InvariantInfo, out ld[4]);
            double.TryParse(isprRuj.Text, System.Globalization.NumberStyles.AllowDecimalPoint, System.Globalization.NumberFormatInfo.InvariantInfo, out ld[5]);
            double.TryParse(prodad1kl.Text, System.Globalization.NumberStyles.AllowDecimalPoint, System.Globalization.NumberFormatInfo.InvariantInfo, out ld[6]);
            double.TryParse(prodad2kl.Text, System.Globalization.NumberStyles.AllowDecimalPoint, System.Globalization.NumberFormatInfo.InvariantInfo, out ld[7]);
            double.TryParse(prodad3kl.Text, System.Globalization.NumberStyles.AllowDecimalPoint, System.Globalization.NumberFormatInfo.InvariantInfo, out ld[8]);
            double.TryParse(prodadLis.Text, System.Globalization.NumberStyles.AllowDecimalPoint, System.Globalization.NumberFormatInfo.InvariantInfo, out ld[9]);
            double.TryParse(prodadOvcho.Text, System.Globalization.NumberStyles.AllowDecimalPoint, System.Globalization.NumberFormatInfo.InvariantInfo, out ld[10]);
            double.TryParse(prodadRuj.Text, System.Globalization.NumberStyles.AllowDecimalPoint, System.Globalization.NumberFormatInfo.InvariantInfo, out ld[11]);

            Day d = new Day();
            d.date = days[dataGridView1.SelectedRows[0].Index].date;
            d.promena_cena = days[dataGridView1.SelectedRows[0].Index].promena_cena;
            d.kupovna_cena_1_klasa = li[0];
            d.prodazhna_cena_1_klasa = li[1];
            d.kupovna_cena_2_klasa = li[2];
            d.prodazhna_cena_2_klasa = li[3];
            d.kupovna_cena_lisichari = li[4];
            d.prodazhna_cena_lisichari = li[5];
            d.kupovna_cena_ovchoshapche = li[6];
            d.prodazhna_cena_ovchoshapche = li[7];
            d.kupovna_cena_rujnica = li[8];
            d.prodazhna_cena_rujnica = li[9];
            d.kupovna_cena_3_klasa = li[10];
            d.prodazhna_cena_3_klasa = li[11];
            d.isprateno_kg_1_klasa = ld[0];
            d.isprateno_kg_2_klasa = ld[1];
            d.isprateno_kg_3_klasa = ld[2];
            d.isprateno_kg_lisichari = ld[3];
            d.isprateno_kg_ovchoshapche = ld[4];
            d.isprateno_kg_rujnica = ld[5];
            d.prodadeno_kg_1_klasa = ld[6];
            d.prodadeno_kg_2_klasa = ld[7];
            d.prodadeno_kg_3_klasa = ld[8];
            d.prodadeno_kg_lisichari = ld[9];
            d.prodadeno_kg_ovchoshapche = ld[10];
            d.prodadeno_kg_rujnica = ld[11];
            d.zavrshen_den = true;

            SQLPort.updateDays(d);
            fillInData();

        }
    }
}
