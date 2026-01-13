using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineOrderProcessing
{
    public class OrderItem
    {
        public Product Product { get; }
        public int Quantity { get; }

        public OrderItem(Product product, int quantity)
        {
            Product = product;
            Quantity = quantity;
        }

        public decimal SubTotal => Product.Price * Quantity;
    }
}
