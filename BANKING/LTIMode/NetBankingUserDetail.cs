using System;
using System.Collections.Generic;

#nullable disable

namespace BANKING.LTIMode
{
    public partial class NetBankingUserDetail
    {
        public int UserId { get; set; }
        public int AccountNumber { get; set; }
        public string UserPassword { get; set; }
        public string TransactionPass { get; set; }

        public virtual AccountDetail AccountNumberNavigation { get; set; }
    }
}
