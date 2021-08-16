using System;
using System.Collections.Generic;

#nullable disable

namespace BANKING.LTIMode
{
    public partial class AccountDetail
    {
        public AccountDetail()
        {
            BeneficiaryDetailBeneficiaryAccNoNavigations = new HashSet<BeneficiaryDetail>();
            BeneficiaryDetailUserAccountNoNavigations = new HashSet<BeneficiaryDetail>();
            NetBankingUserDetails = new HashSet<NetBankingUserDetail>();
            UserTransactions = new HashSet<UserTransaction>();
        }

        public int AccountNumber { get; set; }
        public string AadharCardNumber { get; set; }
        public string AccountType { get; set; }
        public double AccountBalance { get; set; }

        public virtual UserOpenAccount AadharCardNumberNavigation { get; set; }
        public virtual ICollection<BeneficiaryDetail> BeneficiaryDetailBeneficiaryAccNoNavigations { get; set; }
        public virtual ICollection<BeneficiaryDetail> BeneficiaryDetailUserAccountNoNavigations { get; set; }
        public virtual ICollection<NetBankingUserDetail> NetBankingUserDetails { get; set; }
        public virtual ICollection<UserTransaction> UserTransactions { get; set; }
    }
}
