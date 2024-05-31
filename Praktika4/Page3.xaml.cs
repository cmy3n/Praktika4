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
using Praktika4.DataSet1TableAdapters;

namespace Praktika4
{
    
    public partial class Page3 : Page
    {
        OrdersClientsTableAdapter ordersclients = new OrdersClientsTableAdapter();
        OrdersTableAdapter orders = new OrdersTableAdapter();
        public Page3()
        {
            InitializeComponent();

            dg1.ItemsSource = ordersclients.GetData();

            cb1.ItemsSource = orders.GetData();
            cb1.DisplayMemberPath = "Products";
        }

        private void search_button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (search.Text == "")
                {
                    dg1.ItemsSource = ordersclients.GetData();
                }
                else
                {
                    dg1.ItemsSource = ordersclients.Search(Convert.ToInt32(search.Text));
                } 
            }
            catch
            {

            }
        }

        private void filter_button_Click(object sender, RoutedEventArgs e)
        {
            dg1.ItemsSource = ordersclients.GetData();
        }

        private void cb1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                var id = (int)(cb1.SelectedItem as DataRowView).Row[0];
                dg1.ItemsSource = ordersclients.Filter(id);
            }
            catch
            {

            }
        }

        private void back_page_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Page2());
        }

    }
}
