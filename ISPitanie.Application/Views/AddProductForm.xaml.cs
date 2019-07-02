using System.Linq;
using System.Windows;
using DAL.Repositories;
using ISPitanie.BLL.Entities;
using ISPitanie.Interfaces;
using ISPitanie.Services;

namespace ISPitanie.Views
{
    /// <summary>
    /// Логика взаимодействия для WindowAddProduct.xaml
    /// </summary>
    public partial class AddProductForm : Window
    {
        //PitanieContext db = new PitanieContext();
        public Window main;
        private Product Product;
        private IProductService ProductService = new ProductService(new EFUnitOfWork());
        private IUnitService UnitService = new UnitService(new EFUnitOfWork());
        private ITypeService TypeService = new TypeService(new EFUnitOfWork());

        public AddProductForm(MainWindow main)
        {
            this.main = main;
            InitializeComponent();
            Product = new Product();
            this.DataContext = Product;
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
            Product.Name = nameTextBox.Text;
            Product.Norm = int.Parse(normTextBox.Text);
            Product.Price = int.Parse(priceTextBox.Text);
            if (proteinTextBox.Text == "") Product.Protein = null;
            else Product.Protein = int.Parse(proteinTextBox.Text);
            if (fatTextBox.Text == "") Product.Fat = null;
            else Product.Fat = int.Parse(fatTextBox.Text);
            if (carbohydrateTextBox.Text == "") Product.Carbohydrate = null;
            else Product.Carbohydrate = int.Parse(carbohydrateTextBox.Text);
            Unit sel = unitIdComboBox.SelectedItem as Unit;
            Product.UnitName = sel.Name;
            Type sele = typeIdComboBox.SelectedItem as Type;
            Product.TypeName = sele.Name;
            if (vitamine_CTextBox.Text == "") Product.Vitamine_C = null;
            else Product.Vitamine_C = int.Parse(vitamine_CTextBox.Text);

            ProductService.CreateProduct(Product);
            this.Close();
        }

        private void Button_Click_Cancel(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Window_Closed(object sender, System.EventArgs e)
        {
            (main as MainWindow).productDataGrid.Items.Refresh();
            
        }
    }
}