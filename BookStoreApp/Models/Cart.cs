﻿namespace BookStoreApp.Models
{
    public class Cart
    {
        public int Id { get; set; }
        public Book Book { get; set; }
        public int Quantity { get; set; }

      public decimal TotalPrice { get; set; }

        
        
    }
}
