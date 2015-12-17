using System;
using System.Threading.Tasks;
using Xamarin.Forms;
using System.Net;
using System.Diagnostics;
using System.IO;
using Newtonsoft.Json;
using System.Collections.Generic;


namespace OpenRates
{

    public partial class RatesPage : ContentPage
    {

        public RatesPage()
        {
            InitializeComponent();
        }

        public void OnShowRates(object sender, EventArgs e)
        {
            Navigation.PushAsync(new RatesListPage());
          
        }

        public void OnGetLatest(object sender, EventArgs e)
        {
            getLatest();
       
        }

        public void OnGetCurrencies(object sender, EventArgs e)
        {
            getCurrencies();

        }

        private async void getCurrencies()
        {
            string url = "https://openexchangerates.org/api/currencies.json?app_id=c0692641f9374249832959e4ece26813";
            await httpRequest(url, "currencies");
        }

        private async void  getLatest()
        {
            string url = "https://openexchangerates.org/api/latest.json?app_id=c0692641f9374249832959e4ece26813";
            await httpRequest(url, "latest");

        }

        private void ParseData(string jsonData)
        {
            var parsedJson = JsonConvert.DeserializeObject(jsonData);
            Debug.WriteLine(parsedJson);
        }

        public async Task<string> httpRequest(string url, string apiEndpoint)
        {
            Uri uri = new Uri(url);
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(uri);
            string received;

            using (var response = (HttpWebResponse)(await Task<WebResponse>.Factory.FromAsync(request.BeginGetResponse, request.EndGetResponse, null)))
            {
                using (var responseStream = response.GetResponseStream())
                {
                    using (var sr = new StreamReader(responseStream))
                    {

                        received = await sr.ReadToEndAsync();
                    }
                }
            }


            if (apiEndpoint == "currencies")
            {
                var x = JsonConvert.DeserializeObject<Dictionary<string, string>>(received);
                Debug.WriteLine(x);
                App.Rates.currencies = x;
                Debug.WriteLine(App.Rates.currencies);

            }
            else if (apiEndpoint == "latest")
            {
                var x = JsonConvert.DeserializeObject<RatesViewModel>(received);
                App.Rates.rates = x.rates;
                App.Rates.license = x.license;
                App.Rates.disclaimer = x.disclaimer;
                App.Rates.convertToViewStrings();
                App.realRates = App.Rates.realRates;
            }
            return received;
            
        }


    }

   
}