using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

public enum TypeOfWorkerEnum { STAZYSTA, PRACOWNIK, KIEROWNIK, SZEF }

namespace CompService.Models
{
    public class Staff
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        public string Name { get; set; }
        public string Lastname { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        [MaxLength(9)]
        public int Phone { get; set; }
        public TypeOfWorkerEnum TypeOfWorker { get; set; }


        public string NameAndLastname
        {
            get
            {
                return String.Format("{0} {1}", Name, Lastname);
            }
        }
    }
}
