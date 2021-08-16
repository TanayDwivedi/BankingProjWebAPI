using System;
using System.Collections.Generic;

#nullable disable

namespace BANKING.LTIMode
{
    public partial class GrossAnnualIncome
    {
        public GrossAnnualIncome()
        {
            UserOpenAccounts = new HashSet<UserOpenAccount>();
        }

        public string AnnualIncome { get; set; }

        public virtual ICollection<UserOpenAccount> UserOpenAccounts { get; set; }
    }
}
