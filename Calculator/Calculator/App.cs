using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Azure.Mobile;
using Microsoft.Azure.Mobile.Analytics;
using Microsoft.Azure.Mobile.Crashes;

using Xamarin.Forms;

namespace Calculator
{
	public class App : Application
	{
        public App(params View[] children)
		{
			// The root page of your application
            MainPage = new MainPage(children);
		}

		protected override void OnStart()
		{
			// Handle when your app starts
			MobileCenter.Start("ios=0c1cbcf0-f4b0-437b-9f4f-51e9e3f12dd5;", typeof(Analytics), typeof(Crashes));
		}

		protected override void OnSleep()
		{
			// Handle when your app sleeps
		}

		protected override void OnResume()
		{
			// Handle when your app resumes
		}
	}
}
