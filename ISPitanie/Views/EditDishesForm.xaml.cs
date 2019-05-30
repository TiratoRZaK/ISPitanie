using DAL.Entities;
using DAL.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace ISPitanie.Views
{
    /// <summary>
    /// Логика взаимодействия для EditDishesForm.xaml
    /// </summary>
    public partial class EditDishesForm : Window
    {
        Dish dish;
        PitanieContext db = new PitanieContext();
        public EditDishesForm(Dish dish)
        {
            this.dish = dish;
            DataContext = dish;
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
        }

        private void Button_Click_OK(object sender, RoutedEventArgs e)
        {
            Dish dish = db.Dishes.Where(x => x.Id == this.dish.Id).First();
            dish.Name = nameTextBox.Text;
            dish.Norm = int.Parse(normTextBox.Text);
            dish.Price = int.Parse(priceTextBox.Text);
            if (proteinTextBox.Text == "") dish.Protein = null;
            else dish.Protein = int.Parse(proteinTextBox.Text);
            if (fatTextBox.Text == "") dish.Fat = null;
            else dish.Fat = int.Parse(fatTextBox.Text);
            if (carbohydrateTextBox.Text == "") dish.Carbohydrate = null;
            else dish.Carbohydrate = int.Parse(carbohydrateTextBox.Text);
            if (vitamine_CTextBox.Text == "") dish.Vitamine_C = null;
            else dish.Vitamine_C = int.Parse(vitamine_CTextBox.Text);

            db.SaveChanges();
            this.Close();
        }

        private void Button_Click_Cancel(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}