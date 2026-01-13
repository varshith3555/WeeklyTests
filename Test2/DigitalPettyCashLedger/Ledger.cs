using System;
using System.Collections.Generic;
using System.Text;

namespace DigitalPettyCashLedger
{
    /// <summary>
    /// This is generic class to store transactions
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class Ledger<T> where T : Transaction
    {
        /// <summary>
        /// List to store multiple transactions
        /// </summary>
        private List<T> values = new List<T>();
        /// <summary>
        /// This method is to add the transaction
        /// </summary>
        /// <param name="entry"></param>
        public void AddEntry(T entry)
        {
            values.Add(entry);
        }
        /// <summary>
        /// Return the transactions for specific date
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        public List<T> GetTransactionByDate(DateTime date)
        {
            return values.Where(e => e.Date.Date == date.Date).ToList();
        }
        /// <summary>
        /// returns all stored transactions
        /// </summary>
        /// <returns></returns>
        public List<T> GetAll()
        {
            return values;
        }
    }
}
