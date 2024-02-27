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
            LibraryBranches branch = new LibraryBranches
            {
                LibraryBranchId = id,
                BranchName = "Main Branch"
            };

            LibraryBranchesViewModel viewModel = new LibraryBranchesViewModel
            {
                LibraryBranchId = branch.LibraryBranchId,
                Name = branch.BranchName
            };

            return View(viewModel);
        }
    }
}