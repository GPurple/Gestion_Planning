using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionPlanning.src
{
    public class FicheDayMonth
    {
        public int nbFiches = 0;
        public DateTime dateDay = new DateTime();
        public bool attention_retard = false;
        public bool alerte_retard = false;
        public List<TypeOperation> listeOperation = new List<TypeOperation>();
        public bool reco = false;
        
        public FicheDayMonth() { }
    }
    public class ListeFichesMonth
    {
        //Faire un tableau de 7x5 de typer ficheDayMonth
        public FicheDayMonth[,] tabMonthFicheDay = new FicheDayMonth[5, 7];

        public ListeFichesMonth()
        {
            for (int j = 0; j < 5; j++)
            {
                for (int i = 0; i < 7; i++)
                {
                    tabMonthFicheDay[j, i] = new FicheDayMonth();
                }
            }
        }

        public void ProcessListCurrentMonth(List<Fiche> listePlacees, DateTime dateFirstDay)
        {
            DayOfWeek dayOfWeek = dateFirstDay.DayOfWeek;
            int dayInMonth = 0;
            dayInMonth = (int)dayOfWeek;
            dayInMonth--;
            if (dayInMonth < 0) dayInMonth = 6;

            dayInMonth = - dayInMonth;
            
            //TODO recalculer dayInMonth en fonction du dayOfWeek
            for (int j = 0; j < 5; j++)
            {
                for (int i = 0; i < 7; i++)
                {
                    tabMonthFicheDay[j, i].dateDay = new DateTime(dateFirstDay.AddDays(dayInMonth).Year,
                                                                dateFirstDay.AddDays(dayInMonth).Month,
                                                                dateFirstDay.AddDays(dayInMonth).Day);
                    tabMonthFicheDay[j, i].nbFiches = 0;
                    tabMonthFicheDay[j, i].alerte_retard = false;
                    tabMonthFicheDay[j, i].attention_retard = false;
                    tabMonthFicheDay[j, i].listeOperation.Clear();
                    tabMonthFicheDay[j, i].reco = false;

                    foreach (Fiche fiche in listePlacees)
                    {
                        //si la fiche est à placer ce jour là
                        if (dateFirstDay.AddDays(dayInMonth).CompareTo(fiche.dateDebutFabrication) == 0 )
                        {
                            //TODO ajouter infos utiles dans tabMonthFicheDay[j,i]
                            tabMonthFicheDay[j, i].nbFiches++;
                            if(fiche.alerteRetard == true)
                            {
                                tabMonthFicheDay[j, i].alerte_retard = true;
                            }
                            if (fiche.attentionRetard == true)
                            {
                                tabMonthFicheDay[j, i].attention_retard = true;
                            }
                            if(!tabMonthFicheDay[j, i].listeOperation.Contains(fiche.typeOperation))
                            {
                                tabMonthFicheDay[j, i].listeOperation.Add(fiche.typeOperation);
                            }
                            if(fiche.recouvrement == true)
                            {
                                tabMonthFicheDay[j, i].reco = true;
                            }
                        }
                    }
                    dayInMonth++;
                }
            }
            dayInMonth = dayInMonth;
        }
    }
}
