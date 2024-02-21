using Microsoft.AspNetCore.Mvc;
using LibraryManagement.Models;
using LibraryManagement.ViewModels;

namespace LibraryManagement.Controllers
{
    public class AuthorController : Controller
    {
        public IActionResult Details(int id)
        {
            // Simulated data access
            Author author = new Author
            {
                AuthorId = id,
                Name = "John Doe"
            };

            AuthorViewModel viewModel = new AuthorViewModel
            {
                AuthorId = author.AuthorId,
                Name = author.Name
            };

            return View(viewModel);
        }
    }
}