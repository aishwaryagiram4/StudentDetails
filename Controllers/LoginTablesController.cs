﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using StudentDetails.Models;

namespace StudentDetails.Controllers
{
    public class LoginTablesController : Controller
    {
        private readonly StudentDBContext _context;

        public LoginTablesController(StudentDBContext context)
        {
            _context = context;
        }

        // GET: LoginTables
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

        // POST: LoginTables/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("EmailId,Password")] LoginTable loginTable)
        {
            if (ModelState.IsValid)
            {
                _context.Add(loginTable);
                await _context.SaveChangesAsync();
                return RedirectToAction("LoginTable", "Home");
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

        // POST: LoginTables/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
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
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
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
