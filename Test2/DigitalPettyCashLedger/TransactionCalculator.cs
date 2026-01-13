namespace DigitalPettyCashLedger
{
    /// <summary>
    /// class for calculations
    /// </summary>
    public static class TransactionCalculator
    {
        /// <summary>
        /// calculate the total income
        /// </summary>
        public static decimal CalIncomeTotal(List<IncomeTransaction> incomes)
        {
            return incomes.Sum(i => i.Amount);
        }
        
        /// <summary>
        /// calculate the total expense
        /// </summary>
        /// <param name="expenses"></param>
        /// <returns></returns>
        public static decimal CalExpenseTotal(List<ExpenseTransaction> expenses)
        {
            return expenses.Sum(e => e.Amount);
        }
        /// <summary>
        /// calculate the net baalances
        /// </summary>
        /// <param name="incomes"></param>
        /// <param name="expenses"></param>
        /// <returns></returns>
        public static decimal CalNetBalance(
           List<IncomeTransaction> incomes,
           List<ExpenseTransaction> expenses)
        {
            return CalIncomeTotal(incomes) - CalExpenseTotal(expenses);
        }
    }
}
