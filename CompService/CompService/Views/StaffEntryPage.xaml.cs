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
    public partial class StaffEntryPage : ContentPage
    {
        public StaffEntryPage()
        {
            InitializeComponent();
        }

        async void OnSaveButtonClicked(object sender, EventArgs e)
        {
            var staffItem = (Staff)BindingContext;

            int index = TypeOfWorkerPicker.SelectedIndex;

            staffItem.Name = NameEntry.Text;
            staffItem.Lastname = LastnameEntry.Text;
            staffItem.Email = EmailEntry.Text;
            staffItem.Password = PasswordEntry.Text;
            staffItem.Phone = Convert.ToInt32(PhoneEntry.Text);
            staffItem.TypeOfWorker = (TypeOfWorkerEnum)index;

            await App.Database.SaveStaffAsync(staffItem);
            await Navigation.PopAsync();
        }

        async void OnDeleteButtonClicked(object sender, EventArgs e)
        {
            var staffItem = (Staff)BindingContext;
            await App.Database.Delete_Staff_Async(staffItem);
            await Navigation.PopAsync();
        }
    }
}