using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace StudentDetails.Models
{
    public class RequestModel : IRequest<ResponseModelResult>
    {
        public string Email { get; set; }

        public string Password { get; set; }
    }
    public class ResponseModelResult
    {
        public bool Success { get; set; }
        public string ResponseText { get; set; }
    }
    internal class LoginHandler : IRequestHandler<RequestModel, ResponseModelResult>
    {
        public LoginHandler()
        {

        }
        public async Task<ResponseModelResult> Handle(RequestModel request, CancellationToken cancellationToken)
        {
            


            DataAccess dataAccess = new DataAccess();
             LoginTable user = new LoginTable();
             user.EmailId = request.Email;
             user.Password = request.Password;
             bool success = dataAccess.CheckLogin(user);
             return new ResponseModelResult() { Success = success, ResponseText = "Login Successfull" };
        }
    }
}
