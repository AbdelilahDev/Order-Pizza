using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace DataAccess
{
    public class clsManDelivery
    {
        public static int AddNewManDelivery(int PersonID, string Notes, int DelivryOrders)
        {
            //this function will return the new person id if succeeded and -1 if not.
            int ManDelivryID = -1;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"INSERT INTO Livreurs ( 
                            PersonID,Notes,OrderCofirmer)
                             VALUES (@PersonID,@Notes,@OrderCofirmer);
                             SELECT SCOPE_IDENTITY();";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@PersonID", PersonID);
            command.Parameters.AddWithValue("@Notes", Notes);
            command.Parameters.AddWithValue("@OrderCofirmer",DelivryOrders);


            try
            {
                connection.Open();

                object result = command.ExecuteScalar();

                if (result != null && int.TryParse(result.ToString(), out int insertedID))
                {
                    ManDelivryID = insertedID;
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


            return ManDelivryID;

        }

        public static bool GetManDeliveryInfoBYID(int ManDeliveryID, ref int PersonID, ref string Notes, ref int OrderDelivery)
        {
            bool isFound = false;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = "SELECT * FROM Livreurs WHERE LivreurID = @LivreurID";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@LivreurID", ManDeliveryID);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {

                    // The record was found
                    isFound = true;

                    PersonID = (int)reader["PersonID"];

                    if (reader["Notes"] != DBNull.Value)
                       Notes = (string)reader["Notes"];
                    else
                        Notes = "";

                    OrderDelivery = (int)reader["OrderCofirmer"];

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

        public static bool GetManDeliveryInfoPersonID(int PersonID, ref int ManDelivryID, ref string Notes, ref int OrderDelivery)
        {
            bool isFound = false;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = "SELECT * FROM Livreurs WHERE PersonID = @PersonID";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@PersonID",PersonID);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {

                    // The record was found
                    isFound = true;

                   ManDelivryID = (int)reader["LivreurID"];

                    if (reader["Notes"] != DBNull.Value)
                        Notes = (string)reader["Notes"];
                    else
                        Notes = "";

                    OrderDelivery = (int)reader["OrderCofirmer"];

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
        public static bool UpdateManDelivery(int ManDeliveryID, int PersonID, string Note, int DelivryOrders)
        {
            int rowsAffected = 0;
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"Update  Livreurs  
                            set PersonID = @PersonID,
                                Notes = @Notes,
                                OdrerDelivery = @OrderCofirmer
                               
                            
                            where LivreurID=@LivreurID";

            SqlCommand command = new SqlCommand(query, connection);
            
            command.Parameters.AddWithValue("@LivreurID", ManDeliveryID);

            command.Parameters.AddWithValue("@PersonID", PersonID);


            if(Note!=""&&Note!=null)
            command.Parameters.AddWithValue("@Notes", Note);
            else
            command.Parameters.AddWithValue("@Notes",System.DBNull.Value);


            command.Parameters.AddWithValue("@OrderCofirmer",DelivryOrders);




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

        public static bool DeleteManDelivery(int ManDeliveryID)
        {
            int rowsAffected = 0;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"Delete Livreurs 
                                where LivreurID = @LivreurID";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@LivreurID", ManDeliveryID);

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

        public static bool AddAnOrderToManDelivery(int ManDelivery)
        {
            int TotalOrders = GetAllDeliveryOrders(ManDelivery);
            TotalOrders++;
            return UpdateOrders(ManDelivery, TotalOrders);
        
        }

        public static int GetAllDeliveryOrders(int ManDeliveryID)
        {
            //this function will return the new person id if succeeded and -1 if not.
            int TotalOrderLivre = -1;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"select Livreurs.OrderDelivery 
from Livreurs

where LivreurID=@LivreurID";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@LivreurID", ManDeliveryID);
      

            try
            {
                connection.Open();

                object result = command.ExecuteScalar();

                if (result != null && int.TryParse(result.ToString(), out int insertedID))
                {
                    TotalOrderLivre = insertedID;
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

            return TotalOrderLivre;

        }

        public static bool UpdateOrders(int ManDeliveryID, int Orders)
        {
            int rowsAffected = 0;
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"Update  Livreurs  
                            set 
                                OdrerDelivery = @OdrerDelivery
                            where LivreurID=@LivreurID";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("LivreurID", ManDeliveryID);

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

        public static bool DeleteDeliveryMan(int DeliveryMan)
        {
            int rowsAffected = 0;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"Delete Livreurs
                                where LivreurID = @LivreurID";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@LivreurID",DeliveryMan);

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
