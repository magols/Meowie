using Meowie.Lib.Services;

namespace Meowie.Services;

class AccelService
{
    private StateContainerService _state;

    public AccelService(StateContainerService state)
    {
        _state = state;

        if (Accelerometer.IsSupported)
        {
            Accelerometer.Default.ReadingChanged += OnReading;
            Accelerometer.Start(SensorSpeed.Default);
        }
    }
 

    private void OnReading(object sender, AccelerometerChangedEventArgs e)
    {
        _state.SetAcceleration(e.Reading.Acceleration);
    }
}