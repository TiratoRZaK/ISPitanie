using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using ISPitanie.ViewModels;
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
            DishService = new DishService(unitOfWork);
            InitializeComponent();
            FetchData();
            
            this.Closing += MainWindow_Closing;
        }

        private void FetchData()
        {
            ObservableCollection<DishesViewModel> dishes = new ObservableCollection<DishesViewModel>();

            foreach (Dish item in DishService.GetDishes())
            {
                dishes.Add(new DishesViewModel(item.Id));
            }
            dishesDataGrid.ItemsSource = dishes;

            var products = ProductService.GetProducts().ToList();
            ObservableCollection<ProductViewModel> productModels = Mapper.Map<List<Product>, ObservableCollection<ProductViewModel>>(products);
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

        private void EditProduct(object sender, RoutedEventArgs e)
        {
            ProductViewModel cur = productDataGrid.CurrentItem as ProductViewModel;
            ProductViewModel product = Mapper.Map<ProductViewModel>(ProductService.GetProduct(cur.Id));
            EditProductForm editProduct = new EditProductForm(product);
            editProduct.Show();
        }
        private void AddDishButton_Click(object sender, RoutedEventArgs e)
        {
            AddDishesForm addDish = new AddDishesForm();
            addDish.Show();
        }
        private void DeleteProductButton_Click(object sender, RoutedEventArgs e)
        {
            var cur = productDataGrid.CurrentItem as ProductViewModel;
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
            AddProductForm addProduct = new AddProductForm();
            addProduct.Show();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            productDataGrid.Items.Refresh();
            dishesDataGrid.Items.Refresh();
        }

        private void EditDishes(object sender, RoutedEventArgs e)
        {
            DishesViewModel cur = dishesDataGrid.CurrentItem as DishesViewModel;
            DishesViewModel dish = Mapper.Map<DishesViewModel>(DishService.GetDish(cur.Id));
            EditDishesForm editDish = new EditDishesForm(dish);
            editDish.Show();
        }

        private void DeleteDishes(object sender, RoutedEventArgs e)
        {
            var cur = dishesDataGrid.CurrentItem as DishesViewModel;
            MessageBoxResult res = MessageBox.Show("Вы уверены что хотите удалить блюдо " + cur.Name + " безвозвратно?", "Удаление блюда", MessageBoxButton.YesNo);
            var dish = DishService.GetDish(cur.Id);
            if (dish != null && res == MessageBoxResult.Yes)
            {
                DishService.RemoveDish(dish);
            }
            dishesDataGrid.Items.Refresh();
        }
    }
}