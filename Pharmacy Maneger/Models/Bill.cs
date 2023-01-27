using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pharmacy_Maneger.Models
{
    public class Bill
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public Customer Customer { get; set; }
        public decimal Amount { get; set; }
        public DateTime Date { get; set; }= DateTime.Now;
        public ICollection<BillGood> BillGoods { get; set; }
    }
}
