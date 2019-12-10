using Microsoft.Data.SqlClient;
using System;
using System.Data;

namespace StudentDetails.Models
{
    public class DataAccess
    {
        string connectionString = "Server=FSIND-LT-16\\SQLEXPRESS;Database=StudentDB;Trusted_Connection=True;";
        public bool CheckLogin(LoginTable user)
        {
            if(string.IsNullOrEmpty(user.EmailId))
            {
                throw new ArgumentNullException(user.EmailId);
            }
            else if (string.IsNullOrEmpty(user.Password) || user.Password.Length < 8)
            {
                throw new ArgumentNullException(user.Password);
            }
            using (SqlConnection con = new SqlConnection(connectionString))
            {
               SqlCommand cmd = new SqlCommand("SELECT * FROM LoginTable WHERE EmailID=@val1 AND Password=@val2", con);
                SqlParameter emailPara = cmd.Parameters.Add("@val1", SqlDbType.VarChar, 100);

                emailPara.Value = user.EmailId;
                SqlParameter passPara =  cmd.Parameters.Add("@val2",SqlDbType.VarChar,100);
                passPara.Value = user.Password;

                con.Open();
                cmd.Prepare();
        
              SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    string email = reader["EmailId"].ToString();
                    string pass = reader["Password"].ToString();


                    if (email == user.EmailId && pass == user.Password)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                return false;
            }

        }
    }
}
