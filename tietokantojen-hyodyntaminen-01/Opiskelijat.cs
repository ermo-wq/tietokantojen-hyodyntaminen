using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace tietokantojen_hyodyntaminen_01 {
    public partial class Opiskelijat : Form {
        public Opiskelijat() {
            InitializeComponent();
            ReadDataToComboBox();
        }

        private void DeleteData(object sender, EventArgs e) {
            string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Opiskelijaryhma;Integrated Security=True;";
            
            string sqlExpression = "DELETE FROM Opiskelijaryhma WHERE opiskelija IN " +         //delete student from Opiskelijaryhma database
                "(SELECT opiskelija FROM Opiskelijaryhma JOIN Opiskelijat ON Opiskelijaryhma.opiskelija=Opiskelijat.id WHERE etunimi=@etunimi);";
            
            sqlExpression += "DELETE FROM Opiskelijat WHERE etunimi=@etunimi;";         //delete student from Opiskelijat database

            using SqlConnection connection = new SqlConnection(connectionString);
            SqlCommand command = new SqlCommand(sqlExpression) { Connection = connection };
            connection.Open();
            command.Parameters.AddWithValue("@etunimi", dataGridView1.CurrentCell.Value);
            command.ExecuteNonQuery();
        }

        private void InsertData(object sender, EventArgs e) {
            string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Opiskelijaryhma;Integrated Security=True;";
            
            string sqlExpression = $"INSERT INTO Opiskelijat (etunimi, sukunimi) VALUES (@etunimi, @sukunimi);";      //insert student's name and surname into Opiskeliat table
            
            sqlExpression += $"UPDATE Opiskelijat SET ryhma = (SELECT id FROM Ryhmat WHERE ryhman_nimi=@ryhman_nimi) " +        //insert group's id into Opiskelijat table
                $"WHERE etunimi=@etunimi AND sukunimi=@sukunimi;";
                      
            sqlExpression += "INSERT INTO Opiskelijaryhma (opiskelija, ryhma_id) " +                //insert student's and group's ids into Opiskelijaryhma table  
                "SELECT Opiskelijat.id, Ryhmat.id FROM Opiskelijat LEFT JOIN Ryhmat ON Opiskelijat.ryhma = Ryhmat.id " +
                "WHERE Opiskelijat.etunimi=@etunimi AND Ryhmat.id = (SELECT id FROM Ryhmat WHERE ryhman_nimi=@sukunimi);";

            using SqlConnection connection = new SqlConnection(connectionString);
            SqlCommand command = new SqlCommand(sqlExpression) { Connection = connection };
            connection.Open();            
            command.Parameters.AddWithValue("@etunimi", etunimiTextBox.Text);
            command.Parameters.AddWithValue("@sukunimi", sukunimiTextBox.Text);
            command.Parameters.AddWithValue("@ryhman_nimi", comboBox1.SelectedItem);
            command.ExecuteNonQuery();
        }

        private void ReadData(object sender, EventArgs e) {
            string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Opiskelijaryhma;Integrated Security=True;";
            using SqlConnection connection = new SqlConnection(connectionString);
            SqlDataAdapter adapter = new SqlDataAdapter("SELECT etunimi FROM Opiskelijat ORDER BY sukunimi, etunimi", connection);
            DataSet dataSet = new DataSet();
            connection.Open();
            adapter.Fill(dataSet, "Opiskelijat");
            connection.Close();
            dataGridView1.DataSource = dataSet;
            dataGridView1.DataMember = "Opiskelijat";        
        }

        private void ReadDataToComboBox() {
            string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Opiskelijaryhma;Integrated Security=True;";
            using SqlConnection connection = new SqlConnection(connectionString);
            string Sql = "SELECT ryhman_nimi FROM Ryhmat ORDER BY ryhman_nimi";
            connection.Open();
            SqlCommand cmd = new SqlCommand(Sql, connection);
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read()) {
                comboBox1.Items.Add(reader[0]);
            }
        }

        private void Exit(object sender, EventArgs e) {
            Application.Exit();
        }
    }
}
