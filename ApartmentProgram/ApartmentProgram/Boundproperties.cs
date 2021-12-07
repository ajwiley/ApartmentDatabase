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

        private List<Apartment> _Apartments = new();
        public List<Apartment> Apartments {
            get => _Apartments;
            set {
                _Apartments = value;
                OnPropertyChanged();
            }
        }

        private List<Building> _Buildings = new();
        public List<Building> Buildings { 
            get => _Buildings;
            set {
                _Buildings = value;
                OnPropertyChanged();
            }
        }

        private List<lease> _leases = new();
        public List<lease> Leases {
            get => _leases;
            set {
                _leases = value;
                OnPropertyChanged();
            }
        }

        private List<Maintenanceco> _MaintenanceCO = new();
        public List<Maintenanceco> MaintenanceCO {
            get => _MaintenanceCO;
            set {
                _MaintenanceCO = value;
                OnPropertyChanged();
            }
        }

        private List<Service> _Services = new();
        public List<Service> Services { 
            get => _Services;
            set {
                _Services = value;
                OnPropertyChanged();
            }
        }

        private List<Tenant> _Tenants = new();
        public List<Tenant> Tenants {
            get => _Tenants;
            set {
                _Tenants = value;
                OnPropertyChanged();
            }
        }

        private List<Vehicle> _Vehicles = new();
        public List<Vehicle> Vehicles {
            get => _Vehicles;
            set {
                _Vehicles = value;
                OnPropertyChanged();
            }
        }

        public int CurrentlyRented => Apartments.Count(a => a.isAvailable);

        public BoundProperties() { }

        public event PropertyChangedEventHandler? PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string PropertyName = "") {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(PropertyName));
        }
    }
}
