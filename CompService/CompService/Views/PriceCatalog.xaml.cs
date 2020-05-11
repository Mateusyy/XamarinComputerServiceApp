using CompService.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CompService.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PriceCatalog : ContentPage
    {
        public PriceCatalog()
        {
            InitializeComponent();
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();

            listView.ItemsSource = await App.Database.GetData_PriceCatalog_Async();
        }

        async void OnPriceCatalogItemAddedClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new PriceCatalogEntryPage
            {
                BindingContext = new CompService.Models.PriceCatalog()
            });
        }

        async void OnListViewItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            await Navigation.PushAsync(new PriceCatalogEntryPage
            {
                BindingContext = e.SelectedItem as CompService.Models.PriceCatalog
            });
        }
    }
}