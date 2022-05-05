using System.Data;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Collections.Generic;

namespace Autokauppa.model {
    public class DataLoader {
        readonly static string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Autokauppa;Integrated Security=True;";

        public List<Property> LoadProperty(string sqlExpression, Property prop) {           // returns the collection of objects of each property
            List<Property> properties = new();                                              // each object corresponds to each row in the DB
            using SqlConnection connection = new(connectionString);
            connection.Open();
            SqlCommand command = new(sqlExpression, connection);
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read()) {
                prop = prop.PropertyCreator();
                prop.Nimi = (string)reader[0];
                properties.Add(prop);
            }
            return properties;
        }
    }

    public class DatabaseController {
        readonly static string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Autokauppa;Integrated Security=True;";

        public DatabaseController() { }
        

        public int CountRecords() {                // Count the amount of all records in DB
            int allRecords = 0;
            using SqlConnection connection = new(connectionString);
            string sqlExpression = "SELECT COUNT(*) FROM Auto";
            connection.Open();
            SqlCommand command = new(sqlExpression, connection);
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read()) {
                allRecords = int.Parse(reader[0].ToString());
            }
            return allRecords;
        }

        

        public void LoadCars(DataGridView dataGrid, int record) {               // Get rows from the DB one by one
            using SqlConnection connection = new(connectionString);
            SqlDataAdapter adapter = new($"SELECT * FROM Auto ORDER BY hinta, autonmerkkiid OFFSET {record} ROWS FETCH NEXT 1 ROWS ONLY", connection);
            DataSet dataSet = new();
            connection.Open();
            adapter.Fill(dataSet, "Auto");
            dataGrid.DataSource = dataSet;
            dataGrid.DataMember = "Auto";
        }
        

        public string GetId(string sqlExpression) {                 // Convert text from comno boxes to ids
            using SqlConnection connection = new(connectionString);            
            connection.Open();
            SqlCommand command = new(sqlExpression, connection);
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read()) {
                return reader[0].ToString();
            }
            return "not found";
        }
       

        //Insert data into DB

        public void InsertCar(Car car) {
            using SqlConnection connection = new(connectionString);
            SqlCommand command = new($"INSERT INTO Auto (mittarilukema) VALUES(@mittarilukema); SET @id=SCOPE_IDENTITY()", connection);
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
            car.SetId(id);          // assign id property to car object 
            UpdateCar(car, id);         // update the row after we know the id
        }

        private void UpdateCar(Car car, int id) {
            System.Reflection.PropertyInfo[] properties = car.GetType().GetProperties();
            using SqlConnection connection = new(connectionString);
            connection.Open();
            foreach (System.Reflection.PropertyInfo property in properties) {       // add all other car's properties' values into DB one by one             
                SqlCommand command2 = new($"UPDATE Auto SET {property.Name} = @{property.Name} WHERE id=@id", connection);
                command2.Parameters.Add("@id", SqlDbType.Int).Value = id;
                command2.Parameters.AddWithValue($"@{property.Name}", property.GetValue(car));
                command2.ExecuteNonQuery();
            }
        }



        //Delete data from DB

        public void DeleteCar(DataGridView dataGrid) {
            string sqlexpression = "DELETE FROM Auto WHERE id=@id";
            using SqlConnection connection = new(connectionString);
            SqlCommand command = new(sqlexpression, connection);
            connection.Open();
            command.Parameters.Add("@id", SqlDbType.Int).Value = int.Parse(dataGrid.SelectedRows[0].Cells[0].Value.ToString());
            command.ExecuteNonQuery();
        }
    }
}