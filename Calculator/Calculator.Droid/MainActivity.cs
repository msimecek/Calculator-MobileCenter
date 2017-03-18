using System;

using Android.App;
using Android.Content.PM;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using HockeyApp.Android;
using HockeyApp.Android.Metrics;

namespace Calculator.Droid
{
    [Activity(Label = "Calculator", Icon = "@drawable/icon", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsApplicationActivity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            const string appId = "13811f19fe0540a184511b18374628d1";
            CrashManager.Register(this, appId);
            MetricsManager.Register(Application, appId);

            var feedbackButton = new Xamarin.Forms.Button()
            {
                Text = "Feedback"
            };
            feedbackButton.Clicked += (sender, e) => {
                FeedbackManager.Register(this, appId);
                FeedbackManager.ShowFeedbackActivity(this);
            };

            global::Xamarin.Forms.Forms.Init(this, bundle);
            LoadApplication(new App(feedbackButton));
        }

        protected override void OnDestroy()
        {
            FeedbackManager.Unregister();
            base.OnDestroy();
        }

    }
}

