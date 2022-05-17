using System;
using Autokauppa.Model;
using System.Windows.Forms;
using System.Collections.Generic;

namespace Autokauppa.Controller {
    public static class Controller {
        public static List<Property> GetGas() {
            return ViewController.GetGasRecords();
        }

        public static List<Property> GetColours() {
            return ViewController.GetColourRecords();
        }

        public static List<Property> GetBrands() {
            return ViewController.GetBrandRecords();
        }

        public static List<Property> GetModels(string brand) {
            return ViewController.GetModelRecords(brand);
        }

        public static int CountAllRecords() {
            return DatabaseController.CountAllRecords();
        }

        public static void InsertNewRecord(List<string> comboBoxData, List<string> dataForRecord) {
            DatabaseController.InsertRecord(AssignProperties(comboBoxData, dataForRecord));
        }

        public static void DeleteRecord(int id) {
            DatabaseController.DeleteRecord(id);
        }

        public static string TestConnection() {
            return DatabaseController.TestConnection();
        }

        public static void ShowAllRecords(DataGridView dataGrid, int record) {
            ViewController.GetAllRecords(dataGrid, record);
        }


        public static Car AssignProperties(List<string> comboBoxData, List<string> dataForRecord) {
            int i = 0;
            Car car = new();
            List<string> dataForNewRecord = GetDataForNewRecord(comboBoxData, dataForRecord);

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
            }

            return car;
        }

        public static List<string> GetDataForNewRecord(List<string> comboBoxData, List<string> dataForRecord) {
            dataForRecord = ViewController.AppendIdsFromComboBoxes(comboBoxData, dataForRecord);
            return dataForRecord;
        }
    }
}
