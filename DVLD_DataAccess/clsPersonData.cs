using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_DataAccess
{
    public class clsPersonData
    {
        public static bool FindPersonInDataBaseByID(int PersonID, ref string NationalNo, ref string FirstName, ref string SecondName, ref string ThirdName, ref string LastName, ref DateTime DateOfBirth, ref int Gendor, ref string Address, ref string Phone, ref string Email, ref int NationalityCountryID, ref string ImagePath)
        {
            bool Found = false;
            SqlConnection Connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string Query = "SELECT * FROM People WHERE PersonID = @PersonID";
            SqlCommand Command = new SqlCommand(Query, Connection);
            Command.Parameters.AddWithValue("@PersonID", PersonID);

            try
            {
                Connection.Open();
                SqlDataReader Reader = Command.ExecuteReader();
                if (Reader.Read())
                {
                    Found = true;
                    NationalNo = (string)Reader["NationalNo"];
                    FirstName = (string)Reader["FirstName"];
                    SecondName = (string)Reader["SecondName"];
                    if (Reader["ThirdName"] != DBNull.Value)
                    {
                        ThirdName = (string)Reader["ThirdName"];

                    }
                    else
                        ThirdName = "";

                    LastName = (string)Reader["LastName"];
                    DateOfBirth = (DateTime)Reader["DateOfBirth"];
                    Gendor = Convert.ToInt32(Reader["Gendor"]);
                    Address = (string)Reader["Address"];
                    Phone = (string)Reader["Phone"];
                    if (Reader["Email"] != DBNull.Value)
                    {

                        Email = (string)Reader["Email"];
                    }
                    else
                        Email = "";
                    NationalityCountryID = (int)Reader["NationalityCountryID"];
                    if (Reader["ImagePath"] != DBNull.Value)
                    {

                        ImagePath = (string)Reader["ImagePath"];
                    }
                    else ImagePath = "";

                }
                Reader.Close();

            }
            catch (Exception ex)
            {
                Found = false;
            }

            finally
            {
                Connection.Close();
            }
            return Found;
        }
        public static bool FindPersonInDataBaseByNationalNo(ref int PersonID, string NationalNo, ref string FirstName, ref string SecondName, ref string ThirdName, ref string LastName, ref DateTime DateOfBirth, ref int Gendor, ref string Address, ref string Phone, ref string Email, ref int NationalityCountryID, ref string ImagePath)
        {

            bool Found = false;
            SqlConnection Connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string Query = "SELECT * FROM People WHERE NationalNo= @NationalNo";
            SqlCommand Command = new SqlCommand(Query, Connection);
            Command.Parameters.AddWithValue("@NationalNo", NationalNo);

            try
            {
                Connection.Open();
                SqlDataReader Reader = Command.ExecuteReader();
                if (Reader.Read())
                {
                    Found = true;
                    PersonID = int.Parse(Reader["PersonID"].ToString());
                    // NationalNo = (string)Reader["NationalNo"];
                    FirstName = (string)Reader["FirstName"];
                    SecondName = (string)Reader["SecondName"];
                    if (Reader["ThirdName"] != DBNull.Value)
                    {
                        ThirdName = (string)Reader["ThirdName"];

                    }
                    else
                        ThirdName = "";

                    LastName = (string)Reader["LastName"];
                    DateOfBirth = (DateTime)Reader["DateOfBirth"];
                    Gendor = Convert.ToInt32(Reader["Gendor"]);
                    Address = (string)Reader["Address"];
                    Phone = (string)Reader["Phone"];
                    if (Reader["Email"] != DBNull.Value)
                    {

                        Email = (string)Reader["Email"];
                    }
                    else
                        Email = "";
                    NationalityCountryID = (int)Reader["NationalityCountryID"];
                    if (Reader["ImagePath"] != DBNull.Value)
                    {

                        ImagePath = (string)Reader["ImagePath"];
                    }
                    else ImagePath = "";

                }
                Reader.Close();

            }
            catch (Exception ex)
            {
                Found = false;
            }

            finally
            {
                Connection.Close();
            }
            return Found;
        }
        public static int AddNewPersonToDataBase(string NationalNo, string FirstName, string SecondName, string ThirdName, string LastName, DateTime DateOfBirth, int Gendor, string Address, string Phone, string Email, int NationalityCountryID, string ImagePath)
        {
            int PersonID = -1;
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string Query = @"Insert Into People(NationalNo,FirstName,SecondName,ThirdName,LastName,DateOfBirth,Gendor,Address,Phone,Email,NationalityCountryID,ImagePath) values
                (@NationalNO,@FirstName,@SecondName,@ThirdName,@LastName,@DateOfBirth,@Gendor,@Address,@Phone,@Email,@NationalityCountryId,@ImagePath);
                   Select SCOPE_IDENTITY()";

            SqlCommand Command = new SqlCommand(Query, connection);
            Command.Parameters.AddWithValue("@NationalNO", NationalNo);
            Command.Parameters.AddWithValue("@FirstName", FirstName);
            Command.Parameters.AddWithValue("@SecondName", SecondName);
            if (!string.IsNullOrEmpty(ThirdName))
            {
                Command.Parameters.AddWithValue("@ThirdName", ThirdName);
            }
            else Command.Parameters.AddWithValue("@ThirdName", DBNull.Value);
            Command.Parameters.AddWithValue("@LastName", LastName);
            Command.Parameters.AddWithValue("@Gendor", Gendor);
            if (Email != "" && Email != null)
            {
                Command.Parameters.AddWithValue("@Email", Email);
            }
            else Command.Parameters.AddWithValue("@Email", DBNull.Value);
            Command.Parameters.AddWithValue("@Address", Address);
            Command.Parameters.AddWithValue("@DateOfBirth", DateOfBirth);
            Command.Parameters.AddWithValue("@Phone", Phone);
            Command.Parameters.AddWithValue("@NationalityCountryID", NationalityCountryID);
            if (ImagePath != "" && ImagePath != null)
            {
                Command.Parameters.AddWithValue("@ImagePath", ImagePath);
            }
            else
                Command.Parameters.AddWithValue("@ImagePath", DBNull.Value);
            try
            {
                connection.Open();
                Object Result = Command.ExecuteScalar();
                if (Result != DBNull.Value && int.TryParse(Result.ToString(), out int ID))
                {
                    PersonID = ID;
                }

            }
            catch (Exception ex)
            {

            }
            finally
            {
                connection.Close();
            }

            return PersonID;
        }
        public static bool UpdatePersonInfoInDataBase(int PersonID, string NationalNo, string FirstName, string SecondName, string ThirdName, string LastName, DateTime DateOfBirth, int Gendor, string Address, string Phone, string Email, int NationalityCountryID, string ImagePath)
        {
            int RowsAffected = -1;
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string Query = @"Update People set NationalNo=@NationalNo,FirstName=@FirstName,SecondName=@SecondName,ThirdName=@ThirdName
                      ,LastName=@LastName,DateOfBirth=@DateOfBirth,Gendor=@Gendor,Address=@Address,Phone=@Phone,Email=@Email
                      ,NationalityCountryID=@NationalityCountryID,ImagePath=@ImagePath 
                        Where PersonID=@PersonID ";


            SqlCommand Command = new SqlCommand(Query, connection);
            Command.Parameters.AddWithValue("@PersonID", PersonID);
            Command.Parameters.AddWithValue("@NationalNo", NationalNo);
            Command.Parameters.AddWithValue("@FirstName", FirstName);
            Command.Parameters.AddWithValue("@SecondName", SecondName);
            if (ThirdName != "" && ThirdName != null)
            {
                Command.Parameters.AddWithValue("@ThirdName", ThirdName);
            }
            else Command.Parameters.AddWithValue("@ThirdName", DBNull.Value);
            Command.Parameters.AddWithValue("@LastName", LastName);
            Command.Parameters.AddWithValue("@Gendor", Gendor);
            if (Email != "" && Email != null)
            {
                Command.Parameters.AddWithValue("@Email", Email);
            }
            else Command.Parameters.AddWithValue("@Email", DBNull.Value);
            Command.Parameters.AddWithValue("@Address", Address);
            Command.Parameters.AddWithValue("@DateOfBirth", DateOfBirth);
            Command.Parameters.AddWithValue("@Phone", Phone);
            Command.Parameters.AddWithValue("@NationalityCountryID", NationalityCountryID);
            if (ImagePath != "" && ImagePath != null)
            {
                Command.Parameters.AddWithValue("@ImagePath", ImagePath);
            }
            else
                Command.Parameters.AddWithValue("@ImagePath", DBNull.Value);
            try
            {
                connection.Open();
                RowsAffected = Command.ExecuteNonQuery();

            }
            catch (Exception ex)
            {

            }
            finally
            {
                connection.Close();
            }

            return RowsAffected > 0;
        }
        public static DataTable GetAllPeopleFromDataBase()
        { 
            SqlConnection Connection = new SqlConnection(clsDataAccessSettings.ConnectionString);


            string Query = @"select People.PersonID ,People.NationalNo,People.FirstName,People.SecondName,People.ThirdName,People.LastName,People.Gendor, 
Case When People.Gendor = 0 then 'Male' 
 else 'Female' end as GendorCaption,People.DateOfBirth,Countries.CountryName,People.Address,People.Phone,People.Email
 from People inner join Countries 
 ON People.NationalityCountryID=Countries.CountryID;

";
            SqlCommand Command = new SqlCommand(Query, Connection);
            DataTable DT = new DataTable();
            try
            {
                Connection.Open();
                SqlDataReader Reader = Command.ExecuteReader();

               // if (Reader.HasRows)
               // {
                 //   DT.Clear();
                    DT.Load(Reader);
             //   }
                Reader.Close();
            }
            catch (Exception ex)
            {

            }
            finally
            {
                Connection.Close();
            }
            return DT;
        }
        public static bool DeletePersonFromDataBase(int PersonID)
        {
            int RowsAffected = -1;
            SqlConnection Connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string Query = " Delete From People Where PersonID=@PersonID";
            SqlCommand Command = new SqlCommand(Query, Connection);

            Command.Parameters.AddWithValue("@PersonID", PersonID);

            try
            {
                Connection.Open();
                RowsAffected = Command.ExecuteNonQuery();

            }
            catch (Exception ex)
            {

            }

            finally
            {
                Connection.Close();

            }
            return RowsAffected > 0;
        }
        public static bool IsPersonExist(string NationalNo)
        {
            bool Found = false;
            SqlConnection Connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string Query = " Select Found=1 From People Where NationalNo=@NationalNo";
            SqlCommand Command = new SqlCommand(Query, Connection);
            Command.Parameters.AddWithValue("@NationalNo", NationalNo);

            try
            {
                Connection.Open();
                SqlDataReader Reader = Command.ExecuteReader();
                if (Reader.HasRows)
                    Found = true;
                Reader.Close();
            }
            catch (Exception ex)
            {

            }

            finally
            {
                Connection.Close();

            }
            return Found;


        }
        public static bool IsPersonExist(int PersonID)
        {
            bool Found = false;

            SqlConnection Connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string Query = " Select Found=1 From People Where PersonID=@PersonID";
            SqlCommand Command = new SqlCommand(Query, Connection);
            Command.Parameters.AddWithValue("@PersonID", PersonID);

            try
            {
                Connection.Open();
                SqlDataReader Reader = Command.ExecuteReader();
                if (Reader.HasRows)
                    Found = true;
                Reader.Close();
            }
            catch (Exception ex)
            {

            }

            finally
            {
                Connection.Close();

            }
            return Found;


        }
        public static bool DoesUserExistInDataBase(string UserName, string UserPassword)
        {
            bool Found = false;
            SqlConnection Connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string Query = " Select Found=1 From Users Where UserName=@UserName and Password=@UserPassword";
            SqlCommand Command = new SqlCommand(Query, Connection);
            Command.Parameters.AddWithValue("@UserName", UserName);
            Command.Parameters.AddWithValue("@UserPassword", UserPassword);

            try
            {
                Connection.Open();
                SqlDataReader Reader = Command.ExecuteReader();
                Reader.Read();


                Found = Reader.HasRows;



            }
            catch (Exception ex)
            {
                Found = false;
            }

            finally
            {
                Connection.Close();

            }
            return Found;
        }

    }
}
