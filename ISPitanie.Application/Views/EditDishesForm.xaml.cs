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
        private DishesViewModel Dish;
        private IDishService DishService = new DishService(new EFUnitOfWork());
        
        public EditDishesForm(DishesViewModel dish)
        {
            Dish = dish;
            DataContext = dish;
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
        }

        private void Button_Click_OK(object sender, RoutedEventArgs e)
        {
            //Dish dish = db.Dishes.Where(x => x.Id == this.dish.Id).First();
            //dish.Name = nameTextBox.Text;
            //dish.Norm = int.Parse(normTextBox.Text);
            //dish.Price = int.Parse(priceTextBox.Text);
            //if (proteinTextBox.Text == "") dish.Protein = null;
            //else dish.Protein = int.Parse(proteinTextBox.Text);
            //if (fatTextBox.Text == "") dish.Fat = null;
            //else dish.Fat = int.Parse(fatTextBox.Text);
            //if (carbohydrateTextBox.Text == "") dish.Carbohydrate = null;
            //else dish.Carbohydrate = int.Parse(carbohydrateTextBox.Text);
            //if (vitamine_CTextBox.Text == "") dish.Vitamine_C = null;
            //else dish.Vitamine_C = int.Parse(vitamine_CTextBox.Text);

            this.Close();
        }

        private void Button_Click_Cancel(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}