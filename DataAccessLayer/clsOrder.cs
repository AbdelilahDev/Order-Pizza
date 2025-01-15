using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class clsOrderDataAccess

    {
        public static int AddNewOrder(int CustmerID, DateTime OrderDate, int Status, int PizzaID,float TotalPrice)
        {
            //this function will return the new person id if succeeded and -1 if not.
           int OrderID = -1;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"INSERT INTO Ordersss ( 
                            CustmerID,Date,Status,PizzaID,TotalPrice)
                             VALUES (@CustmerID,@Date,@Status,@PizzaID,@TotalPrice);
                             SELECT SCOPE_IDENTITY();";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@CustmerID",CustmerID);
            command.Parameters.AddWithValue("@Date", OrderDate);
            command.Parameters.AddWithValue("@Status",Status);

          
            command.Parameters.AddWithValue("@PizzaID",PizzaID);

            command.Parameters.AddWithValue("@TotalPrice", TotalPrice);

            try
            {
                connection.Open();

                object result = command.ExecuteScalar();

                if (result != null && int.TryParse(result.ToString(), out int insertedID))
                {
                    OrderID = insertedID;
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


            return OrderID;

        }

        public static bool UpdateOrderStatus(int OrderID,short NewStatus)
        {
            int rowsAffected = 0;
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"Update  Ordersss  
                            set Status = @Status
                            where OrdersID=@OrdersID";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@OrderID", OrderID);

            command.Parameters.AddWithValue("@Status",NewStatus);


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

        public static bool UpdateOrder(int OrderID,int CustmerID, DateTime OrderDate, int Status
           , int PizzaID, float TotalPrice)
        {
            int rowsAffected = 0;
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"Update  Ordersss  
                            set   OrdersID=@OrdersID,
                                  CustmerID=@CustmerID,
                                  Date=@Date,
                                  Status = @Status,
                             
                                  PizzaID=@PizzaID,
                           
                                  TotalPrice=@TotalPrice
                            where OrderID=@OrdersID";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@OrdersID", OrderID);
            command.Parameters.AddWithValue("@CustmerID", CustmerID);

            command.Parameters.AddWithValue("@Status", Status);
   
            command.Parameters.AddWithValue("@Date", OrderDate);
            command.Parameters.AddWithValue("@PizzaID", PizzaID);


            command.Parameters.AddWithValue("@TotalPrice",TotalPrice);


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


        public static bool FindOrder(int OrderID, ref int CustmerID, ref int PizzaID, ref DateTime Date, ref int Status, ref float TotalPrice)
        {
            bool isFound = false;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = "SELECT * FROM Ordersss WHERE OrderID = @OrdersID";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@OrdersID",OrderID);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    // The record was found
                    isFound = true;

                    CustmerID= (int)reader["CustmerID"];
                    PizzaID = (int)reader["PizzaID"];
                    Date = (DateTime)reader["Date"];
                    Status= (int)reader["Status"];
                    TotalPrice= Convert.ToSingle(reader["TotalPrice"]);




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


        public bool DeleteOrder(int OrderID)
        {
            int rowsAffected = 0;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"Delete Ordersss
                                where OrderID = @OrdersID";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@OrdersID",OrderID);

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
