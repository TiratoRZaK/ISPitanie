using System.Windows;
using AutoMapper;
using DAL.DTO;
using DAL.Interfaces;
using DAL.Repositories;
using ISPitanie.BLL.Entities;
using ISPitanie.Interfaces;
using ISPitanie.Models;
using ISPitanie.Services;

namespace ISPitanie.Views
{
    /// <summary>
    /// Логика взаимодействия для EditProductForm.xaml
    /// </summary>
    public partial class EditProductForm : Window
    {
        private ProductViewModel Product;
        private IProductService ProductService = new ProductService(new EFUnitOfWork());
        private IUnitService UnitService = new UnitService(new EFUnitOfWork());
        private ITypeService TypeService = new TypeService(new EFUnitOfWork());

        public EditProductForm(ProductViewModel product)
        {
            Product = product;
            this.DataContext = Product;

            InitializeComponent();

            unitIdComboBox.ItemsSource = UnitService.GetUnits();
            unitIdComboBox.Text = this.Product.UnitName;
            typeIdComboBox.ItemsSource = TypeService.GetTypes();
            typeIdComboBox.Text = this.Product.TypeName;

        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
        }

        private void Button_Click_OK(object sender, RoutedEventArgs e)
        {
            Product prod = ProductService.GetProduct(Product.Id);
            prod.Name = nameTextBox.Text;
            prod.Norm = int.Parse(normTextBox.Text);
            prod.Price = int.Parse(priceTextBox.Text);
            if (proteinTextBox.Text == "") prod.Protein = null;
            else prod.Protein = int.Parse(proteinTextBox.Text);
            if (fatTextBox.Text == "") prod.Fat = null;
            else prod.Fat = int.Parse(fatTextBox.Text);
            if (carbohydrateTextBox.Text == "") prod.Carbohydrate = null;
            else prod.Carbohydrate = int.Parse(carbohydrateTextBox.Text);
            Unit sel = unitIdComboBox.SelectedItem as Unit;
            prod.UnitName = sel.Name;
            Type sele = typeIdComboBox.SelectedItem as Type;
            prod.TypeName = sele.Name;
            if (vitamine_CTextBox.Text == "") prod.Vitamine_C = null;
            else prod.Vitamine_C = int.Parse(vitamine_CTextBox.Text);

            ProductService.UpdateProduct(prod);
            this.Close();
        }

        private void Button_Click_Cancel(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void UnitIdComboBox_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {

        }

        private void TypeIdComboBox_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {

        }
    }
}