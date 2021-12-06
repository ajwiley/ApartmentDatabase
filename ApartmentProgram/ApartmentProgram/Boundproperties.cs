using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace ApartmentProgram {
    public class BoundProperties : INotifyPropertyChanged {
        // The COM port for the SparkFun Pro RF
        private string _Data = "";
        public string Data {
            get => _Data;
            set {
                _Data = value;
                OnPropertyChanged();
            }
        }

        private string _Command = "";
        public string Command {
            get => _Command;
            set {
                _Command = value;
                OnPropertyChanged();
            }
        }

        private List<string> _ApartmentRows = new List<string>();
        public List<string> ApartmentRows {
            get => _ApartmentRows;
            set {
                _ApartmentRows = value;
                OnPropertyChanged();
            }
        }

        private int _ApartmentRowSelected = 0;
        public int ApartmentRowSelected {
            get => _ApartmentRowSelected;
            set {
                _ApartmentRowSelected = value;
                OnPropertyChanged();
            }
        }

        public BoundProperties() {
            ApartmentRows.Add("aNum");
            ApartmentRows.Add("numBeds");
            ApartmentRows.Add("numBaths");
            ApartmentRows.Add("gateCode");
            ApartmentRows.Add("isAvailable");
            ApartmentRows.Add("buildingNum");
        }

        public event PropertyChangedEventHandler? PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string PropertyName = "") {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(PropertyName));
        }
    }
}
