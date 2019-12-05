using System;
using System.ComponentModel.DataAnnotations;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;


namespace StudentDetails.Models
{
    public class EditStudentsRequestModel : IRequest<EditStudentsResponseModelResult>
    {
        [Required]
        public long StudId { get; set; }
        [Required]
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
    public class EditStudentsResponseModelResult
    {
        public bool Success { get; set; }
    }
    internal class EditStudentsHandler : IRequestHandler<EditStudentsRequestModel, EditStudentsResponseModelResult>
    {
        private readonly IStudentsDataAccess _studentsDataAccess;
        private readonly IMapper _mapper;
        public EditStudentsHandler(IStudentsDataAccess studentsDataAccess, IMapper mapper)
        {
            _studentsDataAccess = studentsDataAccess;
            _mapper = mapper;
        }
        public async Task<EditStudentsResponseModelResult> Handle(EditStudentsRequestModel request, CancellationToken cancellationToken)
        {
            _studentsDataAccess.UpdateStudents(_mapper.Map<Students>(request));
            return new EditStudentsResponseModelResult() { Success = true };
        }
    }
}
