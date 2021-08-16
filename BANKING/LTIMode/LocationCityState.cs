using System;
using System.Collections.Generic;

#nullable disable

namespace BANKING.LTIMode
{
    public partial class LocationCityState
    {
        public LocationCityState()
        {
            LocationPinCodeCities = new HashSet<LocationPinCodeCity>();
        }

        public string City { get; set; }
        public string CityState { get; set; }

        public virtual ICollection<LocationPinCodeCity> LocationPinCodeCities { get; set; }
    }
}
