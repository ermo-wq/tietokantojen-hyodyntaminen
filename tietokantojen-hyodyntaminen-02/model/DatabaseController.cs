using System.Data;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Collections.Generic;

namespace Autokauppa.Model {
    public static class ViewController {
        private static readonly string connectionString = DatabaseController.ConnectionString;

        public static List<Property> GetBrandRecords() {
            Property element = new Brand();
            List<Property> properties = new();
            string sqlExpression = "SELECT merkki FROM autonmerkki ORDER BY merkki";
            using SqlConnection connection = new(connectionString);
            connection.Open();
            SqlCommand command = new(sqlExpression, connection);
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read()) {
                element = element.CreateNew();
                element.Nimi = (string)reader[0];
                properties.Add(element);
            }
            return properties;
        }

        public static List<Property> GetModelRecords(string brand) {
            Property element = new Model();
            List<Property> properties = new();
            string sqlExpression = "SELECT auton_mallin_nimi FROM autonmallit WHERE autonmerkkiid=(SELECT id FROM AutonMerkki WHERE merkki=@merkki) ORDER BY auton_mallin_nimi";
            using SqlConnection connection = new(connectionString);
            connection.Open();
            SqlCommand command = new(sqlExpression, connection);
            command.Parameters.AddWithValue("@merkki", brand);
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read()) {
                element = element.CreateNew();
                element.Nimi = (string)reader[0];
                properties.Add(element);
            }
            return properties;
        }

        public static List<Property> GetColourRecords() {
            Property element = new Colour();
            List<Property> properties = new();
            string sqlExpression = "SELECT varin_nimi FROM varit ORDER BY varin_nimi";
            using SqlConnection connection = new(connectionString);
            connection.Open();
            SqlCommand command = new(sqlExpression, connection);
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read()) {
                element = element.CreateNew();
                element.Nimi = (string)reader[0];
                properties.Add(element);
            }
            return properties;
        }

        public static List<Property> GetGasRecords() {
            Property element = new Gas();
            List<Property> properties = new();
            string sqlExpression = "SELECT polttoaineen_nimi FROM polttoaine ORDER BY polttoaineen_nimi";
            using SqlConnection connection = new(connectionString);
            connection.Open();
            SqlCommand command = new(sqlExpression, connection);
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read()) {
                element = element.CreateNew();
                element.Nimi = (string)reader[0];
                properties.Add(element);
            }
            return properties;
        }
        
        public static void GetAllRecords(DataGridView dataGrid, int record) {
            using SqlConnection connection = new(connectionString);
            SqlDataAdapter adapter = new($"SELECT * FROM Auto ORDER BY hinta, autonmerkkiid OFFSET {record} ROWS FETCH NEXT 1 ROWS ONLY", connection);
            DataSet dataSet = new();
            connection.Open();
            adapter.Fill(dataSet, "Auto");
            dataGrid.DataSource = dataSet;
            dataGrid.DataMember = "Auto";
        }        

        public static List<string> AppendIdsFromComboBoxes(List<string> comboBoxData, List<string> dataForRecord) {
            comboBoxData.Reverse();
            List<string> sqlExpressions = new() {
                $"SELECT id FROM AutonMerkki WHERE merkki='{comboBoxData[0]}'",
                $"SELECT id FROM AutonMallit WHERE auton_mallin_nimi='{comboBoxData[1]}'",
                $"SELECT id FROM Varit WHERE varin_nimi='{comboBoxData[2]}'",
                $"SELECT id FROM Polttoaine WHERE polttoaineen_nimi='{comboBoxData[3]}'"
            };

            dataForRecord.Reverse();
            for (int i = 0; i < sqlExpressions.Count; i++) {
                dataForRecord.Add(GetId(sqlExpressions[i]));
            }

            return dataForRecord;
        }

        public static string GetId(string sqlExpression) {
            using SqlConnection connection = new(connectionString);            
            connection.Open();
            SqlCommand command = new(sqlExpression, connection);
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read()) {
                return reader[0].ToString();
            }
            return "not found";
        }
    }

    public static class DatabaseController {
        public static readonly string ConnectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Autokauppa;Integrated Security=True;";

        public static void InsertRecord(Car car) {
            using SqlConnection connection = new(ConnectionString);
            SqlCommand command = new("INSERT INTO Auto (mittarilukema) VALUES(@mittarilukema); SET @id=SCOPE_IDENTITY()", connection);
            connection.Open();
            SqlParameter idParam = new() {
                ParameterName = "@id",
                SqlDbType = SqlDbType.Int,
                Direction = ParameterDirection.Output
            };
            command.Parameters.Add(idParam);
            command.Parameters.Add("@mittarilukema", SqlDbType.Int).Value = car.Mittarilukema;
            command.ExecuteNonQuery();
            int id = int.Parse(idParam.Value.ToString());
            car.SetId(id);                  // assign id property to car object 
            UpdateRecord(car, id);              // update the row after we know the id
        }

        private static void UpdateRecord(Car carRecord, int id) {
            System.Reflection.PropertyInfo[] properties = carRecord.GetType().GetProperties();
            using SqlConnection connection = new(ConnectionString);
            connection.Open();
            foreach (System.Reflection.PropertyInfo property in properties) {    
                SqlCommand command = new($"UPDATE Auto SET {property.Name} = @{property.Name} WHERE id=@id", connection);
                command.Parameters.Add("@id", SqlDbType.Int).Value = id;
                command.Parameters.AddWithValue($"@{property.Name}", property.GetValue(carRecord));
                command.ExecuteNonQuery();
            }
        }

        public static void DeleteRecord(int id) {
            string sqlexpression = "DELETE FROM Auto WHERE id=@id";
            using SqlConnection connection = new(ConnectionString);
            SqlCommand command = new(sqlexpression, connection);
            connection.Open();
            command.Parameters.Add("@id", SqlDbType.Int).Value = id;
            command.ExecuteNonQuery();
        }

        public static int CountAllRecords() {
            int allRecords = 0;
            using SqlConnection connection = new(ConnectionString);
            string sqlExpression = "SELECT COUNT(*) FROM Auto";
            connection.Open();
            SqlCommand command = new(sqlExpression, connection);
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read()) {
                allRecords = int.Parse(reader[0].ToString());
            }
            return allRecords;
        }

        public static string TestConnection() {
            SqlConnection connection = new(ConnectionString);
            connection.Open();
            string connectionStatus = (connection != null && connection.State == ConnectionState.Open) ? "Connection is lit!" : "You're done.";
            connection.Close();
            return connectionStatus;
        }
    }
}