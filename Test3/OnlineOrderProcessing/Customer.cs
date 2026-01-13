using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineOrderProcessing
{
    public class Customer
    {
        public int Id { get; }
        public string Name { get; }

        public Customer(int id, string name)
        {
            Id = id;
            Name = name;
        }
    }
}
