using AutoMapper;


namespace StudentDetails.Models
{
    public class Mapping:Profile
    {
        public Mapping()
        {

            //AddStudents Model Mapping
            CreateMap<Students, AddStudentsRequestModel>().ReverseMap();//means you want to map from Students to AddStudentsRequestModel


            //UpdateStudents Model Mapping
            CreateMap<Students, EditStudentsRequestModel>();
            CreateMap<EditStudentsRequestModel, Students>();

            //GetStudents Data Model Mapping
            CreateMap<Students, GetStudentDataResponseModelResult>();
            CreateMap<GetStudentDataResponseModelResult, Students>();

            //Edit 
            CreateMap<GetStudentDataResponseModelResult, EditStudentsRequestModel>();
            CreateMap<EditStudentsRequestModel, GetStudentDataResponseModelResult>();

            //Delete
            CreateMap<Students, DeleteStudentDataRequestModel>();
            CreateMap<DeleteStudentDataResponseModelResult, Students>();

        }
}


}
