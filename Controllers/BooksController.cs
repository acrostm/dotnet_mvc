// BookController.cs
using Microsoft.AspNetCore.Mvc;
using LibraryManagement.Models;
using LibraryManagement.ViewModels;

namespace LibraryManagement.Controllers
{
    public class BookController : Controller
    {
        public IActionResult Details(int id)
        {
            // Simulated data access
            Books book = new Books
            {
                BookId = id,
                Title = "Sample Book",
                AuthorId = 1,
                LibraryBranchId = 1
            };

            Authors author = new Authors
            {
                AuthorId = 1,
                Name = "John Doe"
            };

            LibraryBranches branch = new LibraryBranches
            {
                LibraryBranchId = 1,
                BranchName = "Main Branch"
            };

            BooksViewModel viewModel = new BooksViewModel
            {
                BookId = book.BookId,
                Title = book.Title,
                AuthorName = author.Name,
                BranchName = branch.BranchName
            };

            return View(viewModel);
        }
    }
}
