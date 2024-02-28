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

        public IActionResult Index()
        {
            var branch = _dbContext.LibraryBranches.ToList();


            return View(branch);
        }
    }
}