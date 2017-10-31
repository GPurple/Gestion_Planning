using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionPlanning.src
{
    class TODO
    {

        //choisir couleur : 
        //écran paramétrage des couleurs: créer jusqu'à 10 types
        //btn ajouter fiche(limiter à 10 fiches)
            //définir nom fiche
            //choix couleur dans panel 
        //btn modifier
        //une uc pour chaque type
        //10 couleurs déjà défini

        //fiche: sauvegarde nom type?
        //
        //fichier sauvegarde: sauvegarder les types dans savedata
        //list<typeRevet> (color,name)
        //création fiche: choix d'un type dans la liste dispo
        //affichage d'une combo box à l'ouverture de la fiche à partir des types connus
        //affichage de la couleur d'une fiche en fonction du type de la fiche et des couleurs connues
        //si le nom ne correspond pas, afficher couleur blanche

        //TODO
        //faire un affichage par machine
        //option -> personnaliser couleurs et donner un nom
        //choisir id creation fiche?
        //calculer le temps sur une machine et prévenir en cas de problème
        //réactualiser les données toutes les 15secondes
        //afficher les listes non placées comme pour une machine? ou les fiches sans date de livraison
        //placement automatique au chargement des données
        //retirer du placement automatique
        //modifier le menu pour un meilleur affichage (en haut de l'écran)

        //rendre plus beau

        //Tester plusieurs lancements en parallèle

        //Fait:
        //Faire chargement depuis fichier xcel 
        //affichage en plein écran
        //display fiche jour / semaine
        //bouton afficher jour/semaine/mois
        //affichage des bonnes listes
        //affichage des listes jour
        //affichage des listes semaine
        //écran modification fiche
        //configurer la preise en compte des weeks end pour recouvrement et retard?
        //Valider les fiches !!! -> ne pas les garder dans liste fiche, ne pas les afficher
        //gérer le rafraichissement des données -> sauvegarde quand on veut 
        //tri month : ok - afficher mois : a faire
        //gestion identifications
        //gérer path fichiers
        //ajouter clique droit déplacement horaire/modification fiche/validation fiche(+ écran conbfirmation)
        //Ajouter identification utilisateur et ecrire dans le fichier les derniers à avoir modifier le fichier
        //Ajouter les différentes gestions d'erreurs
        //tout fermer à fermeture fenêtre
        //afficher bon premier jour de la semaine 
        //corriger problème modification du path
        //affichage par machine -> String et non int 
        //choisir heure 8:01 ou 8h1 est différent
        //pouvoir créer une nouvelle fiche -> choisir id?

        //a présenter
        // tous les cas de tests
        //tous les problèmes évités
        //toutes les fonctionnalités

        //fonctionnalités:
        //placement auto: Si date fab tombe sur un week end, elle est déplacée en conséquence
        //effacement données dans fichier sauvegarde après 1 mois
        //bouton chargement des données depuis Xcel et fichier sauvegarde
        //bouton sauvegarde données
        //bouton placement auto
        //bouton placement auto des fiches pas encore faites
        //les fiches sont effacées 30 jours après leur date de livraison si elles sont validées
        //pendant modif fiche, si date livraison à 0 -> retrait du planning
        //pas de placement avant date actuelle(date jour ok)
        //Différentes fonctions de trie et recherche des listes + boutons
        //sauvegarde seulement lors de sauvegarde et placement auto

    }
}
