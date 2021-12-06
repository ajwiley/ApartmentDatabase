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

        public MainWindow() {
            InitializeComponent();
            DataContext = _BoundProperties;

            //Debug.WriteLine(GetValueFromDBUsing("select * from apartment"));
        }

        private string GetValueFromDBUsing(string strQuery) {
            string? strData = "";

            try {
                if (string.IsNullOrEmpty(strQuery) == true) {
                    return string.Empty;
                }

                using (var con = new MySqlConnection(Connect)) {
                    Debug.WriteLine("connected!");
                    MySqlCommand cmd = new MySqlCommand(strQuery, con);
                    con.Open();
                    return cmd.ExecuteScalar().ToString();

                    //using (MySqlCommand cmd = con.CreateCommand()) {
                    //    cmd.CommandType = CommandType.Text;
                    //    cmd.CommandTimeout = 300;
                    //    cmd.CommandText = strQuery;

                    //    object? objValue = cmd.ExecuteScalar();

                    //    if (objValue == null) {
                    //        cmd.Dispose();
                    //        return string.Empty;
                    //    }
                    //    else {
                    //        cmd.CommandType = CommandType.Text;
                    //        cmd.CommandTimeout = 300;
                    //        cmd.CommandText = strQuery;
                    //        strData = cmd.ExecuteScalar() as string;
                    //        cmd.Dispose();
                    //    }

                    //    con.Close();

                    //    if (strData == null) {
                    //        return string.Empty;
                    //    }
                    //    else {
                    //        return strData;
                    //    }
                    //}
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

        private void Button_Click(object sender, RoutedEventArgs e) {
            _BoundProperties.Data = GetValueFromDBUsing("select " + _BoundProperties.ApartmentRows[_BoundProperties.ApartmentRowSelected] + " from apartment where aNum = " + _BoundProperties.Command);
        }
    }    
}
