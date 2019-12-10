using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using StudentDetails.Models;
using StudentDetails.Models.Infrastructure;
using System;
using System.ComponentModel.DataAnnotations;

namespace StudentDetails.Controllers

{
    public class StudentsController : Controller
    {
        private readonly IMediator _mediator;
        IStudentsDataAccess studentsDataAccess;
        private readonly IMapper _mapper;

        public StudentsController(IStudentsDataAccess _studentsDataAccess, IMediator mediator,IMapper mapper)
        {
            studentsDataAccess = _studentsDataAccess;
            _mediator = mediator;
            _mapper = mapper;

        }

        // GET: Students
        [Authorize]
        public  IActionResult Index()
        {
             return View(studentsDataAccess.Students());

           
        }
        [HttpGet]
        [Authorize]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [Authorize]
        public ActionResult Create(AddStudentsRequestModel stud)
        {
    
            if (ModelState.IsValid)
            {
                _mediator.Send(stud);
                return RedirectToAction("Index");
            }
            else
            {
                return View(stud);  
            }
        }
        [Authorize]
        public IActionResult Edit(int? id)
        {
           var stud = _mediator.Send(new GetStudentDataRequestModel { StudId = id });
           return View(_mapper.Map<EditStudentsRequestModel>(stud.Result));
        }

       
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize]
        public ActionResult Edit(EditStudentsRequestModel students)
        {
           _mediator.Send(students);
            return RedirectToAction("Index");
        }
        [Authorize]
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            return View(_mediator.Send(new GetStudentDataRequestModel { StudId = id}).Result);
        }
        [Authorize]
        public IActionResult Delete(int? id)
         {
            var stud = _mediator.Send(new GetStudentDataRequestModel { StudId = id });
            return View(_mapper.Map<Students>(stud.Result));
        }
         [HttpPost, ActionName("Delete")]
         [ValidateAntiForgeryToken]
        [Authorize]
        public IActionResult DeleteConfirmed(int? id)
        {
           _mediator.Send(new DeleteStudentDataRequestModel { StudId = id });
           return RedirectToAction("index");
        }

        


        [Authorize]
       [Route("Logout")]
      public IActionResult Logout()
        {
            HttpContext.Session.Remove("EmailId");
            return RedirectToAction("Index", "Home");
        }

       
    }
}
