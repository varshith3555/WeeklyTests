using System;
using System.Collections.Generic;
using System.Linq;

namespace DigitalPettyCashLedger
{
    /// <summary>
    /// This is abstrat class for all the transactions
    /// </summary>
    public abstract class Transaction : IReportable
    {
        /// <summary>
        /// This are properties
        /// </summary>
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public decimal Amount { get; set; }
        public string Description { get; set; }
        /// <summary>
        /// This is abstract method to implement in child class
        /// </summary>
        /// <returns></returns>
        public abstract string GetSummary();

    }
    /// <summary>
    /// This is ExpenseTransaction inherits from Transaction
    /// </summary>
    public class ExpenseTransaction : Transaction
    {
        public string Category { get; set; }
        /// <summary>
        /// here is the implementation of abstract method
        /// </summary>
        /// <returns></returns>
        public override string GetSummary()
        {
            return $"Expense - {Category} - {Amount} - {Description}";
        }
    }

    /// <summary>
    /// This is IncomeTransaction inherits from Transaction
    /// </summary>
    public class IncomeTransaction : Transaction
    {
        public string Source { get; set; }

        /// <summary>
        /// implementation for abstract method
        /// </summary>
        /// <returns></returns>
        public override string GetSummary()
        {
            return $"Income - {Source} - {Amount} - {Description}";
        }
    }
}
