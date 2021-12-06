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


        public MainWindow() {
            InitializeComponent();
            DataContext = _BoundProperties;

            //Debug.WriteLine(GetValueFromDBUsing("select * from apartment"));
        }
        private void Button_Click(object sender, RoutedEventArgs e) {
            _BoundProperties.Data = GetValueFromDBUsing(TenantContact + _BoundProperties.Command, new string[] { "phone", "email" });
            //_BoundProperties.Data = OtherSQLCommands(WhoIsRentingApt + _BoundProperties.Command);
        }

        private string GetValueFromDBUsing(string strQuery, string[] rows) {
            try {
                if (string.IsNullOrEmpty(strQuery) == true) {
                    return string.Empty;
                }

                using (var con = new MySqlConnection(Connect)) {
                    Debug.WriteLine("connected!");
                    MySqlCommand cmd = new(strQuery, con);
                    con.Open();
                    using (MySqlDataReader reader = cmd.ExecuteReader()) {
                        if (reader.Read()) {
                            string ret = "";

                            foreach (string row in rows) {
                                ret += string.Format("{0}: {1}", row, reader[row]) + "\n";
                            }

                            return ret.Trim();
                        }
                    }

                    return string.Empty;
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
    }    
}
