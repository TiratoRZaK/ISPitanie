using System.Data;
using System.Windows;
using System;
using System.Windows.Controls;
using System.Data.Entity;
using System.ComponentModel;
using System.Collections.Generic;
using System.Linq;
using ISPitanie.Views;
using DAL.Repository;
using DAL.Entities;
using DAL.Repositories;

namespace ISPitanie
{
    public partial class MainWindow : Window
    {

        private EFUnitOfWork db;

        public MainWindow()
        {
            InitializeComponent();
            db = new EFUnitOfWork();
            productDataGrid.ItemsSource = db.Products.GetAll().ToList();
            dishesDataGrid.ItemsSource = db.Dishes.GetAll().ToList();

            this.Closing += MainWindow_Closing;
        }

        private void MainWindow_Closing(object sender, CancelEventArgs e)
        {
            db.Dispose();
        }


        private void ShowHideDetails(object sender, RoutedEventArgs e)
        {
            int id = (int)(sender as Button).CommandParameter;
            var list = db.ProductDishes.GetAll().Where(x => x.DishId == id);
            List<Product> listProduct = new List<Product>();
            String str = " ";
            foreach (var item in list)
            {
                listProduct.Add(item.Product);
                str += item.Product.Name+" ";
            }
            (sender as Button).Content = str;
            (sender as Button).IsEnabled = false;
        }

        private void EditProduct(object sender, RoutedEventArgs e)
        {
            Product cur = productDataGrid.CurrentItem as Product;
            Product product = db.Products.Get(cur.Id);
            EditProductForm editProduct = new EditProductForm(product);
            editProduct.Show();
        }

        private void DeleteProduct(object sender, RoutedEventArgs e)
        {
            var cur = productDataGrid.CurrentItem as Product;
            MessageBoxResult res = MessageBox.Show("Вы уверены что хотите удалить продукт " + cur.Name + " безвозвратно?", "Удаление продукта", MessageBoxButton.YesNo);
            var prod = db.Products.GetAll().Where(x => x.Id == cur.Id).FirstOrDefault();

            if (prod != null && res == MessageBoxResult.Yes)
            {
                IEnumerable<ProductDish> prodDishes = db.ProductDishes.GetAll().Where(x => x.ProductId == prod.Id);
                Delete_prodDish(prodDishes);
                db.Products.Delete(prod.Id);
                db.Save();
            }
            productDataGrid.Items.Refresh();
        }

        private void Delete_prodDish(IEnumerable<ProductDish> productsDishes)
        {
            foreach(var item in productsDishes)
            {
                db.ProductDishes.Delete(item.Id);
            }
            db.Save();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

        }

        private void TabControl_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            AddProductForm addProduct = new AddProductForm();
            addProduct.Show();
        }

        private void Window_Activated(object sender, EventArgs e)
        {
            
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            productDataGrid.Items.Refresh();
        }

        private void EditDishes(object sender, RoutedEventArgs e)
        {
            Dish cur = dishesDataGrid.CurrentItem as Dish;
            Dish dish = db.Dishes.Get(cur.Id);
            EditDishesForm editDishes = new EditDishesForm(dish);
            editDishes.Show();
        }

        private void DeleteDishes(object sender, RoutedEventArgs e)
        {
            var cur = dishesDataGrid.CurrentItem as Dish;
            MessageBoxResult res = MessageBox.Show("Вы уверены что хотите удалить блюдо " + cur.Name + " безвозвратно?", "Удаление блюда", MessageBoxButton.YesNo);
            var dish = db.Dishes.GetAll().Where(x => x.Id == cur.Id).FirstOrDefault();

            if (dish != null && res == MessageBoxResult.Yes)
            {
                var prodDishes = db.ProductDishes.GetAll().Where(x => x.DishId == cur.Id);
                Delete_prodDish(prodDishes);
                db.Dishes.Delete(dish.Id);
                db.Save();
            }
            dishesDataGrid.Items.Refresh();
        }
    }
}
