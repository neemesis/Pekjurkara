using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pekjurkara {
    class Customer {
        public int id { get; set; }
        public string ime { get; set; }

        public Customer(int id, string ime) {
            this.id = id;
            this.ime = ime;
        }

        public override string ToString() {
            return ime + " | " + id;
        }

    }
}
