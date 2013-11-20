using System;
using Android.Content;
using Android.Widget;
using Android.Bluetooth;

namespace Jukeboxer
{
	public class BluetoothReceiver : BroadcastReceiver
	{
		public override void OnReceive(Context context, Intent intent)
		{
			if(BluetoothDevice.ActionFound == intent.Action)
			{
				var device = (BluetoothDevice)intent.GetParcelableExtra(BluetoothDevice.ExtraDevice);
				Toast.MakeText(context, device.Name, ToastLength.Long).Show();
			}
		}
	}
}