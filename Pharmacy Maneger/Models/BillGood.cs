using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pharmacy_Maneger.Models
{
    public class BillGood

    {
        [PrimaryKey, AutoIncrement]
        public int id { get;set; }
        public int BillId { get; set; }
        public Bill Bill { get; set; }
        public int GoodId { get; set; }
        public SellItem Good { get; set; }
    }
}
