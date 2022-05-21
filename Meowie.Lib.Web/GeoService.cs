using BrowserInterop.Geolocation;
using Meowie.Lib.Services;
using Microsoft.JSInterop;
using BrowserInterop.Extensions;

namespace Meowie.Lib.Web
{
    public class GeoService : ILocationService
    {
        private IJSRuntime _js;

        private WindowNavigatorGeolocation? geolocationWrapper;
        private GeolocationPosition? currentPosition = default;

        public GeoService(IJSRuntime js)
        {
            _js = js;
        }
        public async Task<Location> GetLocationAsync()
        {
            await InitializeAsync();

             currentPosition = (await geolocationWrapper.GetCurrentPosition(new PositionOptions()
            {
                EnableHighAccuracy = true,
                MaximumAgeTimeSpan = TimeSpan.FromHours(1),
                TimeoutTimeSpan = TimeSpan.FromMinutes(1)
            })).Location;

             return new Location{Longitude = (decimal)currentPosition.Coords.Longitude, Latitude = (decimal)currentPosition.Coords.Latitude, Accuracy = (decimal)currentPosition.Coords.Accuracy};
        }

        protected async Task InitializeAsync()
        {
            if (geolocationWrapper == null)
            {
                var window = await _js.Window();
                var navigator = await window.Navigator();
                geolocationWrapper = navigator.Geolocation;
            }
        }
    }
}
