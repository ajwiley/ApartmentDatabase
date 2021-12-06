using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApartmentProgram {
    public class Apartment {
        public int aNum { get;set; }
        public int numBeds { get;set; }
        public int numBaths { get;set; }
        public string gateCode { get; set; } = "";
        public bool isAvailable { get; set; }
        public int buildingNum { get; set; }

        public Apartment(int a, int nb, int nba, string gc, bool ia, int bn) {
            aNum = a;
            numBeds = nb;
            numBaths = nba;
            gateCode = gc;
            isAvailable = ia;
            buildingNum = bn;
        }
    }
}
