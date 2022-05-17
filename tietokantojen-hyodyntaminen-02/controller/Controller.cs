using System.Data;
using Autokauppa.Model;
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

        public static DataSet ShowAllRecords(int record) {
            return ViewController.GetAllRecords(record);
        }

        public static Car AssignProperties(List<string> comboBoxData, List<string> dataForRecord) {
            Car car = Car.AssignProperties(GetDataForNewRecord(comboBoxData, dataForRecord));
            return car;
        }

        public static List<string> GetDataForNewRecord(List<string> comboBoxData, List<string> dataForRecord) {
            dataForRecord = ViewController.AppendIdsFromComboBoxes(comboBoxData, dataForRecord);
            return dataForRecord;
        }
    }
}
