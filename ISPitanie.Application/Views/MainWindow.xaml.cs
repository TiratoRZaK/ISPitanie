using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows;
using AutoMapper;
using DAL.DTO;
using DAL.Interfaces;
using DAL.Repositories;
using ISPitanie.BLL.Entities;
using ISPitanie.Interfaces;
using ISPitanie.Models;
using ISPitanie.Services;
using ISPitanie.Views;

namespace ISPitanie
{
    public partial class MainWindow : Window
    {
        private IUnitOfWork unitOfWork = new EFUnitOfWork();
        private IProductService ProductService { get; set; }
        private IDishService DishService { get; set; }

        public MainWindow()
        {
            ProductService = new ProductService(unitOfWork);
            //DishService = new DishService(unitOfWork);
            InitializeComponent();
            FetchProducts();
            //var dishModels = Mapper.Map<IEnumerable<DishViewModel>>(DishService.GetDishes());
            //dishesDataGrid.ItemsSource = dishModels.ToList();

            this.Closing += MainWindow_Closing;
        }

        private void FetchProducts()
        {
            var products = ProductService.GetProducts().ToList();
            List<ProductViewModel> productModels = Mapper.Map<List<Product>, List<ProductViewModel>>(products);
            productDataGrid.ItemsSource = productModels;
        }

        public MainWindow(IProductService productService, IDishService dishService) : this()
        {
            this.ProductService = productService;
            this.DishService = dishService;
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
            ProductViewModel cur = productDataGrid.CurrentItem as ProductViewModel;
            ProductViewModel product = Mapper.Map<ProductViewModel>(ProductService.GetProduct(cur.Id));
            EditProductForm editProduct = new EditProductForm(product);
            editProduct.Show();
        }

        private void DeleteProductButton_Click(object sender, RoutedEventArgs e)
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

        private void AddProductButton_Click(object sender, RoutedEventArgs e)
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