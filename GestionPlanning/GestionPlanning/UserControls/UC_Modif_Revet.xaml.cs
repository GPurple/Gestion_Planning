using GestionPlanning.src;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace GestionPlanning
{
    /// <summary>
    /// Logique d'interaction pour UC_Modif_Revet.xaml
    /// </summary>
    public partial class UC_Modif_Revet : UserControl
    {
        String nameRevet = "";
        public UC_Modif_Revet()
        {
            InitializeComponent();
        }

        public UC_Modif_Revet(TypeColor typeColor)
        {
            InitializeComponent();
            TextBlock_NameRevetement.Text = typeColor.name;
            nameRevet = typeColor.name;
            btnChoiceColor.Background = new SolidColorBrush(typeColor.color);
        }

        private void SupprColor(object sender, RoutedEventArgs e)
        {
            Brain.Instance.SupprColor(nameRevet);
        }

        private void ChoiceColor(object sender, RoutedEventArgs e)
        {
            Brain.Instance.ChoiceColor(nameRevet);
        }
    }
}
