using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace CompService.Models
{
    public class Magazine
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        public string PartName { get; set; }
        public int Counter { get; set; }
    }
}
