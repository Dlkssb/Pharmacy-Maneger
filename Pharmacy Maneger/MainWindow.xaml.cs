using Microsoft.Extensions.DependencyInjection;
using Pharmacy_Maneger.Data;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Pharmacy_Maneger
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly MyService? _myService;

        public MainWindow()
        {
            InitializeComponent();
        }

        public MainWindow(MyService serviceProvider)
        {
            InitializeComponent();
            _myService = serviceProvider;
                Console.Write(_myService);
            ReciptDetiles.ItemsSource = _myService.GetBills();
            total.Content = Sum().ToString();
            total2.Content = Sum().ToString();
            this.Activated += MainWindow_Activated;

        }



        private void MainWindow_Activated(object sender, EventArgs e)
        {
            ReciptDetiles.ItemsSource = _myService.GetBills();
            total.Content = Sum().ToString();
            total2.Content = Sum().ToString();
            ReciptDetiles.Items.Refresh();
        }

        private void addBill_Click(object sender, RoutedEventArgs e)
        {
            bill b = new bill(_myService);
            b.Show();


        }

        private void OnStartup(object sender, RoutedEventArgs e)
        {
            // code that runs when the application starts
           
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Window1 w = new Window1(_myService);
            w.Show();
        }

        public decimal Sum()
        {
            var currentDate = DateTime.Now.Date;
            var currentDateBills = _myService.GetBills()
                                      .Where(b => b.Date.Date == currentDate)
                                      .ToList();
            var totalAmount = currentDateBills.Sum(b => b.Amount);
            return totalAmount;
        }
        
        private void SearchR_Click(object sender, RoutedEventArgs e)
        {
            var s = int.Parse(RicptNumber.Text);
            List<Bill> ss = new List<Bill>();
            ss.Add(_myService.GetBill(s));
            ReciptDetiles.ItemsSource = ss;
        }

        private void RicptNumber_TextChanged(object sender, TextChangedEventArgs e)
        {
            if(RicptNumber.Text=="")
            {
                ReciptDetiles.ItemsSource = _myService.GetBills();
            }

        }

        private void DailyE_Click(object sender, RoutedEventArgs e)
        {
            Expenses_Window expenses_Window=new Expenses_Window(_myService);
            expenses_Window.Show();
        }
    }
}
