using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
namespace StudentDetails.Models
{
    public class StudentsDataAccess : IStudentsDataAccess
    {
        string connectionString = "Server=FSIND-LT-16\\SQLEXPRESS;Database=StudentDB;Trusted_Connection=True;";

        public bool AddStudents(Students stud)
        {
            using SqlConnection con = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand("spAddStudents", con);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@Name", stud.Name);
            cmd.Parameters.AddWithValue("@Address", stud.Address);
            cmd.Parameters.AddWithValue("@DeptName", stud.DeptName);
            cmd.Parameters.AddWithValue("@Marks", stud.Marks);
            con.Open();
            cmd.ExecuteNonQuery();
            cmd.Dispose();
            con.Close();
            return true;

        }
        public IEnumerable<Students> Students()
        {
            List<Students> students = new List<Students>();

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("spGetAllStudents", con);
                cmd.CommandType = CommandType.StoredProcedure;

                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    Students stud = new Students();

                    stud.StudId = Convert.ToInt32(rdr["StudId"]);
                    stud.Name = rdr["Name"].ToString();
                    stud.Address = rdr["Address"].ToString();
                    stud.DeptName = rdr["DeptName"].ToString();
                    stud.CratedDate = Convert.ToDateTime(rdr["CratedDate"].ToString());
                    stud.Marks = Convert.ToDecimal(rdr["Marks"].ToString());

                    students.Add(stud);
                }
                cmd.Dispose();
                con.Close();
            }
            return students;
        }
        public void UpdateStudents(Students stud)
        {
            Debug.WriteLine(stud.StudId + stud.Name + stud.Address + stud.DeptName + stud.Marks);

            using SqlConnection con = new SqlConnection(connectionString);
            SqlCommand cmd = new SqlCommand("spUpdateStudents", con);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@StudId", stud.StudId);
            cmd.Parameters.AddWithValue("@Name", stud.Name);
            cmd.Parameters.AddWithValue("@Address", stud.Address);
            cmd.Parameters.AddWithValue("@DeptName", stud.DeptName);
            cmd.Parameters.AddWithValue("@Marks", stud.Marks);

            con.Open();
            cmd.ExecuteNonQuery();
            cmd.Dispose();
            con.Close();


        }
        public Students GetStudentData(int? id)
        {
            Students students = new Students();

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string sqlQuery = "SELECT * FROM Students WHERE StudId= " + id;
                SqlCommand cmd = new SqlCommand(sqlQuery, con);

                con.Open();
                SqlDataReader rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    students.StudId = Convert.ToInt32(rdr["StudId"]);
                    students.Name = rdr["Name"].ToString();
                    students.Address = rdr["Address"].ToString();
                    students.DeptName = rdr["DeptName"].ToString();
                    students.Marks = Convert.ToDecimal(rdr["Marks"]);
                }
            }
            return students;
        }
        public void DeleteStudents(int? id)
        {

            using (SqlConnection con = new SqlConnection(connectionString))
            {
                SqlCommand cmd = new SqlCommand("spDeleteStudents", con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@StudId", id);

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }
    }
}
