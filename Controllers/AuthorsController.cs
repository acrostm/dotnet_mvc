using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using LibraryManagement.Models;
using LibraryManagement.ViewModels;
using LibraryManagement.Data;

namespace LibraryManagement.Controllers
{
    public class AuthorsController : Controller
    {
        private readonly AppDbContext _dbContext;

        public AuthorsController(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        
        public IActionResult Details(int id)
        {
            // Simulated data access
            var author = _dbContext.Authors.FirstOrDefault(a => a.AuthorId == id);

            if (author == null)
            {
                return NotFound();
            }

            AuthorsViewModel viewModel = new AuthorsViewModel
            {
                AuthorId = author.AuthorId,
                Name = author.Name
            };

            return View(viewModel);
        }
    }
}
