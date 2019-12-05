using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using StudentDetails.Models;
using System.Diagnostics;
namespace StudentDetails.Controllers
{
    public class HomeController : Controller
    {
       /* It is the main interface for implementing logging functionality.
        It is defined in the Microsoft. Extensions*/
        private readonly ILogger<HomeController> _logger;
        private readonly IMediator _mediator;

       
        public HomeController(ILogger<HomeController> logger, IMediator mediator)
        {
            _logger = logger;
           _mediator = mediator;
        }

      
        public IActionResult Index()
        {
            return View();
        }

      
        public IActionResult LoginTable()
        {
            return View();
        }
        
        [HttpPost]

        public IActionResult LoginTable(LoginTable user)
        {
            DataAccess dataAccess = new DataAccess();
         
         /*We pass  request model to the Handler via Send()*/
         var result = _mediator.Send(new RequestModel() { Email = user.EmailId, Password = user.Password });
          bool success = result.Result.Success;
          if (success)
          {
                HttpContext.Session.SetString("EmailId", user.EmailId);
              return RedirectToAction("Index","Students");
          }
          else
          {
              ViewData["Error"] = "Invalid Details";
              return View();
          }
         
        }
       public IActionResult InvalidSession()
        {
            return View();
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
      public IActionResult Error()
      {
          return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
      }
  }
}
