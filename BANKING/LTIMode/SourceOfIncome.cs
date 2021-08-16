using System;
using System.Collections.Generic;

#nullable disable

namespace BANKING.LTIMode
{
    public partial class SourceOfIncome
    {
        public SourceOfIncome()
        {
            UserOpenAccounts = new HashSet<UserOpenAccount>();
        }

        public string SourceType { get; set; }

        public virtual ICollection<UserOpenAccount> UserOpenAccounts { get; set; }
    }
}
