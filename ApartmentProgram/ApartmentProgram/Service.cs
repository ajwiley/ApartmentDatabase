using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApartmentProgram {
    public class Service {
        public int invoiceID { get; set; }
        public DateTime date { get; set; }
        public int companyID { get; set; }
        public int aptID { get; set; }

        public Service(int i, DateTime d, int c, int a) {
            invoiceID = i;
            date = d;
            companyID = c;
            aptID = a;
        }
    }
}
