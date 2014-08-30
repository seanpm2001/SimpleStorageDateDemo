using System;

using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;

using Xamarin.Forms.Platform.Android;
using PerpetualEngine.Storage;


namespace SimpleStorageDateDemo.Android
{
    [Activity(Label = "SimpleStorageDateDemo.Android.Android", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : AndroidActivity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            SimpleStorage.SetContext(this);

            Xamarin.Forms.Forms.Init(this, bundle);

            SetPage(App.GetMainPage());


            double expiresIn = 3600;
            var storage = SimpleStorage.EditGroup("mystore");
            DateTime futureTime = DateTime.Now.AddSeconds(expiresIn);
            storage.Put<DateTime>("authkey-expire", futureTime);
            DateTime expireDate = storage.Get<DateTime>("authkey-expire");

            Console.WriteLine("now: " + DateTime.Now);
            Console.WriteLine("expires: " + expireDate);
        }
    }
}

