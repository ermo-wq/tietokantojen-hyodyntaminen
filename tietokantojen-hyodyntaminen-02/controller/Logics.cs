using System;
using System.Data;
using Autokauppa.model;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Collections.Generic;

namespace Autokauppa.controller {
    public class Logics {
        readonly DatabaseController dbController = new();

        public Logics () { }


        public void LoadProperty(ComboBox comboBox, List<Property> objects) {       // get properties' names to store in the combo boxes
            if (comboBox.Items.Count == 0) {
                foreach (Property property in objects) {
                    comboBox.Items.Add(property.Nimi);
                }
            }
        }

        public IDictionary<string, string> GetSqlExpression(string merkki="") {             // stores sql expressions for methods that fill the combo boxes with values
            IDictionary<string, string> sqlExpressions = new Dictionary<string, string> {
                { "polttoaine", "SELECT polttoaineen_nimi FROM polttoaine ORDER BY polttoaineen_nimi" },
                { "varit", "SELECT varin_nimi FROM varit ORDER BY varin_nimi" },
                { "autonmallit", $"SELECT auton_mallin_nimi FROM autonmallit WHERE autonmerkkiid=(SELECT id FROM AutonMerkki WHERE merkki='{merkki}') ORDER BY auton_mallin_nimi" },
                { "autonmerkki", "SELECT merkki FROM autonmerkki ORDER BY merkki" }
            };
            return sqlExpressions;
        }


        private void AddComboBoxId(List<string> comboBoxInfo, List<string> userInput) {         // returns the corresponding id of the text value in combo box
            comboBoxInfo.Reverse();            
            List<string> sqlExpressions = new() {
                $"SELECT id FROM AutonMerkki WHERE merkki='{comboBoxInfo[0]}'",
                $"SELECT id FROM AutonMallit WHERE auton_mallin_nimi='{comboBoxInfo[1]}'",
                $"SELECT id FROM Varit WHERE varin_nimi='{comboBoxInfo[2]}'",
                $"SELECT id FROM Polttoaine WHERE polttoaineen_nimi='{comboBoxInfo[3]}'"
            };

            userInput.Reverse();
            for (int i = 0; i < sqlExpressions.Count; i++) {
                userInput.Add(dbController.GetId(sqlExpressions[i]));
            }
        }

        public List<string> GetEveryField(Control.ControlCollection controls) {
            List<string> userInput = new();             // stores string values from user's input
            List<string> comboBoxInfo = new();      // stores selected values from the combo boxes to later convert them into ids and after add to userInput

            foreach (Control control in controls) {
                switch (control) {
                    case TextBox:
                        userInput.Add((control as TextBox).Text);
                        break;
                    case ComboBox:
                        comboBoxInfo.Add((control as ComboBox).SelectedItem.ToString());
                        break;
                    case DateTimePicker:
                        userInput.Add((control as DateTimePicker).Value.ToShortDateString());
                        break;
                }
            }

            AddComboBoxId(comboBoxInfo, userInput);         // adds converted to ids values from comboBoxInfo list to userInput list
            return userInput;
        }

        public Car AssignProperties(Car car, Control.ControlCollection controls) {
            int i = 0;
            List<string> carInfo = GetEveryField(controls);         // stores each car's property's value
            
            System.Reflection.PropertyInfo[] properties = car.GetType().GetProperties();   
            foreach (System.Reflection.PropertyInfo property in properties) {
                switch (Type.GetTypeCode(property.PropertyType)) {          // converts string values from user's input to the types of properties
                    case TypeCode.Int32:
                        property.SetValue(car, int.Parse(carInfo[i]));
                        break;
                    case TypeCode.Decimal:
                        property.SetValue(car, decimal.Parse(carInfo[i]));
                        break;
                    case TypeCode.DateTime:
                        property.SetValue(car, DateTime.Parse(carInfo[i]));
                        break;
                }
                i++;
                Console.WriteLine("{0}={1}", property.Name, property.GetValue(car));        // prints properties and values assigned to them just for better visibility
            }

            return car;
        }
        

        public string TestConnection() {            // tests connection        
            SqlConnection connection = new(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Autokauppa;Integrated Security=True;");     // no using since i close the connection myself
            connection.Open();
            string connectionStatus = (connection != null && connection.State == ConnectionState.Open) ? "Connection is lit!" : "You're done.";
            connection.Close();
            return connectionStatus;
        }
    }
}
