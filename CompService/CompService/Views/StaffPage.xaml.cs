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
    public partial class StaffPage : ContentPage
    {
        public StaffPage()
        {
            InitializeComponent();
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();

            listView.ItemsSource = await App.Database.GetData_Staff_Async();
        }

        async void OnStaffItemAddedClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new StaffEntryPage
            {
                BindingContext = new Staff()
            });
        }

        async void OnListViewItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            await Navigation.PushAsync(new StaffEntryPage
            {
                BindingContext = e.SelectedItem as Staff
            });
        }
    }
}