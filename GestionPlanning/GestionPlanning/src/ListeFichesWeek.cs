using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionPlanning.src
{
    public class ListeFichesWeek
    {
        public List<Fiche> listeLundi = new List<Fiche>();
        public List<Fiche> listeMardi = new List<Fiche>();
        public List<Fiche> listeMercredi = new List<Fiche>();
        public List<Fiche> listeJeudi = new List<Fiche>();
        public List<Fiche> listeVendredi = new List<Fiche>();
        public List<Fiche> listeSamedi = new List<Fiche>();
        public List<Fiche> listeDimanche = new List<Fiche>();

        public ListeFichesWeek()
        {

        }
        
        public void ProcessListCurrentWeek(List<Fiche> listePlacees, DateTime dateFirstDay)
        {
            ProcessListWeekForDay(this.listeLundi, listePlacees, dateFirstDay,0);
            ProcessListWeekForDay(this.listeMardi, listePlacees, dateFirstDay,1);
            ProcessListWeekForDay(this.listeMercredi, listePlacees, dateFirstDay,2);
            ProcessListWeekForDay(this.listeJeudi, listePlacees, dateFirstDay,3);
            ProcessListWeekForDay(this.listeVendredi, listePlacees, dateFirstDay,4);
            ProcessListWeekForDay(this.listeSamedi, listePlacees, dateFirstDay,5);
            ProcessListWeekForDay(this.listeDimanche, listePlacees, dateFirstDay,6);
        }

        public void ProcessListWeekForDay(List<Fiche> listeDay, List<Fiche> listePlacees, DateTime dateDay,int numDay)
        {
            dateDay = dateDay.AddDays(numDay);
            listeDay.Clear();
            foreach (Fiche fiche in listePlacees)
            {
                if (Brain.Instance.VerifProcessFiche(fiche) > 0)
                {
                    Brain.Instance.FindAlerteListeInFor(fiche);

                    if (fiche.dateDebutFabrication.Year == dateDay.Year
                        && fiche.dateDebutFabrication.Month == dateDay.Month
                        && fiche.dateDebutFabrication.Day == dateDay.Day)
                    {
                        listeDay.Add(fiche);
                    }
                }
            }
        }

    }
}
