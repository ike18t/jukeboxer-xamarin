using System;
using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using Android.Bluetooth;

namespace AndroidXamarin
{
	[Activity (Label = "AndroidXamarin", MainLauncher = true)]
	public class MainActivity : Activity
	{
		int count = 1;

		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);

			// Set our view from the "main" layout resource
			SetContentView (Resource.Layout.Main);

			// Get our button from the layout resource,
			// and attach an event to it
			Button button = FindViewById<Button> (Resource.Id.myButton);
			
			button.Click += delegate {
				button.Text = string.Format ("{0} clicks!", count++);
			};

			var receiver = new BluetoothReceiver();
			var bluetoothFilter = new IntentFilter(BluetoothDevice.ActionFound);
			RegisterReceiver(receiver, bluetoothFilter);

			var bluetooth = BluetoothAdapter.DefaultAdapter;
			bluetooth.StartDiscovery ();
		}
	}

	public class BluetoothReceiver : BroadcastReceiver
	{
		public void OnReceive(Context context, Intent intent)
		{
			if(BluetoothDevice.ActionFound == intent.Action)
			{
				var device = (BluetoothDevice)intent.GetParcelableExtra(BluetoothDevice.ExtraDevice);
				var rssi = intent.GetShortExtra(BluetoothDevice.ExtraRssi, 0);
				Toast.MakeText(context, device.Name, ToastLength.Long).Show();
			}
		}
	}
}


