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
    /// Логика взаимодействия для GetReceipt.xaml
    /// </summary>
    public partial class GetReceipt : Window
    {
        public GetReceipt(Dish dish)
        {
            InitializeComponent();
            DataContext = dish;
        }
    }
}
