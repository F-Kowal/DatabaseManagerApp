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
    public partial class CategoriesPage : Page
    {       

        NorthwindContext dbContext;
        Category NewCategory = new Category();
        public CategoriesPage(NorthwindContext dbContext)
        {
            this.dbContext = dbContext;
            InitializeComponent();
            GetCategories();

            AddNewCategoryGrid.DataContext = NewCategory;
        }

        private void GetCategories()
        {
            CategoriesDG.ItemsSource = dbContext.Categories.ToList();
        }

        private void AddCategory(object s, RoutedEventArgs e)
        {
            dbContext.Categories.Add(NewCategory);
            dbContext.SaveChanges();
            GetCategories();
            NewCategory = new Category();
            AddNewCategoryGrid.DataContext = NewCategory;
        }

        Category selectedCategory = new Category();
        private void UpdateCategoryForEdit(object s, RoutedEventArgs e)
        {
            selectedCategory = (s as FrameworkElement).DataContext as Category;
            UpdateCategoryGrid.DataContext = selectedCategory;
        }

        private void UpdateCategory(object s, RoutedEventArgs e)
        {
            dbContext.Update(selectedCategory);
            dbContext.SaveChanges();
            GetCategories();
        }

        private void DeleteCategory(object s, RoutedEventArgs e)
        {
            var categoryToBeDeleted = (s as FrameworkElement).DataContext as Category;
            dbContext.Categories.Remove(categoryToBeDeleted);
            dbContext.SaveChanges();
            GetCategories();
        }
    }
}
