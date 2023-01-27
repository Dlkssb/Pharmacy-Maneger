using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pharmacy_Maneger.Models
{
    public class SellItem
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<BillGood> BillGoods { get; set; }
        public Company company { get; set; }

        public string Date { get; set; }

        public int price { get; set; }

        public int NetPrice { get; set; }
    }
}
