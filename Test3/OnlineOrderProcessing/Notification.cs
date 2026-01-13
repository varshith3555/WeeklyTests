using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineOrderProcessing
{
    public static class CustomerNotification
    {
        public static void Notify(Order order, OrderStatus oldStatus, OrderStatus newStatus)
        {
            Console.WriteLine($"[Customer] Order {order.Id} status changed to {newStatus}");
        }
    }

    public static class LogisticsNotification
    {
        public static void Notify(Order order, OrderStatus oldStatus, OrderStatus newStatus)
        {
            if (newStatus == OrderStatus.Shipped)
                Console.WriteLine($"[Logistics] Order {order.Id} ready for delivery");
        }
    }
}
