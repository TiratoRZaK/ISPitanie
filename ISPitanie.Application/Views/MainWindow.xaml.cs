using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows;
using AutoMapper;
using ISPitanie.BLL.Entities;
using ISPitanie.Interfaces;
using ISPitanie.Models;

namespace ISPitanie
{
    public partial class MainWindow : Window
    {
        private IProductService ProductService { get; set; }
        private IDishService DishService { get; set; }

        public MainWindow()
        {
            InitializeComponent();
        }

        public MainWindow(IProductService productService, IDishService dishService) : this()
        {
            this.ProductService = productService;
            this.DishService = dishService;

            var products = productService.GetProducts();
            var productModels = Mapper.Map<IEnumerable<ProductViewModel>>(products);

            productDataGrid.ItemsSource = productModels.ToList();
            //dishesDataGrid.ItemsSource = this.dishService.GetDishes().ToList();

            this.Closing += MainWindow_Closing;
        }

        private void MainWindow_Closing(object sender, CancelEventArgs e)
        {
            ProductService.Dispose();
        }

        private void ShowHideDetails(object sender, RoutedEventArgs e)
        {
            //int id = (int)(sender as Button).CommandParameter;
            //var list = db.ProductDishes.GetAll().Where(x => x.DishId == id);
            //List<Product> listProduct = new List<Product>();
            //String str = " ";
            //foreach (var item in list)
            //{
            //    listProduct.Add(item.Product);
            //    str += item.Product.Name+" ";
            //}
            //(sender as Button).Content = str;
            //(sender as Button).IsEnabled = false;
        }

        private void EditProduct(object sender, RoutedEventArgs e)
        {
            Product cur = productDataGrid.CurrentItem as Product;
            Product product = ProductService.GetProduct(cur.Id);
            //EditProductForm editProduct = new EditProductForm(product);
            //editProduct.Show();
        }

        private void DeleteProduct(object sender, RoutedEventArgs e)
        {
            var cur = productDataGrid.CurrentItem as Product;
            MessageBoxResult res = MessageBox.Show("Вы уверены что хотите удалить продукт " + cur.Name + " безвозвратно?", "Удаление продукта", MessageBoxButton.YesNo);
            var prod = ProductService.GetProduct(cur.Id);
            if (prod != null && res == MessageBoxResult.Yes)
            {
                ProductService.RemoveProduct(prod);
            }
            productDataGrid.Items.Refresh();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //AddProductForm addProduct = new AddProductForm();
            //addProduct.Show();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            productDataGrid.Items.Refresh();
        }

        private void EditDishes(object sender, RoutedEventArgs e)
        {
            //DishDTO cur = dishesDataGrid.CurrentItem as DishDTO;
            //DishDTO dish = dishService.GetDish(cur.Id);
            //EditDishesForm editDishes = new EditDishesForm(dish);
            //editDishes.Show();
        }

        private void DeleteDishes(object sender, RoutedEventArgs e)
        {
            //var cur = dishesDataGrid.CurrentItem as DishDTO;
            //MessageBoxResult res = MessageBox.Show("Вы уверены что хотите удалить блюдо " + cur.Name + " безвозвратно?", "Удаление блюда", MessageBoxButton.YesNo);
            //var dish = dishService.GetDish(cur.Id);

            //if (dish != null && res == MessageBoxResult.Yes)
            //{
            //    dishService.RemoveDish(dish);
            //}
            //dishesDataGrid.Items.Refresh();
        }
    }
}