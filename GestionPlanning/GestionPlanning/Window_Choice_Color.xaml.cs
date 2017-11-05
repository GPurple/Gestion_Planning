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
using System.Windows.Shapes;

namespace GestionPlanning
{
    /// <summary>
    /// Logique d'interaction pour Window_Choice_Color.xaml
    /// </summary>
    public partial class Window_Choice_Color : Window
    {
        public Color color = Colors.White;
        public String name = "";

        public Window_Choice_Color(String newName)
        {
            InitializeComponent();
            btnCream.Background = new SolidColorBrush(Values.COLOR_CREAM);
            btnCyan.Background = new SolidColorBrush(Values.COLOR_CYAN);
            btnGreen.Background = new SolidColorBrush(Values.COLOR_GREEN);
            btnGrey.Background = new SolidColorBrush(Values.COLOR_GRAY);
            btnNightBlue.Background = new SolidColorBrush(Values.COLOR_NIGHTBLUE);
            btnOrange.Background = new SolidColorBrush(Values.COLOR_ORANGE);
            btnPink.Background = new SolidColorBrush(Values.COLOR_PINK);
            btnPurple.Background = new SolidColorBrush(Values.COLOR_PURPLE);
            btnRed.Background = new SolidColorBrush(Values.COLOR_RED);
            btnLightGreen.Background = new SolidColorBrush(Values.COLOR_LIGHTGREEN);
            name = newName;
            textBlockNameRevet.Text = "Nom : " + name;
        }

        private void ResetBorderAll()
        {
            btnCream.BorderBrush = (SolidColorBrush)(new BrushConverter().ConvertFrom("#FF707070"));
            btnCream.BorderThickness = new Thickness(1);

            btnCyan.BorderBrush = (SolidColorBrush)(new BrushConverter().ConvertFrom("#FF707070"));
            btnCyan.BorderThickness = new Thickness(1);

            btnGreen.BorderBrush = (SolidColorBrush)(new BrushConverter().ConvertFrom("#FF707070"));
            btnGreen.BorderThickness = new Thickness(1);

            btnGrey.BorderBrush = (SolidColorBrush)(new BrushConverter().ConvertFrom("#FF707070"));
            btnGrey.BorderThickness = new Thickness(1);

            btnLightGreen.BorderBrush = (SolidColorBrush)(new BrushConverter().ConvertFrom("#FF707070"));
            btnGreen.BorderThickness = new Thickness(1);

            btnNightBlue.BorderBrush = (SolidColorBrush)(new BrushConverter().ConvertFrom("#FF707070"));
            btnNightBlue.BorderThickness = new Thickness(1);

            btnOrange.BorderBrush = (SolidColorBrush)(new BrushConverter().ConvertFrom("#FF707070"));
            btnOrange.BorderThickness = new Thickness(1);

            btnPink.BorderBrush = (SolidColorBrush)(new BrushConverter().ConvertFrom("#FF707070"));
            btnPink.BorderThickness = new Thickness(1);

            btnPurple.BorderBrush = (SolidColorBrush)(new BrushConverter().ConvertFrom("#FF707070"));
            btnPurple.BorderThickness = new Thickness(1);

            btnRed.BorderBrush = (SolidColorBrush)(new BrushConverter().ConvertFrom("#FF707070"));
            btnRed.BorderThickness = new Thickness(1);
        }

        
        private void ChoiceColorGreen(object sender, RoutedEventArgs e)
        {
            ResetBorderAll();
            color = Values.COLOR_GREEN;
            btnGreen.BorderBrush = new SolidColorBrush(Colors.LightSkyBlue);
            btnGreen.BorderThickness = new Thickness(3);
        }

        private void ChoiceColorRed(object sender, RoutedEventArgs e)
        {
            ResetBorderAll();
            color = Values.COLOR_RED;
            btnRed.BorderBrush = new SolidColorBrush(Colors.LightSkyBlue);
            btnRed.BorderThickness = new Thickness(3);
        }

        private void ChoiceColorCyan(object sender, RoutedEventArgs e)
        {
            ResetBorderAll();
            color = Values.COLOR_CYAN;
            btnCyan.BorderBrush = new SolidColorBrush(Colors.LightSkyBlue);
            btnCyan.BorderThickness = new Thickness(3);
        }

        private void ChoiceColorNightBlue(object sender, RoutedEventArgs e)
        {
            ResetBorderAll();
            color = Values.COLOR_NIGHTBLUE;
            btnNightBlue.BorderBrush = new SolidColorBrush(Colors.LightSkyBlue);
            btnNightBlue.BorderThickness = new Thickness(3);
        }

        private void ChoiceColorOrange(object sender, RoutedEventArgs e)
        {
            ResetBorderAll();
            color = Values.COLOR_ORANGE;
            btnOrange.BorderBrush = new SolidColorBrush(Colors.LightSkyBlue);
            btnOrange.BorderThickness = new Thickness(3);
        }

        private void ChoiceColorLightPink(object sender, RoutedEventArgs e)
        {
            ResetBorderAll();
            color = Values.COLOR_PINK;
            btnPink.BorderBrush = new SolidColorBrush(Colors.LightSkyBlue);
            btnPink.BorderThickness = new Thickness(3);
        }

        private void ChoiceColorPurple(object sender, RoutedEventArgs e)
        {
            ResetBorderAll();
            color = Values.COLOR_PURPLE;
            btnPurple.BorderBrush = new SolidColorBrush(Colors.LightSkyBlue);
            btnPurple.BorderThickness = new Thickness(3);
        }

        private void ChoiceColorLightGreen(object sender, RoutedEventArgs e)
        {
            ResetBorderAll();
            color = Values.COLOR_LIGHTGREEN;
            btnLightGreen.BorderBrush = new SolidColorBrush(Colors.LightSkyBlue);
            btnLightGreen.BorderThickness = new Thickness(3);
        }

        private void ChoiceColorCream(object sender, RoutedEventArgs e)
        {
            ResetBorderAll();
            color = Values.COLOR_CREAM;
            btnCream.BorderBrush = new SolidColorBrush(Colors.LightSkyBlue);
            btnCream.BorderThickness = new Thickness(3);
        }

        private void ChoiceColorGrey(object sender, RoutedEventArgs e)
        {
            ResetBorderAll();
            color = Values.COLOR_GRAY;
            btnGrey.BorderBrush = new SolidColorBrush(Colors.LightSkyBlue);
            btnGrey.BorderThickness = new Thickness(3);
        }

        private void ValidateChoiceColor(object sender, RoutedEventArgs e)
        {
            Brain.Instance.ValidateChoiceColor(name);
        }

        private void CancelChoiceColor(object sender, RoutedEventArgs e)
        {
            Brain.Instance.CancelChoiceColor(name);
        }
    }
}
