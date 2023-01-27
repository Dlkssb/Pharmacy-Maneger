using Microsoft.Extensions.DependencyInjection;
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
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        private readonly MyService _myService;
        public Window1(MyService myService)
        {
            _myService = myService;
            
            InitializeComponent();
            CompanyName.ItemsSource = _myService.GetCompanies();
            CompanyName.DisplayMemberPath = "Name";
            CompanyName.SelectedValue = "Id";
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            var ComName = CompanyName.SelectedValue.ToString();
            var MadN = MadName.Text;
            var price1=int.Parse(PriceOne.Text);
            var price2 = int.Parse(PriceTwo.Text);
            var exp=ExpDate.Text;
            var con = int.Parse(Con.Text);
            if(ComName!=""&& MadN!=null&& price1!=null&& price2!=null && exp!=null)
            {
                SellItem Good = new SellItem
                {
                    Date = exp,
                    Name=MadN,
                    price=price1,
                    NetPrice=price2,
                    company=new Company { Name=ComName}
                };
                _myService.AddGood(Good);
            }

        }

        private void Update_Click(object sender, RoutedEventArgs e)
        {
            var ComName = CompanyName.SelectedValue.ToString();
            var MadN = MadName.Text;
            var price1 = int.Parse(PriceOne.Text);
            var price2 = int.Parse(PriceTwo.Text);
            var exp = ExpDate.Text;
            var con = int.Parse(Con.Text);
            if (ComName != "" && MadN != null && price1 != null && price2 != null && exp != null)
            {
                SellItem Good = new SellItem
                {
                    Date = exp,
                    Name = MadN,
                    price = price1,
                    NetPrice = price2,
                    company = new Company { Name = ComName }
                };
             var i=  _myService.UpDateGood(Good);
                
            }
        }
    }
}
