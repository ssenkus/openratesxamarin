using System;
using Newtonsoft.Json;
using System.Diagnostics;
using System.Net;
using System.Threading.Tasks;
using System.IO;
using System.Collections.Generic;


namespace OpenRates
{
    public class RatesRepository
    {

        public RatesRepository() 
        {
            getCurrencies();
        }

        public async void  getCurrencies()
        {
            string url = "https://openexchangerates.org/api/currencies.json?app_id=c0692641f9374249832959e4ece26813";
            await httpRequest(url, "currencies");
        }

        public async void  getLatest()
        {
            string url = "https://openexchangerates.org/api/latest.json?app_id=c0692641f9374249832959e4ece26813";
            await httpRequest(url, "latest");
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
                var currs = JsonConvert.DeserializeObject<Dictionary<string, string>>(received);
                foreach (KeyValuePair<string, string> item in currs)
                {
                    App.Rates.currencies.Add(new Currency()
                        {
                            Abbreviation = item.Key,
                            FullName = item.Value
                        });
                }
            }
            else if (apiEndpoint == "latest")
            {
                var x = JsonConvert.DeserializeObject<RatesViewModel>(received);
                App.Rates.@base = x.@base;
                App.Rates.timestamp = x.timestamp;
                App.Rates.rates = x.rates;
                App.Rates.license = x.license;
                App.Rates.disclaimer = x.disclaimer;
                App.Rates.updateRates();
                App.appCurrencies = App.Rates.viewCurrencies;
            }
            return received;

        }
            
    }
}