using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebApplication2.Data;
using WebApplication2.Models;

namespace WebApplication2.Controllers
{
    public class ReaderController : Controller
    {
        private readonly LibraryContext _context;

        public ReaderController(LibraryContext context)
        {
            _context = context;
        }

        private string SavePath { get { return "/Image/"; } }

		// GET: Readers
		public IActionResult Index()
		{
			return View();
		}

		public async Task<IActionResult> List()
        {
            var libraryContext = _context.Readers.Include(r => r.ReaderGender).Include(r => r.ReaderRoles).Include(r => r.ReaderStatus).Include(r => r.ReaderType);
            return View(await libraryContext.ToListAsync());
        }

        // GET: Readers/Details/5
        public async Task<IActionResult> Details(uint? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var reader = await _context.Readers
                .Include(r => r.ReaderGender)
                .Include(r => r.ReaderRoles)
                .Include(r => r.ReaderStatus)
                .Include(r => r.ReaderType)
                .FirstOrDefaultAsync(m => m.ReaderId == id);
            if (reader == null)
            {
                return NotFound();
            }

            return View(reader);
        }

        // GET: Readers/Create
        public IActionResult Create()
        {
            ViewData["ReaderGenderId"] = new SelectList(_context.ReaderGender, "GenderId", "GenderName");
            ViewData["ReaderRolesId"] = new SelectList(_context.ReaderRole, "RoleId", "RoleName");
            ViewData["ReaderStatusId"] = new SelectList(_context.ReaderStatus, "StatusIdR", "StatusName");
            ViewData["ReaderTypeId"] = new SelectList(_context.ReaderType, "TypeId", "TypeName");
            return View();
        }

        // POST: Readers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ReaderId,ReaderName,ReaderPassword,ReaderTypeId,ReaderRolesId,ReaderStatusId,ReaderBorrowQuantity,ReaderGenderId,ReaderPhonenumber,ReaderEmail,ReaderDepartment,ReaderRegisterDate,ReaderPhoto")] Reader reader)
        {
            if (ModelState.IsValid)
            {
                _context.Add(reader);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ReaderGenderId"] = new SelectList(_context.ReaderGender, "GenderId", "GenderName", reader.ReaderGenderId);
            ViewData["ReaderRolesId"] = new SelectList(_context.ReaderRole, "RoleId", "RoleName", reader.ReaderRolesId);
            ViewData["ReaderStatusId"] = new SelectList(_context.ReaderStatus, "StatusIdR", "StatusName", reader.ReaderStatusId);
            ViewData["ReaderTypeId"] = new SelectList(_context.ReaderType, "TypeId", "TypeName", reader.ReaderTypeId);
            return View(reader);
        }

        // GET: Readers/Edit/5
        public async Task<IActionResult> Edit(uint? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var reader = await _context.Readers.FindAsync(id);
            if (reader == null)
            {
                return NotFound();
            }
            ViewData["ReaderGenderId"] = new SelectList(_context.ReaderGender, "GenderId", "GenderName", reader.ReaderGenderId);
            ViewData["ReaderRolesId"] = new SelectList(_context.ReaderRole, "RoleId", "RoleName", reader.ReaderRolesId);
            ViewData["ReaderStatusId"] = new SelectList(_context.ReaderStatus, "StatusIdR", "StatusName", reader.ReaderStatusId);
            ViewData["ReaderTypeId"] = new SelectList(_context.ReaderType, "TypeId", "TypeName", reader.ReaderTypeId);
            return View(reader);
        }

        // POST: Readers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(uint id, [Bind("ReaderId,ReaderName,ReaderPassword,ReaderTypeId,ReaderRolesId,ReaderStatusId,ReaderBorrowQuantity,ReaderGenderId,ReaderPhonenumber,ReaderEmail,ReaderDepartment,ReaderRegisterDate,ReaderPhoto")] Reader reader)
        {
            if (id != reader.ReaderId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(reader);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ReaderExists(reader.ReaderId))
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
            ViewData["ReaderGenderId"] = new SelectList(_context.ReaderGender, "GenderId", "GenderName", reader.ReaderGenderId);
            ViewData["ReaderRolesId"] = new SelectList(_context.ReaderRole, "RoleId", "RoleName", reader.ReaderRolesId);
            ViewData["ReaderStatusId"] = new SelectList(_context.ReaderStatus, "StatusIdR", "StatusName", reader.ReaderStatusId);
            ViewData["ReaderTypeId"] = new SelectList(_context.ReaderType, "TypeId", "TypeName", reader.ReaderTypeId);
            return View(reader);
        }

        // GET: Readers/Delete/5
        public async Task<IActionResult> Delete(uint? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var reader = await _context.Readers
                .Include(r => r.ReaderGender)
                .Include(r => r.ReaderRoles)
                .Include(r => r.ReaderStatus)
                .Include(r => r.ReaderType)
                .FirstOrDefaultAsync(m => m.ReaderId == id);
            if (reader == null)
            {
                return NotFound();
            }

            return View(reader);
        }

        // POST: Readers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(uint id)
        {
            var reader = await _context.Readers.FindAsync(id);
            _context.Readers.Remove(reader);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ReaderExists(uint id)
        {
            return _context.Readers.Any(e => e.ReaderId == id);
        }
    }
}
