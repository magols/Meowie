using Meowie.Lib.Services;

namespace Meowie.Services;

public class OrientationService : IDisposable
{
    private StateContainerService _state;

    public OrientationService(StateContainerService state)
    {
        _state = state;

        if (OrientationSensor.IsSupported)
        {
            OrientationSensor.Default.ReadingChanged += OnReading;
             OrientationSensor.Start(SensorSpeed.UI);
        }
    }

    private void OnReading(object sender, OrientationSensorChangedEventArgs e)
    {
        _state.SetOrientation(e.Reading.Orientation);
    }


    public void Dispose()
    {
        OrientationSensor.Default.ReadingChanged -= OnReading;
        OrientationSensor.Stop();
    }

}