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
    public partial class Page1 : Page
    {
        ClientsTableAdapter clients = new ClientsTableAdapter();
        public Page1()
        {
            InitializeComponent();

            dg1.ItemsSource = clients.GetData();

            cb1.ItemsSource = clients.GetData();
            cb1.DisplayMemberPath = "ClientSurname";
        }

        private void search_button_Click(object sender, RoutedEventArgs e)
        {
            dg1.ItemsSource = clients.Search(search.Text);
        }

        private void next_page_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Page2());
        }

        private void filter_button_Click(object sender, RoutedEventArgs e)
        {
            dg1.ItemsSource = clients.GetData();
        }

        private void cb1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                string surname = (cb1.SelectedItem as DataRowView).Row[1].ToString();
                dg1.ItemsSource = clients.Filter(surname);
            }
            catch 
            {

            }
        }
    }
}
