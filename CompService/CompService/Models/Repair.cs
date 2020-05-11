using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

public enum RepairStatusEnum { NIE_ROZPOCZETE, W_KOLEJCE, W_TRAKCIE, PRAWIE_UKONCZONE, UKONCZONE }

namespace CompService.Models
{
    public class Repair
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string SerialNumber { get; set; }
        public DateTime StartDate { get; set; }
        public RepairStatusEnum RepairStatus { get; set; }
        public int Price { get; set; }
        public int AdditionalCost { get; set; }

        public string NameAndPrice
        {
            get
            {
                return String.Format("{0} - {1}zł", Name, Price + AdditionalCost);
            }
        }

        public string RepairStatusCorrectFormat
        {
            get
            {
                string result = string.Empty;

                switch (RepairStatus)
                {
                    case RepairStatusEnum.NIE_ROZPOCZETE:
                        result = "Nie rozpoczęte";
                        break;
                    case RepairStatusEnum.W_KOLEJCE:
                        result = "W kolejce";
                        break;
                    case RepairStatusEnum.W_TRAKCIE:
                        result = "W trakcie";
                        break;
                    case RepairStatusEnum.PRAWIE_UKONCZONE:
                        result = "Prawie Ukończone";
                        break;
                    case RepairStatusEnum.UKONCZONE:
                        result = "Ukończone";
                        break;
                    default:
                        break;
                }

                return result;
            }
        }
    }
}
