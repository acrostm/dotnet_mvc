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
                .ToList();

            return View(books);
        }

        public IActionResult Create()
        {
            ViewBag.Branches = new SelectList(_dbContext.LibraryBranches, "LibraryBranchId", "BranchName");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Books book)
        {
            if (ModelState.IsValid)
            {
                _dbContext.Books.Add(book);
                _dbContext.SaveChanges();
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
        [ValidateAntiForgeryToken]
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

        private bool BookExists(int id)
        {
            return _dbContext.Books.Any(e => e.BookId == id);
        }
    }
}
