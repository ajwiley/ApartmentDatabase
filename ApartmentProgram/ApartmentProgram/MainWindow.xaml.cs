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
        string Connect = "server=localhost;userid=root;database=apartments;password=aronwiley10";
        string ApartmentsInBuilding = "select count(isAvailable) from apartment where buildingNum = "; // Add inputted number
        string BedBath = "select numBeds, numBaths from apartment where aNum = "; // Add inputted number
        string isAptleased = "select isAvailable from apartment where aNum = ";
        string WhoIsRentingApt = "select headOfHouse from Lease where aptNum = ";
        string RentValue = "select monthlyRent from Lease where aNum = ";
        string TenantContact = "select phone, email from Tenant where ssn = ";
        string Vehciles = "select make,model,year,color from Vehicle where ownerID = ";
        string TypeOfService = "select cType from maintenanceco where cID = ";
        string CompanyWorkedOn = "select aptID from services where companyID = ";
        string CompanyWorkedOnWhen = "select date from services where companyID = ";
        string AllApartmnet = "select * from apartment";


        public MainWindow() {
            InitializeComponent();
            DataContext = _BoundProperties;

            //Debug.WriteLine(GetValueFromDBUsing("select * from apartment"));
            GetApartments();
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
