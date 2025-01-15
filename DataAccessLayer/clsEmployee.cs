using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class clsEmployee
    {
        public static bool GetEmployeeInformationByID(int PersonID, ref string FullName, ref string PhoneNumber, ref string Address, ref string Email, ref short Gender,
            ref string NationalNumber, ref string ImagePath,ref DateTime DateofHired,ref bool isFired,ref DateTime FiredDate,ref string FiredCouse)
        {
            bool isFound = false;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = "SELECT * FROM Employees WHERE PersonID = @PersonID";

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

                    FullName = (string)reader["FullName"];
                    PhoneNumber = (string)reader["PhoneNumber"];

                 
                    Address = (string)reader["Address"];
                    Email = (string)reader["Email"];
                    Gender = (short)reader["Gendre"];
                    NationalNumber = (string)reader["NationalNumber"];
                    ImagePath = (string)reader["Image"];
                    DateofHired = (DateTime)reader["DateOfHired"];
                    isFired = (bool)reader["IsFired"];

                    if (reader["DateOfFired"] != DBNull.Value)
                    {
                        FiredDate = (DateTime)reader["DateOfFired"];
                    }
                    FiredDate =DateTime.MaxValue;


                    if (reader["CouseFired"] != DBNull.Value)
                    {
                        FiredCouse = (string)reader["CouseFired"];
                    }
                    FiredDate = DateTime.MaxValue;



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
        public static bool GetEmployeeInformationByNationalNumber( string NationalNumber, ref int PersonID, ref string FullName, ref string PhoneNumber, ref string Address, ref string Email, ref short Gender,
            ref string ImagePath,ref DateTime DateofHired, ref bool isFired, ref DateTime FiredDate, ref string FiredCouse)
        {
            bool isFound = false;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = "SELECT * FROM Employees WHERE NationalNumber = @NationalNumber";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("NationalNumber", NationalNumber);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    // The record was found
                    isFound = true;

                    FullName = (string)reader["FullName"];
                    PhoneNumber = (string)reader["PhoneNumber"];


                    Address = (string)reader["Address"];
                    Email = (string)reader["Email"];
                    Gender = (short)reader["Gendre"];
                    PersonID = (int)reader["PersonID"];
                    ImagePath = (string)reader["Image"];

                    isFired = (bool)reader["IsFired"];

                    if (reader["DateOfFired"] != DBNull.Value)
                    {
                        FiredDate = (DateTime)reader["DateOfFired"];
                    }
                    FiredDate = DateTime.MaxValue;


                    if (reader["CouseFired"] != DBNull.Value)
                    {
                        FiredCouse = (string)reader["CouseFired"];
                    }
                    FiredDate = DateTime.MaxValue;


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

        public static int AddNewEmployee( string FullName, string PhoneNumber, string Address,string Email,short Gender,string NationalNumber,
            string ImagePath, DateTime DateofHired,  bool isFired, DateTime FiredDate, string FiredCouse)
        {
            //this function will return the new person id if succeeded and -1 if not.
            int PersonID = -1;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"INSERT INTO Employees (FullName,PhoneNumber,Address,Email,Gender,
                                                   NationalNumber,Image,DateOfHired,isFired,DateOfFired,CouseFired)
                             VALUES (@FullName, @PhoneNumber,@Address, @Email, @Gender,
                                     @NationalNumber,@Image,@DateOfHired,@isFired,@DateOfFired,@CouseFired);
                             SELECT SCOPE_IDENTITY();";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@FullName",FullName);
            command.Parameters.AddWithValue("@PhoneNumber",PhoneNumber);

          
            command.Parameters.AddWithValue("@Address", Address);
            command.Parameters.AddWithValue("@Email", Email);
            command.Parameters.AddWithValue("@Gender", Gender);
            command.Parameters.AddWithValue("@NationalNumber", NationalNumber);
            command.Parameters.AddWithValue("@Address", Address);
            command.Parameters.AddWithValue("@Image",ImagePath);
            command.Parameters.AddWithValue("@DateOfHired", DateofHired);
            command.Parameters.AddWithValue("@isFired", isFired);


            if (FiredDate !=DateTime.MaxValue && FiredDate != null)
                command.Parameters.AddWithValue("@DateOfFired", FiredDate);
            else
                command.Parameters.AddWithValue("@DateOfFired", System.DBNull.Value);


            if (FiredCouse != "" && FiredCouse != null)
                command.Parameters.AddWithValue("@CouseFired", FiredCouse);
            else
                command.Parameters.AddWithValue("@CouseFired", System.DBNull.Value);



            try
            {
                connection.Open();

                object result = command.ExecuteScalar();

                if (result != null && int.TryParse(result.ToString(), out int insertedID))
                {
                    PersonID = insertedID;
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

            return PersonID;

        }

        public static bool UpdateEmployee(int PersonID, string FullName, string PhoneNumber, string Address, string Email, short Gender, string NationalNumber,
            string ImagePath, DateTime DateofHired,  bool isFired,  DateTime FiredDate, string FiredCouse)
        {
            int rowsAffected = 0;
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"Update  Employees  
                            set FullName = @FullName,
                                PhoneNumber = @PhoneNumber,
                                Address = @Address,
                                Email = @Email, 
                                Gendre = @Gendre,
                                NationalNumber = @NationalNumber,
                                Image=@Image,
                                DateOfHired=@DateOfHired,
                                isFired=@isFired,
                                DateOfFired=@DateOfFired,
                                CouseFired=@CouseFired

                                where PersonID = @PersonID";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@PersonID", PersonID);
            command.Parameters.AddWithValue("@FullName", FullName);
            command.Parameters.AddWithValue("@PhoneNumber", PhoneNumber);


            command.Parameters.AddWithValue("@Address",Address);
            command.Parameters.AddWithValue("@Email", Email);
            command.Parameters.AddWithValue("@Gendre",Gender);

            command.Parameters.AddWithValue("@NationalNumber", NationalNumber);
            command.Parameters.AddWithValue("@Image",ImagePath);
            command.Parameters.AddWithValue("@DateOfHired",DateofHired);
            command.Parameters.AddWithValue("@isFired", isFired);

            if(FiredDate!=DateTime.MaxValue||FiredDate!=null)
            command.Parameters.AddWithValue("@DateOfFired", FiredDate);
            else
            command.Parameters.AddWithValue("@DateOfFired", System.DBNull.Value);


            if (FiredCouse!= "" || FiredCouse != null)
                command.Parameters.AddWithValue("@CouseFired",FiredCouse);
            else
                command.Parameters.AddWithValue("@CouseFired", System.DBNull.Value);






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

        public static bool DeleteEmployee(int PersonID)
        {
            int rowsAffected = 0;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"Delete Employees 
                                where PersonID = @PersonID";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@PersonID", PersonID);

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

        public static DataTable GetAllEmployees()
        {
            DataTable dt = new DataTable();
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query =
              @"SELECT Employees.PersonID, Employees.NationalNumber,Employees.FullName
              , Employees.PhoneNumber, Employees.Email,Employees.Address,
			   Employees.Image, 
				  CASE
                  WHEN Employees.Gendre = 0 THEN 'Male'

                  ELSE 'Female'

                  END as Gendor 
			  
              FROM     Employees  
                ORDER BY Employees.PersonID";




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

        public static bool IsEmployeeExist(int PersonID)
        {
            bool isFound = false;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = "SELECT Found=1 FROM Employees WHERE PersonID = @PersonID";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@PersonID", PersonID);

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


        public static bool IsEmployeeExist(string NationalNumber)
        {
            bool isFound = false;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = "SELECT Found=1 FROM Employees WHERE NationalNumber = @NationalNumber";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@NationalNumber", NationalNumber);

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


        public static bool IsEmployeeFired(int PersonID)
        {
            bool IsFired = false;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"select IsFired=1 
                            from Employees 
                            where 
                            PersonID=@PersonID 
                            and isFired=1;";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@PersonID",PersonID);

            try
            {
                connection.Open();

                object result = command.ExecuteScalar();

                if (result != null)
                {
                    IsFired = Convert.ToBoolean(result);
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


            return IsFired;



        }

        public static bool IsEmployeeFired(string NationalNumber)
        {
            bool IsFired = false;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"select IsFired=1 
                            from Employees 
                            where 
                            NationalNumber = @NationalNumber
                            and isFired=1;";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@NationalNumber", NationalNumber);

            try
            {
                connection.Open();

                object result = command.ExecuteScalar();

                if (result != null)
                {
                    IsFired = Convert.ToBoolean(result);
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


            return IsFired;



        }


    }
}
