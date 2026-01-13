using System;
using System.Collections.Generic;
using System.Text;

namespace PayRoll
{
    public class FullTimeEmployee : Employee
    {
        public decimal MonthlySalary { get; }

        public FullTimeEmployee(int id, string name, decimal salary) : base(id, name, "Full-Time")
        {
            if (salary < 0) throw new ArgumentException("Salary should not be negative");
            MonthlySalary = salary;
        }

        /// <summary>
        /// Calculates salary for full-time employee
        /// </summary>
        /// <returns></returns>
        public override PaySlip CalculatePay()
        {
            decimal tax = MonthlySalary * 0.10m;
            decimal net = MonthlySalary - tax;

            return new PaySlip(Id, Name, Type, MonthlySalary, tax, net);
        }
    }
}
