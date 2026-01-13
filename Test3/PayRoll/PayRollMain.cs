using System;
using System.Collections.Generic;
using System.Text;

namespace PayRoll
{
    public class PayRollMain
    {
        private static List<Employee> employees1 = new List<Employee>();
        static void Main()
        {
            Console.Write("Do you want to add a new employee? (yes/no): ");
            string choice = Console.ReadLine().ToLower();

            while (choice == "yes")
            {
                Console.Write("Enter Employee ID: ");
                int id = int.Parse(Console.ReadLine());

                Console.Write("Enter Employee Name: ");
                string name = Console.ReadLine();

                Console.Write("Enter Employee Type (1-FullTime, 2-Contract): ");
                int type = int.Parse(Console.ReadLine());

                if (type == 1)
                {
                    Console.Write("Enter Monthly Salary: ");
                    decimal salary = decimal.Parse(Console.ReadLine());

                    employees1.Add(new FullTimeEmployee(id, name, salary));
                }
                else
                {
                    Console.Write("Enter Working Days: ");
                    int days = int.Parse(Console.ReadLine());

                    Console.Write("Enter Rate Per Day: ");
                    decimal rate = decimal.Parse(Console.ReadLine());

                    employees1.Add(new ContractEmployee(id, name, days, rate));
                }

                Console.Write("\nAdd another employee? (yes/no): ");
                choice = Console.ReadLine().ToLower();
            }

            var employees = EmpData.GetEmployees();

            var processor = new PayrollProcessor();

            processor.SalaryProcessed += HRNotification.Notify;
            processor.SalaryProcessed += FinanceNotification.Notify;


            EmpData.AddEmp(employees1);
            List<PaySlip> paySlips = processor.ProcessPayroll(employees);

            decimal totalPayout = 0;
            foreach (var slip in paySlips)
            {
                totalPayout += slip.Net;
                Console.WriteLine(
                    $"{slip.EmployeeId} | {slip.Name} | {slip.Type} | Gross: {slip.Gross} | Deduction: {slip.Deductions} | Net: {slip.Net}"
                );
            }

            int fullTimeCount = 0, contractCount = 0;
            PaySlip highest = paySlips[0];

            foreach (var slip in paySlips)
            {
                if (slip.Type == "Full-Time") fullTimeCount++;
                else contractCount++;

                if (slip.Net > highest.Net)
                    highest = slip;
            }

            Console.WriteLine($"\nTotal Employees: {paySlips.Count}");
            Console.WriteLine($"Full-Time Employees: {fullTimeCount}");
            Console.WriteLine($"Contract Employees: {contractCount}");
            Console.WriteLine($"Highest Paid Employee: {highest.Name} | Net: {highest.Net}");
            Console.WriteLine($"Total Payout: {totalPayout}");
        }

    }
}
