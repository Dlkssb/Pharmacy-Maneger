using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pharmacy_Maneger.Models
{
    public class Expenses
    {
        [PrimaryKey,AutoIncrement]
        public int Id { get; set; }
        public string Description { get;set; }

        public DateTime date { get; set; }= DateTime.Now;

        public decimal Amount { get; set; }
    }
}
