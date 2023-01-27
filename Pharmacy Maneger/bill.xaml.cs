using Pharmacy_Maneger.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Pharmacy_Maneger
{
    /// <summary>
    /// Interaction logic for bill.xaml
    /// </summary>
    public partial class bill : Window
    {

        private readonly MyService myService;
        public int totalBill=0;
        public string customer;
        public Customer c;
        List<SellItem> sellItems;
        
        public bill(MyService myService)
        {
            this.myService = myService;
            InitializeComponent();
            CustomerName.ItemsSource = myService.GetCustomers();
            CustomerName.SelectedValuePath = "Id";
            CustomerName.DisplayMemberPath = "Name";

            MadName.ItemsSource=myService.GetGoods();
            MadName.SelectedValuePath = "Id";
            MadName.DisplayMemberPath = "Name";

            sellItems = new List<SellItem>();
        }

        private void NewItem_Click(object sender, RoutedEventArgs e)
        {
             customer = CustomerName.SelectedValue.ToString();
            var mad = MadName.SelectedValue.ToString();
            var count = Con.Text;
            var total=Sum.Text;
            if(customer != null && mad != null)
            {
                CustomerName.IsEnabled = false;
                MessageBox.Show(mad);
                var m = myService.GetGood(int.Parse(mad));
                 c=myService.GetCustomer(int.Parse(customer));
                totalBill += m.price*int.Parse(count);
                sellItems.Add(m);
                MadName.Text = "";
                Con.Text = "";
                Sum.Text = totalBill.ToString();

                UpdateDataGrid();


            }
            else
            {
                MessageBox.Show("enter Customer Name or the madicain");
                
            }

        }

        private void BillExport_Click(object sender, RoutedEventArgs e)
        {
            Bill bill=new Bill();
            bill.Customer = c;
            bill.CustomerId = c.Id;
            bill.Amount = totalBill;
            List<BillGood> billGoods=new List<BillGood>();
            myService.AddBill(bill);
            foreach (var n in sellItems)
            {
                billGoods.Add(new BillGood
                {
                   BillId=bill.Id,
                    Good = n,
                    GoodId = n.Id,

                });
                    }
            foreach (var good in billGoods)
                myService.AddBillGood(good);
          //  bill.BillGoods = billGoods;
            
        }

        private void UpdateDataGrid()
        {
            BilLData.ItemsSource = sellItems;
            BilLData.Items.Refresh();
        }
    }
}
