using Microsoft.AspNetCore.Mvc;
using LibraryManagement.Models;
using LibraryManagement.ViewModels;

namespace LibraryManagement.Controllers
{
    public class CustomerController : Controller
    {
        public IActionResult Details(int id)
        {
            // Simulated data access
            Customer customer = new Customer
            {
                CustomerId = id,
                Name = "John Doe"
            };

            CustomerViewModel viewModel = new CustomerViewModel
            {
                CustomerId = customer.CustomerId,
                Name = customer.Name
            };

            return View(viewModel);
        }
    }
}