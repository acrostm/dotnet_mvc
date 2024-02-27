// LibraryBranches.cs
using System.ComponentModel.DataAnnotations;

namespace LibraryManagement.Models
{
    public class LibraryBranches
    {
        [Key]
        public int LibraryBranchId { get; set; }
        public string? BranchName { get; set; }
    }
}
