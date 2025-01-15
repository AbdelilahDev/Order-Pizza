using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Net;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace DataAccess
{
    public class clsPizzaDataAccess
    {
        public static int AddNewPizza(int ToppingID, int Quantity, int Size, float Price,string PizzaName)
        {
            //this function will return the new person id if succeeded and -1 if not.
            int PizzaID = -1;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"INSERT INTO Piza (ToppingID,Quantity,Size,Price,PizzaName)
                             VALUES (@ToppinID, @Quanty,@Siz,@Pric,@PizzaName);
                             SELECT SCOPE_IDENTITY();"
            ;

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@ToppinID", ToppingID);
            command.Parameters.AddWithValue("@Quanty", Quantity);


            command.Parameters.AddWithValue("@Siz", Size);
            command.Parameters.AddWithValue("@Pric", Price);
            if (PizzaName != "" || PizzaName != null)
            { 
            command.Parameters.AddWithValue("@PizzaName", PizzaName);
            }

            else
                command.Parameters.AddWithValue("@PizzaName",System.DBNull.Value);



            try
            {
                connection.Open();

                object result = command.ExecuteScalar();

                if (result != null && int.TryParse(result.ToString(), out int insertedID))
                {
                    PizzaID = insertedID;
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

            return PizzaID;


        }


        public static bool GetPizzaInformationByID(int PizzaID, ref int ToppingID, ref int Quantity, ref int Size, ref float Price,ref string PizzaName)
        {
            bool isFound = false;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = "SELECT * FROM Pizza WHERE PizzaID = @PizzaID";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("PizzaID", PizzaID);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    // The record was found
                    isFound = true;

                    ToppingID = (int)reader["ToppingID"];
                    Quantity = (int)reader["Quantity"];
                    Size = (int)reader["Size"];
                    Price = Convert.ToSingle(reader["Price"]);
                    if ((string)reader["PizzaName"] != "" || (string)reader["PizzaName"] != null)
                    {
                        PizzaName = (string)reader["PizzaName"];
                    }

                    else
                        PizzaName = "";

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


        public static bool DeletePizza(int PizzaID)
        {
            int rowsAffected = 0;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"Delete Piza 
                                where PizzaID = @ToppingID";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@ToppingID", PizzaID);

            try
            {
                connection.Open();

                rowsAffected = command.ExecuteNonQuery();

            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
            finally
            {

                connection.Close();

            }

            return (rowsAffected > 0);

        }
    }
}
