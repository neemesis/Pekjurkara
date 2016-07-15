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
    public partial class PromeniImeForma : Form {
        List<Customer> cust;

        public PromeniImeForma() {
            InitializeComponent();
            fillCustomerNames();
        }

        private void fillCustomerNames() {
            cust = SQLPort.getAllCustomers();
            listBox1.DataSource = cust;
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e) {
            txtName.Text = cust[listBox1.SelectedIndex].ime;
        }

        private void btnChange_Click(object sender, EventArgs e) {
            SQLPort.updateCustomer(new Customer(cust[listBox1.SelectedIndex].id, txtName.Text));
            fillCustomerNames();
        }
    }
}
