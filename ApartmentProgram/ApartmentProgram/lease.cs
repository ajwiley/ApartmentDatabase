using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApartmentProgram {
    public class lease {
        public int lID { get; set; }
        public int deposit { get; set; }
        public int monthlyRent { get; set; }
        public DateTime startDate { get; set; }
        public DateTime endDate { get; set; }
        public int aptNum { get; set; }
        public string primaryTenant { get; set; } = "";
        public string? secondaryTenant { get; set; }
        public string? tertiaryTenant { get; set; }

        public lease(int id, int d, int mr, DateTime sd, DateTime ed, int an, string pt, string? st, string? tt) {
            lID = id;
            deposit = d;
            monthlyRent = mr;
            startDate = sd;
            endDate = ed;
            aptNum = an;
            primaryTenant = pt;
            secondaryTenant = st;
            tertiaryTenant = tt;
        }
    }
}
