using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;
using static GestionPlanning.src.FichierSauvegarde;

namespace GestionPlanning.src
{
    enum DispPlanning { day, week, month, simple ,machine} // day = 1
    enum TriOp { all, fab, aff , na}; //all = 1
    enum TriReco { all, yes, non }; //all = 1
    enum TriRetard { all, attention, alerte, both, none}

    class Brain
    {
        public String nameUser = " Default user";

        //Affichage du jour ou de la semaine
        public DispPlanning dispPlanning = DispPlanning.week;

        //Le jour à afficher ou le premier jour de la semaine ou du mois à afficher
        public DateTime dateToDisplay = new DateTime();// = DateTime.Now;

        //Afficher les opérations
        public TriOp triOperation = TriOp.all; //operation fabrication all=0/fabrication/affutage/ -> faire une enum

        //Afficher les recouvrements
        public TriReco triReco = TriReco.all; //recouvrement all=0/oui/non/

        public TriRetard triRetard = TriRetard.all;
        //Afficher le nom de tri
        public String triName = "Tous noms";

        //Afficher le numéro de machine de tri
        public String triMachine = ""; //"" = all
        
        //La liste de fiches completes
        public List<Fiche> listeFiches = new List<Fiche>();

        //La liste de fiches pour une journée
        public List<Fiche> listeDay = new List<Fiche>();

        //La liste de fiches pour une semaine
        public ListeFichesWeek listeWeek = new ListeFichesWeek();

        //La liste de fiches pour une semaine
        public ListeFichesMonth listeMonth = new ListeFichesMonth();

        //La liste de fiches non placées
        public List<Fiche> listeNonPlacees = new List<Fiche>();

        //La liste de fiches non placées
        public List<Fiche> listeSimple = new List<Fiche>();

        //La liste des types de revetement
        public List<TypeColor> listeColors = new List<TypeColor>();

        //Le fichier de sauvegarde
        public FichierXcel fichierXcel = new FichierXcel();

        //Le fichier xcel
        public FichierSauvegarde fichierSauvegarde = new FichierSauvegarde();

        //Le fichier gestion modifs
        public GestionModifs gestionModif = new GestionModifs();

        //Les différents controls utilisateurs
        public MainWindow mainWindow;
        public UC_Disp_Controls ucDispControl;
        public UC_display_day ucDispDay;
        public UC_Display_week ucDispWeek;
        public UC_Disp_Month ucDispMonth;
        public UC_Display_Simple ucDispSimple;
        public UC_Disp_modifs ucDispModifs;
        public UC_param_logiciel ucParamLog;

        public Window_Identification WinPageIdentification;
        public WindowChangePaths winChangePaths;
        public Window_Modif_Fiche winModifFiche = new Window_Modif_Fiche();
        public Window_Create_Fiche winCreateFiche;
        public Window_Modif_Colors winModifColors;
        public Window_Add_Color winAddColor;

        MessageConfValidationFiche message_validationFiche;
        MessageConfRetraitFichePlanning message_retraitFiche;

        private static Brain instance;

        public static Brain Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new Brain();
                }
                return instance;
            }
        }
        
        /**
         * @brief Initialisation du brain au démarrage
         * @note none
         * @param none
         */
        private Brain() {
            dateToDisplay = DateTime.Now;
            dateToDisplay = new DateTime(dateToDisplay.Year, dateToDisplay.Month, dateToDisplay.Day);
        }

        static public void Main()
        {

        }

        public void InitDisplay()
        {
            dispPlanning = DispPlanning.week;
            dateToDisplay = DateTime.Now;
            while (dateToDisplay.DayOfWeek != DayOfWeek.Monday)
            {
                dateToDisplay = dateToDisplay.AddDays(-1);
            }
            while (ucDispDay == null || ucDispWeek == null || ucDispMonth == null || ucDispSimple == null || ucDispControl == null || mainWindow == null)
            {

            }
            ResetWeek();
            RefreshData();
        }
        
        /**
         * @brief Place automatiquement toutes les fiches dans l'emploi du temps en fonction de leurs paramètres
         * @note la synchro doit être appellées
         * @param none
         * */
        public void PlacementAutoAll()
        {
            foreach (Fiche fiche in listeFiches)
            {
                PlacementAutoOneFiche(fiche);
            }
            SaveListeInData();
            ProcessListSimple();
            ProcessListNotPlaced();
            ProcessListCurrentDay();
            listeWeek.ProcessListCurrentWeek(listeFiches, dateToDisplay);
            //TODO ProcessListMonth
            DisplayFiches();
            gestionModif.AddModif(new Modification(TypeModification.placementAuto, nameUser, -1, "Placement automatique de toutes les fiches", DateTime.Now,""));
        }

        //Replace les fiches dont la date de fabrication est dépassée sans être validée
        public void ReplacementRetardAutoAll()
        {
            foreach (Fiche fiche in listeFiches)
            {
                if (fiche.dateDebutFabrication.CompareTo(DateTime.Now) < 0 && fiche.check == false)
                {
                    DateTime dateTmp = DateTime.Now;
                    fiche.dateDebutFabrication = new DateTime(dateTmp.Year, dateTmp.Month, dateTmp.Day);
                }
            }
            SaveListeInData();
            ProcessListNotPlaced();
            ProcessListCurrentDay();
            listeWeek.ProcessListCurrentWeek(listeFiches, dateToDisplay);
            //TODO ProcessListMonth
            DisplayFiches();
            gestionModif.AddModif(new Modification(TypeModification.replacementAuto, nameUser, -1, "Replacement automatique de toutes les fiches", DateTime.Now,""));
        }
        
        public void PlacementAutoOneFiche(Fiche fiche)
        {
            //si la fiche n'a pas de date de fabrication
            if (fiche.dateDebutFabrication.CompareTo(new DateTime(2000, 1, 1)) < 0)
            {
                //si la fiche a une date de livraison
                if (fiche.dateLivraison.CompareTo(new DateTime(2000, 1, 1)) > 0)
                {
                    fiche.dateDebutFabrication = fiche.dateLivraison.AddDays(-2);
                    //Si la fabrication tombe un week end elle est décalée de 2 jours supplémentaire
                    if (fiche.dateDebutFabrication.DayOfWeek == DayOfWeek.Sunday || fiche.dateDebutFabrication.DayOfWeek == DayOfWeek.Saturday)
                    {
                        fiche.dateDebutFabrication = fiche.dateDebutFabrication.AddDays(-2);
                    }
                    //Déplacement de 2 jours si recouvrement et prise en compte du week end
                    if (fiche.recouvrement == true)
                    {
                        fiche.dateDebutFabrication = fiche.dateLivraison.AddDays(-2);
                        if (fiche.dateDebutFabrication.DayOfWeek == DayOfWeek.Sunday || fiche.dateDebutFabrication.DayOfWeek == DayOfWeek.Saturday)
                        {
                            fiche.dateDebutFabrication = fiche.dateDebutFabrication.AddDays(-2);
                        }
                    }
                    if (fiche.dateDebutFabrication.CompareTo(DateTime.Now) < 0)
                    {
                        fiche.dateDebutFabrication = DateTime.Now;
                        if (fiche.dateDebutFabrication.DayOfWeek == DayOfWeek.Sunday)
                        {
                            fiche.dateDebutFabrication = fiche.dateDebutFabrication.AddDays(1);
                        }
                        if (fiche.dateDebutFabrication.DayOfWeek == DayOfWeek.Saturday)
                        {
                            fiche.dateDebutFabrication = fiche.dateDebutFabrication.AddDays(2);
                        }

                    }
                }
                else
                {
                    fiche.dateDebutFabrication = DateTime.Now;
                    if (fiche.dateDebutFabrication.DayOfWeek == DayOfWeek.Sunday)
                    {
                        fiche.dateDebutFabrication = fiche.dateDebutFabrication.AddDays(1);
                    }
                    if (fiche.dateDebutFabrication.DayOfWeek == DayOfWeek.Saturday)
                    {
                        fiche.dateDebutFabrication = fiche.dateDebutFabrication.AddDays(2);
                    }
                }
                fiche.dateDebutFabrication = new DateTime(fiche.dateDebutFabrication.Year, fiche.dateDebutFabrication.Month, fiche.dateDebutFabrication.Day);
            }
        }
        
        public void FindAlerteListeFull(List<Fiche> liste)
        {
            mainWindow.image_alerteGeneral.Visibility = Visibility.Collapsed;
            mainWindow.image_warningGeneral.Visibility = Visibility.Collapsed;
            foreach (Fiche fiche in liste)
            {
                FindAlerteListeInFor(fiche);
            }
        }
        
        public void FindAlerteListeInFor(Fiche fiche)
        {
            DateTime dateLivraison = new DateTime();
            DateTime dateFabrication = new DateTime();

            if (fiche.check == false)
            {
                if (fiche.dateLivraison != null && fiche.dateLivraison.CompareTo(new DateTime(2000, 1, 1)) > 0)
                {
                    if (fiche.dateDebutFabrication.CompareTo(new DateTime(2000, 1, 1)) > 0 )
                    {
                        dateLivraison = fiche.dateLivraison;
                        dateFabrication = fiche.dateDebutFabrication;
                    }
                    else //Si la fiche n'a pas de date de fabrication, on prend en compte le retard par rapport à la date d'aujourd'hui
                    {
                        dateLivraison = fiche.dateLivraison;
                        dateFabrication = DateTime.Now;
                        dateFabrication = new DateTime(dateFabrication.Year, dateFabrication.Month, dateFabrication.Day);
                    }

                    TimeSpan time = dateFabrication - dateLivraison;
                    if(time.Days > 0 ) //date fabrication après date livraison
                    {
                        fiche.alerteRetard = true;
                        fiche.attentionRetard = false;
                        mainWindow.image_alerteGeneral.Visibility = Visibility.Visible;
                    }
                    else if (time.Days >-2) //moins de 2 jours entre fabrication et livraison en semaine
                    {
                        fiche.alerteRetard = false;
                        fiche.attentionRetard = true;
                        mainWindow.image_warningGeneral.Visibility = Visibility.Visible;
                    }
                    else if (time.Days > -4 && (dateLivraison.AddDays(-1).DayOfWeek == DayOfWeek.Sunday || dateLivraison.AddDays(-2).DayOfWeek == DayOfWeek.Sunday))
                    {
                        fiche.alerteRetard = false;
                        fiche.attentionRetard = true;
                        mainWindow.image_warningGeneral.Visibility = Visibility.Visible;
                    }
                    else 
                    {
                        fiche.alerteRetard = false;
                        fiche.attentionRetard = false;
                    }
                }
            }
        }
        
        public void ProcessListCurrentDay()
        {
            listeDay.Clear();
            foreach (Fiche fiche in listeFiches)
            {
                if (VerifProcessFiche(fiche)>0)
                {
                    FindAlerteListeInFor(fiche);
                    if (fiche.dateDebutFabrication.Year == dateToDisplay.Year
                        && fiche.dateDebutFabrication.Month == dateToDisplay.Month
                        && fiche.dateDebutFabrication.Day == dateToDisplay.Day)
                    {
                        listeDay.Add(fiche);
                    }
                }
            }
        }
        
        public void ProcessListCurrentMonth()
        {
            //listeMonth
            foreach (Fiche fiche in listeFiches)
            {
                if (VerifProcessFiche(fiche) > 0)
                {
                    FindAlerteListeInFor(fiche);
                    if (fiche.dateLivraison.Year == dateToDisplay.Year
                        && fiche.dateLivraison.Month == dateToDisplay.Month
                        && fiche.dateLivraison.Day == dateToDisplay.Day)
                    {
                        listeDay.Add(fiche);
                    }
                }
            }
        }
        
        public void ProcessListNotPlaced()
        {
            listeNonPlacees.Clear();
            foreach (Fiche fiche in listeFiches)
            {
                if (VerifProcessFiche(fiche) > 0)
                {
                    FindAlerteListeInFor(fiche);
                    if (fiche.dateDebutFabrication.Year < 2000)
                    {
                        listeNonPlacees.Add(fiche);
                    }
                }
            }
        }
        
        public void ProcessListSimple()
        {
            listeSimple.Clear();
            foreach (Fiche fiche in listeFiches)
            {
                if (VerifProcessFiche(fiche) > 0)
                {
                    FindAlerteListeInFor(fiche);
                    listeSimple.Add(fiche);
                }
            }
        }

        public int VerifProcessFiche(Fiche fiche)
        {
            int val = 0, ret = 0;
            
            //tri retard
            if(triRetard == TriRetard.all)
            {
            }
            else if(triRetard == TriRetard.both && ( fiche.alerteRetard == true || fiche.attentionRetard == true) )
            {
            }
            else if(triRetard == TriRetard.alerte && fiche.alerteRetard == true && fiche.attentionRetard == false)
            {
            }
            else if (triRetard == TriRetard.attention && fiche.alerteRetard == false && fiche.attentionRetard == true)
            {
            }
            else if (triRetard == TriRetard.none && fiche.alerteRetard == false && fiche.attentionRetard == false)
            {
            }
            else
            {
                val++;
            }

            //tri operation
            if (triOperation == TriOp.all)
            {
            }
            else if(triOperation == TriOp.aff && fiche.typeOperation == TypeOperation.aiguisage)
            {
            }
            else if(triOperation == TriOp.fab && fiche.typeOperation == TypeOperation.fabrication)
            {
            }
            else if (triOperation == TriOp.na && fiche.typeOperation == TypeOperation.na)
            {
            }
            else 
            {
                val++;
            }

            //tri recouvrement
            if (triReco == TriReco.all)
            {
            }
            else if (triReco == TriReco.non && fiche.recouvrement == false)
            {
            }
            else if (triReco == TriReco.yes && fiche.recouvrement == true)
            {
            }
            else
            {
                val++;
            }

            //tri nom
            if (String.Compare(triName, "Tous noms") == 0)
            {
            }
            else if (String.Compare(triName, fiche.name) == 0)
            {
            }
            else
            { 
                val++;
            }


            //tri nombre machine
            if (triMachine == "" || triMachine ==  "Toutes machines")
            {
            }
            else if(triMachine != fiche.machine)
            {
                val++;
            }
            
            if(val > 0)
            {
                ret = 0;
            }
            else
            {
                ret = 1;
            }
            return ret;

    }
        
        public void RefreshData()
        {
            if (fichierXcel.LoadFiches(listeFiches) >= 0)
            {
                List<Fiche> newListe = fichierSauvegarde.SynchroListe(listeFiches);
                if (newListe != null)
                {
                    foreach (Fiche ficheTmp in newListe)
                    {
                        listeFiches.Add(ficheTmp);
                    }
                    //Trier fiches par id
                    listeFiches = listeFiches.OrderBy(fiche => fiche.id).ToList();
                }
                FindAlerteListeFull(listeFiches);
                ProcessListCurrentDay();
                listeWeek.ProcessListCurrentWeek(listeFiches, dateToDisplay);
                //processListCurrentMonth
                ProcessListNotPlaced();
                DisplayFiches();
                RefreshDispControlTri();
                gestionModif.AddModif(new Modification(TypeModification.refreshData, nameUser, -1, "Rafraichissement des données", DateTime.Now,""));
            }
        }
        
        public void RefreshDispControlTri()
        {
            List<String> listName = new List<String>();
            List<String> listeMachine = new List<String>();
            foreach (Fiche fiche in listeFiches)
            {
                if (!listName.Contains(fiche.name))
                {
                    listName.Add(fiche.name);
                }
                if (!listeMachine.Contains(fiche.machine))
                {
                    listeMachine.Add(fiche.machine);
                }
            }
            
            listName.Sort();
            listeMachine.Sort();

            ucDispControl.SetListName(listName);
            //TODO setListColor
            ucDispControl.SetListMachine(listeMachine);
        }

        public void RefreshDisplayListes()
        {
            ProcessListSimple();
            ProcessListNotPlaced();
            ProcessListCurrentDay();
            listeWeek.ProcessListCurrentWeek(listeFiches, dateToDisplay);
            DisplayFiches();
        }
        
        public void SaveListeInData()
        {
            fichierSauvegarde.SaveListe(listeFiches);
        }
        
        public void DisplayFiches()
        {
            switch (dispPlanning)
            {
                case DispPlanning.day:
                    DisplayDay();
                    break;
                case DispPlanning.week:
                    DisplayWeek();
                    break;
                case DispPlanning.month:
                    DisplayMonth();
                    break;
                case DispPlanning.simple:
                    DisplayListeSimple();
                    break;
                case DispPlanning.machine:
                    //TODO
                    break;
                default:
                    DisplayDay();
                    break;
            }
        }

        public void DisplayDay()
        {
            dispPlanning = DispPlanning.day;
            mainWindow.UC_Disp_Day.Visibility = Visibility.Visible;
            mainWindow.UC_Disp_Week.Visibility = Visibility.Collapsed;
            mainWindow.UC_Disp_Month.Visibility = Visibility.Collapsed;
            mainWindow.UC_Disp_Simple.Visibility = Visibility.Collapsed;
            ucDispModifs.Visibility = Visibility.Collapsed;

            ProcessListCurrentDay();
            ucDispDay.RefreshDayToDisplay(dateToDisplay);
            ucDispDay.RefreshListToDisplay(listeDay);
        }
        
        public void DisplayWeek()
        {
            dispPlanning = DispPlanning.week;
            //utiliser premiere semaine du mois ou semaine du jour
            mainWindow.UC_Disp_Day.Visibility = Visibility.Collapsed;
            mainWindow.UC_Disp_Week.Visibility = Visibility.Visible;
            mainWindow.UC_Disp_Month.Visibility = Visibility.Collapsed;
            mainWindow.UC_Disp_Simple.Visibility = Visibility.Collapsed;
            ucDispModifs.Visibility = Visibility.Collapsed;

            //obtenir premier jour de la semaine et afficher numéro semaine et jours
            int numberWeek = GetNumberWeek(dateToDisplay);
            //obtenir les fiches de la semaine affichée et les afficher
            while (dateToDisplay.DayOfWeek != DayOfWeek.Monday)
            {
                dateToDisplay = dateToDisplay.AddDays(-1);
            }
            ucDispWeek.RefreshWeekToDisplay(dateToDisplay, numberWeek);
            listeWeek.ProcessListCurrentWeek(listeFiches, dateToDisplay);
            ucDispWeek.RefreshListToDisplay(listeWeek);
        }

        public void DisplayMonth()
        {
            dispPlanning = DispPlanning.month;
            mainWindow.UC_Disp_Day.Visibility = Visibility.Collapsed;
            mainWindow.UC_Disp_Week.Visibility = Visibility.Collapsed;
            mainWindow.UC_Disp_Month.Visibility = Visibility.Visible;
            mainWindow.UC_Disp_Simple.Visibility = Visibility.Collapsed;
            ucDispModifs.Visibility = Visibility.Collapsed;

            //TODO obtenir premier jour du mois
            dateToDisplay = new DateTime(dateToDisplay.Year, dateToDisplay.Month, 1);

            listeMonth.ProcessListCurrentMonth(listeFiches, dateToDisplay);
            ucDispMonth.RefreshMonthToDisplay(dateToDisplay,listeMonth);

        }

        public void DisplayListeSimple()
        {
            dispPlanning = DispPlanning.simple;
            //utiliser premiere semaine du mois ou semaine du jour
            mainWindow.UC_Disp_Day.Visibility = Visibility.Collapsed;
            mainWindow.UC_Disp_Week.Visibility = Visibility.Collapsed;
            mainWindow.UC_Disp_Month.Visibility = Visibility.Collapsed;
            mainWindow.UC_Disp_Simple.Visibility = Visibility.Visible;
            ucDispModifs.Visibility = Visibility.Collapsed;

            ProcessListSimple();
            ucDispSimple.RefreshListToDisplay(listeSimple);
        }

        public void DisplayListeModifs()
        {
            mainWindow.UC_Disp_Day.Visibility = Visibility.Collapsed;
            mainWindow.UC_Disp_Week.Visibility = Visibility.Collapsed;
            mainWindow.UC_Disp_Month.Visibility = Visibility.Collapsed;
            mainWindow.UC_Disp_Simple.Visibility = Visibility.Collapsed;
            ucDispModifs.DisplayModifs(gestionModif.ReadDatas());
            ucDispModifs.Visibility = Visibility.Visible;
        }

        public void NextDay()
        {
            dispPlanning = DispPlanning.day;
            dateToDisplay = dateToDisplay.AddDays(1);
            DisplayFiches();
        }

        public void PreviousDay()
        {
            dispPlanning = DispPlanning.day;
            dateToDisplay = dateToDisplay.AddDays(-1);
            DisplayFiches();
        }

        public void ResetDay()
        {
            dispPlanning = DispPlanning.day;
            dateToDisplay = DateTime.Now;
            DisplayFiches();
        }

        public void NextWeek()
        {
            dispPlanning = DispPlanning.week;
            dateToDisplay = dateToDisplay.AddDays(7);
            DisplayFiches();
        }

        public void PreviousWeek()
        {
            dispPlanning = DispPlanning.week;
            dateToDisplay = dateToDisplay.AddDays(-7);
            DisplayFiches();
        }

        public void ResetWeek()
        {
            dispPlanning = DispPlanning.week;
            dateToDisplay = DateTime.Now;
            while (dateToDisplay.DayOfWeek != DayOfWeek.Monday)
            {
                dateToDisplay = dateToDisplay.AddDays(-1);
            }
            DisplayFiches();
        }

        public void NextMonth()
        {
            dispPlanning = DispPlanning.month;
            dateToDisplay = dateToDisplay.AddMonths(1);
            dateToDisplay = new DateTime(dateToDisplay.Year, dateToDisplay.Month,1);
            DisplayFiches();
        }

        public void ResetMonth()
        {
            dispPlanning = DispPlanning.month;
            dateToDisplay = DateTime.Now;
            dateToDisplay = new DateTime(dateToDisplay.Year, dateToDisplay.Month, 1);
            DisplayFiches();
        }

        public void PreviousMonth()
        {
            dispPlanning = DispPlanning.month;
            dateToDisplay = dateToDisplay.AddMonths(-1);
            dateToDisplay = new DateTime(dateToDisplay.Year, dateToDisplay.Month, 1);
            DisplayFiches();
        }

        private int GetNumberWeek(DateTime date)
        {
            DateTimeFormatInfo dfi = DateTimeFormatInfo.CurrentInfo;
            Calendar cal = dfi.Calendar;
            return cal.GetWeekOfYear(date, dfi.CalendarWeekRule, dfi.FirstDayOfWeek);
        }

        public void ClickModifyFiche(int idFiche)
        {
            foreach (Fiche fiche in listeFiches)
            {
                if (fiche.id == idFiche)
                {
                    winModifFiche = new Window_Modif_Fiche(fiche);
                    winModifFiche.Show();
                    break;
                }
            }
        }

        public void ValidateModificationFiche(int idFiche)
        {
            //réenregistrer les nouvelles données dans la liste
            String textTemp;
            Fiche ficheTemp = new Fiche();
            textTemp = winModifFiche.textBoxDateLivraison.Text;
            Boolean error = false;
            DateTime dateTime = new DateTime(1,1,1);
            DateTime dateDayNow = DateTime.Now;
            dateDayNow = new DateTime(dateDayNow.Year, dateDayNow.Month, dateDayNow.Day);

            if(winModifFiche.RadioButtonOpAffutage.IsChecked == true)
            {
                ficheTemp.typeOperation = TypeOperation.aiguisage;
            }
            else if (winModifFiche.radioButtonOpFabrication.IsChecked == true)
            {
                ficheTemp.typeOperation = TypeOperation.fabrication;
            }
            else if (winModifFiche.RadioButtonOpNA.IsChecked == true)
            {
                ficheTemp.typeOperation = TypeOperation.na;
            }
            else
            {
                ficheTemp.typeOperation = TypeOperation.na;
            }

            if (winModifFiche.RadioButtonRecYes.IsChecked == true)
            {
                ficheTemp.recouvrement = true;
            }
            else if (winModifFiche.RadioButtonRecNo.IsChecked == true)
            {
                ficheTemp.recouvrement = false;
            }
            else
            {
                ficheTemp.recouvrement = false;
            }

            //modif date livraison
            try
            {
                dateTime = Convert.ToDateTime(winModifFiche.textBoxDateLivraison.Text);
            }
            catch
            {
                error = true;
                winModifFiche.imageAttention_dateLiv.Visibility = Visibility.Visible;
            }
            if (dateTime.CompareTo(dateDayNow) >= 0)
            {
                ficheTemp.dateLivraison = dateTime;
                winModifFiche.imageAttention_dateLiv.Visibility = Visibility.Collapsed;
            }
            else
            {
                error = true;
                winModifFiche.imageAttention_dateLiv.Visibility = Visibility.Visible;
            }
            //modif date fabrication
            if (winModifFiche.textBoxDateFabrication.Text.Length > 0 && winModifFiche.textBoxDateFabrication.Text.CompareTo(" ") !=0 )
            {
                try
                {
                    dateTime = Convert.ToDateTime(winModifFiche.textBoxDateFabrication.Text);
                }
                catch
                {
                    error = true;
                    winModifFiche.imageAttention_dateFab.Visibility = Visibility.Visible;
                }
                if (dateTime.CompareTo(dateDayNow) >= 0)
                {
                    ficheTemp.dateDebutFabrication = dateTime;
                    winModifFiche.imageAttention_dateFab.Visibility = Visibility.Collapsed;
                }
                else
                {
                    error = true;
                    winModifFiche.imageAttention_dateFab.Visibility = Visibility.Visible;
                }
            }
            else //pas de date de fabrication
            {
                ficheTemp.dateDebutFabrication = new DateTime(1, 1, 1);
                winModifFiche.imageAttention_dateFab.Visibility = Visibility.Collapsed;
            }
            //Heure début fabrication
            try
            {
                winModifFiche.imageAttention_heureFab.Visibility = Visibility.Collapsed;
                string[] tab_line = new string[2]; // tableau qui va contenir les sous-chaines extraites d'une ligne.
                char[] splitter = { ':' }; // délimiteur du fichier texte
                tab_line = winModifFiche.textBoxHeureFabrication.Text.Split(splitter);
                ficheTemp.dateDebutFabrication = ficheTemp.dateDebutFabrication.AddHours(int.Parse(tab_line[0]));
                
                int lenght = tab_line[1].ToCharArray().Length;
                if (lenght == 0)
                {
                    //ficheTemp.dateDebutFabrication.AddMinutes(0);
                }
                else if (lenght == 1)
                {
                    int value_tab = int.Parse(tab_line[1]);
                    if (value_tab < 6 && value_tab >= 0)
                    {
                        value_tab = value_tab * 10;
                        ficheTemp.dateDebutFabrication = ficheTemp.dateDebutFabrication.AddMinutes(value_tab);
                    }
                    else
                    {
                        error = true;
                        winModifFiche.imageAttention_heureFab.Visibility = Visibility.Visible;
                    }
                }
                else if (lenght == 2)
                {
                    int value_tab = int.Parse(tab_line[1]);
                    if (value_tab < 60 && value_tab >= 0)
                    {
                        ficheTemp.dateDebutFabrication = ficheTemp.dateDebutFabrication.AddMinutes(int.Parse(tab_line[1]));
                    }
                    else
                    {
                        error = true;
                        winModifFiche.imageAttention_heureFab.Visibility = Visibility.Visible;
                    }
                }
                else
                {
                    error = true;
                    winModifFiche.imageAttention_heureFab.Visibility = Visibility.Visible;
                }
            }
            catch
            {
                error = true;
                winModifFiche.imageAttention_heureFab.Visibility = Visibility.Visible;
            }
            //temps fabrication
            if (int.TryParse(winModifFiche.textBoxTempsFabrication.Text, out ficheTemp.tempsFabrication))
            {
                if (ficheTemp.tempsFabrication >= 0) //ok
                {
                    winModifFiche.imageAttention_TempsFab.Visibility = Visibility.Collapsed;
                }
                else 
                {
                    error = true;
                    winModifFiche.imageAttention_TempsFab.Visibility = Visibility.Visible;
                }
            }
            else
            { 
                error = true;
                winModifFiche.imageAttention_TempsFab.Visibility = Visibility.Visible;
            }

            //la machine
            ficheTemp.machine = winModifFiche.TextBoxNumMachine.Text;

            //quantité élements
            if ( int.TryParse(winModifFiche.TextBoxQty.Text, out ficheTemp.quantiteElement))
            {
                if (ficheTemp.quantiteElement >= -1)
                {
                    winModifFiche.imageAttention_QtyEl.Visibility = Visibility.Collapsed;
                }
                else
                { 
                    error = true;
                    winModifFiche.imageAttention_QtyEl.Visibility = Visibility.Visible;
                }
            }
            else
            {
                error = true;
                winModifFiche.imageAttention_QtyEl.Visibility = Visibility.Visible;
            }

            ficheTemp.textDescription = winModifFiche.textBoxTextFiche.Text;
            if (winModifFiche.textBoxTextFiche.Text.Length <= 200)
            {
                winModifFiche.imageAttention_SizeText.Visibility = Visibility.Collapsed;
            }
            else
            { 
                error = true;
                winModifFiche.imageAttention_SizeText.Visibility = Visibility.Visible;
            }
            
            if(!error)
            { 
                //synchro ficheTemp avec listeFiches
                foreach (Fiche fiche in listeFiches)
                {
                    if (fiche.id == idFiche)
                    {
                        fiche.dateLivraison = ficheTemp.dateLivraison;
                        fiche.dateDebutFabrication = ficheTemp.dateDebutFabrication;
                        fiche.tempsFabrication = ficheTemp.tempsFabrication;
                        fiche.machine = ficheTemp.machine;
                        fiche.quantiteElement = ficheTemp.quantiteElement;
                        fiche.textDescription = ficheTemp.textDescription;
                        fiche.typeOperation = ficheTemp.typeOperation;
                        fiche.recouvrement = ficheTemp.recouvrement;

                        FindAlerteListeFull(listeFiches);
                        DisplayFiches();
                        break;
                        
                    }
                }
                winModifFiche.Close();
                RefreshDispControlTri();
                fichierSauvegarde.SaveListe(listeFiches);
            }
            gestionModif.AddModif(new Modification(TypeModification.modifFiche, nameUser, idFiche, "Modification d'une fiche", DateTime.Now,""));
        }

        public void CancelModificationFiche(int idFiche)
        {
            winModifFiche.Close();
        }

        public void DemandValidationFiche(int idFiche)
        {
            message_validationFiche = new MessageConfValidationFiche(idFiche);
            message_validationFiche.Show();
        }

        public void ValidateFabricationFiche(int idFiche)
        {
            bool modif = false;
            message_validationFiche.Hide();
            foreach (Fiche fiche in listeFiches)
            {
                if (fiche.id == idFiche)
                {
                    fiche.check = true;
                    //modifie les nouvelles données dans la liste 
                    //resynchronise la liste et réaffiche tout en retirant la fiche de ucdisplayfiche si possible
                    FindAlerteListeFull(listeFiches);
                    DisplayFiches();
                    modif = true;
                    break;
                }
            }
            if (modif == true)
            {
                SaveListeInData();
                gestionModif.AddModif(new Modification(TypeModification.validationFiche, nameUser, idFiche, "Validation d'une fiche", DateTime.Now, ""));
            }
        }

        public void CancelFabricationFiche(int idFiche)
        {
            message_validationFiche.Hide();
        }

        public void PlacementFicheAuto(int idFiche)
        {
            bool modif = false;
            foreach (Fiche fiche in listeFiches)
            {
                if (fiche.id == idFiche)
                {
                    if(fiche.dateDebutFabrication.Year >2000)
                    {
                        //message demande autorisation retrait
                        message_retraitFiche = new MessageConfRetraitFichePlanning(idFiche);
                        message_retraitFiche.Show();
                    }
                    else
                    {
                        PlacementAutoOneFiche(fiche);
                        DisplayFiches();
                    }
                    modif = true;
                    break;
                }
            }
            //si la fiche est placée et non check, la retirer avec message confirmation
            //si la fiche n'est pas placée la placer
            if (modif == true)
            {
                SaveListeInData();
            }
        }

        public void ConfirmationPlacementFiche(int idFiche)
        {
            bool modif = false;
            message_retraitFiche.Hide();
            foreach (Fiche fiche in listeFiches)
            {
                if (fiche.id == idFiche)
                {
                    fiche.dateDebutFabrication = new DateTime(1, 1, 1);
                    DisplayFiches();
                    modif = true;
                    break;
                }
            }
            if (modif == true)
            {
                SaveListeInData();
            }
        }

        public void CancelPlacementFiche(int idFiche)
        {
            message_retraitFiche.Hide();
        }

        public void SearchByName(String name)
        {
            triName = String.Copy(name);
        }

        public void SearchByOperation(String st_operation)
        {
            switch (st_operation)
            {
                case "Toutes operations":
                    triOperation = TriOp.all;
                    break;
                case "Fabrication":
                    triOperation = TriOp.fab;
                    break;
                case "Aiguisage":
                    triOperation = TriOp.aff;
                    break;
                case "NA":
                    triOperation = TriOp.na;
                    break;
                default:
                    triOperation = TriOp.all;
                    break;
            }
        }

        public void SearchByReco(String st_reco)
        {
            //TODO modif en fonction des différents revêtements
            switch (st_reco)
            {
                case "Tous recouvrements":
                    triReco = TriReco.all;
                    break;
                case "Oui":
                    triReco = TriReco.yes;
                    break;
                case "Non":
                    triReco = TriReco.non;
                    break;
                default:
                    triReco = TriReco.all;
                    break;
            }
        }

        public void SearchByMachine(String st_numMachine)
        {
            triMachine = st_numMachine;
        }

        public void SearchByRetard(String st_retard)
        {
            switch (st_retard)
            {
                case "Tous retards":
                    triRetard = TriRetard.all;
                    break;
                case "Attention":
                    triRetard = TriRetard.attention;
                    break;
                case "Alerte":
                    triRetard = TriRetard.alerte;
                    break;
                case "Alerte/retard":
                    triRetard = TriRetard.both;
                    break;
                case "Sans problème":
                    triRetard = TriRetard.none;
                    break;
                default:
                    triRetard = TriRetard.all;
                    break;
            }
        }

        public void TriFiches(String name, String st_operation, String st_reco, String st_machine, String st_retard)
        {
            SearchByName(name);
            SearchByOperation(st_operation);
            SearchByReco(st_reco);
            SearchByMachine(st_machine);
            SearchByRetard(st_retard);
            DisplayFiches();
        }

        public void ValidateIdentification(String username, String password)
        {
            if (username != "Identifiant")
            {
                this.nameUser = username;
                WinPageIdentification.Hide();
                mainWindow.Show();
                gestionModif.AddModif(new Modification(TypeModification.connexion, nameUser, -1, "Connexion de l'utilisateur", DateTime.Now, ""));
            }
        }

        public void ChangeUser()
        {
            WinPageIdentification.Show();
            mainWindow.Hide();
            gestionModif.AddModif(new Modification(TypeModification.connexion, nameUser, -1, "Déconnexion utilisateur : " + nameUser, DateTime.Now, ""));
        }

        public void DispWindowPaths()
        {
            winChangePaths = new WindowChangePaths(fichierSauvegarde.nameFileCsv, fichierSauvegarde.pathFileCsv, fichierSauvegarde.pathFileModifs);
            winChangePaths.Show();
        }

        public void ChangeNameFileCsv(String newName)
        {
            fichierSauvegarde.RenommerFichierXcel(newName);
            RefreshData();
            gestionModif.AddModif(new Modification(TypeModification.changementNameFile, nameUser, -1, "Renommage fichier csv", DateTime.Now, ""));
        }

        public void ChangePathFileCsv(String newPath)
        {
            fichierSauvegarde.ModifierPathFichierXcel(newPath);
            gestionModif.AddModif(new Modification(TypeModification.changementPath, nameUser, -1, "Changement chemin d'accès fichier csv", DateTime.Now, ""));
        }

        public void ChangePathFichierModifs(String newPath)
        {
            fichierSauvegarde.ModifierPathFichierModifs(newPath);
            gestionModif.AddModif(new Modification(TypeModification.changementPath, nameUser, -1, "Changement chemin d'accès fichier modifications", DateTime.Now, ""));
        }

        public void CreateFiche()
        {
            winCreateFiche = new Window_Create_Fiche();
            winCreateFiche.Show();
        }

        public void CancelCreationFiche()
        {
            if (winCreateFiche != null)
            {
                winCreateFiche.Close();
            }
        }

        public void ValidateCreationFiche()
        {
            if (winCreateFiche != null)
            {
                // réenregistrer les nouvelles données dans la liste
                Fiche newFiche = new Fiche();
                
                Boolean error = false;
                DateTime dateTime = new DateTime(1, 1, 1);
                DateTime dateDayNow = DateTime.Now;
                dateDayNow = new DateTime(dateDayNow.Year, dateDayNow.Month, dateDayNow.Day);

                //nom de la fiche
                newFiche.name = winCreateFiche.textBoxName.Text;
                
                if (int.TryParse(winCreateFiche.textBoxID.Text, out newFiche.id))
                {
                    if (newFiche.id >= 0) //ok
                    {
                        winCreateFiche.imageAttention_ID.Visibility = Visibility.Collapsed;
                    }
                    else
                    {
                        error = true;
                        winCreateFiche.imageAttention_ID.Visibility = Visibility.Visible;
                    }
                }
                else
                {
                    error = true;
                    winCreateFiche.imageAttention_ID.Visibility = Visibility.Visible;
                }


                //opération
                if (winCreateFiche.RadioButtonOpAffutage.IsChecked == true)
                {
                    newFiche.typeOperation = TypeOperation.aiguisage;
                }
                else if (winCreateFiche.radioButtonOpFabrication.IsChecked == true)
                {
                    newFiche.typeOperation = TypeOperation.fabrication;
                }
                else if (winCreateFiche.RadioButtonOpNA.IsChecked == true)
                {
                    newFiche.typeOperation = TypeOperation.na;
                }
                else
                {
                    newFiche.typeOperation = TypeOperation.na;
                }

                //TODO modifier choix revetement
                if (winCreateFiche.RadioButtonRecYes.IsChecked == true)
                {
                    newFiche.recouvrement = true;
                }
                else if (winCreateFiche.RadioButtonRecNo.IsChecked == true)
                {
                    newFiche.recouvrement = false;
                }
                else
                {
                    newFiche.recouvrement = false;
                }

                //modif date livraison
                try
                {
                    dateTime = Convert.ToDateTime(winCreateFiche.textBoxDateLivraison.Text);
                }
                catch
                {
                    error = true;
                    winCreateFiche.imageAttention_dateLiv.Visibility = Visibility.Visible;
                }
                if (dateTime.CompareTo(dateDayNow) >= 0)
                {
                    newFiche.dateLivraison = dateTime;
                    winCreateFiche.imageAttention_dateLiv.Visibility = Visibility.Collapsed;
                }
                else
                {
                    error = true;
                    winCreateFiche.imageAttention_dateLiv.Visibility = Visibility.Visible;
                }

                //modif date fabrication
                if (winCreateFiche.textBoxDateFabrication.Text.Length > 0 && winCreateFiche.textBoxDateFabrication.Text.CompareTo(" ") != 0)
                {
                    try
                    {
                        dateTime = Convert.ToDateTime(winCreateFiche.textBoxDateFabrication.Text);
                    }
                    catch
                    {
                        error = true;
                        winCreateFiche.imageAttention_dateFab.Visibility = Visibility.Visible;
                    }
                    if (dateTime.CompareTo(dateDayNow) >= 0)
                    {
                        newFiche.dateDebutFabrication = dateTime;
                        winCreateFiche.imageAttention_dateFab.Visibility = Visibility.Collapsed;
                    }
                    else
                    {
                        error = true;
                        winCreateFiche.imageAttention_dateFab.Visibility = Visibility.Visible;
                    }
                }
                else //pas de date de fabrication
                {
                    newFiche.dateDebutFabrication = new DateTime(1, 1, 1);
                    winCreateFiche.imageAttention_dateFab.Visibility = Visibility.Collapsed;
                }

                //Heure début fabrication
                try
                {
                    winCreateFiche.imageAttention_heureFab.Visibility = Visibility.Collapsed;
                    string[] tab_line = new string[2]; // tableau qui va contenir les sous-chaines extraites d'une ligne.
                    char[] splitter = { ':' }; // délimiteur du fichier texte
                    tab_line = winCreateFiche.textBoxHeureFabrication.Text.Split(splitter);
                    newFiche.dateDebutFabrication = newFiche.dateDebutFabrication.AddHours(int.Parse(tab_line[0]));

                    int lenght = tab_line[1].ToCharArray().Length;
                    if (lenght == 0)
                    {
                    }
                    else if (lenght == 1)
                    {
                        int value_tab = int.Parse(tab_line[1]);
                        if (value_tab < 6 && value_tab >= 0)
                        {
                            value_tab = value_tab * 10;
                            newFiche.dateDebutFabrication = newFiche.dateDebutFabrication.AddMinutes(value_tab);
                        }
                        else
                        {
                            error = true;
                            winCreateFiche.imageAttention_heureFab.Visibility = Visibility.Visible;
                        }
                    }
                    else if (lenght == 2)
                    {
                        int value_tab = int.Parse(tab_line[1]);
                        if (value_tab < 60 && value_tab >= 0)
                        {
                            newFiche.dateDebutFabrication = newFiche.dateDebutFabrication.AddMinutes(int.Parse(tab_line[1]));
                        }
                        else
                        {
                            error = true;
                            winCreateFiche.imageAttention_heureFab.Visibility = Visibility.Visible;
                        }
                    }
                    else
                    {
                        error = true;
                        winCreateFiche.imageAttention_heureFab.Visibility = Visibility.Visible;
                    }
                }
                catch
                {
                    error = true;
                    winCreateFiche.imageAttention_heureFab.Visibility = Visibility.Visible;
                }
                //temps fabrication
                if (int.TryParse(winCreateFiche.textBoxTempsFabrication.Text, out newFiche.tempsFabrication))
                {
                    if (newFiche.tempsFabrication >= 0) //ok
                    {
                        winCreateFiche.imageAttention_TempsFab.Visibility = Visibility.Collapsed;
                    }
                    else
                    {
                        error = true;
                        winCreateFiche.imageAttention_TempsFab.Visibility = Visibility.Visible;
                    }
                }
                else
                {
                    error = true;
                    winCreateFiche.imageAttention_TempsFab.Visibility = Visibility.Visible;
                }

                //la machine
                newFiche.machine = winCreateFiche.textBoxNumMachine.Text;

                //quantité élements
                if (int.TryParse(winCreateFiche.TextBoxQty.Text, out newFiche.quantiteElement))
                {
                    if (newFiche.quantiteElement >= -1)
                    {
                        winCreateFiche.imageAttention_QtyEl.Visibility = Visibility.Collapsed;
                    }
                    else
                    {
                        error = true;
                        winCreateFiche.imageAttention_QtyEl.Visibility = Visibility.Visible;
                    }
                }
                else
                {
                    error = true;
                    winCreateFiche.imageAttention_QtyEl.Visibility = Visibility.Visible;
                }

                //description
                newFiche.textDescription = winCreateFiche.textBoxTextFiche.Text;
                if (winCreateFiche.textBoxTextFiche.Text.Length <= 200)
                {
                    winCreateFiche.imageAttention_SizeText.Visibility = Visibility.Collapsed;
                }
                else
                {
                    error = true;
                    winCreateFiche.imageAttention_SizeText.Visibility = Visibility.Visible;
                }

                if (!error)
                {
                    listeFiches.Add(newFiche);
                    listeFiches = listeFiches.OrderBy(fiche => fiche.id).ToList();
                    FindAlerteListeFull(listeFiches);
                    DisplayFiches();

                    winCreateFiche.Close();
                    RefreshDispControlTri();
                    fichierSauvegarde.SaveListe(listeFiches);
                }
                gestionModif.AddModif(new Modification(TypeModification.modifFiche, nameUser, newFiche.id, "Création d'une fiche", DateTime.Now, ""));

            }
        }

        public void ClickModifyColor()
        {
            winModifColors = new Window_Modif_Colors();
            winModifColors.Show();

            winModifColors.DisplayColors(listeColors);
        }

        public void ClickAddColor()
        {
            if(listeColors.Count<10)
            {
                winAddColor = new Window_Add_Color();
                winAddColor.Show();
            }
        }

        public void LeaveModifColors()
        {
            winModifColors.Close();
        }

        public void CancelCreationColor()
        {
            winAddColor.Close();
        }

        public void ValidateCreationColor()
        {
            bool error = true;
            foreach (TypeColor color in listeColors)
            {
                if (winAddColor.textBoxNameRevet.Text == color.name && winAddColor.color!= Colors.White)
                {
                    listeColors.Add(new TypeColor(winAddColor.textBoxNameRevet.Text, winAddColor.color));
                    error = false;
                }
            }
            if (error == false)
            {
                winAddColor.Close();
                winModifColors.DisplayColors(listeColors);
            }
        }

        public void CloseAll()
        {
            if(System.Windows.Forms.Application.MessageLoop)
            {
                System.Windows.Forms.Application.Exit();
            }
            else
            {
                System.Environment.Exit(1);
            }
        }
    }

}
