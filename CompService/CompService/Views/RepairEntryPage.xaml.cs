using CompService.Data;
using CompService.Models;
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
    public partial class RepairEntryPage : ContentPage
    {
        private List<CompService.Models.PriceCatalog> priceCatalogFromDatabase;

        public RepairEntryPage()
        {
            InitializeComponent();
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();

            priceCatalogFromDatabase = await App.Database.GetData_PriceCatalog_Async();
            PriceCatalogPicker.ItemsSource = priceCatalogFromDatabase;
        }

        async void OnSaveButtonClicked(object sender, EventArgs e)
        {
            var repairItem = (Repair)BindingContext;

            int indexOfRepairStatus = StatusPicker.SelectedIndex;
            int indexOfPriceCatalog = PriceCatalogPicker.SelectedIndex;
            int totalPrice = 0;

            if (!String.IsNullOrEmpty(AdditionalCostEntry.Text))
            {
                totalPrice = priceCatalogFromDatabase[indexOfPriceCatalog].Price + Convert.ToInt32(AdditionalCostEntry.Text);
            }
            else
            {
                totalPrice = priceCatalogFromDatabase[indexOfPriceCatalog].Price;
            }

            repairItem.Name = NameEntry.Text;
            repairItem.Description = DescriptionEntry.Text;
            repairItem.SerialNumber = SerialNumberEntry.Text;
            repairItem.StartDate = System.DateTime.UtcNow;
            repairItem.RepairStatus = (RepairStatusEnum)indexOfRepairStatus;
            repairItem.Price = totalPrice;

            await App.Database.SaveRepairAsync(repairItem);
            await Navigation.PopAsync();
        }

        async void OnDeleteButtonClicked(object sender, EventArgs e)
        {
            var repairItem = (Repair)BindingContext;
            await App.Database.Delete_Repair_Async(repairItem);
            await Navigation.PopAsync();
        }
    }
}