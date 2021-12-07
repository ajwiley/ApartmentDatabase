using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApartmentProgram {
    public class Maintenanceco {
        public int cID { get; set; }
        public string cName { get; set; } = "";
        public string cType { get; set; } = "";

        public Maintenanceco(int c, string cn, string ct) { 
            cID = c;
            cName = cn;
            cType = ct;
        }
    }
}
