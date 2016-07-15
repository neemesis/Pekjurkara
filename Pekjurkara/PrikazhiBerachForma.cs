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
    public partial class PrikazhiBerachForma : Form {

        List<Customer> cust;

        public PrikazhiBerachForma() {
            InitializeComponent();
            fillCustomerNames();
        }

        private void fillCustomerNames() {
            cust = SQLPort.getAllCustomers();
            listBox1.DataSource = cust;
        }

        private void fillData(int idx) {

            double vkupno1kl = 0;
            double vkupno2kl = 0;
            double vkupno3kl = 0;
            double vkupnoLis = 0;
            double vkupnoOvc = 0;
            double vkupnoRuj = 0;
            int vkupnoPla = 0;
            int vkupnoDolzhi = 0;
            int vkupnoDolzhime = 0;

            CustomerEntry ce = SQLPort.getEntriesForCustomer(cust[idx].ime);

            for (int i = 0; i < ce.entries.Count; ++i) {
                vkupno1kl += ce.entries[i].kg_1_klasa;
                vkupno2kl += ce.entries[i].kg_2_klasa;
                vkupno3kl += ce.entries[i].kg_3_klasa;
                vkupnoLis += ce.entries[i].kg_lisichari;
                vkupnoOvc += ce.entries[i].kg_ovchoshapche;
                vkupnoRuj += ce.entries[i].kg_rujnica;
                vkupnoPla += ce.entries[i].kolku_plateno;
                vkupnoDolzhi += ce.entries[i].dolzhi;
                vkupnoDolzhime += ce.entries[i].dolzhime;
            }

            
            DataTable dt = ToDataTable<CustomerDay>(ce.entries);
            //lblStatus.Text = "Vkupno: " + vkupno1kl + " | " + vkupno2kl + "" vkupno3kl, vkupnoLis, vkupnoOvc, vkupnoRuj, vkupnoPla,
             //   vkupnoDolzhi, vkupnoDolzhime
            dt.Rows.Add("Vkupno: ", "", "", "", vkupno1kl, vkupno2kl, vkupno3kl, vkupnoLis, vkupnoOvc, vkupnoRuj, vkupnoPla,
                vkupnoDolzhi, vkupnoDolzhime);
            dt.AcceptChanges();
            dataGridView1.DataSource = dt;
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e) {
            Debug.WriteLine(listBox1.SelectedIndex);
            fillData(listBox1.SelectedIndex);
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
    }
}
