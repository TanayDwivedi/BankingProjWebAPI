using System;
using System.Collections.Generic;

#nullable disable

namespace BANKING.LTIMode
{
    public partial class LocationPinCodeCity
    {
        public LocationPinCodeCity()
        {
            UserOpenAccounts = new HashSet<UserOpenAccount>();
        }

        public string Pincode { get; set; }
        public string City { get; set; }

        public virtual LocationCityState CityNavigation { get; set; }
        public virtual ICollection<UserOpenAccount> UserOpenAccounts { get; set; }
    }
}
