//using DAL.Entities;
//using DAL.Repository;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using System.Windows;
//using System.Windows.Controls;
//using System.Windows.Data;
//using System.Windows.Documents;
//using System.Windows.Input;
//using System.Windows.Media;
//using System.Windows.Media.Imaging;
//using System.Windows.Shapes;

//namespace ISPitanie.Views
//{
//    /// <summary>
//    /// Логика взаимодействия для WindowAddProduct.xaml
//    /// </summary>
//    public partial class AddProductForm : Window
//    {
//        PitanieContext db = new PitanieContext();
//        Product product;
//        public AddProductForm()
//        {
//            InitializeComponent();
//            product = new Product();
//            this.DataContext = product;
//            unitIdComboBox.ItemsSource = db.Units.ToList();
//        }

//        private void Window_Loaded(object sender, RoutedEventArgs e)
//        {

//        }

//        private void Button_Click_OK(object sender, RoutedEventArgs e)
//        {
//            product.Name = nameTextBox.Text;
//            product.Norm = int.Parse(normTextBox.Text);
//            product.Price = int.Parse(priceTextBox.Text);
//            if (proteinTextBox.Text == "") product.Protein = null;
//            else product.Protein = int.Parse(proteinTextBox.Text);
//            if (fatTextBox.Text == "") product.Fat = null;
//            else product.Fat = int.Parse(fatTextBox.Text);
//            if (carbohydrateTextBox.Text == "") product.Carbohydrate = null;
//            else product.Carbohydrate = int.Parse(carbohydrateTextBox.Text);
//            Unit sel = unitIdComboBox.SelectedItem as Unit;
//            product.Unit = sel;
//            product.UnitId = sel.Id;
//            if (vitamine_CTextBox.Text == "") product.Vitamine_C = null;
//            else product.Vitamine_C = int.Parse(vitamine_CTextBox.Text);

//            db.Products.Add(product);
//            db.SaveChanges();
//            this.Close();
//        }

//        private void Button_Click_Cancel(object sender, RoutedEventArgs e)
//        {
//            MessageBox.Show("Ну отмена чо");
//        }
//    }
//}
