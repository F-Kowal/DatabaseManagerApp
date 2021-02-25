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
    /// Interaction logic for CategoriesPage.xaml
    /// </summary>
    public partial class CustomersPage : Page
    {       

        NorthwindContext dbContext;
        Customer NewCustomer = new Customer();
        public CustomersPage(NorthwindContext dbContext)
        {
            this.dbContext = dbContext;
            InitializeComponent();
            GetElements();

            AddNewElementGrid.DataContext = NewCustomer;
        }

        private void GetElements()
        {
            ElementsDG.ItemsSource = dbContext.Categories.ToList();
        }

        private void AddElement(object s, RoutedEventArgs e)
        {
            dbContext.Customers.Add(NewCustomer);
            dbContext.SaveChanges();
            GetElements();
            NewCustomer = new Customer();
            AddNewElementGrid.DataContext = NewCustomer;
        }

        Customer selectedElement = new Customer();
        private void UpdateElementForEdit(object s, RoutedEventArgs e)
        {
            selectedElement = (s as FrameworkElement).DataContext as Customer;
            UpdateElementGrid.DataContext = selectedElement;
        }

        private void UpdateElement(object s, RoutedEventArgs e)
        {
            dbContext.Update(selectedElement);
            dbContext.SaveChanges();
            GetElements();
        }

        private void DeleteElement(object s, RoutedEventArgs e)
        {
            var elementToBeDeleted = (s as FrameworkElement).DataContext as Customer;
            dbContext.Customers.Remove(elementToBeDeleted);
            dbContext.SaveChanges();
            GetElements();
        }
    }
}
