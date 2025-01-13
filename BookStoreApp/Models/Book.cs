using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookStoreApp.Models
{
    public class Book
    {
        
        public int BookId { get; set;}
        public required string Title { get; set; }

        public required string Description { get; set; }
        public required string Author { get; set; }
        public required string ISBN {  get; set; }
         
        public int PublishedYear { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal Price { get; set; }

        
      
    }
}
