// LibraryBranchesController.cs
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using LibraryManagement.Models;
using LibraryManagement.ViewModels;
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

        public IActionResult Details()
        {
            var branches = _dbContext.LibraryBranches.ToList();

            // LibraryBranchesViewModel viewModel = new LibraryBranchesViewModel
            // {
            //     LibraryBranchId = branch.LibraryBranchId,
            //     Name = branch.BranchName
            // };

            return View(branches);
        }
    }
}