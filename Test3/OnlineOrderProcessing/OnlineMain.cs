using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineOrderProcessing
{
    class OnlineMain
    {
        static void Main()
        {
            // Add the products
            var products = new Dictionary<int, Product>
            {
                {1, new Product(1, "Laptop", 50000)},
                {2, new Product(2, "Mouse", 500)},
                {3, new Product(3, "Keyboard", 1500)},
                {4, new Product(4, "Monitor", 12000)},
                {5, new Product(5, "Headphones", 3000)}
            };

            // Add customers
            var customers = new List<Customer>
            {
                new Customer(1, "Varshith"),
                new Customer(2, "Nani"),
                new Customer(3, "Vivek")
            };

            // Orders
            var orders = new List<Order>();
            /// This is order1
            var order1 = new Order(101, customers[0]);
            order1.AddItem(products[1], 1);
            order1.AddItem(products[2], 2);

            order1.StatusChanged += CustomerNotification.Notify;
            order1.StatusChanged += LogisticsNotification.Notify;
            orders.Add(order1);

            Console.WriteLine($"Order {order1.Id} created for {order1.Customer.Name}");
            order1.PrintItems();
            Console.WriteLine($"Total: {order1.CalculateTotal()}");

            order1.ChangeStatus(OrderStatus.Paid);
            order1.ChangeStatus(OrderStatus.Packed);
            order1.ChangeStatus(OrderStatus.Shipped);
            order1.ChangeStatus(OrderStatus.Delivered);

            PrintSummary(order1);

            /// This is order2
            var order2 = new Order(102, customers[1]);
            order2.AddItem(products[3], 1);
            order2.AddItem(products[5], 1);

            order2.StatusChanged += CustomerNotification.Notify;
            order2.StatusChanged += LogisticsNotification.Notify;
            orders.Add(order2);

            Console.WriteLine($"\nOrder {order2.Id} created for {order2.Customer.Name}");
            order2.PrintItems();
            Console.WriteLine($"Total: {order2.CalculateTotal()}");

            order2.ChangeStatus(OrderStatus.Shipped); // INVALID
            order2.ChangeStatus(OrderStatus.Paid);
            order2.ChangeStatus(OrderStatus.Packed);

            PrintSummary(order2);

            /// This is order3
            var order3 = new Order(103, customers[1]);
            order3.AddItem(products[4], 1);
            order3.AddItem(products[2], 1);

            order3.StatusChanged += CustomerNotification.Notify;
            order3.StatusChanged += LogisticsNotification.Notify;
            orders.Add(order3);

            Console.WriteLine($"\nOrder {order3.Id} created for {order3.Customer.Name}");
            order3.PrintItems();
            Console.WriteLine($"Total: {order3.CalculateTotal()}");

            order3.ChangeStatus(OrderStatus.Paid);
            order3.ChangeStatus(OrderStatus.Packed);
            order3.ChangeStatus(OrderStatus.Shipped);

            PrintSummary(order3);

            var order4 = new Order(103, customers[2]);
            order4.AddItem(products[3], 1);
            order4.AddItem(products[2], 1);

            order4.StatusChanged += CustomerNotification.Notify;
            order4.StatusChanged += LogisticsNotification.Notify;
            orders.Add(order4);

            Console.WriteLine($"\nOrder {order4.Id} created for {order4.Customer.Name}");
            order4.PrintItems();
            Console.WriteLine($"Total: {order4.CalculateTotal()}");

            order4.ChangeStatus(OrderStatus.Paid);
            order4.ChangeStatus(OrderStatus.Packed);
            order4.ChangeStatus(OrderStatus.Shipped);

            PrintSummary(order4);
        }
        static void PrintSummary(Order order)
        {
            Console.WriteLine("\nOrder Summary:");
            Console.WriteLine($"Order ID: {order.Id}");
            Console.WriteLine($"Customer: {order.Customer.Name}");
            Console.WriteLine($"Current Status: {order.Status}");

            foreach (var log in order.StatusHistory)
            {
                Console.WriteLine($"{log.Status} at {log.ChangedAt}");
            }

            Console.WriteLine(new string('-', 50));
        }
    }
}
