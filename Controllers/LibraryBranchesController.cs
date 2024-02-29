// LibraryBranchesController.cs
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using LibraryManagement.Models;
using System.Linq;
using LibraryManagement.Data;

namespace LibraryManagement.Controllers
{
    public class LibraryBranchesController : Controller
    {
        private readonly AppDbContext _dbContext;

        public LibraryBranchesController(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IActionResult Index()
        {
            var branch = _dbContext.LibraryBranches.ToList();


            return View(branch);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create([Bind("LibraryBranchId,BranchName")] LibraryBranches branch)
        {
            if (ModelState.IsValid)
            {
                if (LibraryBranchExist(branch.LibraryBranchId))
                {
                    ModelState.AddModelError("LibraryBranchId", "ID already exists.");
                    return View(branch);
                }

                _dbContext.Add(branch);
                _dbContext.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(branch);
        }

        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var branch = _dbContext.LibraryBranches.Find(id);

            if (branch == null)
            {
                return NotFound();
            }

            return View(branch);
        }

        [HttpPost]
        public IActionResult Edit(int id, [Bind("LibraryBranchId,BranchName")] LibraryBranches branch)
        {
            if (id != branch.LibraryBranchId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _dbContext.Update(branch);
                    _dbContext.SaveChanges();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LibraryBranchExist(branch.LibraryBranchId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        if (!LibraryBranchExist(branch.LibraryBranchId))
                        {
                            return NotFound();
                        }
                        else
                        {
                            throw;
                        }
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(branch);
        }

        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var branch = _dbContext.LibraryBranches
                .FirstOrDefaultAsync(m => m.LibraryBranchId == id);

            if (branch == null)
            {
                return NotFound();
            }

            return View(branch);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            var branch = _dbContext.LibraryBranches.Find(id);
            _dbContext.LibraryBranches.Remove(branch);
            _dbContext.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        private bool LibraryBranchExist(int id)
        {
            return _dbContext.LibraryBranches.Any(e => e.LibraryBranchId == id);
        }
    }
}