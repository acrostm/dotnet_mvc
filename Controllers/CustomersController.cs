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
            Customers customer = new Customers
            {
                CustomerId = id,
                Name = "John Doe"
            };

            CustomersViewModel viewModel = new CustomersViewModel
            {
                CustomerId = customer.CustomerId,
                Name = customer.Name
            };

            return View(viewModel);
        }
    }
}