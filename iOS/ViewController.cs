using System;
using DeviceMotion.Plugin;
using DeviceMotion.Plugin.Abstractions;
using UIKit;

namespace MagnetFinder.iOS
{
	public partial class ViewController : UIViewController
	{
		public ViewController(IntPtr handle) : base(handle)
		{
		}

		public override void ViewDidLoad()
		{
			base.ViewDidLoad();

			CrossDeviceMotion.Current.Start(MotionSensorType.Magnetometer);

			CrossDeviceMotion.Current.SensorValueChanged += (sender, e) =>
			{
				switch (e.SensorType)
				{
					case MotionSensorType.Magnetometer:
						var values = (MotionVector)e.Value;
						Sensor sensor = new Sensor();
						sensor.LimitsTestFunction(values);

						progressX.Progress = (float) (values.X / 300);
						progressY.Progress = (float) (values.Y / 200);
						progressZ.Progress = (float) (values.Z / -1100);

						break;
					default:
						break;
				}
			};

		}

		public override void DidReceiveMemoryWarning()
		{
			base.DidReceiveMemoryWarning();
			// Release any cached data, images, etc that aren't in use.		
		}
	}
}
