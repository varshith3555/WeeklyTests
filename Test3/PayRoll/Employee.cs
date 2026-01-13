namespace PayRoll
{
    /// <summary>
    /// Delegate used to notify when salary is processed
    /// </summary>
    public delegate void SalaryProcessedHandler(Employee employee, PaySlip paySlip);
    /// <summary>
    /// Base class for all the employee types
    /// </summary>
    public abstract class Employee
    {
        public int Id { get; }
        public string Name { get; }
        public string Type { get; }

        protected Employee(int id, string name, string type)
        {
            Id = id;
            Name = name;
            Type = type;
        }
        /// <summary>
        /// Child class must implement the CalculatePay method
        /// </summary>
        /// <returns></returns>
        public abstract PaySlip CalculatePay();
    }
}
