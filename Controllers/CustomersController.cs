using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using LibraryManagement.Models;
using LibraryManagement.ViewModels;
using LibraryManagement.Data;

namespace LibraryManagement.Controllers
{
    public class CustomersController : Controller
    {
        private readonly AppDbContext _dbContext;

        public CustomersController(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public IActionResult Details(int id)
        {
            var customers = _dbContext.Customers.ToList();

            return View(customers);
        }
    }
}