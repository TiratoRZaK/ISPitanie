using System.Windows;
using ISPitanie.BLL.Entities;
using ISPitanie.Interfaces;
using ISPitanie.Models;

namespace ISPitanie.Views
{
    /// <summary>
    /// Логика взаимодействия для EditProductForm.xaml
    /// </summary>
    public partial class EditProductForm : Window
    {
        private ProductViewModel product;
        private IProductService productService;
        private IUnitService unitService;

        public EditProductForm(Product prod)
        {
            ProductViewModel productView = new ProductViewModel(); // prod.Id
            product = productView;
            this.DataContext = product;
            InitializeComponent();
            unitIdComboBox.ItemsSource = unitService.GetUnits();
            unitIdComboBox.Text = product.UnitName;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
        }

        private void Button_Click_OK(object sender, RoutedEventArgs e)
        {
            //ProductDTO prod = db.Products.Where(x => x.Id == product.Id).First();
            //prod.Name = nameTextBox.Text;
            //prod.Norm = int.Parse(normTextBox.Text);
            //prod.Price = int.Parse(priceTextBox.Text);
            //if (proteinTextBox.Text == "") prod.Protein = null;
            //else prod.Protein = int.Parse(proteinTextBox.Text);
            //if (fatTextBox.Text == "") prod.Fat = null;
            //else prod.Fat = int.Parse(fatTextBox.Text);
            //if (carbohydrateTextBox.Text == "") prod.Carbohydrate = null;
            //else prod.Carbohydrate = int.Parse(carbohydrateTextBox.Text);
            //Unit sel = unitIdComboBox.SelectedItem as Unit;
            //prod.Unit = sel;
            //prod.UnitId = sel.Id;
            //if (vitamine_CTextBox.Text == "") prod.Vitamine_C = null;
            //else prod.Vitamine_C = int.Parse(vitamine_CTextBox.Text);

            //db.SaveChanges();
            //this.Close();
            //var model = Mapper.Map<Product, ProductViewModel> (prod);
        }

        private void Button_Click_Cancel(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}