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

namespace ExploreWPF.CWs
{
    /// <summary>
    /// Логика взаимодействия для EditRecipe.xaml
    /// </summary>
    public partial class EditRecipe : Window
    {
        Dish thisDish;
        public EditRecipe(Dish dish)
        {
            thisDish = dish ?? new Dish();

            DataContext = thisDish;
            InitializeComponent();
        }



        private void AcceptBtn_OnClick(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(NameTBx.Text) || string.IsNullOrWhiteSpace(TimeTBx.Text) || string.IsNullOrWhiteSpace(PortionsTxB.Text)
                || string.IsNullOrWhiteSpace(OrderTB.Text) || thisDish.Ingredients.Count == 0) return;
            thisDish.CookingOrder = OrderTB.Text;
            DialogResult = true;
        }





        private void Btn_add_OnClick(object sender, RoutedEventArgs e)
        {
            List<Ingredient> temp;
            if (thisDish.Ingredients == null)
            {
                temp = new List<Ingredient>();
                thisDish.Ingredients = new List<Ingredient>();
            }
            else
            {
                temp = Ingreds.ItemsSource.Cast<Ingredient>().ToList();
            }

            var tempIng = new Ingredient()
            { Name = NameOfInd.Text, Amount = short.Parse(UnitsOfInd.Text), Units = AmountOfUnits.Text };
            temp.Add(tempIng);
            Ingreds.ItemsSource = temp;
            thisDish.Ingredients.Add(tempIng);
            NameOfInd.Text = string.Empty;
            UnitsOfInd.Text = string.Empty;
            AmountOfUnits.Text = string.Empty;
        }

        private void DelIng_OnClick(object sender, RoutedEventArgs e)
        {
            if (Ingreds.SelectedItem != null)
            {
                var temp = Ingreds.ItemsSource.OfType<Ingredient>().ToList();
                var remItem = (Ingredient)Ingreds.SelectedItem;
                temp.Remove(remItem);
                Ingreds.ItemsSource = temp;
                thisDish.Ingredients.Remove(remItem);
            }
        }
    }
}
