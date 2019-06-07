using System.Collections.Generic;
using System.Windows;
using DAL.Repositories;
using ISPitanie.BLL.Entities;
using ISPitanie.Interfaces;
using ISPitanie.Services;
using ISPitanie.ViewModels;

namespace ISPitanie.Views
{
    /// <summary>
    /// Логика взаимодействия для EditDishesForm.xaml
    /// </summary>
    public partial class EditDishesForm : Window
    {
        public Dish Dish;
        public List<ProductInDish> productInDishes = new List<ProductInDish>();
        public IProductService ProductService = new ProductService(new EFUnitOfWork());
        public IDishService DishService = new DishService(new EFUnitOfWork());

        public EditDishesForm(Dish dish)
        {
            InitializeComponent();
            Dish = dish;
            DataContext = this.Dish;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            nameTextBox.Text = Dish.Name;
            normTextBox.Text = Dish.Norm.ToString();
            proteinTextBox.Text = Dish.Protein.ToString();
            fatTextBox.Text = Dish.Fat.ToString();
            carbohydrateTextBox.Text = Dish.Carbohydrate.ToString();
            vitamine_CTextBox.Text = Dish.Vitamine_C.ToString();
            foreach (Product item in ProductService.GetProducts())
            {
                listProducts.Items.Add(item);
            }
            foreach (ProductDish item in Dish.ProductsDishes)
            {
                listProductInDishes.Items.Add(new ProductInDish
                {
                    Product = item.Product,
                    Norm = item.Norm
                });
            }
        }

        private void Button_Click_OK(object sender, RoutedEventArgs e)
        {
            Dish.Name = nameTextBox.Text;
            Dish.Norm = int.Parse(normTextBox.Text);
            if (proteinTextBox.Text == "") Dish.Protein = null;
            else Dish.Protein = int.Parse(proteinTextBox.Text);
            if (fatTextBox.Text == "") Dish.Fat = null;
            else Dish.Fat = int.Parse(fatTextBox.Text);
            if (carbohydrateTextBox.Text == "") Dish.Carbohydrate = null;
            else Dish.Carbohydrate = int.Parse(carbohydrateTextBox.Text);
            if (vitamine_CTextBox.Text == "") Dish.Vitamine_C = null;
            else Dish.Vitamine_C = int.Parse(vitamine_CTextBox.Text);
            List<ProductDish> productDishes = new List<ProductDish>();
            foreach (ProductInDish item in listProductInDishes.Items)
            {
                productDishes.Add(new ProductDish
                {
                    Dish = Dish,
                    Norm = item.Norm,
                    Product = ProductService.GetProduct(item.Product.Id)
                });
            }
            Dish.ProductsDishes = productDishes;

            DishService.UpdateDish(Dish);
            this.Close();
        }

        private void Button_Click_Cancel(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            SetNormWindow setNormWindow = new SetNormWindow();

            if (setNormWindow.ShowDialog() == true)
            {
                if (int.Parse(setNormWindow.Norm) > 0)
                {
                    ProductInDish prodInDish = new ProductInDish
                    {
                        Product = (listProducts.SelectedItem as Product),
                        Norm = int.Parse(setNormWindow.Norm)
                    };
                    productInDishes.Add(prodInDish);
                    listProductInDishes.Items.Add(prodInDish);
                }
                else
                    MessageBox.Show("Неверно задана норма продукта");
            }

        }

        private void RemoveButton_Click(object sender, RoutedEventArgs e)
        {
            listProductInDishes.Items.Remove(listProductInDishes.SelectedItem);
            productInDishes.Remove(listProductInDishes.SelectedItem as ProductInDish);
        }
    }
}