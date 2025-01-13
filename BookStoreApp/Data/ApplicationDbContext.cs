using Microsoft.EntityFrameworkCore;
using BookStoreApp.Models;
using System.Net;

namespace BookStoreApp.Data
{
    public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : DbContext(options)
    {
        public DbSet<Book> Books { get; set; }
        public DbSet <Cart> Carts { get; set; }

       
     

    }
}
