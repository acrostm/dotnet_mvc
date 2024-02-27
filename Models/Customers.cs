// Customers.cs
using System;
using System.ComponentModel.DataAnnotations;

namespace LibraryManagement.Models
{
    public class Customers
    {
        [Key]
        public int CustomerId { get; set; }
        public string? Name { get; set; }
    }
}
