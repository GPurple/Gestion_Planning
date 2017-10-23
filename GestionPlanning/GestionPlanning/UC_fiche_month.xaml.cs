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
    /// Logique d'interaction pour UC_fiche_month.xaml
    /// </summary>
    public partial class UC_fiche_month : UserControl
    {
        private String textDateFab = "Date fab : ";
        private String textNbFiches = "Nb fiches : ";
        private String textReco = "Reco : ";
        private bool dispWarning = false;
        private bool dispAlerte = false;

        public UC_fiche_month()
        {
            InitializeComponent();
        }

        public UC_fiche_month(FicheDayMonth ficheDayMonth)
        {
            InitializeComponent();

            textDateFab = "Date fab : " + ficheDayMonth.dateDay.Day + "/" + ficheDayMonth.dateDay.Month;
            TextDateFab.Text = textDateFab;

            textNbFiches = "Nb fiches : " + ficheDayMonth.nbFiches;
            TextNbFiches.Text = textNbFiches;

            textReco = "Reco : " + ficheDayMonth.reco;
            TextReco.Text = textReco;

            if(ficheDayMonth.alerte_retard == true)
            {
                image_AlerteRetard.Visibility = Visibility.Visible;
            }
            else
            {
                image_AlerteRetard.Visibility = Visibility.Collapsed;
            }

            if (ficheDayMonth.attention_retard == true)
            {
                image_AttentionRetard.Visibility = Visibility.Visible;
            }
            else
            {
                image_AttentionRetard.Visibility = Visibility.Collapsed;
            }

            //(int nbFiches, DateTime dateDay, bool attention_retard, bool alerte_retard, List<TypeOperation> listeOperation, bool reco)
            UC_DispColorsOperation(ficheDayMonth);

        }

        public void UC_DispColorsOperation(FicheDayMonth ficheDayMonth)
        {
            int nbTypeOp = 0;

            List<Color> listColors = new List<Color>();

            bool dispFab = false;
            bool dispAig = false;
            bool dispNA = false;

            int HEIGHT = 90;
            Rectangle rectLeftFab = new Rectangle();
            rectLeftFab.Width = 59;
            rectLeftFab.Fill = new SolidColorBrush(Colors.LawnGreen);
            Canvas.SetLeft(rectLeftFab, 1);

            Rectangle rectLeftAig = new Rectangle();
            rectLeftAig.Width = 59;
            rectLeftAig.Fill = new SolidColorBrush(Colors.Firebrick);
            Canvas.SetLeft(rectLeftAig, 1);

            Rectangle rectLeftNA = new Rectangle();
            rectLeftNA.Width = 59;
            rectLeftNA.Fill = new SolidColorBrush(Colors.White);
            Canvas.SetLeft(rectLeftNA, 1);


            int heightOP = 0;

            if (ficheDayMonth.listeOperation.Contains(TypeOperation.fabrication))
            {
                dispFab = true;
                nbTypeOp++;
            }
            if (ficheDayMonth.listeOperation.Contains(TypeOperation.aiguisage))
            {
                dispAig = true;
                nbTypeOp++;
            }
            if (ficheDayMonth.listeOperation.Contains(TypeOperation.na))
            {
                dispNA = true;
                nbTypeOp++;
            }

            if (nbTypeOp == 3)
            {
                rectLeftFab.Height = (int) (HEIGHT/3) - 1;
                Canvas.SetTop(rectLeftFab, 1);
                CanvaColorDisplay.Children.Add(rectLeftFab);

                rectLeftAig.Height = (int) (HEIGHT / 3);
                Canvas.SetTop(rectLeftAig, (int)( HEIGHT / 3));
                CanvaColorDisplay.Children.Add(rectLeftAig);

                rectLeftNA.Height = (int)(HEIGHT / 3) - 1;
                Canvas.SetTop(rectLeftNA, (int)(2 * HEIGHT / 3));
                CanvaColorDisplay.Children.Add(rectLeftNA);

            }
            else if (nbTypeOp == 2)
            {
                if (dispFab == true)
                {
                    rectLeftFab.Height = (int)(HEIGHT / 2) - 1;
                    Canvas.SetTop(rectLeftFab, 1);
                    CanvaColorDisplay.Children.Add(rectLeftFab);

                    if (dispAig == true)
                    {
                        rectLeftAig.Height = (int)(HEIGHT / 2) - 1;
                        Canvas.SetTop(rectLeftAig, (int)(HEIGHT / 2));
                        CanvaColorDisplay.Children.Add(rectLeftAig);
                    }
                    else
                    {
                        rectLeftNA.Height = (int)(HEIGHT / 2) - 1;
                        Canvas.SetTop(rectLeftNA, (int)(HEIGHT / 2));
                        CanvaColorDisplay.Children.Add(rectLeftNA);
                    }
                }
                else
                {
                    rectLeftAig.Height = (int)(HEIGHT / 2) - 1;
                    Canvas.SetTop(rectLeftAig, 1);
                    CanvaColorDisplay.Children.Add(rectLeftAig);

                    rectLeftNA.Height = (int)(HEIGHT / 2) - 1;
                    Canvas.SetTop(rectLeftNA, (int)(HEIGHT / 2));
                    CanvaColorDisplay.Children.Add(rectLeftNA);
                }
            }
            else if (nbTypeOp== 1)
            {
                if (dispFab == true)
                {
                    rectLeftFab.Height = HEIGHT - 2;
                    Canvas.SetTop(rectLeftFab, 1);
                    CanvaColorDisplay.Children.Add(rectLeftFab);
                }
                else if( dispAig == true)
                {
                    rectLeftAig.Height = HEIGHT - 2;
                    Canvas.SetTop(rectLeftAig, 1);
                    CanvaColorDisplay.Children.Add(rectLeftAig);
                }
                else
                {
                    rectLeftNA.Height = HEIGHT - 2;
                    Canvas.SetTop(rectLeftNA, 1);
                    CanvaColorDisplay.Children.Add(rectLeftNA);
                }
            }
            else
            {
                rectLeftNA.Height = HEIGHT - 2;
                Canvas.SetTop(rectLeftNA, 1);
                CanvaColorDisplay.Children.Add(rectLeftNA);
            }
            

            
            //moitié droite : 
            Rectangle rectRight = new Rectangle();
            rectRight.Height = 88;
            rectRight.Width = 59;

            Canvas.SetTop(rectRight, 1);
            Canvas.SetLeft(rectRight, 60);

            if (ficheDayMonth.reco == true)
            {
                //afficher rectangle gold
                rectRight.Fill = new SolidColorBrush(Colors.Gold);
            }
            else
            {
                //afficher rectangle blanc
                rectRight.Fill = new SolidColorBrush(Colors.White);
            }
            CanvaColorDisplay.Children.Add(rectRight);

        }

    }
}
