
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StudentDetails.Models;
using AutoMapper;
using MediatR;


namespace StudentDetails.Controllers
{
    public class LoginTablesController : Controller
    {
        private readonly StudentDBContext _context;
        private readonly IMediator _mediator;

        public LoginTablesController(StudentDBContext context, IMediator mediator)
        {
            _context = context;
            _mediator = mediator;
        }



        // GET: LoginTables
        //ToListAsync()=Creates a List<T> from an IQueryable by enumerating it asynchronously.
        public async Task<IActionResult> Index()
        {
            return View(await _context.LoginTable.ToListAsync());
        }

        // GET: LoginTables/Details/5
       
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }
            
            var loginTable = await _context.LoginTable
                .FirstOrDefaultAsync(m => m.EmailId == id);
            //returns the first element of a sequence, 
            //or a default value if the sequence contains no elements
            if (loginTable == null)
            {
                return NotFound();
            }

            return View(loginTable);
        }

        // GET: LoginTables/Create
       
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]// to check code is sent from the browser of a trusted user

        public async Task<IActionResult> Create([Bind("EmailId,Password")] LoginTable loginTable)
         {
             if (ModelState.IsValid)
             {
                 LoginTable myUser = _context.LoginTable.SingleOrDefault(user => user.EmailId == loginTable.EmailId);
                 if (myUser == null)
                 {
                     _context.Add(loginTable);
                     await _context.SaveChangesAsync();
                     return RedirectToAction("LoginTable", "Home");
                 }
                 else
                 {
                     ViewData["Error"] = "User Already Exists.";
                     return View();
                 }
             }
             return View(loginTable);

         }
    

            // GET: LoginTables/Edit/5
            public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var loginTable = await _context.LoginTable.FindAsync(id);
            if (loginTable == null)
            {
                return NotFound();
            }
            return View(loginTable);
        }

       
        [HttpPost]
        [ValidateAntiForgeryToken]
        
        public async Task<IActionResult> Edit(string id, [Bind("EmailId,Password")] LoginTable loginTable)
        {
            if (id != loginTable.EmailId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(loginTable);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LoginTableExists(loginTable.EmailId))
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
            return View(loginTable);
        }

        // GET: LoginTables/Delete/5
        
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var loginTable = await _context.LoginTable
                .FirstOrDefaultAsync(m => m.EmailId == id);
            if (loginTable == null)
            {
                return NotFound();
            }

            return View(loginTable);
        }
        

        // POST: LoginTables/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
       
        public async Task<IActionResult> DeleteConfirmed(long id)
        {
            var loginTable = await _context.LoginTable.FindAsync(id);
            _context.LoginTable.Remove(loginTable);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
       

        private bool LoginTableExists(string id)
        {
            return _context.LoginTable.Any(e => e.EmailId == id);
        }
    }
}
