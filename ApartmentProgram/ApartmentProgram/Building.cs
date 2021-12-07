using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApartmentProgram {
    public class Building {
        public int bNum { get; set; }
        public bool petsAllowed { get; set; }
        public Building(int b, bool pa) {
            bNum = b;
            petsAllowed = pa;
        }
    }
}
