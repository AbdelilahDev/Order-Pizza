using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace DataAccess
{
    public class clsReviewsDataAccess
    {
        public static int AddNewReview(int CustmerID, int OrderID, string Delevry, string Pizza,DateTime date)
        {
            //this function will return the new person id if succeeded and -1 if not.
            int ReviewID = -1;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"INSERT INTO Riviews (CustmerID,Deleviry,Pizza,OrderID,Date)
                             VALUES (@CustmerID, @Deleviry,@Pizza,@OrderID,@Date);
                             SELECT SCOPE_IDENTITY();"
            ;

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@CustmerID",CustmerID);
            command.Parameters.AddWithValue("@Date", date);

            command.Parameters.AddWithValue("@OrderID", OrderID);


            if (Delevry != "None" || Delevry != null)
            {
                command.Parameters.AddWithValue("@Deleviry",Delevry);
            }

            else
                command.Parameters.AddWithValue("@Deleviry", System.DBNull.Value);


            if (Pizza != "None" || Pizza != null)
            {
                command.Parameters.AddWithValue("@Pizza", Pizza);
            }

            else
                command.Parameters.AddWithValue("@Pizza", System.DBNull.Value);


            try
            {
                connection.Open();

                object result = command.ExecuteScalar();

                if (result != null && int.TryParse(result.ToString(), out int insertedID))
                {
                    ReviewID = insertedID;
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

            return ReviewID;


        }

        public static bool UpdateReview(int ReviewID, int OrderID, string Delevry, string Pizza)
        {
            int rowsAffected = 0;
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

           
            string query = @"Update  Riviews 
                            set  OrderID= @OrderID,
                                Deleviry= @Deleviry,
                                   Pizza= @Pizza
                           
                                where RiveiwID = @RiveiwID";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@OrderID",OrderID);
            command.Parameters.AddWithValue("@RiveiwID", ReviewID);

            if (Delevry != "None" || Delevry != null)
            {
                command.Parameters.AddWithValue("@Deleviry", Delevry);
            }

            else
                command.Parameters.AddWithValue("@Deleviry", System.DBNull.Value);


            if (Pizza != "None" || Pizza != null)
            {
                command.Parameters.AddWithValue("@Pizza", Pizza);
            }

            else
                command.Parameters.AddWithValue("@Pizza", System.DBNull.Value);




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

        public static DataTable FindReviewsOfCustmer(int CustmerID)
        {
            DataTable dt = new DataTable();
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            /*
            @"INSERT INTO Riviews (CustmerID,Deleviry,Pizza,OrderID)
                            VALUES (@CustmerID, @Deleviry,@Pizza,@OrderID);
                            SELECT SCOPE_IDENTITY();"
            */
            string query = @"select * from Riviews
                       	       	 where CustmerID=@CustmerID";

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

        public static bool DeleteReviewOfCustmer(int CustmerID)
        {
            int rowsAffected = 0;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"Delete Riviews 
                                where CustmerID=@CustmerID";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@CustmerID", @CustmerID);

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
