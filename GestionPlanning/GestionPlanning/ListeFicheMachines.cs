using GestionPlanning.src;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionPlanning
{
    public class ListeMachine
    {
        public String nameMachine;
        public List<Fiche> listeFiches = new List<Fiche>();

        public ListeMachine(String newNameMachine)
        {
            this.nameMachine = newNameMachine;
        }
    }

    public class ListeFicheMachines
    {
        public List<ListeMachine> listeFichesByMachines = new List<ListeMachine>();

       

        public ListeFicheMachines()
        {

        }

        public void ProcessListeFicheMachines(List<Fiche> listeFiches)
        {
            bool exists = false;

            listeFichesByMachines.Clear();

            foreach (Fiche fiche in listeFiches)
            {
                exists = false;
                foreach (ListeMachine machine in listeFichesByMachines)
                {
                    if(machine.nameMachine == fiche.machine)
                    {
                        if (Brain.Instance.VerifProcessFiche(fiche) > 0)
                        {
                            Brain.Instance.FindAlerteListeInFor(fiche);

                            machine.listeFiches.Add(new Fiche(fiche));
                            exists = true;
                        }
                    }
                }
                //si la fiche n'est pas placée on créer une machine et on place la fiche
                if(!exists)
                {
                    listeFichesByMachines.Add(new ListeMachine(fiche.machine));
                    foreach (ListeMachine machine in listeFichesByMachines)
                    {
                        if (machine.nameMachine == fiche.machine)
                        {
                            if (Brain.Instance.VerifProcessFiche(fiche) > 0)
                            {
                                Brain.Instance.FindAlerteListeInFor(fiche);

                                machine.listeFiches.Add(new Fiche(fiche));
                            }
                        }
                    }
                }
            }
            //tri, placer na en fin de liste
            ListeMachine listeNA = new ListeMachine("na");
            List<ListeMachine> listeTmp = new List<ListeMachine>();

            foreach (ListeMachine machine in listeFichesByMachines)
            {
                if (machine.nameMachine == "na")
                {
                    listeNA = machine;
                }
                else
                {
                    listeTmp.Add(machine);
                }
            }
            listeFichesByMachines.Clear();
            foreach (ListeMachine machine in listeTmp)
            {
                listeFichesByMachines.Add(machine);
            }
            listeFichesByMachines.Add(listeNA);

        }

    }
}
