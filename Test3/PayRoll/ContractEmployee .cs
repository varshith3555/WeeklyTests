using System;
using System.Collections.Generic;
using System.Text;

namespace PayRoll
{
    public class ContractEmployee : Employee
    {
        /// <summary>
        /// Total no of days worked
        /// </summary>
        public int WorkingDays { get; }
        /// <summary>
        /// Payment for each working day
        /// </summary>
        public decimal RatePerDay { get; }
        /// Constructor initializes contract employee data
        public ContractEmployee(int id, string name, int days, decimal rate) : base(id, name, "Contract")
        {
            if (days < 0 || days > 31)
                throw new ArgumentException("Working days must be between 0 and 31");

            WorkingDays = days;
            RatePerDay = rate;
        }

        /// <summary>
        /// Below method Calculates salary
        /// </summary>
        /// <returns></returns>
        public override PaySlip CalculatePay()
        {
            decimal gross = WorkingDays * RatePerDay;
            decimal deduction = gross * 0.05m;
            decimal net = gross - deduction;

            return new PaySlip(Id, Name, Type, gross, deduction, net);
        }
    }
}
