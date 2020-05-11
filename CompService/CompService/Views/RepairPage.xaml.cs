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
    public partial class RepairPage : ContentPage
    {
        public RepairPage()
        {
            InitializeComponent();
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();

            listView.ItemsSource = await App.Database.GetData_Repair_Async();
        }

        async void OnRepairItemAddedClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new RepairEntryPage
            {
                BindingContext = new Repair()
            });
        }

        async void OnListViewItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            await Navigation.PushAsync(new RepairEntryPage
            {
                BindingContext = e.SelectedItem as Repair
            });
        }
    }
}