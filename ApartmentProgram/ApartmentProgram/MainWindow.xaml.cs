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
        string Connect = "server=localhost;userid=root;database=apartments;password=aronwiley10";

        public MainWindow() {
            InitializeComponent();


            Debug.WriteLine(GetValueFromDBUsing("show tables"));
        }

        private string GetValueFromDBUsing(string strQuery) {
            string? strData = "";

            try {
                if (string.IsNullOrEmpty(strQuery) == true)
                    return string.Empty;

                using (var mysqlconnection = new MySqlConnection(Connect)) {
                    mysqlconnection.Open();
                    Debug.WriteLine("connected!");
                    using (MySqlCommand cmd = mysqlconnection.CreateCommand()) {
                        cmd.CommandType = CommandType.Text;
                        cmd.CommandTimeout = 300;
                        cmd.CommandText = strQuery;

                        object? objValue = cmd.ExecuteScalar();

                        if (objValue == null) {
                            cmd.Dispose();
                            return string.Empty;
                        }
                        else {
                            strData = cmd.ExecuteScalar() as string;
                            cmd.Dispose();
                        }

                        mysqlconnection.Close();

                        if (strData == null) {
                            return string.Empty;
                        }
                        else {
                            return strData;
                        }
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
    }    
}
