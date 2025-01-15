using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class clsVegetablesToppingsDataAccess

    {
        public static int AddNewVegetablesToppings(string Name, float Price, string Image)
        {
            //this function will return the new person id if succeeded and -1 if not.
            int VegetablesID = -1;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"INSERT INTO Vegetables (Name,Price,Image)
                             VALUES (@Name, @Price,@Image);
                             SELECT SCOPE_IDENTITY();";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@Name", Name);
            command.Parameters.AddWithValue("@Price", Price);
            command.Parameters.AddWithValue("@Image", Image);


            try
            {
                connection.Open();

                object result = command.ExecuteScalar();

                if (result != null && int.TryParse(result.ToString(), out int insertedID))
                {
                    VegetablesID = insertedID;
                }
            }

            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);

            }

            finally
            {
                connection.Close();
            }

            return VegetablesID;

        }

        public static bool GetVegetablesInformationByID(int VegetableID, ref string Name, ref float Price, ref string Image)
        {
            bool isFound = false;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = "SELECT * FROM Vegetables WHERE VegetableID = @VegetableID";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@VegetableID", VegetableID);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    // The record was found
                    isFound = true;

                    Name = (string)reader["Name"];
                    Image = (string)reader["Image"];


                    Price =Convert.ToSingle (reader["Price"]);

                }
                else
                {
                    // The record was not found
                    isFound = false;
                }

                reader.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);

                isFound = false;
            }
            finally
            {
                connection.Close();
            }

            return isFound;


        }


        public static bool GetVegetablesInformationByName(string Name, ref int VegetableID, ref float Price, ref string Image)
        {
            bool isFound = false;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = "SELECT * FROM Vegetables WHERE Name = @Name";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@Name", Name);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    // The record was found
                    isFound = true;

                 VegetableID= (int)reader["VegetableID"];
                      Image = (string)reader["Image"];
                      Price = (float)reader["Price"];

                }
                else
                {
                    // The record was not found
                    isFound = false;
                }

                reader.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);

                isFound = false;
            }
            finally
            {
                connection.Close();
            }

            return isFound;


        }

        public static float GetVegetablePrice(int VegetableID)
        {
            //this function will return the new person id if succeeded and -1 if not.
            float VegetablePrice = -1;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"select Vegetables.Price from Vegetables
where VegetableID=@VegetableID";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@VegetableID", VegetableID);


            try
            {
                connection.Open();

                object result = command.ExecuteScalar();

                if (result != null && float.TryParse(result.ToString(), out float insertedID))
                {
                    VegetablePrice = insertedID;
                }
            }

            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);

            }

            finally
            {
                connection.Close();
            }

            return VegetablePrice;
        }

        public static DataTable GetAllVegetable()
        {

            DataTable dt = new DataTable();
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = "SELECT * FROM Vegetables";

            SqlCommand command = new SqlCommand(query, connection);

            try
            {
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)

                {
                    dt.Load(reader);
                }

                reader.Close();


            }

            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
            finally
            {
                connection.Close();
            }

            return dt;


        }
        public static bool UpdateVegetables(int VegetablesID, string Name, float Price, string Image)
        {
            int rowsAffected = 0;
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"Update  Vegetables  
                            set Name = @Name,
                                Price = @Price,
                                Image = @Image
                                where VegetableID = @VegetableID";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@VegetableID", VegetablesID);
            command.Parameters.AddWithValue("@Name", Name);
            command.Parameters.AddWithValue("@Price", Price);
            command.Parameters.AddWithValue("@Image", Image);
            try
            {
                connection.Open();
                rowsAffected = command.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
                return false;
            }

            finally
            {
                connection.Close();
            }

            return (rowsAffected > 0);


        }


    }
}
