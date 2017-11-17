using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace GestionPlanning.src
{
    
    //Le type d'opération
    public enum TypeOperation { na, fabrication, aiguisage };

    //Retard placement (1 = pas de retard, 2 = date prod placée après 2 jours, 3 = date prod placée après date livraison)
    public enum RetardPlacement {na, aucun, attentionRetard, alerteRetard }

    //[Serializable]
    [XmlType("Fiche")]
    [XmlInclude(typeof(DateTime))]
    public class Fiche
    {
        //L'identifiant de la fiche
        public int id;       
        
        //Le nom de l'entreprise
        public String name;

        //Le temps de fabrication en minutes
        public int tempsFabrication = 0;

        //Le type d'opération
        public TypeOperation typeOperation = TypeOperation.na;

        //Le recouvrement
        public TypeColor recouvrement = null;

        //Quantité élement
        public int quantiteElement = 0;

        //Le numéro de machine (-1 = non défini)
        public String machine = "NA";

        //Datedébut fabrication 
        public DateTime dateDebutFabrication = new DateTime();

        //Date rendu
        public DateTime dateLivraison = new DateTime();

        //Retard livraison
        //public RetardPlacement retardPlacement = RetardPlacement.na;

        //Le texte de description de la fiche
        public String textDescription = null;

        //Si la date de livraison est dépassée
        public Boolean alerteRetard = false;

        //Si la date de livraison est dans moins de 2 jours
        public Boolean attentionRetard = false;

        //Si la fiche est validée(déja fabriquée)
        public Boolean check = false;
        
        /**
         * @brief Creation d'une nouvelle fiche
         * @note none 
         * @param none
         * */
        public Fiche(){}

        /**
        * @brief Création d'une nouvelle fiche
        * @note none 
        * @param name
        * @param id
        * @param time Le temps de fabrication
        * @param machine Le numéro de machine
        * @param dateBeginning La date de début de fabrication + heure
        * @param dateLivraison
        * @param enum typeOperation
        * @param boolean recouvrement
        * @param enum retardPlacement (aucun/avant 2jours/ apres date rendu)
        * @param text
        * */
        public Fiche(String newName, int newId, int newTempsFabrication, DateTime newDateLivraison, TypeOperation typeOperation, TypeColor recouvrement)
        {
            //Les valeurs non définies sont à -1 ou null
            this.name = String.Copy(newName);
            this.id = newId;
            this.tempsFabrication = newTempsFabrication;
            this.dateLivraison = newDateLivraison;
            this.typeOperation = typeOperation;
            this.recouvrement = new TypeColor(recouvrement.name,recouvrement.color);
        }
        
        public Fiche(Fiche newFiche)
        {
            this.name = String.Copy(newFiche.name);
            this.id = newFiche.id;
            this.tempsFabrication = newFiche.tempsFabrication;
            this.dateLivraison = newFiche.dateLivraison;
            this.typeOperation = newFiche.typeOperation;
            this.quantiteElement = newFiche.quantiteElement;
            this.recouvrement = newFiche.recouvrement;
            this.dateDebutFabrication = newFiche.dateDebutFabrication;
            this.textDescription = newFiche.textDescription;
            this.attentionRetard = newFiche.attentionRetard;
            this.alerteRetard = newFiche.alerteRetard;
            this.check = newFiche.check;
            this.machine = newFiche.machine;
        }

        // Default comparer for Part type.
        public int CompareTo(Fiche compareFiche)
        {
            // A null value means that this object is greater.
            if (compareFiche == null)
                return 1;

            else
                return this.id.CompareTo(compareFiche.id);
        }
        public override int GetHashCode()
        {
            return id;
        }
        public bool Equals(Fiche other)
        {
            if (other == null) return false;
            return (this.id.Equals(other.id));
        }

        /**
         * @brief Activer le retard
         * @param retardPlacement Le retard de placement (aucun, attention, erreur)
         * */
        public void SetRetard(RetardPlacement newRetardPlacement)
        {
            //this.retardPlacement = newRetardPlacement;
        }

        /**
         * @brief Modifier heure et date de début de fabrication
         * @param newDate La nouvelle date
         * */
        public void ModifyHourBeginning(DateTime newDate)
        {
            this.dateDebutFabrication = newDate;
        }

        /**
         * @brief Modifier quantité d'élements
         * @param newNbr nombre d'élements
         * */
        public void ModifyNbrElements(int newQuantiteElements)
        {
            this.quantiteElement = newQuantiteElements;
        }

        /**
         * @brief Modifier le temps de fabrication
         * @param newTime en minutes
         * */
        public void ModifyTimeOperation(int newTime)
        {
            this.tempsFabrication = newTime;
        }

        /**
         * @brief Modifier le texte de la fiche
         * @param newText Le nouveau texte
         * */
        public void ModifyTexte(String newText)
        {
            this.textDescription = String.Copy(newText);
        }


    }
}
