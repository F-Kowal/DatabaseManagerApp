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
    /// Interaction logic for ProductsPage.xaml
    /// </summary>
    public partial class ProductsPage : Page
    {       

        NorthwindContext dbContext;
        Product NewProduct = new Product();
        /// <summary>
        /// Constructor creating instance of ProductsPage and it's components
        /// </summary>
        /// <param name="dbContext"></param>
        public ProductsPage(NorthwindContext dbContext)
        {
            this.dbContext = dbContext;
            InitializeComponent();
            GetProducts();

            AddNewProductGrid.DataContext = NewProduct;
        }

        private void GetProducts()
        {
            ProductsDG.ItemsSource = dbContext.Products.ToList();
        }

        private void AddProduct(object s, RoutedEventArgs e)
        {
            dbContext.Products.Add(NewProduct);
            dbContext.SaveChanges();
            GetProducts();
            NewProduct = new Product();
            AddNewProductGrid.DataContext = NewProduct;
        }

        Product selectedProduct = new Product();
        private void UpdateProductForEdit(object s, RoutedEventArgs e)
        {
            selectedProduct = (s as FrameworkElement).DataContext as Product;
            UpdateProductGrid.DataContext = selectedProduct;
        }

        private void UpdateProduct(object s, RoutedEventArgs e)
        {
            dbContext.Update(selectedProduct);
            dbContext.SaveChanges();
            GetProducts();
        }

        private void DeleteProduct(object s, RoutedEventArgs e)
        {
            var productToBeDeleted = (s as FrameworkElement).DataContext as Product;
            dbContext.Products.Remove(productToBeDeleted);
            dbContext.SaveChanges();
            GetProducts();
        }
    }
}
