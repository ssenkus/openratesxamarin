using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using Xamarin.Forms;

namespace OpenRates
{
    public partial class RatesListPage : ContentPage
    {

        public RatesListPage()
        {
            InitializeComponent();
        }

        public void OnShowDetails(object sender, EventArgs e)
        {

            Navigation.PushAsync(new OpenRates.SingleRatePage());
        }

        public void OnRefreshRates(object sender, EventArgs e)
        {
            App.ratesRepository.getLatest();
        }
            
        public void OnDelete(object sender, EventArgs e)
        {
            var mi = ((MenuItem)sender);
            DisplayAlert("Placeholder", mi.CommandParameter + " would be deleted if set up", "OK");
        }
    }
}

