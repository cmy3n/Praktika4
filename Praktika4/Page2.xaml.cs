using Praktika4.DataSet1TableAdapters;
using System;
using System.Collections.Generic;
using System.Data;
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

namespace Praktika4
{
    
    public partial class Page2 : Page
    {
        OrdersTableAdapter orders = new OrdersTableAdapter();

        public Page2()
        {
            InitializeComponent();

            dg1.ItemsSource = orders.GetData();

            cb1.ItemsSource = orders.GetData();
            cb1.DisplayMemberPath = "Order_Number";
        }

        private void next_page_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Page3());
        }

        private void filter_button_Click(object sender, RoutedEventArgs e)
        {
            dg1.ItemsSource = orders.GetData(); 
        }

        private void search_button_Click(object sender, RoutedEventArgs e)
        {
            dg1.ItemsSource = orders.Search(search.Text);
        }

        private void cb1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                int order_number = (int)(cb1.SelectedItem as DataRowView).Row[1];
                dg1.ItemsSource = orders.Filter(order_number);
            }
            catch
            {

            }
        }

        private void back_page_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Page1());
        }
    }
}
