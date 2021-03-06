using Meowie.Lib.Services;

namespace Meowie.Services;

class CompassService
{
    private StateContainerService _state;

    public CompassService(StateContainerService state)
    {
        _state = state;

        if (Compass.IsSupported)
        {
            Compass.Default.ReadingChanged += OnReading;
            Compass.Start(SensorSpeed.Default);
        }
    }

    private void OnReading(object sender, CompassChangedEventArgs e)
    {
        _state.SetCompass(e.Reading.HeadingMagneticNorth);
    }
}