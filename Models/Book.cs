// Book.cs
using System;
using System.ComponentModel.DataAnnotations;

namespace LibraryManagement.Models
{
    public class Book
    {
        [Key]
        public int BookId { get; set; }
        public required string Title { get; set; }
        public int AuthorId { get; set; }
        public int? LibraryBranchId { get; set; }
        public DateTime CreateAt { get; set; }
    }
}