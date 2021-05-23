using Android.App;
using Android.Content;
using Android.OS;
using Android.Support.V7.App;
using Android.Views;

namespace App1.Droid
{
    [Activity(
      Label = "Roots",
      Icon = "@mipmap/icon",
      Theme = "@style/SplashTheme",
      MainLauncher = true,
      NoHistory = true)]
    public class SplashActivity : AppCompatActivity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            if (Build.VERSION.SdkInt >= BuildVersionCodes.Lollipop)
            {
                Window.DecorView.SystemUiVisibility = StatusBarVisibility.Visible;
                Window.SetStatusBarColor(Android.Graphics.Color.Transparent);
            }

            InvokeMainActivity();
        }

        void InvokeMainActivity()
        {
            var mainActivityIntent = new Intent(this, typeof(MainActivity));
            StartActivity(mainActivityIntent);
        }
    }
}