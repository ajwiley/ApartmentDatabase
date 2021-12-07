using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApartmentProgram {
    public class Tenant {
        public string ssn { get; set; } = "";
        public string firstName { get; set; } = "";
        public string lastName { get; set; } = "";
        public string phone { get; set; } = "";
        public string email { get; set; } = "";
        public char gender { get; set; }

        public Tenant(string s, string fn, string ln, string p, string e, char g) {
            ssn = s;
            firstName = fn;
            lastName = ln;
            gender = g;
            phone = p;
            email = e;
        }
    }
}
