using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pekjurkara {
    class CustomerEntry {
        public Customer customer { get; set; }
        public List<CustomerDay> entries { get; set; }
    }
}
