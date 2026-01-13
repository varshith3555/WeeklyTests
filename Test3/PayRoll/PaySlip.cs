using System;
using System.Collections.Generic;
using System.Text;

namespace PayRoll
{
    /// <summary>
    /// Holds the salary details of an employee
    /// </summary>
    public class PaySlip
    {
        public int EmployeeId { get; }
        public string Name { get; }
        public string Type { get; }
        public decimal Gross { get; }
        public decimal Deductions { get; }
        public decimal Net { get; }

        public PaySlip(int id, string name, string type, decimal gross, decimal deductions, decimal net)
        {
            EmployeeId = id;
            Name = name;
            Type = type;
            Gross = gross;
            Deductions = deductions;
            Net = net;
        }
    }
}
