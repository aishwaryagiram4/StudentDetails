using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace StudentDetails.Models
{
    public class DeleteStudentDataRequestModel : IRequest<DeleteStudentDataResponseModelResult>
    {
        [Key]
        public int? StudId { get; set; }

        public string Name { get; set; }
        [Required]
        public string Address { get; set; }
        [Required]
        public string DeptName { get; set; }
        [Required]
        public decimal Marks { get; set; }
        [Required]
        public DateTime CratedDate { get; set; }
    }
    public class DeleteStudentDataResponseModelResult
    {
        public bool Success { get; set; }
    }
    internal class DeleteStudentDataHandler : IRequestHandler<DeleteStudentDataRequestModel, DeleteStudentDataResponseModelResult>
    {
        private readonly IStudentsDataAccess _studentsDataAccess;
   
        public DeleteStudentDataHandler(IStudentsDataAccess studentsDataAccess)
        {

            _studentsDataAccess = studentsDataAccess;
        }
        public async Task<DeleteStudentDataResponseModelResult> Handle(DeleteStudentDataRequestModel request, CancellationToken cancellationToken)
        {
            _studentsDataAccess.DeleteStudents(request.StudId);
            return new DeleteStudentDataResponseModelResult() { Success = true };
   
        }
       
    }
}
