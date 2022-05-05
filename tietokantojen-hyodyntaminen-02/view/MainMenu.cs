using System;
using Autokauppa.model;
using System.Windows.Forms;
using Autokauppa.controller;

namespace tietokantojen_hyodyntaminen_02 {
    public partial class Form1 : Form {
        readonly DatabaseController dbController = new();
        readonly DataLoader dataLoader = new();
        readonly Logics controller = new();
        
        public Form1() {
            InitializeComponent();
        }


        // Navigate through database records

        int record = 0;

        private void NextRecord(object sender, EventArgs e) {
            record += 1;
            record = (record > dbController.CountRecords() - 1) ? 0 : record;
            dbController.LoadCars(dataGridView1, record);
        }

        private void PreviousRecord(object sender, EventArgs e) {
            record -= 1;
            record = (record < 0) ? dbController.CountRecords() - 1 : record;
            dbController.LoadCars(dataGridView1, record);
        }


        // loads data from the DB to store in the combo boxes

        private void LoadGas(object sender, EventArgs e) {              
            controller.LoadProperty(polttoaineComboBox, dataLoader.LoadProperty(controller.GetSqlExpression()["polttoaine"], new Gas()));
        }

        private void LoadColours(object sender, EventArgs e) {
            controller.LoadProperty(variComboBox, dataLoader.LoadProperty(controller.GetSqlExpression()["varit"], new Colour()));
        }

        private void LoadCarBrands(object sender, EventArgs e) {
            controller.LoadProperty(merkkiComboBox, dataLoader.LoadProperty(controller.GetSqlExpression()["autonmerkki"], new Brand()));
        }

        private void LoadCarModels(object sender, EventArgs e) {
            malliComboBox.Items.Clear();
            if (merkkiComboBox.SelectedItem != null) {
                controller.LoadProperty(malliComboBox, dataLoader.LoadProperty(controller.GetSqlExpression(merkkiComboBox.SelectedItem.ToString())["autonmallit"], new Model()));
            }
        }

        private void LoadCars(object sender, EventArgs e) {         // gets rows from the DB one by one and loads them into the data grid view element
            dbController.LoadCars(dataGridView1, record);
            Console.WriteLine($"Current record: {record}, Amount of records: {dbController.CountRecords()}.");      // prints basic information about each record
        }

        

        private void InsertCar(object sender, EventArgs e) {        // inserts new row into the DB // checks the input format
            Validation();
            dbController.InsertCar(controller.AssignProperties(new Car(), Controls));
        }


        private void DeleteCar(object sender, EventArgs e) {        // deletes a row from the DB
            dbController.DeleteCar(dataGridView1);
            Console.WriteLine("Successfully deleted 1 row.");
        }


        private void TestConnection(object sender, EventArgs e) {               // tests connection   
            MessageBox.Show(controller.TestConnection(), "Connection state");
        }


        private bool Validation() {                     // checks user's input
            foreach (Control control in Controls) {
                switch (control) {
                    case TextBox:
                        if (control is TextBox & !control.Name.Contains("mittarilukema") & control.Text != null) {
                            control.Text = control.Text.Replace('.', ',');
                            control.Text = string.Format("{0:0.0}", Convert.ToDecimal(control.Text));
                        }
                        break;
                    case ComboBox:
                        (control as ComboBox).SelectedIndex = (control as ComboBox).Items.Contains(control.Text) ? (control as ComboBox).SelectedIndex : 1;
                        break;
                }
            }
            return true;
        }

        private void ClearFields(object sender, EventArgs e) {      // empties all components' fields for a new record
            foreach (Control control in Controls) {
                switch (control) {
                    case TextBox:
                        (control as TextBox).Clear();
                        break;
                    case ComboBox:
                        (control as ComboBox).SelectedIndex = -1;
                        break;
                    case DateTimePicker:
                        (control as DateTimePicker).Value = DateTime.Today;
                        break;
                }
            }
        }


        private void AuthorInfo(object sender, EventArgs e) {
            MessageBox.Show("Tietokantojen hyödyntäminen\n (C) 2022 Petri Raatikainen \n Vera Ermolaeva", "Tietoja tekijästä");
        }


        private void Exit(object sender, EventArgs e) {         // exits the program
            Application.Exit();
        }
    }
}
