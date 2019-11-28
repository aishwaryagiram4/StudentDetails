using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using StudentDetails.Models;


namespace StudentDetails.Controllers
{
    public class StudentsController : Controller
    {
        //ADO.NET
       StudentsDataAccess studentsDataAccess = new StudentsDataAccess();
       // StudentsDataAccess2 studentsDataAccess;

        public StudentsController(StudentDBContext context)
        {
            //studentsDataAccess = new StudentsDataAccess2(context);
        }

        // GET: Students
        public  IActionResult Index()
        {
            return View(studentsDataAccess.Students());
        }

        // GET: Students/Details/5
       /* public async Task<IActionResult> Details(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var students = await _context.Students
                .FirstOrDefaultAsync(m => m.StudId == id);
            if (students == null)
            {
                return NotFound();
            }

            return View(students);
        }*/

        // GET: Students/Create
        /*public IActionResult Create()
        {
            return View();
        }

        // POST: Students/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("StudId,Name,Address,DeptName,Marks,CratedDate")] Students students)
        {
            if (ModelState.IsValid)
            {
                _context.Add(students);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(students);
        }*/

        // GET: Students/Edit/5
       /* public async Task<IActionResult> Edit(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var students = await _context.Students.FindAsync(id);
            if (students == null)
            {
                return NotFound();
            }
            return View(students);
        }*/

        // POST: Students/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
       /* [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id, [Bind("StudId,Name,Address,DeptName,Marks,CratedDate")] Students students)
        {
            if (id != students.StudId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(students);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!StudentsExists(students.StudId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(students);
        }

        // GET: Students/Delete/5
        public async Task<IActionResult> Delete(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var students = await _context.Students
                .FirstOrDefaultAsync(m => m.StudId == id);
            if (students == null)
            {
                return NotFound();
            }

            return View(students);
        }*/

        [HttpGet]
         public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Students stud)
        {
            studentsDataAccess.AddStudents(stud);
            return RedirectToAction("Index");
        }
        public IActionResult Edit(int? id)
        {
            
            Students students = studentsDataAccess.GetStudentData(id);
            
            return View(students);
        }
       
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, [Bind]Students students)
        {
                studentsDataAccess.UpdateStudents(students);
                return RedirectToAction("Index");
         }
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            Students students = studentsDataAccess.GetStudentData(id);
            if (students == null)
            {
                return NotFound();
            }
            return View(students);
        }
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            Students students = studentsDataAccess.GetStudentData(id);

            if (students == null)
            {
                return NotFound();
            }
            return View(students);
        }
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int? id)
        {
            studentsDataAccess.DeleteStudents(id);
            return RedirectToAction("Index");
        }






        // POST: Students/Delete/5
        /*  [HttpPost, ActionName("Delete")]
          [ValidateAntiForgeryToken]
          public async Task<IActionResult> DeleteConfirmed(long id)
          {
              var students = await _context.Students.FindAsync(id);
              _context.Students.Remove(students);
              await _context.SaveChangesAsync();
              return RedirectToAction(nameof(Index));
          }*/

    }
}
