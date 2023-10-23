using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Expense_manager
{
    public class Transaction
    {
       public int TransactionID { get; set; }
        public string Description { get; set; }
        public decimal Amount { get; set; }
        public DateTime Date { get; set; }
        public int CategoryID { get; set; }

        public Category Category { get; set; }
    }
}