using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CompService.Data;
using CompService.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CompService.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PriceCatalogEntryPage : ContentPage
    {
        public PriceCatalogEntryPage()
        {
            InitializeComponent();
        }

        async void OnSaveButtonClicked(object sender, EventArgs e)
        {
            var priceCatalogItem = (CompService.Models.PriceCatalog)BindingContext;
            priceCatalogItem.Name = NameEntry.Text;
            priceCatalogItem.Price = Convert.ToInt32(PriceEntry.Text);

            await App.Database.SavePriceCatalogAsync(priceCatalogItem);
            await Navigation.PopAsync();
        }

        async void OnDeleteButtonClicked(object sender, EventArgs e)
        {
            var priceCatalogItem = (CompService.Models.PriceCatalog)BindingContext;
            await App.Database.Delete_PriceCatalogItem_Async(priceCatalogItem);
            await Navigation.PopAsync();
        }
    }
}