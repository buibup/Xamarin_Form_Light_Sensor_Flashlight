using System;
using Android.App;
using Android.Content.PM;
using Android.Runtime;
using Android.Widget;
using Android.OS;
using Android.Support.Design.Widget;
using Android.Hardware;
using Android.Content;

namespace App.QR.Droid
{
    [Activity(Label = "App.QR", Icon = "@mipmap/icon", Theme = "@style/MainTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity, Android.Hardware.ISensorEventListener
    {
        private SensorManager sensorService;
        float lightSensorValue;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;

            base.OnCreate(savedInstanceState);

            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            global::Xamarin.Forms.Forms.Init(this, savedInstanceState);
            LoadApplication(new App());

            // Get a SensorManager
            sensorService = (SensorManager)GetSystemService(SensorService);

            //// Get a Light Sensor
            var lightSensor = sensorService.GetDefaultSensor(SensorType.Light);
            sensorService.RegisterListener(this, lightSensor, Android.Hardware.SensorDelay.Game);
        }
        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }

        private void FabOnClick(object sender, EventArgs eventArgs)
        {
            // Get a SensorManager
            sensorService = (SensorManager)GetSystemService(Context.SensorService);

            // Get a Light Sensor
            var lightSensor = sensorService.GetDefaultSensor(SensorType.Light);

            // Register this class a listener for light sensor
            sensorService.RegisterListener(null, lightSensor, Android.Hardware.SensorDelay.Game);

            Android.Views.View view = (Android.Views.View)sender;
            Snackbar.Make(view, "Replace with your own action", Snackbar.LengthLong)
                .SetAction("Action", (Android.Views.View.IOnClickListener)null).Show();
        }

        public void OnSensorChanged(SensorEvent s)
        {
            // Your processing here
            s.Sensor = sensorService.GetDefaultSensor(SensorType.Light);
            lightSensorValue = s.Values[0];
            Settings.CurrentLightSensorValue = lightSensorValue;
            Toast.MakeText(this, lightSensorValue.ToString("0.00"), ToastLength.Long).Show();
        }

        public void OnAccuracyChanged(Sensor sensor, [GeneratedEnum] SensorStatus accuracy)
        {
            //throw new NotImplementedException();
        }
    }
}