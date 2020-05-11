using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CompService.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CompService.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MagazinePage : ContentPage
    {
        public MagazinePage()
        {
            InitializeComponent();
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();

            listView.ItemsSource = await App.Database.GetData_Magazine_Async();
        }

        async void OnMagazineItemAddedClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new MagazineEntryPage
            {
                BindingContext = new Magazine()
            });
        }

        async void OnListViewItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if(e.SelectedItem != null)
            {
                await Navigation.PushAsync(new MagazineEntryPage
                {
                    BindingContext = e.SelectedItem as Magazine
                });
            }
        }
    }
}