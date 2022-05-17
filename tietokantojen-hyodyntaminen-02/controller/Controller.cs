using System;
using Autokauppa.model;
using System.Windows.Forms;
using System.Collections.Generic;

namespace Autokauppa.controller {
    public static class Controller {
        public static List<Property> GetGas() {
            return DatabaseController.GetGasRecords();
        }

        public static List<Property> GetColours() {
            return DatabaseController.GetColourRecords();
        }

        public static List<Property> GetBrands() {
            return DatabaseController.GetBrandRecords();
        }

        public static List<Property> GetModels(string brand) {
            return DatabaseController.GetColumnRecords(DatabaseController.GetSqlExpression(brand)["autonmallit"], new Model());
        }

        public static List<string> GetDataForNewRecord(Control.ControlCollection controls) {
            List<string> dataForRecord = new();
            List<string> comboBoxData = new();

            foreach (Control control in controls) {
                switch (control) {
                    case TextBox:
                        dataForRecord.Add((control as TextBox).Text);
                        break;
                    case ComboBox:
                        comboBoxData.Add((control as ComboBox).SelectedItem.ToString());
                        break;
                    case DateTimePicker:
                        dataForRecord.Add((control as DateTimePicker).Value.ToShortDateString());
                        break;
                }
            }

            dataForRecord = DatabaseController.AppendIdsFromComboBoxes(comboBoxData, dataForRecord);            
            return dataForRecord;
        }

        public static Car AssignProperties(Car car, Control.ControlCollection controls) {
            int i = 0;
            List<string> dataForNewRecord = GetDataForNewRecord(controls);
            
            System.Reflection.PropertyInfo[] properties = car.GetType().GetProperties();   
            foreach (System.Reflection.PropertyInfo property in properties) {
                switch (Type.GetTypeCode(property.PropertyType)) {
                    case TypeCode.Int32:
                        property.SetValue(car, int.Parse(dataForNewRecord[i]));
                        break;
                    case TypeCode.Decimal:
                        property.SetValue(car, decimal.Parse(dataForNewRecord[i]));
                        break;
                    case TypeCode.DateTime:
                        property.SetValue(car, DateTime.Parse(dataForNewRecord[i]));
                        break;
                }
                i++;
                Console.WriteLine("{0}={1}", property.Name, property.GetValue(car));
            }

            return car;
        }
    }
}
