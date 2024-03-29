// BookViewModels.cs
namespace LibraryManagement.ViewModels
{
    public class BooksViewModel
    {
        public int BookId { get; set; }
        public string? Title { get; set; }
        public string? AuthorName { get; set; }
        public string? BranchName { get; set; }
    }
}
