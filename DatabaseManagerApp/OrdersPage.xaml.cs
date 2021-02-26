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
    /// Interaction logic for OrdersPage.xaml
    /// </summary>
    public partial class OrdersPage : Page
    {       

        NorthwindContext dbContext;
        Order NewOrder = new Order();
        /// <summary>
        /// Constructor creating instance of OrdersPage and it's components
        /// </summary>
        /// <param name="dbContext"></param>
        public OrdersPage(NorthwindContext dbContext)
        {
            this.dbContext = dbContext;
            InitializeComponent();
            GetOrders();

            AddNewOrderGrid.DataContext = NewOrder;
        }

        private void GetOrders()
        {
            OrdersDG.ItemsSource = dbContext.Orders.ToList();
        }

        private void AddOrder(object s, RoutedEventArgs e)
        {
            dbContext.Orders.Add(NewOrder);
            dbContext.SaveChanges();
            GetOrders();
            NewOrder = new Order();
            AddNewOrderGrid.DataContext = NewOrder;
        }

        Order selectedOrder = new Order();
        private void UpdateOrderForEdit(object s, RoutedEventArgs e)
        {
            selectedOrder = (s as FrameworkElement).DataContext as Order;
            UpdateOrderGrid.DataContext = selectedOrder;
        }

        private void UpdateOrder(object s, RoutedEventArgs e)
        {
            dbContext.Update(selectedOrder);
            dbContext.SaveChanges();
            GetOrders();
        }

        private void DeleteOrder(object s, RoutedEventArgs e)
        {
            var orderToBeDeleted = (s as FrameworkElement).DataContext as Order;
            dbContext.Orders.Remove(orderToBeDeleted);
            dbContext.SaveChanges();
            GetOrders();
        }
    }
}
