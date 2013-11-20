using Android.App;
using Android.Content;
using Android.Widget;
using Android.OS;
using Android.Bluetooth;

namespace Jukeboxer
{
	[Activity(Label = "Jukeboxer", MainLauncher = true)]
	public class MainActivity : Activity
	{
		protected override void OnCreate(Bundle bundle)
		{
			base.OnCreate(bundle);

			// Set our view from the "main" layout resource
			SetContentView(Resource.Layout.Main);

			// Get our button from the layout resource,
			// and attach an event to it
			Button button = FindViewById<Button> (Resource.Id.myButton);
			
			button.Click += delegate {
				BluetoothAdapter.DefaultAdapter.StartDiscovery();
			};

			var receiver = new BluetoothReceiver();
			var bluetoothFilter = new IntentFilter(BluetoothDevice.ActionFound);
			RegisterReceiver(receiver, bluetoothFilter);
		}
	}
}
