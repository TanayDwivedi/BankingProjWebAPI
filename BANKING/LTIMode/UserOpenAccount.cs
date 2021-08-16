using System;
using System.Collections.Generic;

#nullable disable

namespace BANKING.LTIMode
{
    public partial class UserOpenAccount
    {
        public UserOpenAccount()
        {
            AccountDetails = new HashSet<AccountDetail>();
        }

        public string AadharCardNumber { get; set; }
        public string Title { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string FathersName { get; set; }
        public string MobileNumber { get; set; }
        public string EmailId { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string ResidentialAddrLine1 { get; set; }
        public string ResidentialAddrLine2 { get; set; }
        public string ResidentialLandmark { get; set; }
        public string ResidentialPincode { get; set; }
        public bool PermEqualRes { get; set; }
        public string OccupationType { get; set; }
        public string SourceOfIncome { get; set; }
        public string GrossAnnualIncome { get; set; }
        public bool DebitCard { get; set; }
        public bool NetBanking { get; set; }
        public bool ApprovalStatus { get; set; }

        public virtual GrossAnnualIncome GrossAnnualIncomeNavigation { get; set; }
        public virtual OccupationType OccupationTypeNavigation { get; set; }
        public virtual LocationPinCodeCity ResidentialPincodeNavigation { get; set; }
        public virtual SourceOfIncome SourceOfIncomeNavigation { get; set; }
        public virtual ICollection<AccountDetail> AccountDetails { get; set; }
    }
}
