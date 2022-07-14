using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
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
using System.Xml;
using System.Xml.Serialization;

namespace ExploreWPF.CWs
{
    public partial class Lesson_12 : Window
    {
        public Lesson_12()
        {
            InitializeComponent();
            Deserialize();
        }

        private void EditClick(object sender, RoutedEventArgs e)
        {
            if (DBox.SelectedItem == null) return;
            EditRecipe edit = new EditRecipe((Dish)DBox.SelectedItem);
            edit.ShowDialog();

        }

        private void AddClick(object sender, RoutedEventArgs e)
        {
            Dish dish = new Dish();
            EditRecipe edit = new EditRecipe(dish);

            if (edit.ShowDialog() == true)
            {
                List<Dish> temp = DBox.ItemsSource.Cast<Dish>().ToList();
                temp.Add(dish);
                DBox.ItemsSource = temp;
            }
        }

        private void ButtonReceipt_OnClick(object sender, RoutedEventArgs e)
        {
            if (DBox.SelectedItem == null) return;
            GetReceipt get = new GetReceipt((Dish)DBox.SelectedItem);
            get.ShowDialog();
        }

        private void Serialize()
        {
            using (FileStream fs = new FileStream("dishes.xml", FileMode.Create))
            {
                List<Dish> temp = DBox.ItemsSource.OfType<Dish>().ToList();
                XmlSerializer xmlSerializer = new XmlSerializer(typeof(List<Dish>));
                xmlSerializer.Serialize(fs, temp);
            }
        }

        private void Deserialize()
        {
            try
            {
                using (FileStream fs = new FileStream("dishes.xml", FileMode.Open))
                {
                    var xmlSerializer = new XmlSerializer(typeof(ObservableCollection<Dish>));
                    DBox.ItemsSource = (ObservableCollection<Dish>)xmlSerializer.Deserialize(fs);
                }
            }
            catch (FileNotFoundException fileNotFoundException)
            {

            }
        }


        private void WindowClosing(object sender, CancelEventArgs e)
        {
            Serialize();
        }
    }
    public class Dishes
    {
        private ObservableCollection<Dish> dishes = new ObservableCollection<Dish>();
        public ObservableCollection<Dish> Get() => dishes;
    }
    /// <summary>
    /// Класс описующий блюдо (сериализуется)
    /// </summary>
    [Serializable]
    public class Dish
    {
        public string Name { get; set; }
        public short TimeOfCooking { get; set; }
        public short Portions { get; set; }
        public List<Ingredient> Ingredients { get; set; }
        public string CookingOrder { get; set; }
    }
    /// <summary>
    /// Класс описующий ингредиент (сериализуется)
    /// </summary>
    public class Ingredient
    {
        public string Name { get; set; }
        public string Units { get; set; }
        public short Amount { get; set; }
    }
}
