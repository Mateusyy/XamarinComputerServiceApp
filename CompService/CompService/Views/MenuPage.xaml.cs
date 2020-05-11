using CompService.Models;
using System.Collections.Generic;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CompService.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MenuPage : ContentPage
    {
        private MainPage RootPage { get => Application.Current.MainPage as MainPage; }
        private List<HomeMenuItem> menuItems;

        public MenuPage()
        {
            InitializeComponent();

            menuItems = new List<HomeMenuItem>
            {
                new HomeMenuItem {Id = MenuItemType.StronaGlowna, Title="Strona główna" },
                new HomeMenuItem {Id = MenuItemType.Naprawy, Title="Naprawy" },
                new HomeMenuItem {Id = MenuItemType.Cennik, Title="Cennik" },
                new HomeMenuItem {Id = MenuItemType.Personel, Title="Personel" },
                new HomeMenuItem {Id = MenuItemType.Magazyn, Title="Magazyn" }
            };

            ListViewMenu.ItemsSource = menuItems;
            ListViewMenu.SelectedItem = menuItems[0];
            ListViewMenu.ItemSelected += async (sender, e) =>
            {
                if (e.SelectedItem == null)
                    return;

                var id = (int)((HomeMenuItem)e.SelectedItem).Id;
                await RootPage.NavigateFromMenu(id);
            };
        }
    }
}