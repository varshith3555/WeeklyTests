using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineOrderProcessing
{
    public class Order
    {
        public int Id { get; }
        public Customer Customer { get; }
        public List<OrderItem> Items { get; }
        public OrderStatus Status { get; private set; }

        private List<OrderStatusLog> statusHistory;

        public IReadOnlyList<OrderStatusLog> StatusHistory => statusHistory.AsReadOnly();

        public OrderStatusChangedHandler StatusChanged;


        public Order(int id, Customer customer)
        {
            Id = id;
            Customer = customer;
            Items = new List<OrderItem>();
            statusHistory = new List<OrderStatusLog>();
            Status = OrderStatus.Created;
            statusHistory.Add(new OrderStatusLog(Status));
        }

        public void AddItem(Product product, int qty)
        {
            Items.Add(new OrderItem(product, qty));
        }

        public decimal CalculateTotal()
        {
            decimal total = 0;
            foreach (var item in Items)
                total += item.SubTotal;

            decimal tax = total * 0.05m;
            return total + tax;
        }

        public void ChangeStatus(OrderStatus newStatus)
        {
            if (!IsValidTransition(Status, newStatus))
            {
                Console.WriteLine($"Invalid transition: {Status} -> {newStatus}");
                return;
            }

            var oldStatus = Status;
            Status = newStatus;
            statusHistory.Add(new OrderStatusLog(newStatus));

            StatusChanged?.Invoke(this, oldStatus, newStatus);
        }

        private bool IsValidTransition(OrderStatus oldStatus, OrderStatus newStatus)
        {
            if (oldStatus == OrderStatus.Cancelled)
                return false;

            return (oldStatus, newStatus) switch
            {
                (OrderStatus.Created, OrderStatus.Paid) => true,
                (OrderStatus.Paid, OrderStatus.Packed) => true,
                (OrderStatus.Packed, OrderStatus.Shipped) => true,
                (OrderStatus.Shipped, OrderStatus.Delivered) => true,
                (_, OrderStatus.Cancelled) => true,
                _ => false
            };
        }
        public void PrintItems()
        {
            Console.WriteLine("Items:");
            foreach (var item in Items)
            {
                Console.WriteLine($"{item.Product.Name} x{item.Quantity} = {item.SubTotal}");
            }
        }
    }
}
