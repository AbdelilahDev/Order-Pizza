using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class clsSeaFichDataAccess
    {

        public static int AddNewSeaFishToppings(string Name, float Price, string Image)
        {
            //this function will return the new person id if succeeded and -1 if not.
            int SeaFichsID = -1;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"INSERT INTO SeaFichs (Name,Price,Image)
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
                    SeaFichsID = insertedID;
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

            return SeaFichsID;

        }

        public static bool GetSeaFichsInformationByID(int SeaFichID, ref string Name, ref float Price, ref string Image)
        {
            bool isFound = false;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = "SELECT * FROM SeaFichs WHERE SeaFishID = @SeaFishID";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@SeaFishID", SeaFichID);

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

                    Price = Convert.ToSingle(reader["Price"]);

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


        public static bool GetSeaFichsInformationByNmae(string Name, ref int SeaFichID, ref float Price, ref string Image)
        {
            bool isFound = false;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = "SELECT * FROM SeaFichs WHERE Name = @Name";

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

                    SeaFichID = (int)reader["SeaFishID"];
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


        public static float GetSeaFishIDPrice(int SeaFishID)
        {
            //this function will return the new person id if succeeded and -1 if not.
            float VegetablePrice = -1;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"select Price from SeaFichs
                           where SeaFishID=@SeaFishID";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@SeaFishID", SeaFishID);


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


        public static bool UpdateSeaFish(int SeaFishID, string Name, float Price, string Image)
        {
            int rowsAffected = 0;
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"Update  SeaFichs  
                            set Name = @Name,
                                Price = @Price,
                                Image = @Image
                                where SeaFishID=@SeaFishID";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@SeaFishID", SeaFishID);
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

        public static DataTable GetAllSeaFish()
        {

            DataTable dt = new DataTable();
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = "SELECT * FROM SeaFichs ";

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

    }
}
