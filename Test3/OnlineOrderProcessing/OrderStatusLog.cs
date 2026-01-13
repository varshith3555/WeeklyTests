using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineOrderProcessing
{
    public class OrderStatusLog
    {
        public OrderStatus Status { get; }
        public DateTime ChangedAt { get; }

        public OrderStatusLog(OrderStatus status)
        {
            Status = status;
            ChangedAt = DateTime.Now;
        }
    }

}
