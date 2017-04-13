using System;
using DeviceMotion.Plugin.Abstractions;

namespace MagnetFinder
{
	public class Sensor
	{
		double maxX = 0;
		double maxY = 0;
		double maxZ = 0;

		double minX = 0;
		double minY = 0;
		double minZ = 0;
		public Sensor()
		{
		}

		public void LimitsTestFunction(MotionVector a)
		{
			var xVal = a.X;
			var yVal = a.Y;
			var zVal = a.Z;

			if (xVal > maxX)
			{
				maxX = xVal;
				Console.WriteLine("X max: " + maxX);
			}

			if (yVal > maxY)
			{
				maxY = yVal;
				Console.WriteLine("Y max: " + maxY);
			}

			if (zVal > maxZ)
			{
				maxZ = zVal;
				Console.WriteLine("Z max: " + maxZ);
			}

			if (xVal < minX)
			{
				minX = xVal;
				Console.WriteLine("X min: " + minX);
			}

			if (yVal < minY)
			{
				minY = yVal;
				Console.WriteLine("Y min: " + minY);
			}

			if (zVal < minZ)
			{
				minZ = zVal;
				Console.WriteLine("Z min: " + minZ);
			}
		}
	}
}
