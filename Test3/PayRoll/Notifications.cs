using System;
using System.Collections.Generic;
using System.Text;

namespace PayRoll
{
    /// <summary>
    /// HR department notification
    /// </summary>
    public static class HRNotification
    {
        public static void Notify(Employee emp, PaySlip slip)
        {
            Console.WriteLine($"[HR] {emp.Name} | Gross: {slip.Gross} | Deduction: {slip.Deductions} | Net: {slip.Net}");
        }
    }
    /// <summary>
    /// Finance department notification
    /// </summary>
    public static class FinanceNotification
    {
        public static void Notify(Employee emp, PaySlip slip)
        {
            Console.WriteLine($"[Finance] Payment recorded for {emp.Name} | Net: {slip.Net}");
        }
    }
}
