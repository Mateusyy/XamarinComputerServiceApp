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
    public partial class HomePage : ContentPage
    {
        public HomePage()
        {
            InitializeComponent();
        }


        /*async void OnLoginButtonClicked(object sender, EventArgs e)
        {
            var staff = await App.Database.Login_Async(LoginEntry.Text, PasswordEntry.Text);
        }*/
    }
}