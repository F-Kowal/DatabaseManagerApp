using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace DatabaseManagerApp
{
    /// <summary>
    /// Interaction logic for CustomersPage.xaml
    /// </summary>
    public partial class CustomersPage : Page
    {       

        NorthwindContext dbContext;
        Customer NewCustomer = new Customer();
        public CustomersPage(NorthwindContext dbContext)
        {
            this.dbContext = dbContext;
            InitializeComponent();
            GetCustomers();

            AddNewCustomerGrid.DataContext = NewCustomer;
        }

        private void GetCustomers()
        {
            CustomersDG.ItemsSource = dbContext.Customers.ToList();
        }

        private void AddCustomer(object s, RoutedEventArgs e)
        {
            dbContext.Customers.Add(NewCustomer);
            dbContext.SaveChanges();
            GetCustomers();
            NewCustomer = new Customer();
            AddNewCustomerGrid.DataContext = NewCustomer;
        }

        Customer selectedCustomer = new Customer();
        private void UpdateCustomerForEdit(object s, RoutedEventArgs e)
        {
            selectedCustomer = (s as FrameworkElement).DataContext as Customer;
            UpdateCustomerGrid.DataContext = selectedCustomer;
        }

        private void UpdateCustomer(object s, RoutedEventArgs e)
        {
            dbContext.Update(selectedCustomer);
            dbContext.SaveChanges();
            GetCustomers();
        }

        private void DeleteCustomer(object s, RoutedEventArgs e)
        {
            var customerToBeDeleted = (s as FrameworkElement).DataContext as Customer;
            dbContext.Customers.Remove(customerToBeDeleted);
            dbContext.SaveChanges();
            GetCustomers();
        }
    }
}
