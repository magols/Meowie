using System.Numerics;

namespace Meowie.Lib.Data
{
    public class SensorData
    {
        public Vector3 Accelerometer { get; set; }

        public float AccelerometerX { get; set; }
        public float AccelerometerY { get; set; }
        public float AccelerometerZ { get; set; }
        public double CompassHeadingMagneticNorth { get; set; }


        public float OrientationX { get; set; }
        public float OrientationY { get; set; }
        public float OrientationZ { get; set; }
        public float OrientationW { get; set; }


        public override string ToString()
        {
            return "SensorData:\n" +
                   $"Accel: {Accelerometer.X}, {Accelerometer.Y}, {Accelerometer.Z}\n" +
                   $"AccelX: {AccelerometerX}, Y: {AccelerometerY}, Z: {AccelerometerZ}\n" +
                   $"Compass: {CompassHeadingMagneticNorth}\n" +
                   $"OrientationX: {OrientationX}, Y: {OrientationY}, Z: {OrientationZ}, W: {OrientationW}\n" +


                   "";
        }
    }
}
