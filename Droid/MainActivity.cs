using Android.App;
using Android.Widget;
using Android.OS;
using DeviceMotion.Plugin;
using DeviceMotion.Plugin.Abstractions;
using System;

namespace MagnetFinder.Droid
{
	[Activity(Label = "Magnet Finder", MainLauncher = true, Icon = "@mipmap/icon")]
	public class MainActivity : Activity
	{

		protected override void OnCreate(Bundle savedInstanceState)
		{
			base.OnCreate(savedInstanceState);

			// Set our view from the "main" layout resource
			SetContentView(Resource.Layout.Main);

			var progressBarX = FindViewById<ProgressBar>(Resource.Id.progressBarX);
			var progressBarY = FindViewById<ProgressBar>(Resource.Id.progressBarY);
			var progressBarZ = FindViewById<ProgressBar>(Resource.Id.progressBarZ);

			CrossDeviceMotion.Current.Start(MotionSensorType.Magnetometer);

			CrossDeviceMotion.Current.SensorValueChanged += (sender, e) =>
			{
				switch (e.SensorType)
				{
					case MotionSensorType.Magnetometer:
						var values = (MotionVector)e.Value;
						Sensor sensor = new Sensor();
						sensor.LimitsTestFunction(values);

						progressBarX.Progress = (int)values.X;
						progressBarY.Progress = (int)values.Y;
						progressBarZ.Progress = (int)values.Z;

						break;
					default:
						break;
				}
			};
		}
	}
}

