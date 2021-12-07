using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApartmentProgram {
    public class Vehicle {
        public int vinNumber { get; set; }
        public string make { get; set; } = "";
        public string model { get; set; } = "";
        public int year { get; set; }
        public string color { get; set; } = "";
        public int ownerID { get; set; }

        public Vehicle(int vn, string m, string mo, int y, string c, int o) {
            vinNumber = vn;
            make = m;
            model = mo;
            year = y;
            color = c;
            ownerID = o;
        }
    }
}
