// BooksController.cs
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using LibraryManagement.Data;
using LibraryManagement.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace LibraryManagement.Controllers
{
    public class BooksController : Controller
    {
        private readonly AppDbContext _dbContext;

        public BooksController(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IActionResult Index()
        {
            var books = _dbContext.Books
                .Include(b => b.LibraryBranch)
                .Include(b => b.Author)
                .ToList();

            return View(books);
        }

        public IActionResult Create()
        {
            ViewBag.Branches = new SelectList(_dbContext.LibraryBranches, "LibraryBranchId", "BranchName");
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Books book)
        {
            if (ModelState.IsValid)
            {
                if (BookExists(book.BookId))
                {
                    ModelState.AddModelError("BookId", "ID already exists.");
                    return View(book);
                }
                _dbContext.Books.Add(book);
                await _dbContext.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            ViewBag.Branches = new SelectList(_dbContext.LibraryBranches, "LibraryBranchId", "BranchName", book.LibraryBranchId);
            return View(book);
        }

        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var book = _dbContext.Books.Find(id);
            if (book == null)
            {
                return NotFound();
            }

            ViewBag.Branches = new SelectList(_dbContext.LibraryBranches, "LibraryBranchId", "BranchName", book.LibraryBranchId);
            return View(book);
        }

        [HttpPost]
        public IActionResult Edit(int id, Books book)
        {
            if (id != book.BookId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _dbContext.Update(book);
                    _dbContext.SaveChanges();
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

            ViewBag.Branches = new SelectList(_dbContext.LibraryBranches, "LibraryBranchId", "BranchName", book.LibraryBranchId);
            return View(book);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var book = await _dbContext.Books
                .FirstOrDefaultAsync(m => m.BookId == id);

            if (book == null)
            {
                return NotFound();
            }

            return View(book);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var book = await _dbContext.Books.FindAsync(id);
            _dbContext.Books.Remove(book);
            await _dbContext.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BookExists(int id)
        {
            return _dbContext.Books.Any(e => e.BookId == id);
        }
    }
}
