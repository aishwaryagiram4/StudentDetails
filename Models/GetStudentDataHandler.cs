using System;
using System.ComponentModel.DataAnnotations;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;


namespace StudentDetails.Models
{
    public class GetStudentDataRequestModel : IRequest<GetStudentDataResponseModelResult>
    {
        [Key]
        public int? StudId { get; set; }

    }
    public class GetStudentDataResponseModelResult
    {
        [Required]
        public int? StudId { get; set; }
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
    internal class GetStudentDataHandler : IRequestHandler<GetStudentDataRequestModel, GetStudentDataResponseModelResult>
    {
        private readonly IStudentsDataAccess _studentsDataAccess;
        private readonly IMapper _mapper;
        public GetStudentDataHandler(IStudentsDataAccess studentsDataAccess, IMapper mapper)
        {
            _studentsDataAccess = studentsDataAccess;
            _mapper = mapper;
        }
        public async Task<GetStudentDataResponseModelResult> Handle(GetStudentDataRequestModel request, CancellationToken cancellationToken)
        {
            var stud = _mapper.Map<GetStudentDataResponseModelResult>(_studentsDataAccess.GetStudentData(request.StudId));
            return stud; 
        }
    }
}
