using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
   public class clsChef
    {
        public static int AddNewChef(int PersonID, string Specific, string Degree, string Note, float Salary)
        {
            //this function will return the new person id if succeeded and -1 if not.
            int ChefID = -1;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"INSERT INTO Chefs ( 
                            PersonID,Spicifiec,Dogree,
                            Note,Salary)
                             VALUES (@PersonID,@Spicifiec,@Dogree,
                                      @Note,@Salary);
                             SELECT SCOPE_IDENTITY();";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@PersonID", PersonID);
            command.Parameters.AddWithValue("@Spicifiec", Specific);
            command.Parameters.AddWithValue("@Dogree", Degree);
            command.Parameters.AddWithValue("@Note", Note);
            command.Parameters.AddWithValue("@Salary", Salary);

            try
            {
                connection.Open();

                object result = command.ExecuteScalar();

                if (result != null && int.TryParse(result.ToString(), out int insertedID))
                {
                    ChefID = insertedID;
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


            return ChefID;

        }

        public static bool GetChefInformationByChefID(int ChefID, ref int PersonID, ref string Specific, ref string Dogree, ref string Note, ref float Salary)
        {
            bool isFound = false;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = "SELECT * FROM Chefs WHERE ChefID = @ChefID";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@ChefID",ChefID);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {

                    // The record was found
                    isFound = true;

                   PersonID = (int)reader["PersonID"];

                    if (reader["Spicifiec"] != DBNull.Value)
                        Specific = (string)reader["Spicifiec"];
                    else
                        Specific = "";

                    if (reader["Dogree"] != DBNull.Value)
                        Dogree = (string)reader["Dogree"];
                    else
                        Dogree = "";

                    if (reader["Note"] != DBNull.Value)
                        Note = (string)reader["Note"];
                    else
                        Note = "";

                    Salary   =Convert.ToSingle( reader["Dogree"]);

                  

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

        public static bool GetChefInformationByPersonID(int PersonID, ref int ChefID, ref string Specific, ref string Dogree, ref string Note, ref float Salary)
        {
            bool isFound = false;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = "SELECT * FROM Chefs WHERE PersonID = @PersonID";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@PersonID", PersonID);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {

                    // The record was found
                    isFound = true;

                    ChefID = (int)reader["ChefID"];

                    if (reader["Spicifiec"] != DBNull.Value)
                        Specific = (string)reader["Spicifiec"];
                    else
                        Specific = "";

                    if (reader["Dogree"] != DBNull.Value)
                        Dogree = (string)reader["Dogree"];
                    else
                        Dogree = "";

                    if (reader["Note"] != DBNull.Value)
                        Note = (string)reader["Note"];
                    else
                        Note = "";

                    Salary = Convert.ToSingle(reader["Dogree"]);



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


        public static bool UpdateChef(int ChefID,int PersonID, string Specific, string Dogree, string Note, float Salary)
        {
            int rowsAffected = 0;
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"Update  Chefs  
                            set PersonID = @PersonID,
                                Spicifiec = @Spicifiec,
                                Dogree = @Dogree,
                                Note = @Note, 
                                Salary = @Salary
                            
                            where ChefID=@ChefID";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@PersonID", PersonID);
            command.Parameters.AddWithValue("@Spicifiec", Specific);
            command.Parameters.AddWithValue("@Dogree",Dogree);
            command.Parameters.AddWithValue("@Note", Note);
            command.Parameters.AddWithValue("@Salary", Salary);
            command.Parameters.AddWithValue("@ChefID", ChefID);



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
