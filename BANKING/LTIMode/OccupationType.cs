using System;
using System.Collections.Generic;

#nullable disable

namespace BANKING.LTIMode
{
    public partial class OccupationType
    {
        public OccupationType()
        {
            UserOpenAccounts = new HashSet<UserOpenAccount>();
        }

        public string Otype { get; set; }

        public virtual ICollection<UserOpenAccount> UserOpenAccounts { get; set; }
    }
}
