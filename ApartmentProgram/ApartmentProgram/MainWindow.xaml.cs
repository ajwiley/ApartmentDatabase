using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Diagnostics;

namespace ApartmentProgram {
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window {
        private BoundProperties _BoundProperties = new();
        string Connect = "server=localhost;userid=root;database=apartment2;password=aronwiley10";
        string AllApartmnet = "select * from apartment";
        string AllBuildings = "select * from building";
        string AllLeases = "select * from leases";
        string AllMaintenanceCO = "select * from maintenanceco";
        string AllServices = "select * from services";
        string AllTenants = "select * from tenant";
        string AllVehicles = "select * from vehicle";

        public MainWindow() {
            InitializeComponent();
            DataContext = _BoundProperties;

            //Debug.WriteLine(GetValueFromDBUsing("select * from apartment"));
            GetApartments();
            GetBuildings();
            GetLeases();
            GetMaintenanceCO();
            GetServices();
            GetTenants();
            GetVehicles();
        }

        private void GetVehicles() {
            string Vehicle = GetValueFromDBUsing(AllVehicles, new string[] { "vinNumber", "make", "model", "year", "color", "ownderID" });
            string[] vs = Vehicle.Split("\n");

            for (int i = 0; i < vs.Length - 1; i++) {
                string[] vs1 = vs[i].Split(',');
                Debug.WriteLine(vs1[i]);

                Vehicle temp = new(Convert.ToInt32(vs1[0]), vs1[1], vs1[2], Convert.ToInt32(vs1[3]), vs1[4], Convert.ToInt32(vs1[5]));
                _BoundProperties.Vehicles.Add(temp);
            }
        }

        private void GetTenants() {
            string Tenant = GetValueFromDBUsing(AllTenants, new string[] { "ssn", "firstName", "lastName", "phone", "email", "gender" });
            string[] vs = Tenant.Split("\n");

            for (int i = 0; i < vs.Length - 1; i++) {
                string[] vs1 = vs[i].Split(',');

                Tenant temp = new(vs1[0], vs1[1], vs1[2], vs1[3], vs1[4], Convert.ToChar(vs1[5]));
                _BoundProperties.Tenants.Add(temp);
            }
        }

        private void GetServices() {
            string Services = GetValueFromDBUsing(AllServices, new string[] { "invoiceID", "date", "companyID", "aptID" });
            string[] vs = Services.Split("\n");

            for (int i = 0; i < vs.Length - 1; i++) {
                string[] vs1 = vs[i].Split(',');

                Service temp = new(Convert.ToInt32(vs1[0]), Convert.ToDateTime(vs1[1]), Convert.ToInt32(vs1[2]), Convert.ToInt32(vs1[3]));
                _BoundProperties.Services.Add(temp);
            }
        }

        private void GetMaintenanceCO() {
            string MainteanceCO = GetValueFromDBUsing(AllMaintenanceCO, new string[] { "cID", "cName", "cType" });
            string[] vs = MainteanceCO.Split("\n");

            for (int i = 0; i < vs.Length - 1; i++) {
                string[] vs1 = vs[i].Split(',');

                Maintenanceco temp = new(Convert.ToInt32(vs1[0]), vs1[1], vs1[2]);
                _BoundProperties.MaintenanceCO.Add(temp);
            }
        }

        private void GetLeases() {
            string Apartments = GetValueFromDBUsing(AllLeases, new string[] { "lID", "deposit", "monthlyRent", "startDate", "endDate", "aptNum", "primaryTenant", "secondaryTenant", "tertiaryTenant" });
            string[] vs = Apartments.Split("\n");

            for (int i = 0; i < vs.Length - 1; i++) {
                string[] vs1 = vs[i].Split(',');

                lease temp;

                if (vs1.Length == 9) {
                    temp = new(Convert.ToInt32(vs1[0]), Convert.ToInt32(vs1[1]), Convert.ToInt32(vs1[2]), Convert.ToDateTime(vs1[3]), Convert.ToDateTime(vs1[4]), Convert.ToInt32(vs1[5]), vs1[6], vs1[7], vs1[8]);
                }
                else if (vs1.Length == 8) {
                    temp = new(Convert.ToInt32(vs1[0]), Convert.ToInt32(vs1[1]), Convert.ToInt32(vs1[2]), Convert.ToDateTime(vs1[3]), Convert.ToDateTime(vs1[4]), Convert.ToInt32(vs1[5]), vs1[6], vs1[7], null);
                }
                else {
                    temp = new(Convert.ToInt32(vs1[0]), Convert.ToInt32(vs1[1]), Convert.ToInt32(vs1[2]), Convert.ToDateTime(vs1[3]), Convert.ToDateTime(vs1[4]), Convert.ToInt32(vs1[5]), vs1[6], null, null);
                }

                _BoundProperties.Leases.Add(temp);
            }
        }

        private void GetApartments() {
            string Apartments = GetValueFromDBUsing(AllApartmnet, new string[] { "aNum", "numBeds", "numBaths", "gateCode", "isAvailable", "buildingNum" });
            string[] vs = Apartments.Split("\n");

            for (int i = 0; i < vs.Length - 1; i++) {
                string[] vs1 = vs[i].Split(',');

                Apartment temp = new(Convert.ToInt32(vs1[0]), Convert.ToInt32(vs1[1]), Convert.ToInt32(vs1[2]), vs1[3], Convert.ToBoolean(vs1[4]), Convert.ToInt32(vs1[5]));
                _BoundProperties.Apartments.Add(temp);
            }
        }

        private void GetBuildings() {
            string Buildings = GetValueFromDBUsing(AllBuildings, new string[] { "bNum", "petsAllowed" });
            string[] vs = Buildings.Split("\n");

            for (int i = 0; i < vs.Length - 1; i++) {
                string[] vs1 = vs[i].Split(',');

                Building temp = new(Convert.ToInt32(vs1[0]), Convert.ToBoolean(vs1[1]));
                _BoundProperties.Buildings.Add(temp);
            }
        }

        private string GetValueFromDBUsing(string strQuery, string[] cols) {
            try {
                if (string.IsNullOrEmpty(strQuery) == true) {
                    return string.Empty;
                }

                using (var con = new MySqlConnection(Connect)) {
                    Debug.WriteLine("connected!");
                    MySqlCommand cmd = new(strQuery, con);
                    con.Open();
                    using (MySqlDataReader reader = cmd.ExecuteReader()) {
                        string ret = "";

                        while (reader.Read()) {
                            foreach (string col in cols) {
                                ret += string.Format("{0}", reader[col]) + ",";
                            }

                            ret = ret.Trim(',');
                            ret += '\n';
                        }
                        return ret.Trim(',');
                    }
                }
            }
            catch (MySqlException ex) {
                return ex.Message;
            }
            catch (Exception ex) {
                return ex.Message;
            }
            finally {

            }
        }

        private string OtherSQLCommands(string strQuery) {
            try {
                if (string.IsNullOrEmpty(strQuery) == true) {
                    return string.Empty;
                }

                using (var con = new MySqlConnection(Connect)) {
                    Debug.WriteLine("connected!");
                    MySqlCommand cmd = new(strQuery, con);
                    con.Open();

                    return cmd.ExecuteScalar().ToString();
                }
            }
            catch (MySqlException ex) {
                return ex.Message;
            }
            catch (Exception ex) {
                return ex.Message;
            }
            finally {

            }
        }

        private void DataGrid_IsEnabledChanged(object sender, DependencyPropertyChangedEventArgs e) {

        }
    }
}
