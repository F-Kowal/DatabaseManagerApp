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
using Microsoft.Extensions.DependencyInjection;

namespace DatabaseManagerApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        NorthwindContext context = new NorthwindContext();
        public MainWindow()
        {
            InitializeComponent();
            DataContext = this;
        }

        CategoriesPage categoriesPage;
        private void ButtonClickCategories(object sender, RoutedEventArgs e)
        {
            if (categoriesPage == null)
            {
                categoriesPage = new CategoriesPage(context);
            }
            Main.Content = categoriesPage;
        }

        CustomersPage customersPage;
        private void ButtonClickCustomers(object sender, RoutedEventArgs e)
        {
            if (customersPage == null)
            {
                customersPage = new CustomersPage(context);
            }
            Main.Content = customersPage;
        }

        EmployeesPage employeesPage;
        private void ButtonClickEmployees(object sender, RoutedEventArgs e)
        {
            if (employeesPage == null)
            {
                employeesPage = new EmployeesPage(context);
            }
            Main.Content = employeesPage;
        }

        OrdersPage ordersPage;
        private void ButtonClickOrders(object sender, RoutedEventArgs e)
        {
            if (ordersPage == null)
            {
                ordersPage = new OrdersPage(context);
            }
            Main.Content = ordersPage;
        }

        ProductsPage productsPage;
        private void ButtonClickProducts(object sender, RoutedEventArgs e)
        {
            if (productsPage == null)
            {
                productsPage = new ProductsPage(context);
            }
            Main.Content = productsPage;
        }
    }
}
