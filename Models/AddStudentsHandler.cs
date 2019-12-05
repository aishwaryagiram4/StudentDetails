using System;
using System.ComponentModel.DataAnnotations;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;

namespace StudentDetails.Models
{
    public class AddStudentsRequestModel : IRequest<AddStudentsResponseModelResult>
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
    public class AddStudentsResponseModelResult
    {
        public bool Success { get; set; }
    }
    internal class AddStudentsHandler : IRequestHandler<AddStudentsRequestModel, AddStudentsResponseModelResult>
    {
        private readonly IStudentsDataAccess _studentsDataAccess;
        private readonly IMapper _mapper;
        public AddStudentsHandler(IStudentsDataAccess studentsDataAccess, IMapper mapper)
        {
            _studentsDataAccess = studentsDataAccess;
            _mapper = mapper;
        }
        public async Task<AddStudentsResponseModelResult> Handle(AddStudentsRequestModel request, CancellationToken cancellationToken)
        {
            _studentsDataAccess.AddStudents(_mapper.Map<Students>(request));
            return new AddStudentsResponseModelResult() { Success = true };
        }
    }
}
