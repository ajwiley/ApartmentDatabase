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

        private List<string> _BuildingRows = new List<string>();
        public List<string> BuildingRows {
            get => _BuildingRows;
            set {
                _BuildingRows = value;
                OnPropertyChanged();
            }
        }

        private List<string> _leaseRows = new List<string>();
        public List<string> leaseRows {
            get => _leaseRows;
            set {
                _leaseRows = value;
                OnPropertyChanged();
            }
        }

        private List<string> _MaintenanceCORows = new List<string>();
        public List<string> MaintenanceCORows {
            get => _MaintenanceCORows;
            set {
                _MaintenanceCORows = value;
                OnPropertyChanged();
            }
        }

        private List<string> _ServicesRows = new List<string>();
        public List<string> ServicesRows {
            get => _ServicesRows;
            set {
                _ServicesRows = value;
                OnPropertyChanged();
            }
        }

        private List<string> _TenantRows = new List<string>();
        public List<string> TenantRows {
            get => _TenantRows;
            set {
                _TenantRows = value;
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
