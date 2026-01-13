using System;
using System.Collections.Generic;
using System.Text;

namespace PayRoll
{
    /// <summary>
    /// It will handle the payroll processing for all employees
    /// </summary>
    public class PayrollProcessor
    {
        /// <summary>
        /// Multicast delegate to notify multiple departments
        /// </summary>
        public SalaryProcessedHandler SalaryProcessed;
        /// <summary>
        /// Calculates the salary for all employees
        /// </summary>
        /// <returns></returns>
        public List<PaySlip> ProcessPayroll(List<Employee> employees)
        {
            var paySlips = new List<PaySlip>();

            foreach (var emp in employees)
            {
                try
                {
                    PaySlip slip = emp.CalculatePay();
                    paySlips.Add(slip);

                    /// Notify HR and Finance after salary is processed
                    SalaryProcessed?.Invoke(emp, slip);
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error processing {emp.Name}: {ex.Message}");
                }
            }

            return paySlips;
        }
    }
}
