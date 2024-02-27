// Authors.cs
using System.ComponentModel.DataAnnotations;

namespace LibraryManagement.Models
{
    public class Authors
    {
        [Key]
        public int AuthorId { get; set; }
        public string? Name { get; set; }
    }
}
