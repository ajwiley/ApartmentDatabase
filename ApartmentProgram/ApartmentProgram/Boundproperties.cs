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

        private List<Apartment> _Apartments = new List<Apartment>();
        public List<Apartment> Apartments {
            get => _Apartments;
            set {
                _Apartments = value;
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
