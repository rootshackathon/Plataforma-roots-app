using Android.App;
using Android.Content;
using Android.Locations;
using App1.Services;

namespace App1.Droid.Renderers
{
    public class Actions : IActions
    {
        public void EnableGPS()
        {
            LocationManager locationManager = (LocationManager)MainActivity.mContext.GetSystemService(Context.LocationService);

            if (locationManager.IsProviderEnabled(LocationManager.GpsProvider) == false)
            {
                Android.App.AlertDialog.Builder dialog = new AlertDialog.Builder(MainActivity.mContext);
                AlertDialog alert = dialog.Create();
                alert.SetTitle("Roots");
                alert.SetMessage("Seu GPS não está ativado, por favor ative o GPS para continuar.");
                alert.SetButton("OK", (c, ev) =>
                {
                    Intent gpsSettingIntent = new Intent(Android.Provider.Settings.ActionLocationSourceSettings);
                    MainActivity.mContext.StartActivity(gpsSettingIntent);
                });
                alert.Show();
            }
        }
    }
}