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
    public class BookController : Controller
    {
        private readonly LibraryContext _context;

        public BookController(LibraryContext context)
        {
            _context = context;
        }

        // GET: Book
        public async Task<IActionResult> Index(string searchString)
        {
            var libraryContext = _context.Books.Include(b => b.BookLanguage).Include(b => b.BookStatus);

            if (!string.IsNullOrEmpty(searchString))
            {
                libraryContext = _context.Books.Where(x => x.BookName.Contains(searchString))
                    .Include(b => b.BookLanguage).Include(b => b.BookStatus);				

                return View(await libraryContext.ToListAsync());
            }           
            return View(await libraryContext.ToListAsync());
        }

        // GET: Book/Details/5
        public async Task<IActionResult> Details(uint? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var book = await _context.Books
                .Include(b => b.BookLanguage)
                .Include(b => b.BookStatus)
                .FirstOrDefaultAsync(m => m.BookId == id);
            if (book == null)
            {
                return NotFound();
            }

            return View(book);
        }

        // GET: Book/Create
        public IActionResult Create()
        {
            ViewData["BookLanguageId"] = new SelectList(_context.BookLanguage, "LanguageId", "LanguageName");
            ViewData["BookStatusId"] = new SelectList(_context.BookStatus, "StatusId", "StatusName");
            return View();
        }

        // POST: Book/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("BookId,BookCode,BookName,BookNameSub,BookIsbn,BookClccode,BookStatusId,BookAuthor,BookPublisher,BookPressDate,BookLanguageId,BookPages,BookPrice,BookPurchaseDate,BookBrief,BookCover")] Book book)
        {
            if (ModelState.IsValid)
            {
                _context.Add(book);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["BookLanguageId"] = new SelectList(_context.BookLanguage, "LanguageId", "LanguageName", book.BookLanguageId);
            ViewData["BookStatusId"] = new SelectList(_context.BookStatus, "StatusId", "StatusName", book.BookStatusId);
            return View(book);
        }

        // GET: Book/Edit/5
        public async Task<IActionResult> Edit(uint? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var book = await _context.Books.FindAsync(id);
            if (book == null)
            {
                return NotFound();
            }
            ViewData["BookLanguageId"] = new SelectList(_context.BookLanguage, "LanguageId", "LanguageName", book.BookLanguageId);
            ViewData["BookStatusId"] = new SelectList(_context.BookStatus, "StatusId", "StatusName", book.BookStatusId);
            return View(book);
        }

        // POST: Book/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(uint id, [Bind("BookId,BookCode,BookName,BookNameSub,BookIsbn,BookClccode,BookStatusId,BookAuthor,BookPublisher,BookPressDate,BookLanguageId,BookPages,BookPrice,BookPurchaseDate,BookBrief,BookCover")] Book book)
        {
            if (id != book.BookId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(book);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BookExists(book.BookId))
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
            ViewData["BookLanguageId"] = new SelectList(_context.BookLanguage, "LanguageId", "LanguageName", book.BookLanguageId);
            ViewData["BookStatusId"] = new SelectList(_context.BookStatus, "StatusId", "StatusName", book.BookStatusId);
            return View(book);
        }

        // GET: Book/Delete/5
        public async Task<IActionResult> Delete(uint? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var book = await _context.Books
                .Include(b => b.BookLanguage)
                .Include(b => b.BookStatus)
                .FirstOrDefaultAsync(m => m.BookId == id);
            if (book == null)
            {
                return NotFound();
            }

            return View(book);
        }

        // POST: Book/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(uint id)
        {
            var book = await _context.Books.FindAsync(id);
            _context.Books.Remove(book);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BookExists(uint id)
        {
            return _context.Books.Any(e => e.BookId == id);
        }
    }
}
