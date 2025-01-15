using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;
using System.Xml.Linq;

namespace DataAccess
{
    public class clsToppingDataAccess
    {

        public static int AddNewTopping(int VegetableID, int FruitsID, int MeatID, float SeaFishID)
        {
            //this function will return the new person id if succeeded and -1 if not.
            int ToppingID = -1;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"INSERT INTO Toppingss (VegetableID,FruitsID,MeatID,SeaFishID)
                             VALUES (@VegetableID, @FruitsID,@MeatID,@SeaFishID);
                             SELECT SCOPE_IDENTITY();"
            ;

            SqlCommand command = new SqlCommand(query, connection);

            if(VegetableID!=-1)
            command.Parameters.AddWithValue("@VegetableID", VegetableID);
            else
                command.Parameters.AddWithValue("@VegetableID", System.DBNull.Value);

            if(FruitsID!=-1)
            command.Parameters.AddWithValue("@FruitsID", FruitsID);
            else
                command.Parameters.AddWithValue("@FruitsID", System.DBNull.Value);

            if(MeatID!=-1)
            command.Parameters.AddWithValue("@MeatID",MeatID);
            else
                command.Parameters.AddWithValue("@MeatID", System.DBNull.Value);

            if(SeaFishID!=-1)
            command.Parameters.AddWithValue("@SeaFishID",SeaFishID);
            else
                command.Parameters.AddWithValue("@SeaFishID", System.DBNull.Value);



            try
            {
                connection.Open();

                object result = command.ExecuteScalar();

                if (result != null && int.TryParse(result.ToString(), out int insertedID))
                {
                    ToppingID = insertedID;
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

            return ToppingID;


        }


        public static bool GetToppingInfoByID(int ToppingID, ref int VegetableID, ref int FruitID, ref int MeatID, ref int SeaFishID)
        {

            bool isFound = false;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = "SELECT * FROM Toppingss WHERE ToppingsID = @ToppingsID";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("ToppingsID", ToppingID);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    // The record was found
                    isFound = true;

                    if (reader["VegetableID"] != null)
                        VegetableID = (int)reader["VegetableID"];
                    else
                        VegetableID = -1;

                    if (reader["FruitsID"] != null)
                        FruitID = (int)reader["FruitsID"];
                    else
                        MeatID = -1;

                    if (reader["MeatID"] != null)
                        MeatID = (int)reader["MeatID"];
                    else
                        MeatID = -1;


                    if (reader["SeaFishID"] != null)
                        SeaFishID = (int)reader["SeaFishID"];
                    else
                        SeaFishID = -1;

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

        public static bool DeleteTopping(int ToppingID)
        {
            int rowsAffected = 0;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"Delete Toppingss 
                                where ToppingID = @ToppingID";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@ToppingID", ToppingID);

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
