using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Meowie.Lib.Services;
using Location = Meowie.Lib.Services.Location;

namespace Meowie.Services
{

    class LocationServiceApp : ILocationService
    {

        public Location GetLocation()
        {
            throw new NotImplementedException();
        }

        public async Task<Location> GetLocationAsync()
        {
           var loc = await Geolocation.GetLocationAsync();

           return new Location
           {
               Longitude = (decimal)loc.Longitude,
               Latitude = (decimal)loc.Latitude,
               Accuracy = (decimal)loc.Accuracy
           };
        }
    }
}
