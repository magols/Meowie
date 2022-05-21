using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
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


    //class AccelService
    //{
    //    private static AccelService _instance;

    //    private Vector3 _acc = Vector3.Zero;

    //    public event Func Notify;

    //    AccelService()
    //    {
    //        if (Accelerometer.IsSupported)
    //        {
    //            Accelerometer.ReadingChanged += OnReading;
    //            Accelerometer.Start(SensorSpeed.Default);
    //        }
    //    }

    //    private AccelService Instance
    //    {
    //        get
    //        {
    //            if (_instance == null)
    //                _instance = new AccelService();
    //            return _instance ;
    //        }
    //    }

    //    private void OnReading(object sender, AccelerometerChangedEventArgs e)
    //    {
    //        _acc = e.Reading.Acceleration;

    //        if (Notify != null)
    //        {
    //            await Notify.Invoke();
    //        }

    //    }


    //}
}
