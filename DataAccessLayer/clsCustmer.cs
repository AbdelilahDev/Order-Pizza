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
    public class clsCustmerDatAcess
    {
        public static int AddCustmer(string Name, string Phone, string Address,string Note)
        {
            //this function will return the new person id if succeeded and -1 if not.
            int CustmerID = -1;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"INSERT INTO Custmerss (Name,Phone,Adress,Note)
                             VALUES (@Name, @PhoneNumber,@Address,@Note);
                             SELECT SCOPE_IDENTITY();";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@Name", Name);
            command.Parameters.AddWithValue("@PhoneNumber", Phone);
            command.Parameters.AddWithValue("@Address", Address);
            if(Address!=""||Address!=null)
            command.Parameters.AddWithValue("@Note", Note);
            else
                command.Parameters.AddWithValue("@Note",System.DBNull.Value);



            try
            {
                connection.Open();

                object result = command.ExecuteScalar();

                if (result != null && int.TryParse(result.ToString(), out int insertedID))
                {
                    CustmerID = insertedID;
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

            return CustmerID;


        }
        public static bool GetCusmtmerInformationByID(int CustmerID,ref string Name,ref string Phone,ref string Address,ref string Note )
        {
            bool isFound = false;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = "SELECT * FROM Custmerss WHERE CustmerID = @CustmersID";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@CustmersID",CustmerID);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    // The record was found
                    isFound = true;

                     Name = (string)reader["Name"];
                    Phone = (string)reader["PhoneNumber"];
                    Address = (string)reader["Address"];
                    Note = (string)reader["Note"];

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
        public static bool GetCusmtmerInformationByPhoneNumber(string PhoneNumber,ref string Name,ref int CustmerID,ref string Address,ref string Note )
        {
            bool isFound = false;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = "SELECT * FROM Custmerss WHERE Phone = @PhoneNumber";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@PhoneNumber",PhoneNumber);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    // The record was found
                    isFound = true;

                     Name = (string)reader["Name"];
                    CustmerID = (int)reader["CustmerID"];
                    Address = (string)reader["Adress"];
                    if ((string)reader["Note"] != "" || (string)reader["Note"] == null)
                        Note = (string)reader["Note"];
                    else
                        Note = "";

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
        public static DataTable GetAllCustmers()
        {
            DataTable dt = new DataTable();
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"SELECT *  from Custmerss";




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

        public static bool IsCustmerExist(string PhoneNumber)
        {
            bool isFound = false;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = "SELECT Found=1 FROM Custmerss WHERE Phone = @PhoneNumber";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@PhoneNumber", PhoneNumber);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                isFound = reader.HasRows;

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

        public static bool UpdateCustmer(int CustmerID, string Name, string Phone, string Address, string Note)
        {
            int rowsAffected = 0;
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"Update  Custmerss 
                            set Name = @Name,
                                Phone = @PhoneNumber,
                                Address = @Address,
                                Note = @Note
                                where CustmerID = @CustmersID";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@CustmersID",CustmerID);
            command.Parameters.AddWithValue("@Name", Name);
            command.Parameters.AddWithValue("@PhoneNumber", Phone);


            command.Parameters.AddWithValue("@Address", Address);
            command.Parameters.AddWithValue("@Note", Note );



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

        public static DataTable GetActiveOrderForCustmer(int CustmerID)
        {
            DataTable dt = new DataTable();
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"select * from View_ActiveOrdersInformation
                       	       	 where CustmerID=@CustmerID and OrderStatus='New'";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@CustmerID", CustmerID);

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

        public static int CountActiveOrdersForCustmer(int CustmerID)
        {
            int TotalOrders = 0;
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string query = @"
                select COUNT(OrderID) from View_ActiveOrdersInformation
                where CustmerID=@CustmerID and OrderStatus='New'
";
            SqlCommand cmd = new SqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@CustmerID", CustmerID);
            try
            {
                connection.Open();
                object result = cmd.ExecuteScalar();

                if (result != null && int.TryParse(result.ToString(), out int TotalPers))
                {

                    TotalOrders = TotalPers;
                }
            }
            catch (Exception e)
            {
                TotalOrders = 0;
            }
            finally { connection.Close(); }
            return TotalOrders;


        }


    }
}
