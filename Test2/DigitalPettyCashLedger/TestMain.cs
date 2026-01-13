using System;
using System.Collections.Generic;
using System.Text;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace DigitalPettyCashLedger
{
    class TestMain
    {
        static void Main()
        {
            /// Ledger for income transactions
            Ledger<IncomeTransaction> incomeLedger = new Ledger<IncomeTransaction>();
            incomeLedger.AddEntry(new IncomeTransaction {
                Id = 1,
                Date = DateTime.Today,
                Amount = 500m,
                Description = "Replenishment",
                Source = "Main Cash"
            });

            // Expense Ledger
            Ledger<ExpenseTransaction> expenseLedger = new Ledger<ExpenseTransaction>();
            expenseLedger.AddEntry(new ExpenseTransaction
            {
                Id = 2,
                Date = DateTime.Today,
                Amount = 20m,
                Description = "Small Expenses",
                Category = "Stationery"
            });
            expenseLedger.AddEntry(new ExpenseTransaction {
                Id = 3,
                Date = DateTime.Today,
                Amount = 15m,
                Description = "Spent for Snacks",
                Category = "Food"
            });

            decimal totalIncome = TransactionCalculator.CalIncomeTotal(incomeLedger.GetAll());
            decimal totalExpense = TransactionCalculator.CalExpenseTotal(expenseLedger.GetAll());
            decimal netBalance = TransactionCalculator.CalNetBalance(
                incomeLedger.GetAll(),
                expenseLedger.GetAll()
            );

            /// output
            Console.WriteLine($"Total Income -{totalIncome}");
            Console.WriteLine($"Total Expenses -{totalExpense}");
            Console.WriteLine($"Net Balance -{ totalIncome - totalExpense}");

            // Polymorphic Output
            List<Transaction> allTransactions = new List<Transaction>();
            allTransactions.AddRange(incomeLedger.GetAll());
            allTransactions.AddRange(expenseLedger.GetAll());

            foreach (Transaction transaction in allTransactions)
            {
                Console.WriteLine(transaction.GetSummary());
            }
        }
    }

}
