using System;
using Autokauppa.model;
using System.Windows.Forms;
using Autokauppa.controller;
using System.Collections.Generic;

namespace tietokantojen_hyodyntaminen_02 {
    public partial class MainMenu : Form {        
        public MainMenu() {
            InitializeComponent();
        }

        // navigate through database records

        int record = 0;

        private void NextRecord(object sender, EventArgs e) {
            record += 1;
            record = (record > DatabaseController.CountAllRecords() - 1) ? 0 : record;
            DatabaseController.LoadCars(dataGridView1, record);
        }

        private void PreviousRecord(object sender, EventArgs e) {
            record -= 1;
            record = (record < 0) ? DatabaseController.CountAllRecords() - 1 : record;
            DatabaseController.LoadCars(dataGridView1, record);
        }

        private void AddElementsToComboBoxes(ComboBox comboBox, List<Property> objects) {
            if (comboBox.Items.Count == 0) {
                foreach (Property property in objects) {
                    comboBox.Items.Add(property.Nimi);
                }
            }
        }


        // load data from the DB to store in the combo boxes

        private void LoadGas(object sender, EventArgs e) {              
            AddElementsToComboBoxes(polttoaineComboBox, Controller.GetGas());
        }

        private void LoadColours(object sender, EventArgs e) {
            AddElementsToComboBoxes(variComboBox, Controller.GetColours());
        }

        private void LoadCarBrands(object sender, EventArgs e) {
            AddElementsToComboBoxes(merkkiComboBox, Controller.GetBrands());
        }

        private void LoadCarModels(object sender, EventArgs e) {
            malliComboBox.Items.Clear();
            if (merkkiComboBox.SelectedItem != null) {
                AddElementsToComboBoxes(malliComboBox, Controller.GetModels(merkkiComboBox.Text));
            }
        }

        private void ShowRecords(object sender, EventArgs e) {
            DatabaseController.LoadCars(dataGridView1, record);
            Console.WriteLine($"Current record: {record}, Amount of records: {DatabaseController.CountAllRecords()}.");
        }    
        
        // DB related methods

        private void InsertRecord(object sender, EventArgs e) {
            if(InputValidation()) DatabaseController.InsertRecord(Controller.AssignProperties(new Car(), Controls));
        }

        private void DeleteRecord(object sender, EventArgs e) {
            DatabaseController.DeleteRecord(int.Parse(dataGridView1.SelectedRows[0].Cells[0].Value.ToString()));
            Console.WriteLine("Successfully deleted 1 row.");
        }

        private void TestConnection(object sender, EventArgs e) {  
            MessageBox.Show(DatabaseController.TestConnection(), "Connection state");
        }


        // user input validation

        private bool InputValidation() {
            foreach (Control control in Controls) {
                switch (control) {
                    case TextBox:
                        if(!ValidateTextBox(control)) return false;
                        break;
                    case ComboBox:
                        if(!ValidateComboBox(control)) return false;
                        break;
                }
            }
            return true;
        }

        private bool ValidateTextBox(Control control) {
            try {
                if (control is TextBox & !control.Name.Contains("mittarilukema") & control.Text != null) {
                    control.Text = control.Text.Replace('.', ',');
                    control.Text = string.Format("{0:0.0}", Convert.ToDecimal(control.Text));
                }
            }
            catch {
                MessageBox.Show("Invalid text box input! Please, make sure your input is in correct format.", "Message");
                return false;
            }
            return true;
        }

        private bool ValidateComboBox(Control control) {
            try {
                (control as ComboBox).SelectedIndex = (control as ComboBox).Items.Contains(control.Text) ? (control as ComboBox).SelectedIndex : 1;
            }
            catch {
                MessageBox.Show("Invalid combo box input! Please, make sure your input is in correct format.", "Message");
                return false;
            }
            return true;
        }

        // other

        private void ClearAllFields(object sender, EventArgs e) {
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


        private void Exit(object sender, EventArgs e) {
            Application.Exit();
        }
    }
}
