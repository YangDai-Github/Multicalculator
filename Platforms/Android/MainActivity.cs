using Android.App;
using Android.Content.PM;
using Android.OS;

namespace Multicalculator;

[Activity(Theme = "@style/MainTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation | ConfigChanges.UiMode | ConfigChanges.ScreenLayout | ConfigChanges.SmallestScreenSize | ConfigChanges.Density)]
public class MainActivity : MauiAppCompatActivity
{
    protected override void OnCreate(Bundle savedInstanceState)
    {
        Window.SetStatusBarColor(Android.Graphics.Color.Transparent);
        base.OnCreate(savedInstanceState);
        if (DeviceInfo.Current.Idiom == DeviceIdiom.Phone)
        {
            this.RequestedOrientation = ScreenOrientation.Portrait;
        }
    }
}
