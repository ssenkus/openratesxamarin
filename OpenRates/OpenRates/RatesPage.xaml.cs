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
            App.ratesRepository.getLatest();
        }
    }

}