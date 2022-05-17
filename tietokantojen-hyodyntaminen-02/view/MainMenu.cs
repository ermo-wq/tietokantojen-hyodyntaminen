using System;
using Autokauppa.Model;
using System.Windows.Forms;
using Autokauppa.Controller;
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
            record = (record > Controller.CountAllRecords() - 1) ? 0 : record;
            dataGridView1.DataSource = Controller.ShowAllRecords(record);
            dataGridView1.DataMember = "Auto";
        }

        private void PreviousRecord(object sender, EventArgs e) {
            record -= 1;
            record = (record < 0) ? Controller.CountAllRecords() - 1 : record;
            dataGridView1.DataSource = Controller.ShowAllRecords(record);
            dataGridView1.DataMember = "Auto";
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
            dataGridView1.DataSource = Controller.ShowAllRecords(record);
            dataGridView1.DataMember = "Auto";
            Console.WriteLine($"Current record: {record}, Amount of records: {Controller.CountAllRecords()}.");
        }    
        

        // DB related methods

        private void InsertRecord(object sender, EventArgs e) {
            if (InputValidation()) {
                Controller.InsertNewRecord(GetComboBoxData(), GetDataForRecord());
            }
            Console.WriteLine("Successfully inserted 1 row");
        }

        private void DeleteRecord(object sender, EventArgs e) {
            Controller.DeleteRecord(int.Parse(dataGridView1.SelectedRows[0].Cells[0].Value.ToString()));
            Console.WriteLine("Successfully deleted 1 row.");
        }

        private void TestConnection(object sender, EventArgs e) {  
            MessageBox.Show(Controller.TestConnection(), "Connection state");
        }
        

        // get data from controls

        public List<string> GetComboBoxData() {
            List<string> comboBoxData = new();

            foreach (Control control in Controls) {
                switch (control) {
                    case ComboBox:
                        comboBoxData.Add((control as ComboBox).SelectedItem.ToString());
                        break;
                }
            }

            return comboBoxData;
        }

        public List<string> GetDataForRecord() {
            List<string> dataForRecord = new();

            foreach (Control control in Controls) {
                switch (control) {
                    case TextBox:
                        dataForRecord.Add((control as TextBox).Text);
                        break;
                    case DateTimePicker:
                        dataForRecord.Add((control as DateTimePicker).Value.ToShortDateString());
                        break;
                }
            }

            return dataForRecord;
        }


        // user input validation

        private bool InputValidation() {
            foreach (Control control in Controls) {
                switch (control) {
                    case TextBox:
                        if (!ValidateTextBox(control)) return false;
                        break;
                    case ComboBox:
                        if (!ValidateComboBox(control)) return false;
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


        // form controls

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
