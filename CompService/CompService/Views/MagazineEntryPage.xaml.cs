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
    public partial class MagazineEntryPage : ContentPage
    {
        public MagazineEntryPage()
        {
            InitializeComponent();
        }

        async void OnSaveButtonClicked(object sender, EventArgs e)
        {
            var magazineItem = (Magazine)BindingContext;

            magazineItem.PartName = PartNameEntry.Text;
            magazineItem.Counter = Convert.ToInt32(CountEntry.Text);

            await App.Database.SaveMagazineAsync(magazineItem);
            await Navigation.PopAsync();
        }

        async void OnDeleteButtonClicked(object sender, EventArgs e)
        {
            var magazineItem = (Magazine)BindingContext;
            await App.Database.Delete_Magazine_Async(magazineItem);
            await Navigation.PopAsync();
        }
    }
}