using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using LibraryManagement.Data;
using LibraryManagement.Models;
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

        // GET: Books
        public async Task<IActionResult> Index()
        {
            var books = await _dbContext.Books
                .Include(b => b.LibraryBranch)
                .Include(b => b.Author)
                .ToListAsync();

            return View(books);
        }

        // GET: Books/Create
        // GET: Books/Create
        public IActionResult Create()
        {
            ViewBag.Branches = new SelectList(_dbContext.LibraryBranches, "LibraryBranchId", "BranchName");
            ViewBag.Authors = new SelectList(_dbContext.Authors, "AuthorId", "Name");
            return View();
        }

        // POST: Books/Create
        [HttpPost]
        public async Task<IActionResult> Create([Bind("BookId,Title,AuthorId,LibraryBranchId")] Books book)
        {
            if (ModelState.IsValid)
            {
                if (BookExists(book.BookId))
                {
                    ModelState.AddModelError("BookId", "ID already exists.");
                    ViewBag.Branches = new SelectList(_dbContext.LibraryBranches, "LibraryBranchId", "BranchName", book.LibraryBranchId);
                    ViewBag.Authors = new SelectList(_dbContext.Authors, "AuthorId", "Name", book.AuthorId);
                    return View(book);
                }

                _dbContext.Add(book);
                await _dbContext.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewBag.Branches = new SelectList(_dbContext.LibraryBranches, "LibraryBranchId", "BranchName", book.LibraryBranchId);
            ViewBag.Authors = new SelectList(_dbContext.Authors, "AuthorId", "Name", book.AuthorId);
            return View(book);
        }


        // GET: Books/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var book = await _dbContext.Books.FindAsync(id);
            if (book == null)
            {
                return NotFound();
            }
            ViewBag.Branches = new SelectList(_dbContext.LibraryBranches, "LibraryBranchId", "BranchName", book.LibraryBranchId);
            ViewBag.Authors = new SelectList(_dbContext.Authors, "AuthorId", "Name", book.AuthorId);
            return View(book);
        }

        // POST: Books/Edit/5
        [HttpPost]
        public async Task<IActionResult> Edit(int id, [Bind("BookId,Title,AuthorId,LibraryBranchId")] Books book)
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
                    await _dbContext.SaveChangesAsync();
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
            ViewBag.Authors = new SelectList(_dbContext.Authors, "AuthorId", "Name", book.AuthorId);
            return View(book);
        }

        // GET: Books/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var book = await _dbContext.Books
                .Include(b => b.LibraryBranch)
                .Include(b => b.Author)
                .FirstOrDefaultAsync(m => m.BookId == id);

            if (book == null)
            {
                return NotFound();
            }

            return View(book);
        }

        // POST: Books/Delete/5
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
