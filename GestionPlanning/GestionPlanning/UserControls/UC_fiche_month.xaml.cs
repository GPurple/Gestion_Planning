﻿using GestionPlanning.src;
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

            if (ficheDayMonth.reco != null)
            {
                textReco = "Reco : oui";
            }
            else
            {
                textReco = "Reco : non";
            }
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

            UC_DispColorsOperation(ficheDayMonth);

        }

        public void UC_DispColorsOperation(FicheDayMonth ficheDayMonth)
        {
            int nbTypeOp = 0;

            List<Color> listColors = new List<Color>();

            bool dispFab = false;
            bool dispAig = false;
            bool dispNA = false;
                        
            Rectangle rectLeftFab = new Rectangle();
            rectLeftFab.Width = Values.Instance.WIDTH_FICHE_MONTH * 0.5 - 1;
            rectLeftFab.Fill = new SolidColorBrush(Values.COLOR_FAB);
            Canvas.SetLeft(rectLeftFab, 1);

            Rectangle rectLeftAig = new Rectangle();
            rectLeftAig.Width = Values.Instance.WIDTH_FICHE_MONTH * 0.5 - 1;
            rectLeftAig.Fill = new SolidColorBrush(Values.COLOR_AFF);
            Canvas.SetLeft(rectLeftAig, 1);

            Rectangle rectLeftNA = new Rectangle();
            rectLeftNA.Width = Values.Instance.WIDTH_FICHE_MONTH * 0.5 - 1;
            rectLeftNA.Fill = new SolidColorBrush(Values.COLOR_NA);
            Canvas.SetLeft(rectLeftNA, 1);

            rectFiche.Height = Values.Instance.HEIGHT_FICHE_MONTH;
            rectFiche.Width = Values.Instance.WIDTH_FICHE_MONTH;

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

            double height = Values.Instance.HEIGHT_FICHE_MONTH;
            double width = Values.Instance.WIDTH_FICHE_MONTH;

            if (nbTypeOp == 3)
            {
                rectLeftFab.Height = (int) (height / 3) - 1;
                Canvas.SetTop(rectLeftFab, 1);
                CanvaColorDisplay.Children.Add(rectLeftFab);

                rectLeftAig.Height = (int) (height / 3);
                Canvas.SetTop(rectLeftAig, (int)(height / 3));
                CanvaColorDisplay.Children.Add(rectLeftAig);

                rectLeftNA.Height = (int)(height / 3) - 1;
                Canvas.SetTop(rectLeftNA, (int)(2 * height / 3));
                CanvaColorDisplay.Children.Add(rectLeftNA);

            }
            else if (nbTypeOp == 2)
            {
                if (dispFab == true)
                {
                    rectLeftFab.Height = (int)(height / 2) - 1;
                    Canvas.SetTop(rectLeftFab, 1);
                    CanvaColorDisplay.Children.Add(rectLeftFab);

                    if (dispAig == true)
                    {
                        rectLeftAig.Height = (int)(height / 2) - 1;
                        Canvas.SetTop(rectLeftAig, (int)(height / 2));
                        CanvaColorDisplay.Children.Add(rectLeftAig);
                    }
                    else
                    {
                        rectLeftNA.Height = (int)(height / 2) - 1;
                        Canvas.SetTop(rectLeftNA, (int)(height / 2));
                        CanvaColorDisplay.Children.Add(rectLeftNA);
                    }
                }
                else
                {
                    rectLeftAig.Height = (int)(height / 2) - 1;
                    Canvas.SetTop(rectLeftAig, 1);
                    CanvaColorDisplay.Children.Add(rectLeftAig);

                    rectLeftNA.Height = (int)(height / 2) - 1;
                    Canvas.SetTop(rectLeftNA, (int)(height / 2));
                    CanvaColorDisplay.Children.Add(rectLeftNA);
                }
            }
            else if (nbTypeOp== 1)
            {
                if (dispFab == true)
                {
                    rectLeftFab.Height = height - 2;
                    Canvas.SetTop(rectLeftFab, 1);
                    CanvaColorDisplay.Children.Add(rectLeftFab);
                }
                else if( dispAig == true)
                {
                    rectLeftAig.Height = height - 2;
                    Canvas.SetTop(rectLeftAig, 1);
                    CanvaColorDisplay.Children.Add(rectLeftAig);
                }
                else
                {
                    rectLeftNA.Height = height - 2;
                    Canvas.SetTop(rectLeftNA, 1);
                    CanvaColorDisplay.Children.Add(rectLeftNA);
                }
            }
            else
            {
                rectLeftNA.Height = height - 2;
                Canvas.SetTop(rectLeftNA, 1);
                CanvaColorDisplay.Children.Add(rectLeftNA);
            }
            

            
            //moitié droite : 
            Rectangle rectRight = new Rectangle();
            rectRight.Height = Values.Instance.HEIGHT_FICHE_MONTH - 2;
            rectRight.Width = Values.Instance.WIDTH_FICHE_MONTH * 0.5 - 1;

            Canvas.SetTop(rectRight, 1);
            Canvas.SetLeft(rectRight, Values.Instance.WIDTH_FICHE_MONTH * 0.5);

            if (ficheDayMonth.reco != null)
            {
                rectRight.Fill = new SolidColorBrush(ficheDayMonth.reco.color);
            }
            else
            {
                rectRight.Fill = new SolidColorBrush( Colors.White);
            }
            
            CanvaColorDisplay.Children.Add(rectRight);

        }

    }
}
