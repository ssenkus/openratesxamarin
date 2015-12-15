using System;
using Xamarin.Forms;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Net;
using Newtonsoft.Json;
using System.IO;
using System.Diagnostics;


namespace OpenRates
{
    public class App : Application
    {

        public static RatesViewModel Rates;
        public static List<string> realRates;
        public App()
        {
            
            MainPage = new NavigationPage(new OpenRates.RatesPage ());
        }
   
        protected override void OnStart()
        {
            // Handle when your app starts
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