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
    /// Логика взаимодействия для AddDishesForm.xaml
    /// </summary>
    public partial class AddDishesForm : Window
    {
        PitanieContext db = new PitanieContext();
        Dish dish;
        public AddDishesForm()
        {
            InitializeComponent();
            dish = new Dish();
            this.DataContext = dish;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Click_OK(object sender, RoutedEventArgs e)
        {
            dish.Name = nameTextBox.Text;
            dish.Norm = int.Parse(normTextBox.Text);
            dish.Price = int.Parse(priceTextBox.Text);

            if (proteinTextBox.Text == "")
            {
                dish.Protein = null;
            }
            else
            {
                dish.Protein = int.Parse(proteinTextBox.Text);
            }

            if (fatTextBox.Text == "") dish.Fat = null;
            else dish.Fat = int.Parse(fatTextBox.Text);
            if (carbohydrateTextBox.Text == "") dish.Carbohydrate = null;
            else dish.Carbohydrate = int.Parse(carbohydrateTextBox.Text);
            if (vitamine_CTextBox.Text == "") dish.Vitamine_C = null;
            else dish.Vitamine_C = int.Parse(vitamine_CTextBox.Text);

            db.Dishes.Add(dish);
            db.SaveChanges();
            this.Close();
        }

        private void Button_Click_Cancel(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
