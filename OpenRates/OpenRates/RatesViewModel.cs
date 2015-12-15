using System;
using System.Collections.Generic;

namespace OpenRates
{
    public class RatesViewModel
    {
        public string disclaimer { get; set; }

        public string license { get; set; }

        public string timestamp { get; set; }

        public string baseCurrency { get; set; }

        public Dictionary<string, string> rates { get; set; }

        public List<string> realRates { get; set; }

        public void convertToViewStrings() 
        {
            this.realRates = new List<string>();
            foreach(KeyValuePair<string, string> item in this.rates) {
                string keyValue = item.Key + ": " + item.Value;
                this.realRates.Add(keyValue);
            }
        }
    }
}

