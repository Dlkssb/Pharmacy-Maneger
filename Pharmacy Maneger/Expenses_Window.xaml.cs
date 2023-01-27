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
    /// Interaction logic for Expenses_Window.xaml
    /// </summary>
    public partial class Expenses_Window : Window
    {
        private readonly MyService _myServices;
        public Expenses_Window(MyService myServices)
        {
            _myServices = myServices;
            InitializeComponent();
            UpdateDataGrid();


        }
        public Expenses_Window()
        {
            InitializeComponent();
            
        }

        private void EnterExpenses_Click(object sender, RoutedEventArgs e)
        {
            if(Desc.Text!="" && Amount.Text!="")
            {
                var E = new Expenses
                {
                    Amount = int.Parse(Amount.Text),
                    Description = Desc.Text
                };

                _myServices.InsertExpenses(E);
                UpdateDataGrid();
            }
        }

        private void UpdateDataGrid()
        {
            ExpensesData.ItemsSource = _myServices.GetExpenses();
            ExpensesData.Items.Refresh();
        }
    }
}
