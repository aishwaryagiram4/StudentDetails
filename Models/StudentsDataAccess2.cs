using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentDetails.Models
{
    public class StudentsDataAccess2 : IStudentsDataAccess
    {
        StudentDBContext studentDBContext;

        public StudentsDataAccess2(StudentDBContext context)
        {
            studentDBContext = context;
        }

        public bool AddStudents(Students student)
        {
          
            if (student.Marks > 100 || student.Marks < 0)
            {
                throw new ArgumentOutOfRangeException();
            }
            else if (string.IsNullOrEmpty(student.Name))
            {
                throw new ArgumentNullException(student.Name);
            }
            else if (string.IsNullOrEmpty(student.Address))
            {
                throw new ArgumentNullException(student.Address);
            }
            else if (string.IsNullOrEmpty(student.DeptName))
            {
                throw new ArgumentNullException(student.DeptName);
            }
            studentDBContext.Add(student);
            studentDBContext.SaveChanges();
           return true;
           
        }

        public IEnumerable<Students>Students()
        {
            return studentDBContext.Students.ToList(); ;
        }

        public void DeleteStudents(int? id)
        {
            var student = studentDBContext.Students.Find(Convert.ToInt64(id));
           
        
            studentDBContext.Students.Remove(student);
            studentDBContext.SaveChanges();
        }

        public void UpdateStudents(Students students)
        {
            studentDBContext.Update(students);
            studentDBContext.SaveChanges();
            
        }
        public Students GetStudentData(int? id)
        {
            Students student = studentDBContext.Students.Find(Convert.ToInt64(id));

            return student;
        }


 
    }
}
