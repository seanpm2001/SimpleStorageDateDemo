using System;
using System.Collections.Generic;
using System.Linq;

using MonoTouch.Foundation;
using MonoTouch.UIKit;

using Xamarin.Forms;
using PerpetualEngine.Storage;

namespace SimpleStorageDateDemo.iOS
{
    [Register("AppDelegate")]
    public partial class AppDelegate : UIApplicationDelegate
    {
        UIWindow window;

        public override bool FinishedLaunching(UIApplication app, NSDictionary options)
        {
            Forms.Init();

            window = new UIWindow(UIScreen.MainScreen.Bounds);
            
            window.RootViewController = App.GetMainPage().CreateViewController();
            window.MakeKeyAndVisible();

            double expiresIn = 3600;
            var storage = SimpleStorage.EditGroup("mystore");
            DateTime futureTime = DateTime.Now.AddSeconds(expiresIn);
            storage.Put<DateTime>("authkey-expire", futureTime);
            DateTime expireDate = storage.Get<DateTime>("authkey-expire");

            Console.WriteLine("now: " + DateTime.Now);
            Console.WriteLine("expires: " + expireDate);

            return true;
        }
    }
}

