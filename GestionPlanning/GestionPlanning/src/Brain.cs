using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using static GestionPlanning.src.FichierSauvegarde;

namespace GestionPlanning.src
{
    enum DispPlanning { day, week, month, simple } // day = 1
    enum TriOp { all, fab, aff }; //all = 1
    enum TriReco { all, yes, non }; //all = 1
    enum TriRetard { all, attention, alerte, both, none}

    class Brain
    {
        //Affichage du jour ou de la semaine
        public DispPlanning dispPlanning = DispPlanning.week; 

        //Le jour à afficher ou le premier jour de la semaine ou du mois à afficher
        public DateTime dateToDisplay = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day); 

        //Afficher les opérations
        public TriOp triOperation; //operation fabrication all=0/fabrication/affutage/ -> faire une enum

        //Afficher les recouvrements
        public TriReco triReco; //recouvrement all=0/oui/non/

        //Afficher le nom de tri
        public String triName = "All";

        //Afficher le numéro de machine de tri
        public int triNumberMachine = -1; //-1 = all
        
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

        //Le fichier de sauvegarde
        public FichierXcel fichierXcel = new FichierXcel();

        //Le fichier xcel
        public FichierSauvegarde fichierSauvegarde = new FichierSauvegarde();
        
        //Les différents controls utilisateurs
        public MainWindow mainWindow;
        public UC_Disp_Controls ucDispControl;
        public UC_display_day ucDispDay;
        public UC_Display_week ucDispWeek;
        public UC_Disp_Month ucDispMonth;
        public UC_modif_fiche ucModifFiche;

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
            RefreshData();
        }
        
        /**
         * @brief Recupération de la liste des fiches en fonction d'un nom
         * @note none
         * @param none
         */
        public List<Fiche> GetListFichesByName(String name)
        {
            //Une liste contenant les références de fiches seulement pour un tri en fonction des noms
            List<Fiche> listFichesName = new List<Fiche>();
            return listFichesName;
        }

        /**
         * @brief Recupération de la liste des fiches en fonction d'un nom
         * @note none
         * @param none
         */
        public List<Fiche> GetListFichesByOperation(TypeOperation typeOp)
        {
            //Une liste contenant les références de fiches seulement pour un tri en fonction des noms
            List<Fiche> listFichesOperation = new List<Fiche>();
            return listFichesOperation;
        }

        /**
         * @brief Recupération de la liste des fiches en fonction d'un nom
         * @note none
         * @param none
         */
        public List<Fiche> GetListFichesByRecouvrement(Boolean reco)
        {
            //Une liste contenant les références de fiches seulement pour un tri en fonction des noms
            List<Fiche> listFichesRec = new List<Fiche>();
            return listFichesRec;
        }

        /**
         * @brief Récupération d'une fiche en fonction de son id
         * @note none
         * @param id l'identifiant de la fiche
         * @retval Fiche la fiche
         */
        public Fiche GetFiche(int id)
        {
            return new Fiche();
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
            ProcessListNotPlaced();
            ProcessListCurrentDay();
            listeWeek.ProcessListCurrentWeek(listeFiches, dateToDisplay);
            //TODO ProcessListMonth
            DisplayFiches();
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
        }

        //Place automatiquement une seule fiche dans l'emploi du temps
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

        //Detection des alertes et des warnings dans la liste
        public void FindAlerteListeFull(List<Fiche> liste)
        {
            mainWindow.image_alerteGeneral.Visibility = Visibility.Collapsed;
            mainWindow.image_warningGeneral.Visibility = Visibility.Collapsed;
            foreach (Fiche fiche in liste)
            {
                FindAlerteListeInFor(fiche);
            }
        }

        //Detection des alertes et des warnings pour une fiche
        public void FindAlerteListeInFor(Fiche fiche)
        {
            DateTime dateLivraison = new DateTime();
            DateTime dateFabrication = new DateTime();
            
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
                else if (time.Days <2) //moins de 2 jours entre fabrication et livraison en semaine
                {
                    fiche.alerteRetard = false;
                    fiche.attentionRetard = true;
                    mainWindow.image_warningGeneral.Visibility = Visibility.Visible;
                }
                else if (time.Days < 4 && (dateLivraison.AddDays(-1).DayOfWeek == DayOfWeek.Sunday || dateLivraison.AddDays(-2).DayOfWeek == DayOfWeek.Sunday))
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

        //récupère la liste du jour
        public void ProcessListCurrentDay()
        {
            listeDay.Clear();
            foreach (Fiche fiche in listeFiches)
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

        //récupère la liste du mois
        public void ProcessListCurrentMonth()
        {
            //listeMonth
            foreach (Fiche fiche in listeFiches)
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

        //récupère la liste du jour
        public void ProcessListNotPlaced()
        {
            listeNonPlacees.Clear();
            foreach (Fiche fiche in listeFiches)
            {
                FindAlerteListeInFor(fiche);
                if(fiche.dateDebutFabrication.Year < 2000)
                {
                    listeNonPlacees.Add(fiche);
                }
            }
        }

        //Modifie le nombre d'éléments de la liste
        public void ModifyQtyElements(int idFiche, int nbElements)
        {
            //TODO utile?
        }

        //resynchronise les données avec fichier Xcel et fichierSauvegarde
        public void RefreshData()
        {
            if (fichierXcel.LoadFiches(listeFiches) >= 0)
            {
                fichierSauvegarde.SynchroListe(listeFiches);
                FindAlerteListeFull(listeFiches);
                ProcessListCurrentDay();
                listeWeek.ProcessListCurrentWeek(listeFiches, dateToDisplay);
                //processListCurrentMonth
                ProcessListNotPlaced();
                DisplayFiches();
                RefreshDispControlTri();
            }
        }
        
        public void RefreshDispControlTri()
        {
            //TODO rafraichir dispcontrol
            //*
                //à partir de listeFiches (la liste complète)
            List<String> listName = new List<String>();
            List<int> listeNumMachine = new List<int>();
            foreach (Fiche fiche in listeFiches)
            {
                listName.Add(fiche.name);
                listeNumMachine.Add(fiche.numMachine);
            }
            
            listName.Sort();
            listeNumMachine.Sort();

            ucDispControl.SetListName(listName);
            ucDispControl.SetListNumMachine(listeNumMachine);
        }

        //suauvegarde les données dans le fichier sauvegarde
        public void SaveListeInData()
        {
            fichierSauvegarde.SaveListe(listeFiches);
        }

        //affiche les listes actuelles
        public void DisplayFiches()
        {
            mainWindow.DisplayFichesNotPlaced(listeNonPlacees);
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
            
            ProcessListCurrentDay();
            ucDispDay.RefreshDayToDisplay(dateToDisplay);
            ucDispDay.RefreshListToDisplay(listeDay);
        }
        
        public void DisplayWeek()
        {
            //utiliser premiere semaine du mois ou semaine du jour
            mainWindow.UC_Disp_Day.Visibility = Visibility.Collapsed;
            mainWindow.UC_Disp_Week.Visibility = Visibility.Visible;
            mainWindow.UC_Disp_Month.Visibility = Visibility.Collapsed;

            //obtenir premier jour de la semaine et afficher numéro semaine et jours
            int numberWeek = GetNumberWeek(dateToDisplay);
            ucDispWeek.RefreshWeekToDisplay(dateToDisplay, numberWeek);

            //obtenir les fiches de la semaine affichée et les afficher
            listeWeek.ProcessListCurrentWeek(listeFiches, dateToDisplay);
            ucDispWeek.RefreshListToDisplay(listeWeek);
        }

        public void DisplayMonth()
        {
            mainWindow.UC_Disp_Day.Visibility = Visibility.Collapsed;
            mainWindow.UC_Disp_Week.Visibility = Visibility.Collapsed;
            mainWindow.UC_Disp_Month.Visibility = Visibility.Visible;
            //TODO obtenir premier jour du mois
            dateToDisplay = new DateTime(dateToDisplay.Year, dateToDisplay.Month, 1);
            ucDispMonth.RefreshMonthToDisplay(dateToDisplay);
        }

        public void DisplayListeSimple()
        {
            //utiliser premiere semaine du mois ou semaine du jour
            mainWindow.UC_Disp_Day.Visibility = Visibility.Collapsed;
            mainWindow.UC_Disp_Week.Visibility = Visibility.Collapsed;
            mainWindow.UC_Disp_Month.Visibility = Visibility.Collapsed;

            
            //TODO ucDispSimple.RefreshListToDisplay(listeFiches);
        }


        public void NextDay()
        {
            dateToDisplay = dateToDisplay.AddDays(1);
            ucDispDay.RefreshDayToDisplay(dateToDisplay);
            ProcessListCurrentDay();
            ucDispDay.RefreshListToDisplay(listeDay);
        }

        public void PreviousDay()
        {
            dateToDisplay = dateToDisplay.AddDays(-1);
            ucDispDay.RefreshDayToDisplay(dateToDisplay);
            ProcessListCurrentDay();
            ucDispDay.RefreshListToDisplay(listeDay);
        }

        public void ResetDay()
        {
            dateToDisplay = DateTime.Now;
            ucDispDay.RefreshDayToDisplay(dateToDisplay);
            ProcessListCurrentDay();
            ucDispDay.RefreshListToDisplay(listeDay);
        }

        public void NextWeek()
        {
            dateToDisplay = dateToDisplay.AddDays(7);
            while (dateToDisplay.DayOfWeek != DayOfWeek.Monday)
            {
                dateToDisplay = dateToDisplay.AddDays(-1);
            }
            DisplayWeek();
        }

        public void PreviousWeek()
        {
            dateToDisplay = dateToDisplay.AddDays(-7);
            while (dateToDisplay.DayOfWeek != DayOfWeek.Monday)
            {
                dateToDisplay = dateToDisplay.AddDays(-1);
            }
            DisplayWeek();
        }

        public void ResetWeek()
        {
            dateToDisplay = DateTime.Now;
            while (dateToDisplay.DayOfWeek != DayOfWeek.Monday)
            {
                dateToDisplay = dateToDisplay.AddDays(-1);
            }
            //DisplayWeek();
        }

        public void NextMonth()
        {
            dateToDisplay = dateToDisplay.AddMonths(1);
            dateToDisplay = new DateTime(dateToDisplay.Year, dateToDisplay.Month,1);
            ucDispMonth.RefreshMonthToDisplay(dateToDisplay);
            //TODO ucDispDay.RefrshListToDisplay(liste)
        }

        public void ResetMonth()
        {
            dateToDisplay = DateTime.Now;
            dateToDisplay = new DateTime(dateToDisplay.Year, dateToDisplay.Month, 1);
            ucDispMonth.RefreshMonthToDisplay(dateToDisplay);
            //TODO ucDispDay.RefrshListToDisplay(liste)
        }

        public void PreviousMonth()
        {
            dateToDisplay = dateToDisplay.AddMonths(-1);
            dateToDisplay = new DateTime(dateToDisplay.Year, dateToDisplay.Month, 1);
            ucDispMonth.RefreshMonthToDisplay(dateToDisplay);
            //TODO ucDispDay.RefrshListToDisplay(liste)
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
                    ucModifFiche.ModifyDataFiche(fiche);
                    break;
                }
            }
            //UC modifyFiche 
            ucModifFiche.Visibility = Visibility.Visible;
        }

        public void ValidateModificationFiche(int idFiche)
        {
            
            //réenregistrer les nouvelles données dans la liste
            String textTemp;
            Fiche ficheTemp = new Fiche();
            textTemp = ucModifFiche.textBoxDateLivraison.Text;
            Boolean error = false;
            DateTime dateTime = new DateTime(1,1,1);
            DateTime dateDayNow = DateTime.Now;
            dateDayNow = new DateTime(dateDayNow.Year, dateDayNow.Month, dateDayNow.Day);

            if(ucModifFiche.RadioButtonOpAffutage.IsChecked == true)
            {
                ficheTemp.typeOperation = TypeOperation.aiguisage;
            }
            else if (ucModifFiche.radioButtonOpFabrication.IsChecked == true)
            {
                ficheTemp.typeOperation = TypeOperation.fabrication;
            }
            else if (ucModifFiche.RadioButtonOpNA.IsChecked == true)
            {
                ficheTemp.typeOperation = TypeOperation.na;
            }
            else
            {
                ficheTemp.typeOperation = TypeOperation.na;
            }

            if (ucModifFiche.RadioButtonRecYes.IsChecked == true)
            {
                ficheTemp.recouvrement = true;
            }
            else if (ucModifFiche.RadioButtonRecNo.IsChecked == true)
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
                dateTime = Convert.ToDateTime(ucModifFiche.textBoxDateLivraison.Text);
            }
            catch
            {
                error = true;
                ucModifFiche.imageAttention_dateLiv.Visibility = Visibility.Visible;
            }
            if (dateTime.CompareTo(dateDayNow) >= 0)
            {
                ficheTemp.dateLivraison = dateTime;
                ucModifFiche.imageAttention_dateLiv.Visibility = Visibility.Collapsed;
            }
            else
            {
                error = true;
                ucModifFiche.imageAttention_dateLiv.Visibility = Visibility.Visible;
            }
            //modif date fabrication
            if (ucModifFiche.textBoxDateFabrication.Text.Length > 0 && ucModifFiche.textBoxDateFabrication.Text.CompareTo(" ") !=0 )
            {
                try
                {
                    dateTime = Convert.ToDateTime(ucModifFiche.textBoxDateFabrication.Text);
                }
                catch
                {
                    error = true;
                    ucModifFiche.imageAttention_dateFab.Visibility = Visibility.Visible;
                }
                if (dateTime.CompareTo(dateDayNow) >= 0)
                {
                    ficheTemp.dateDebutFabrication = dateTime;
                    ucModifFiche.imageAttention_dateFab.Visibility = Visibility.Collapsed;
                }
                else
                {
                    error = true;
                    ucModifFiche.imageAttention_dateFab.Visibility = Visibility.Visible;
                }
            }
            else //pas de date de fabrication
            {
                ficheTemp.dateDebutFabrication = new DateTime(1, 1, 1);
                ucModifFiche.imageAttention_dateFab.Visibility = Visibility.Collapsed;
            }
            //Heure début fabrication
            try
            {
                string[] tab_line = new string[20]; // tableau qui va contenir les sous-chaines extraites d'une ligne.
                char[] splitter = { ':' }; // délimiteur du fichier texte
                tab_line = ucModifFiche.textBoxHeureFabrication.Text.Split(splitter);
                ficheTemp.dateDebutFabrication.AddHours(int.Parse(tab_line[0]));
                ficheTemp.dateDebutFabrication.AddMinutes(int.Parse(tab_line[1]));
                ucModifFiche.imageAttention_heureFab.Visibility = Visibility.Collapsed;
            }
            catch
            {
                error = true;
                ucModifFiche.imageAttention_heureFab.Visibility = Visibility.Visible;
            }
            //temps fabrication
            if (int.TryParse(ucModifFiche.textBoxTempsFabrication.Text, out ficheTemp.tempsFabrication))
            {
                if (ficheTemp.tempsFabrication >= 0) //ok
                {
                    ucModifFiche.imageAttention_TempsFab.Visibility = Visibility.Collapsed;
                }
                else 
                {
                    error = true;
                    ucModifFiche.imageAttention_TempsFab.Visibility = Visibility.Visible;
                }
            }
            else
            { 
                error = true;
                ucModifFiche.imageAttention_TempsFab.Visibility = Visibility.Visible;
            }

            //numéro machine
            if (int.TryParse(ucModifFiche.TextBoxNumMachine.Text, out ficheTemp.numMachine))
            {
                if (ficheTemp.numMachine >= -1)//ok
                {
                    ucModifFiche.imageAttention_NumMach.Visibility = Visibility.Collapsed;
                }
                else
                { 
                    error = true;
                    ucModifFiche.imageAttention_NumMach.Visibility = Visibility.Visible;
                }
            }
            else
            {
                error = true;
                ucModifFiche.imageAttention_NumMach.Visibility = Visibility.Visible;
            }
            //quantité élements
            if ( int.TryParse(ucModifFiche.TextBoxQty.Text, out ficheTemp.quantiteElement))
            {
                if (ficheTemp.quantiteElement >= -1)
                {
                    ucModifFiche.imageAttention_QtyEl.Visibility = Visibility.Collapsed;
                }
                else
                { 
                    error = true;
                    ucModifFiche.imageAttention_QtyEl.Visibility = Visibility.Visible;
                }
            }
            else
            {
                error = true;
                ucModifFiche.imageAttention_QtyEl.Visibility = Visibility.Visible;
            }

            ficheTemp.textDescription = ucModifFiche.textBoxTextFiche.Text;
            if (ucModifFiche.textBoxTextFiche.Text.Length <= 200)
            {
                ucModifFiche.imageAttention_SizeText.Visibility = Visibility.Collapsed;
            }
            else
            { 
                error = true;
                ucModifFiche.imageAttention_SizeText.Visibility = Visibility.Visible;
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
                        fiche.numMachine = ficheTemp.tempsFabrication; ;
                        fiche.quantiteElement = ficheTemp.quantiteElement;
                        fiche.textDescription = ficheTemp.textDescription;
                        fiche.typeOperation = ficheTemp.typeOperation;
                        fiche.recouvrement = ficheTemp.recouvrement;

                        FindAlerteListeFull(listeFiches);
                        ProcessListCurrentDay();
                        listeWeek.ProcessListCurrentWeek(listeFiches, dateToDisplay);
                        //processListCurrentMonth
                        ProcessListNotPlaced();
                        DisplayFiches();
                        break;
                        
                    }
                }
                ucModifFiche.Visibility = Visibility.Collapsed;
                RefreshDispControlTri();
            }
        }

        public void CancelModificationFiche(int idFiche)
        {
            //réenregistrer les nouvelles données dans la liste
            ucModifFiche.Visibility = Visibility.Collapsed;
        }

        public void DemandValidationFiche(int idFiche)
        {
            message_validationFiche = new MessageConfValidationFiche(idFiche);
            message_validationFiche.Show();
        }

        public void ValidateFabricationFiche(int idFiche)
        {
            message_validationFiche.Hide();
            foreach (Fiche fiche in listeFiches)
            {
                if (fiche.id == idFiche)
                {
                    fiche.check = true;
                    //modifie les nouvelles données dans la liste 
                    //resynchronise la liste et réaffiche tout en retirant la fiche de ucdisplayfiche si possible
                    FindAlerteListeFull(listeFiches);
                    ProcessListCurrentDay();
                    listeWeek.ProcessListCurrentWeek(listeFiches, dateToDisplay);
                    //processListCurrentMonth
                    ProcessListNotPlaced();
                    DisplayFiches();
                }
            }
        }

        public void CancelFabricationFiche(int idFiche)
        {
            message_validationFiche.Hide();
        }

        public void PlacementFicheAuto(int idFiche)
        {
            foreach(Fiche fiche in listeFiches)
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
                        ProcessListNotPlaced();
                        ProcessListCurrentDay();
                        listeWeek.ProcessListCurrentWeek(listeFiches, dateToDisplay);
                        //TODO ProcessListMonth
                        DisplayFiches();
                    }
                    break;
                }
            }
            //si la fiche est placée et non check, la retirer avec message confirmation
            //si la fiche n'est pas placée la placer
        }

        public void ConfirmationPlacementFiche(int idFiche)
        {
            message_retraitFiche.Hide();
            foreach (Fiche fiche in listeFiches)
            {
                if (fiche.id == idFiche)
                {
                    fiche.dateDebutFabrication = new DateTime(1, 1, 1);
                    ProcessListNotPlaced();
                    ProcessListCurrentDay();
                    listeWeek.ProcessListCurrentWeek(listeFiches, dateToDisplay);
                    //TODO ProcessListMonth
                    DisplayFiches();
                    break;
                }
            }
        }

        public void CancelPlacementFiche(int idFiche)
        {
            message_retraitFiche.Hide();
        }

        public void SearchByName(String name)
        {
            //TODO
            //une liste générale
            //une liste triée
            //des listes différentes à afficher?

            //recharger les données?
        }
        public void SearchByOperation(String st_operation)
        {
            switch (st_operation)
            {
                case "All":
                    break;
                case "Fabrication":
                    break;
                case "Aiguisage":
                    break;
                case "NA":
                    break;
                default:
                    break;

            }
        }

        public void SearchByReco(String item)
        {

        }

        public void SearchByMachine(String item)
        {

        }

        public void SearchByRetard(String item)
        {

        }



        /*
         * Fonctions d'essai du logiciel
         * */
        public int Test1_saveLoadDatas_dummy()
        {
            SaveData dummyData = new SaveData();
            CreateDummyData(dummyData);

            //Sauvegarde des données dans le fichier
            fichierSauvegarde.SaveDatas(dummyData);

            //vider les données
            dummyData.nameFileCSV = "";
            dummyData.pathFileCSV = "";
            dummyData.displayDay = false;
            dummyData.listeFiches.Clear();

            //Charger les données
            dummyData = fichierSauvegarde.ReadDatas();

            //Comparer les données avec les données d'entrée (au moins une donnée)
            if (dummyData.nameFileCSV == "fileCsV" && dummyData.pathFileCSV == "" && dummyData.displayDay == true)
            {
               if (dummyData.listeFiches != null && dummyData.listeFiches.Count>0)
                {
                    if (dummyData.listeFiches[0].typeOperation == TypeOperation.fabrication)
                    {
                        return 1;
                    }
                }
            }
            return 0;
        }

        public void CreateDummyData(SaveData data)
        {
            //Génerer fausses données (créer 1 fiche)
            listeFiches.Add(new Fiche("AOS", 32000, 10, new DateTime(2018, 01, 01), TypeOperation.fabrication, true));

            data.nameFileCSV = "fileCsV";
            data.pathFileCSV = "";
            data.displayDay = true;
            data.listeFiches = listeFiches;
        }

        /*
         * Fonctions d'essai du logiciel
         * */
        public int Test2_saveLoadDatas_dummy()
        {

            List<Fiche> list_test = new List<Fiche>();
            if(fichierXcel.LoadFiches(list_test)>=0)
            {
                //list_test = list_test.OrderBy(fiche => fiche.id).ToList();
                fichierSauvegarde.SynchroListe(list_test);
                listeFiches = list_test;

                foreach (Fiche fiche in listeFiches)
                {
                    fiche.dateDebutFabrication = fiche.dateLivraison;
                }

                return 1;
            }
            else
            {
                return 0;
            }

            
            
        }

        public void Test3_displayListe()
        {
            int nbList = 0;

            List<Fiche> list_test = new List<Fiche>();
            Fiche fiche1 = new Fiche();
            fiche1.id = 1234; fiche1.name = "Test1";fiche1.dateLivraison = new DateTime(2017, 12, 12); fiche1.quantiteElement = 12; fiche1.typeOperation = TypeOperation.fabrication; fiche1.recouvrement = true;
            list_test.Add(fiche1);

            Fiche fiche2 = new Fiche();
            fiche2.id = 2345; fiche2.name = "Test2"; fiche2.dateLivraison = new DateTime(2018, 12, 12); fiche2.quantiteElement = 1; fiche2.typeOperation = TypeOperation.aiguisage; fiche2.recouvrement = true;
            list_test.Add(fiche2);

            Fiche fiche3 = new Fiche();
            fiche3.id = 121134; fiche3.name = "Test3"; fiche3.dateLivraison = new DateTime(2016, 12, 12); fiche3.quantiteElement = 3; fiche3.typeOperation = TypeOperation.na; fiche3.recouvrement = false;
            list_test.Add(fiche3);

            Fiche fiche4 = new Fiche();
            fiche4.id = 121134; fiche4.name = "Test4"; fiche4.dateLivraison = new DateTime(2016, 12, 12); fiche4.quantiteElement = 120; fiche4.typeOperation = TypeOperation.fabrication; fiche4.recouvrement = false;
            list_test.Add(fiche4);



            /*if (fichierXcel.LoadFiches(list_test) >= 0  
)             {
                //list_test = list_test.OrderBy(fiche => fiche.id).ToList();
                fichierSauvegarde.SynchroListe(list_test); 
            }*/
            

            //TODO ajouter nouvelles uc dans UC_display_day
            //TODO liste déroulante
            //ajouter seulement 3 fiches
            for (int i =0;i<4; i++)
            {
               /* UC_fiche_day ucfd = new UC_fiche_day(list_test[i].id, list_test[i].name, list_test[i].dateLivraison, list_test[i].quantiteElement, true, false, list_test[i].typeOperation, list_test[i].recouvrement);
                mainWindow.UC_Disp_Day.StackPanelDisplayDay.Children.Add(ucfd);

                UC_Fiche_week ucfw = new UC_Fiche_week(list_test[i].id, list_test[i].name, list_test[i].dateLivraison, list_test[i].quantiteElement, true, false, list_test[i].typeOperation, list_test[i].recouvrement);
                mainWindow.UC_Disp_Week.SPDisplayDay_lundi.Children.Add(ucfw);

                UC_Fiche_week ucfw_2 = new UC_Fiche_week(list_test[i].id, list_test[i].name, list_test[i].dateLivraison, list_test[i].quantiteElement, false, true, list_test[i].typeOperation, list_test[i].recouvrement);
                mainWindow.UC_Disp_Week.SPDisplayDay_mercredi.Children.Add(ucfw_2);

                UC_Fiche_week ucfw_3 = new UC_Fiche_week(list_test[i].id, list_test[i].name, list_test[i].dateLivraison, list_test[i].quantiteElement, false, true, list_test[i].typeOperation, list_test[i].recouvrement);
                mainWindow.UC_Disp_Week.SPDisplayDay_samedi.Children.Add(ucfw_3);

                UC_Fiche_week ucfnp = new UC_Fiche_week(list_test[i].id, list_test[i].name, list_test[i].dateLivraison, list_test[i].quantiteElement, false, true, list_test[i].typeOperation, list_test[i].recouvrement);
                mainWindow.STFichesNotPlaced.Children.Add(ucfnp);*/
            }
            mainWindow.UC_Disp_Day.RefreshDayToDisplay(dateToDisplay);
            
            nbList = mainWindow.UC_Disp_Day.StackPanelDisplayDay.Children.Count;
            mainWindow.UC_Disp_Day.StackPanelDisplayDay.Height = nbList * 40;

            nbList = ucDispWeek.SPDisplayDay_lundi.Children.Count;
            ucDispWeek.SPDisplayDay_lundi.Height = nbList * 70;

            nbList = ucDispWeek.SPDisplayDay_mardi.Children.Count;
            ucDispWeek.SPDisplayDay_mardi.Height = nbList * 70;

            nbList = ucDispWeek.SPDisplayDay_mercredi.Children.Count;
            ucDispWeek.SPDisplayDay_mercredi.Height = nbList * 70;

            nbList = mainWindow.STFichesNotPlaced.Children.Count;
            mainWindow.STFichesNotPlaced.Height = nbList * 70;
        }

        public void EraseDataFichierSauvegarde()
        {
            listeFiches.Clear();
            fichierSauvegarde.EraseData();
        }

        //TODO modif valeurs d'une fiche

        /**
         * @brief Modifier le nom
         * */

        /**
         * @brief Modifier l'id? probablement interdit 
         * */

        /**
         * @brief Modification quantité éléments
         * */

        /**
         * @brief Modifier le temps de création de l'élement
         * */

        /**
         * @brief Modifier la machine de l'élément
         * */

        /**
         * @brief Modifier la date de début de fabrication + heure
         * */

        /**
         * @brief Modifier la date de livraison? privé
         * */

        /**
         * @brief Modifier le type de fabrication? privé
         * */

        /**
         * @brief Modifier le type de recouvrement ? privé
         * */

        /**
         * @brief Modification de l'état du retard de placement


        /**
         * @brief Modifier le texte de la fiche
         * */

        /**
         * @brief Modifier toute une fiche
         * */
    }

}
