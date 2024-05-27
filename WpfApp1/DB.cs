using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data;
using MySql;
using MySql.Data.MySqlClient;
using WpfApp1.classes;
using System.Data.SqlClient;
using System.Windows.Controls;
using System.Configuration;


namespace WpfApp1
{
    public class DB
    {
        private static string connectionString = "server=localhost;user=root;password=z01061159985;database=db;";

        public static void InitializeDatabase()
        {
            // This method is not needed for MySQL since the database and table are created manually.
        }

        public static void SaveUser(string username, string password)
        {
            using (var connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                string insertQuery = "INSERT INTO Users (Username, Password) VALUES (@Username, @Password)";
                using (var command = new MySqlCommand(insertQuery, connection))
                {
                    command.Parameters.AddWithValue("@Username", username);
                    command.Parameters.AddWithValue("@Password", password);
                    command.ExecuteNonQuery();
                }
            }
        }

        public static (string username, string password) GetUser()
        {
            using (var connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                string selectQuery = "SELECT Username, Password FROM Users LIMIT 1";
                using (var command = new MySqlCommand(selectQuery, connection))
                {
                    using (var reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return (reader["Username"].ToString(), reader["Password"].ToString());
                        }
                    }
                }
            }
            return (null, null);
        }

        public static void UpdateUser(string newUsername, string newPassword)
        {
            using (var connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                string updateQuery = "UPDATE Users SET Username = @NewUsername, Password = @NewPassword LIMIT 1";
                using (var command = new MySqlCommand(updateQuery, connection))
                {
                    command.Parameters.AddWithValue("@NewUsername", newUsername);
                    command.Parameters.AddWithValue("@NewPassword", newPassword);
                    command.ExecuteNonQuery();
                }
            }
        }
    

        public void InsertDoctor(Doctor doctor)
        {
            string insertSql = @"INSERT INTO doctor 
                                 (doctorName, nationalID, DOB, age, gender, address, 
                                  phoneNumber, email, docPassword, specialization, jointDate) 
                                 VALUES 
                                 (@DoctorName, @NationalID, @DOB, @Age, @Gender, @Address, 
                                  @PhoneNumber, @Email, @DocPassword, @Specialization, @JointDate)";

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();

                using (MySqlCommand command = new MySqlCommand(insertSql, connection))
                {
                    command.Parameters.AddWithValue("@DoctorName", doctor.DoctorName);
                    command.Parameters.AddWithValue("@NationalID", doctor.NationalID);
                    command.Parameters.AddWithValue("@DOB", doctor.DOB);
                    command.Parameters.AddWithValue("@Age", doctor.Age);
                    command.Parameters.AddWithValue("@Gender", doctor.Gender);
                    command.Parameters.AddWithValue("@Address", doctor.Address);
                    command.Parameters.AddWithValue("@PhoneNumber", doctor.PhoneNumber);
                    command.Parameters.AddWithValue("@Email", doctor.Email);
                    command.Parameters.AddWithValue("@DocPassword", doctor.DocPassword);
                    command.Parameters.AddWithValue("@Specialization", doctor.Specialization);
                    command.Parameters.AddWithValue("@JointDate", doctor.JointDate);
                    command.ExecuteNonQuery();
                }
            }
        }
        public void PopulateDoctorDropdown(ComboBox cb)
        {
            cb.Items.Clear(); // Clear existing items

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();

                string query = "SELECT doctorID, doctorName FROM doctor";
                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            int doctorID = reader.GetInt32("doctorID");
                            string doctorName = reader.GetString("doctorName");

                            // Convert doctorID to string and concatenate with name
                            string doctorInfo = $"{doctorName} - {doctorID.ToString()}";

                            // Add doctorInfo as an item to the ComboBox
                            cb.Items.Add(doctorInfo);
                        }
                    }
                }
            }
        }

        public static Doctor GetDoctorById(int doctorId)
        {
            Doctor resultDoctor = null;

            using (MySqlConnection connection = new MySqlConnection(connectionString))
            {
                connection.Open();

                string query = "SELECT * FROM doctor WHERE doctorID = @DoctorId";

                using (MySqlCommand command = new MySqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@DoctorId", doctorId);

                    using (MySqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            resultDoctor = new Doctor
                            {
                                DoctorID = Convert.ToInt32(reader["doctorID"]),
                                DoctorName = reader["doctorName"].ToString(),
                                NationalID = reader["nationalID"].ToString(),
                                DOB = reader["DOB"] is DBNull ? null : (DateTime?)reader["DOB"],
                                Age = Convert.ToInt32(reader["age"]),
                                Gender = reader["gender"].ToString(),
                                Address = reader["address"].ToString(),
                                PhoneNumber = reader["phoneNumber"].ToString(),
                                Email = reader["email"].ToString(),
                                DocPassword = reader["docPassword"].ToString(),
                                Specialization = reader["specialization"].ToString(),
                                JointDate = reader["jointDate"] is DBNull ? null : (DateTime?)reader["jointDate"]
                            };
                        }
                    }
                }
            }

            return resultDoctor;
        }

    }
}
