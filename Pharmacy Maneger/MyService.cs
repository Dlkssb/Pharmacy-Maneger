using Microsoft.EntityFrameworkCore;
using Pharmacy_Maneger.Data;
using Pharmacy_Maneger.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Pharmacy_Maneger
{
    public class MyService
    {
        private readonly AppDbContext _context;
        public MyService(AppDbContext context)
        {
            _context = context;
            MessageBox.Show(_context.Database.GetConnectionString());
            _context.Database.EnsureCreated();
            _context.Database.OpenConnection();
            


        }

        public void AddCustomer(Customer customer)
        {
            _context.Customers.Add(customer);
            _context.SaveChanges();
        }

        public Customer GetCustomer(int id)
        {
            return _context.Customers
                .Include(c => c.Bills)
                .ThenInclude(b => b.BillGoods)
                .ThenInclude(bg => bg.Good)
                .SingleOrDefault(c => c.Id == id);
        }

        public List<Bill> GetCustomerBills(int customerId)
        {
            return _context.Bills
                .Where(b => b.CustomerId == customerId)
                .ToList();
        }

        public void AddBill(Bill bill)
        {
            _context.Bills.Add(bill);
            _context.SaveChanges();
        }

        public Bill GetBill(int id)
        {
            return _context.Bills
                .Include(b => b.Customer)
                .Include(b => b.BillGoods)
                .ThenInclude(bg => bg.Good)
                .SingleOrDefault(b => b.Id == id);
        }

        public List<SellItem> GetGoods()
        {
            return _context.sellItems.ToList();
        }

        public int UpDateGood(SellItem good)
        {
           var g= _context.sellItems.SingleOrDefault(x => x.Id == good.Id);
            if (g != null)
            {
                _context.sellItems.Update(good);
                return g.Id;
            }
            else
                throw new Exception("Good not found during the update");
        }
        public List<Company> GetCompanies()
        {
           return _context.Company.ToList();
        }

        public void AddGood(SellItem good)
        {
            _context.sellItems.Add(good);
            _context.SaveChanges();
        }

        public SellItem GetGood(int id)
        {
            return _context.sellItems.SingleOrDefault(g => g.Id == id);
        }

        public void AddCompany(Company company)
        {
            _context.Company.Add(company);
            _context.SaveChanges();
        }

        public Company GetCompany(int id)
        {
            return _context.Company
                .Include(c => c.sellItems)
                .SingleOrDefault(c => c.Id == id);
        }

        public void AddBillGood(BillGood billGood)
        {
            _context.BillGoods.Add(billGood);
            _context.SaveChanges();
        }

        public BillGood GetBillGood(int billId, int goodId)
        {
            return _context.BillGoods
                .Include(bg => bg.Bill)
                .Include(bg => bg.Good)
                .SingleOrDefault(bg => bg.BillId == billId && bg.GoodId == goodId);
        }

        public void DeleteCustomer(int id)
        {
           Customer cutomer= _context.Customers.SingleOrDefault(c => c.Id == id);  
            if( cutomer!=null)
            {
                _context.Customers.Remove(cutomer);
            }

            else
            {
                throw new Exception("Cutomer not found Check the ID");
            }
        }

        public void DeleteGood(int id)
        {
            var good=_context.sellItems.SingleOrDefault(c => c.Id == id);
            if(good!=null)
            {
                _context.Remove(good);
            }
            else
            {
                throw new Exception("Good not found");
            }
        }

        public void deleteCompany(int id)
        {
         var company=   _context.Company.SingleOrDefault(c => c.Id == id);
            if (company != null)
            {
                _context.Company.Remove(company);
            }
            else
            {
                throw new Exception("company not found");
            }
        }

        public void deleteBill(int id)
        {
            var bill = _context.Bills.SingleOrDefault(c => c.Id == id);
            if (bill != null)
            {
                _context.Bills.Remove(bill);
            }
            else
            {
                throw new Exception("bill not found");
            }
        }

        public List<Customer> GetCustomers()
        {
            return _context.Customers.ToList<Customer>();
        }

        public List<Bill> GetBills()
        {
            return _context.Bills
        .Include(b => b.BillGoods)
            .ThenInclude(bg => bg.Good)
        .Include(b => b.Customer)
        .ToList();
        }

        public List<Expenses> GetExpenses()
        {
            try
            {
                return _context.Expenses.ToList();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
                return new List<Expenses>();
            }
        }

        public void InsertExpenses(Expenses expenses )
        {
            if(expenses !=null)
            {
                _context.Expenses.Add(expenses);
            }
        }
    }

}
