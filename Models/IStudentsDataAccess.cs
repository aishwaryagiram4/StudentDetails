using System.Collections.Generic;

namespace StudentDetails.Models
{
    public interface IStudentsDataAccess
    {
        void AddStudents(Students stud);
        void DeleteStudents(int? id);
        Students GetStudentData(int? id);
        IEnumerable<Students> Students();
        void UpdateStudents(Students stud);
    }
}