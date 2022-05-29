using System.Numerics;

namespace Meowie.Lib.Services;

public class StateContainerService
{

    /// <summary>
    /// The event that will be raised for state changed
    /// </summary>
    public event Action OnStateChange;
    
    
    public Vector3 Acceleration { get; private set; } = Vector3.Zero;
    public double CompassHeadingMagneticNorth{ get; private set; } = Double.NaN;
    public DateTime LastShake { get; private set; } = DateTime.MinValue;


    public void SetAcceleration(Vector3 value)
    {
        Acceleration = value;
        NotifyStateChanged();
    }

    /// <summary>
    /// The state change event notification
    /// </summary>
    private void NotifyStateChanged() => OnStateChange?.Invoke();


    public void SetCompass(double readingHeadingMagneticNorth)
    {
        CompassHeadingMagneticNorth = readingHeadingMagneticNorth;
        NotifyStateChanged();

    }

    public void SetShake()
    {
         LastShake = DateTime.Now;
         NotifyStateChanged();
    }


    public Quaternion Orientation { get; private set; } = new Quaternion();

    public void SetOrientation(Quaternion orientation)
    {
        Orientation = orientation;
        NotifyStateChanged();
    }
}