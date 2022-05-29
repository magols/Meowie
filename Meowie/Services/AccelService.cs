using Meowie.Lib.Services;

namespace Meowie.Services;

public class AccelService : IDisposable
{
    private StateContainerService _state;

    public AccelService(StateContainerService state)
    {
        _state = state;

        
        if (Accelerometer.IsSupported)
        {
            Accelerometer.Default.ReadingChanged += OnReading;
            Accelerometer.Default.ShakeDetected += OnShake;

            Accelerometer.Start(SensorSpeed.Default);
        }
    }

    private void OnShake(object sender, EventArgs e)
    {
        _state.SetShake();
    }


    private void OnReading(object sender, AccelerometerChangedEventArgs e)
    {
        _state.SetAcceleration(e.Reading.Acceleration);
    }

    public void Dispose()
    {
         if (Accelerometer.IsMonitoring)
             Accelerometer.Stop();

         Accelerometer.Default.ReadingChanged -= OnReading;
         Accelerometer.Default.ShakeDetected -= OnShake;
    }

 }