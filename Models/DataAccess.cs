using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace StudentDetails.Models
{
    public class DataAccess
    {
        string connectionString = "Server=FSIND-LT-16\\SQLEXPRESS;Database=StudentDB;Trusted_Connection=True;";
        public bool CheckLogin(LoginTable user)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
               SqlCommand cmd = new SqlCommand("SELECT * FROM LoginTable WHERE EmailID=@val1 AND Password=@val2", con);
                SqlParameter emailPara = cmd.Parameters.Add("@val1", SqlDbType.VarChar, 100);

                emailPara.Value = user.EmailId;
                SqlParameter passPara =  cmd.Parameters.Add("@val2",SqlDbType.VarChar,100);
                passPara.Value = user.Password;

                /***cmd.Parameters.AddWithValue("@val1", SqlDbType.VarChar);
                
                cmd.Parameters.AddWithValue("@val2", SqlDbType.VarChar); ***/

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
