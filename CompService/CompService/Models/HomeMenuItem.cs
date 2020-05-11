using System;
using System.Collections.Generic;
using System.Text;

namespace CompService.Models
{
    public enum MenuItemType
    {
        StronaGlowna,
        Naprawy,
        Cennik,
        Personel,
        Magazyn
    }
    class HomeMenuItem
    {
        public MenuItemType Id { get; set; }
        public string Title { get; set; }
    }
}
