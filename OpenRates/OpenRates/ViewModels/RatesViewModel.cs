using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace OpenRates
{
    public class RatesViewModel
    {
        public RatesViewModel()
        {
            rates = new Dictionary<string, string>();
            currencies = new List<Currency>();
            viewCurrencies = new ObservableCollection<Currency>();
        }

        public string disclaimer { get; set; }

        public string license { get; set; }

        public string timestamp { get; set; }

        public string @base { get; set; }

        public Dictionary<string, string> rates { get; set; }

        public List<Currency> currencies { get; set; }

        public ObservableCollection<Currency> viewCurrencies { get; set;}

        public void updateRates()
        {
            foreach (KeyValuePair<string, string> item in rates)
            {
                var currentCurrency = currencies.Find(x => x.Abbreviation == item.Key);
                currentCurrency.Rate = item.Value;
                viewCurrencies.Add(currentCurrency);
            }
        }
    }
}

