using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace OpenRates
{
    public partial class RatesListPage : ContentPage
    {
        public RatesListPage()
        {
            InitializeComponent();
        }

        public void OnMore (object sender, EventArgs e) {
            var mi = ((MenuItem)sender);
            DisplayAlert("More Context Action", mi.CommandParameter + " more context action", "OK");
        }

        public void OnDelete (object sender, EventArgs e) {
            var mi = ((MenuItem)sender);
            DisplayAlert("Delete Context Action", mi.CommandParameter + " delete context action", "OK");
        }
    }
}

