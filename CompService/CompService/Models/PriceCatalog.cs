using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace CompService.Models
{
    public class PriceCatalog
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }
    }
}
