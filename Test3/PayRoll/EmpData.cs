using System;
using System.Collections.Generic;
using System.Text;

namespace PayRoll
{
    public static class EmpData
    {
        /// <summary>
        /// Static collection to store all employees
        /// </summary>
        private static List<Employee> employees = new List<Employee>();

        /// Static constructor
        static EmpData()
        {
            employees.Add(new FullTimeEmployee(1, "Nani", 50000));
            employees.Add(new FullTimeEmployee(2, "Mani", 60000));
            employees.Add(new FullTimeEmployee(3, "Varshith", 45000));
            employees.Add(new ContractEmployee(4, "Vivekananda", 20, 1000));
            employees.Add(new ContractEmployee(5, "Avishek", 25, 900));
            employees.Add(new ContractEmployee(6, "Rahul", 15, 1200));
        }

        public static void AddEmp(List<Employee> newEmployees)
        {
            if (newEmployees != null)
                employees.AddRange(newEmployees);
        }
        public static List<Employee> GetEmployees()
        {
            return employees;
        }
    }
}
