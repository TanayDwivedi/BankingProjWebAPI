using System;
using System.Collections.Generic;

#nullable disable

namespace BANKING.LTIMode
{
    public partial class UserTransaction
    {
        public long TransactionId { get; set; }
        public int AccountNumber { get; set; }
        public DateTime TransactionDate { get; set; }
        public string TransactionType { get; set; }
        public double AccountBalance { get; set; }
        public string Remark { get; set; }

        public virtual AccountDetail AccountNumberNavigation { get; set; }
    }
}
