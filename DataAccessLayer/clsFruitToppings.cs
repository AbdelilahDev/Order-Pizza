using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class clsFruitToppingsDataAccess
    {
        public static int AddNewFruitToppings(string Name,float Price,string Image)
        {
            //this function will return the new person id if succeeded and -1 if not.
            int FruitID = -1;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"INSERT INTO Fruits (Name,Price,Image)
                             VALUES (@Name, @Price,@Image);
                             SELECT SCOPE_IDENTITY();";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@Name", Name);
            command.Parameters.AddWithValue("@Price", Price);
            command.Parameters.AddWithValue("@Image",Image);


            try
            {
                connection.Open();

                object result = command.ExecuteScalar();

                if (result != null && int.TryParse(result.ToString(), out int insertedID))
                {
                    FruitID = insertedID;
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

            return FruitID;

        }

        public static bool GetFruitInformationByID(int FruitID, ref string Name, ref float Price, ref string Image)
        {
            bool isFound = false;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = "SELECT * FROM Fruits WHERE FruitID = @FruitID";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@FruitID", FruitID);

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


                    Price =Convert.ToSingle(reader["Price"]);
                  
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


        public static bool GetFruitInformationName( string Name,ref int FruitID, ref float Price, ref string Image)
        {
            bool isFound = false;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = "SELECT * FROM Fruit WHERE Name = @Name";

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

                    FruitID = (int)reader["FruitID"];
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


        public static float GetFruitPrice(int FruitID)
        {
            //this function will return the new person id if succeeded and -1 if not.
            float FruitPrice = -1;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"select Fruits.Price from Fruits 
where FruitID=@FruitID";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@FruitID", FruitID);


            try
            {
                connection.Open();

                object result = command.ExecuteScalar();

                if (result != null && float.TryParse(result.ToString(), out float insertedID))
                {
                    FruitPrice = insertedID;
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

            return FruitPrice;
        }

        public static float GetFruitPrice(string Name)
        {
            //this function will return the new person id if succeeded and -1 if not.
            float FruitPrice = -1;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"select Fruits.Price from Fruits 
where Name=@Name";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@Name",Name);


            try
            {
                connection.Open();

                object result = command.ExecuteScalar();

                if (result != null && float.TryParse(result.ToString(), out float insertedID))
                {
                    FruitPrice = insertedID;
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

            return FruitPrice;
        }


        public static bool UpdateFruit(int FruitID,string Name,float Price,string Image)
        {
            int rowsAffected = 0;
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"Update  Fruits  
                            set Name = @Name,
                                Price = @Price,
                                Image = @Image
                                where FruitID = @FruitID";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@FruitID",FruitID);
            command.Parameters.AddWithValue("@Name", Name);
            command.Parameters.AddWithValue("@Price",Price);
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

        public static DataTable GetAllFruit()
        {

            DataTable dt = new DataTable();
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = "SELECT * FROM Fruits ";

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
