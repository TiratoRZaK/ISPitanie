using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using AutoMapper;
using BLL.Entities;
using DAL.Interfaces;
using DAL.Repositories;
using ISPitanie.BLL.Entities;
using ISPitanie.Interfaces;
using ISPitanie.Models;
using ISPitanie.Services;
using ISPitanie.ViewModels;
using ISPitanie.Views;
using Microsoft.Office.Interop.Word;

namespace ISPitanie
{
    public partial class MainWindow : System.Windows.Window
    {
        public static Microsoft.Office.Interop.Word.Application app = new Microsoft.Office.Interop.Word.Application();
        public static string generalfile = @"F:\Contract.docx"; // файл-шаблон
        public static string newfile = @"F:\test1.doc"; // новый файл на основе файла-шаблона
        public static Object fileName = generalfile;
        public static Object missing = System.Type.Missing;

        private IUnitOfWork unitOfWork = new EFUnitOfWork();
        private IProductService ProductService { get; set; }
        private IDishService DishService { get; set; }
        private ITypeService TypeService { get; set; }

        public ObservableCollection<DishesViewModel> dishes = new ObservableCollection<DishesViewModel>();
        public ObservableCollection<CheckBoxListItem> itemsListProduct = new ObservableCollection<CheckBoxListItem>();
        public ObservableCollection<ProductViewModel> productModels = new ObservableCollection<ProductViewModel>();
        public ObservableCollection<Seller> sellers = new ObservableCollection<Seller>();
        public ObservableCollection<Customer> customers = new ObservableCollection<Customer>();

        public MainWindow()
        {
            ProductService = new ProductService(unitOfWork);
            DishService = new DishService(unitOfWork);
            TypeService = new TypeService(unitOfWork);
            InitializeComponent();
            FetchData();
            FetchProducts(false);
            FetchContactData();

            this.Closing += MainWindow_Closing;
        }

        private void FetchContactData()
        {
            sellers = Mapper.Map<ObservableCollection<Seller>>(unitOfWork.Sellers.GetAll());
            sellerBox.ItemsSource = sellers;
            customers = Mapper.Map<ObservableCollection<Customer>>(unitOfWork.Customers.GetAll());
            customerBox.ItemsSource = customers;
        }

        private void FetchProducts(bool check)
        {
            itemsListProduct.Clear();
            foreach (Product product in ProductService.GetProducts())
            {
                itemsListProduct.Add(new CheckBoxListItem(check, product));
            }
            lstExclude.ItemsSource = itemsListProduct;
        }

        private void FetchData()
        {
            foreach (Dish item in DishService.GetDishes())
            {
                dishes.Add(new DishesViewModel(item.Id));
            }
            dishesDataGrid.ItemsSource = dishes;

            var products = ProductService.GetProducts().ToList();
            productModels = Mapper.Map<List<Product>, ObservableCollection<ProductViewModel>>(products);
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
            DishService.Dispose();
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
            AddProductForm addProduct = new AddProductForm(this);
            addProduct.Show();

        }

        private void EditDishes(object sender, RoutedEventArgs e)
        {
            DishesViewModel cur = dishesDataGrid.CurrentItem as DishesViewModel;
            EditDishesForm editDish = new EditDishesForm(DishService.GetDish(cur.Id));
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

        public class CheckBoxListItem
        {
            public bool Checked { get; set; }
            public Product Product { get; set; }
            public string Name { get; set; }
            public int? Balance { get; set; }
            public int Price { get; set; }

            public CheckBoxListItem(bool ch, Product product)
            {
                Checked = ch;
                Product = product;
                Name = product.Name;
                Price = product.Price;
                Balance = product.Balance;
            }
        }

        private void CheckBox_Click(object sender, RoutedEventArgs e)
        {
            var cb = sender as System.Windows.Controls.CheckBox;
            var item = cb.DataContext;
            (item as CheckBoxListItem).Checked = true;
        }

        private void unCheckAll_Click(object sender, RoutedEventArgs e)
        {
            FetchProducts(false);
        }

        private void CheckAll_Click(object sender, RoutedEventArgs e)
        {
            FetchProducts(true);
        }

        private void BuildContract_Click(object sender, RoutedEventArgs e)
        {
            productModels.Clear();
            List<string> types = new List<string>();
            foreach (CheckBoxListItem item in lstExclude.Items.SourceCollection)
            {
                if (item.Checked)
                {
                    productModels.Add(Mapper.Map<ProductViewModel>(item.Product));
                    if (!types.Contains(item.Product.TypeName))
                    {
                        types.Add(item.Product.TypeName);
                    }
                }
            }

            OpenFile();
            FindReplace("{date}", dateBegin.DisplayDate.ToShortDateString());
            FindReplace("{number}", numberContract.Text.ToString());
            FindReplace("{fullNameCompanyCustomer}", (customerBox.SelectedItem as Customer).FullNameCompany);
            FindReplace("{fullNameCompanySeller}", (sellerBox.SelectedItem as Seller).FullNameCompany);
            FindReplace("{nameCustomerSpec}", (customerBox.SelectedItem as Customer).NameCustomerSpec);
            FindReplace("{nameCustomer}", (customerBox.SelectedItem as Customer).NameCustomer);
            FindReplace("{nameSeller}", (sellerBox.SelectedItem as Seller).NameSeller);
            FindReplace("{nameSellerSpec}", (sellerBox.SelectedItem as Seller).NameSellerSpec);
            FindReplace("{addressCustomer}", (customerBox.SelectedItem as Customer).AddressCompany);
            FindReplace("{addressSeller}", (sellerBox.SelectedItem as Seller).AddressCompany);
            FindReplace("{emailSeller}", (sellerBox.SelectedItem as Seller).Email);
            FindReplace("{personalAccountCustomer}", (customerBox.SelectedItem as Customer).PersonalAccount);
            FindReplace("{corespAccountSeller}", (sellerBox.SelectedItem as Seller).CorrespondentAccount);
            FindReplace("{bikCustomer}", (customerBox.SelectedItem as Customer).BIK.ToString());
            FindReplace("{bikSeller}", (sellerBox.SelectedItem as Seller).BIK.ToString());
            FindReplace("{bikCustomer}", (customerBox.SelectedItem as Customer).BIK.ToString());
            FindReplace("{innCustomer}", (customerBox.SelectedItem as Customer).INN.ToString()); 
            FindReplace("{innSeller}", (sellerBox.SelectedItem as Seller).INN.ToString());
            FindReplace("{kppCustomer}", (customerBox.SelectedItem as Customer).KPP.ToString());
            FindReplace("{kppSeller}", (sellerBox.SelectedItem as Seller).KPP.ToString());
            FindReplace("{bankCustomer}", (customerBox.SelectedItem as Customer).Bank);
            FindReplace("{bankSeller}", (sellerBox.SelectedItem as Seller).Bank);
            FindReplace("{bankAccountCustomer}", (customerBox.SelectedItem as Customer).BankAccount);
            FindReplace("{bankAccountSeller}", (sellerBox.SelectedItem as Seller).BankAccount);
            FindReplace("{phoneSeller}", (sellerBox.SelectedItem as Seller).PhoneNumber);
            FindReplace("{nameResponssable}", nameResponssable.Text.ToString());
            FindReplace("{year}", dateBegin.DisplayDate.Year.ToString());
            if (threeMounth.IsChecked == true)
            {
                FindReplace("{dateEnd}", dateBegin.DisplayDate.AddMonths(3).ToShortDateString());
            }
            else
            {
                FindReplace("{dateEnd}", dateBegin.DisplayDate.AddMonths(6).ToShortDateString());
            }
            Document document = app.ActiveDocument;
            Range range = document.Paragraphs[document.Paragraphs.Count].Range;
            document.Tables.Add(range, lstExclude.Items.Count + types.Count, 7);
            int i = 1;
            foreach(string item in types)
            {
                i++;
                document.Tables[4].Cell(i, 1).Range.Text = item;
                foreach (Product product in ProductService.GetProducts().Where(x=>x.TypeName == item)){
                    i++;
                    document.Tables[4].Cell(i, 1).Range.Text = product.Name;
                    document.Tables[4].Cell(i, 2).Range.Text = product.UnitName;
                    document.Tables[4].Cell(i, 3).Range.Text = product.Price.ToString();
                    document.Tables[4].Cell(i, 4).Range.Text = "-";
                    document.Tables[4].Cell(i, 5).Range.Text = product.Balance.ToString();
                    document.Tables[4].Cell(i, 6).Range.Text = (product.Price * product.Balance).ToString();
                    document.Tables[4].Cell(i, 7).Range.Text = "0";
                }
            }
            SaveCloseFile();
        }

        public void OpenFile()
        {
            app.Documents.Open(ref fileName);
            
        }

        public void SaveCloseFile()
        {
            app.ActiveDocument.SaveAs(newfile);
            app.ActiveDocument.Close();
            app.Quit();
        }

        public void FindReplace(string str_old, string str_new)
        {
            Microsoft.Office.Interop.Word.Find find = app.Selection.Find;

            find.Text = str_old; // текст поиска
            find.Replacement.Text = str_new; // текст замены
            
            find.Execute(FindText: System.Type.Missing, MatchCase: false, MatchWholeWord: false, MatchWildcards: false,
                        MatchSoundsLike: missing, MatchAllWordForms: false, Forward: true, Wrap: Microsoft.Office.Interop.Word.WdFindWrap.wdFindContinue,
                        Format: false, ReplaceWith: missing, Replace: Microsoft.Office.Interop.Word.WdReplace.wdReplaceAll);
        }

        private void Calendar_SelectedDatesChanged(object sender, SelectionChangedEventArgs e)
        {
            
            MessageBox.Show(calendar.SelectedDate.Value.ToLongDateString());
        }
    }
}