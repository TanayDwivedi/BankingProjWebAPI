using System;
using System.Collections.Generic;

#nullable disable

namespace BANKING.LTIMode
{
    public partial class BeneficiaryDetail
    {
        public int BeneficiaryAccNo { get; set; }
        public int UserAccountNo { get; set; }
        public string BeneficiaryName { get; set; }
        public string NickName { get; set; }

        public virtual AccountDetail BeneficiaryAccNoNavigation { get; set; }
        public virtual AccountDetail UserAccountNoNavigation { get; set; }
    }
}
