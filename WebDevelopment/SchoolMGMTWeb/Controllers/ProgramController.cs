﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
//using SchoolMGMTWeb.Data;
//using SchoolManagement.ApplicationCore.Models;;
using SchoolManagement.ApplicationCore.Models;
using SchoolManagement.Infrastructure.Data;

namespace SchoolMGMTWeb.Controllers
{
    public class ProgramController : Controller
    {
        private readonly SchoolContext _context;

        public ProgramController(SchoolContext context)
        {
            _context = context;
        }

        // GET: Program
        public async Task<IActionResult> Index()
        {
              return View(await _context.Programs.ToListAsync());
        }

        // GET: Program/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Programs == null)
            {
                return NotFound();
            }

            var program = await _context.Programs
                .FirstOrDefaultAsync(m => m.Id == id);
            if (program == null)
            {
                return NotFound();
            }

            return View(program);
        }

        // GET: Program/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Program/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Stream,Details,Established")] Program program)
        {
            if (ModelState.IsValid)
            {
                _context.Add(program);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(program);
        }

        // GET: Program/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Programs == null)
            {
                return NotFound();
            }

            var program = await _context.Programs.FindAsync(id);
            if (program == null)
            {
                return NotFound();
            }
            return View(program);
        }

        // POST: Program/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Stream,Details,Established")] Program program)
        {
            if (id != program.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(program);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProgramExists(program.Id))
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
            return View(program);
        }

        // GET: Program/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Programs == null)
            {
                return NotFound();
            }

            var program = await _context.Programs
                .FirstOrDefaultAsync(m => m.Id == id);
            if (program == null)
            {
                return NotFound();
            }

            return View(program);
        }

        // POST: Program/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Programs == null)
            {
                return Problem("Entity set 'SchoolContext.Programs'  is null.");
            }
            var program = await _context.Programs.FindAsync(id);
            if (program != null)
            {
                _context.Programs.Remove(program);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProgramExists(int id)
        {
          return _context.Programs.Any(e => e.Id == id);
        }
    }
}
