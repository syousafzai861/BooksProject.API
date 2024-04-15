using System.ComponentModel.DataAnnotations;

namespace BooksProject.API.Models
{
    public class BookModel
    {

        public int Id { get; set; }
        [Required (ErrorMessage = "The Title Field Is Required")]
        public string Title { get; set; }
        public string Description { get; set; }
    }
}
