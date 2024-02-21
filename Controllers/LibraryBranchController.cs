using Microsoft.AspNetCore.Mvc;
using LibraryManagement.Models;
using LibraryManagement.ViewModels;

namespace LibraryManagement.Controllers
{
    public class LibraryBranchController : Controller
    {
        public IActionResult Details(int id)
        {
            // Simulated data access
            LibraryBranch branch = new LibraryBranch
            {
                LibraryBranchId = id,
                BranchName = "Main Branch"
            };

            LibraryBranchViewModel viewModel = new LibraryBranchViewModel
            {
                LibraryBranchId = branch.LibraryBranchId,
                Name = branch.BranchName
            };

            return View(viewModel);
        }
    }
}