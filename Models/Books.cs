using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LibraryManagement.Models
{
    public class Books
    {
        [Key]
        public int BookId { get; set; }

        [Required]
        public string Title { get; set; }

        [ForeignKey("Author")]
        public int AuthorId { get; set; }
        public Authors Author { get; set; }

        [ForeignKey("LibraryBranch")]
        public int? LibraryBranchId { get; set; }
        public LibraryBranches LibraryBranch { get; set; }
    }
}