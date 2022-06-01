using System.Numerics;

namespace Meowie.Lib.Data
{
    public class SensorData
    {
        public Vector3 Accelerometer { get; set; }

        public decimal AccelerometerX { get; set; }
        public decimal AccelerometerY { get; set; }
        public decimal AccelerometerZ { get; set; }
        public decimal CompassHeadingMagneticNorth { get; set; }


        public decimal OrientationX { get; set; }
        public decimal OrientationY { get; set; }
        public decimal OrientationZ { get; set; }
        public decimal OrientationW { get; set; }


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
