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

        public void OnRatesList(object sender, EventArgs e)
        {
            Navigation.PushAsync(new RatesListPage());
          
        }

        public void OnGotData(object sender, EventArgs e)
        {
            getRates();
       
        }

        private async void  getRates()
        {
            string url = "https://openexchangerates.org/api/latest.json?app_id=c0692641f9374249832959e4ece26813";
            await httpRequest(url);

        }

        private void addData() {
        }

        private void ParseData(string jsonData)
        {
            var parsedJson = JsonConvert.DeserializeObject(jsonData);
            Debug.WriteLine(parsedJson);
        }

        public async Task<string> httpRequest(string url)
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

            var x = JsonConvert.DeserializeObject<RatesViewModel>(received);
            App.Rates = new RatesViewModel(){
                rates = x.rates,
                license = x.license,
                disclaimer = x.disclaimer
            };
            App.Rates.convertToViewStrings();
            App.realRates = App.Rates.realRates;
            return received;
        }


    }

   
}