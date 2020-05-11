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
    public partial class MainPage : MasterDetailPage
    {
        private Dictionary<int, NavigationPage> MenuPages = new Dictionary<int, NavigationPage>();

        public MainPage()
        {
            InitializeComponent();

            MasterBehavior = MasterBehavior.Popover;

            MenuPages.Add((int)MenuItemType.StronaGlowna, (NavigationPage)Detail);
        }

        public async Task NavigateFromMenu(int id)
        {
            if (!MenuPages.ContainsKey(id))
            {
                switch (id)
                {
                    case (int)MenuItemType.StronaGlowna:
                        MenuPages.Add(id, new NavigationPage(new HomePage()));
                        break;
                    case (int)MenuItemType.Naprawy:
                        MenuPages.Add(id, new NavigationPage(new RepairPage()));
                        break;
                    case (int)MenuItemType.Cennik:
                        MenuPages.Add(id, new NavigationPage(new PriceCatalog()));
                        break;
                    case (int)MenuItemType.Personel:
                        MenuPages.Add(id, new NavigationPage(new StaffPage()));
                        break;
                    case (int)MenuItemType.Magazyn:
                        MenuPages.Add(id, new NavigationPage(new MagazinePage()));
                        break;
                }
            }

            var newPage = MenuPages[id];

            if(newPage != null && Detail != newPage)
            {
                Detail = newPage;

                if (Device.RuntimePlatform == Device.Android)
                    await Task.Delay(100);

                IsPresented = false;
            }
        }
    }
}