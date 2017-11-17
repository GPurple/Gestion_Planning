using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionPlanning.src
{
    class TODO
    {

        //temps limite par jour et par temps de fabrication et machine
        //placement auto, si dépassement de temps sur une machine sur une journée -> alerte : comment?
        //création d'une fiche, si trop de temps sur une journée -> indication de l'alerte ; mais autorisation?
        //modification d'une fiche, comme pour l'alerte
        //au chargement, voir si problème de temps

        //l'alerte est indiquée par un message après une modif? ->  afficher messageBox
        //alerte empêche de modifier la fiche?
        //l'alerte est indiquée dans machine? sur un jour? -> afficher messageBox si affichage du jour ou filtre de la machine
        //
        


        //TODO
        //tester une dernière fois le path
        //gérer le prblème avec l'ID 0 ou trouver une solution...
        //donner un id aléatoire?

        //ajouter fenetre modif temps prod max journée
        //refaire des données complètes pour présentation

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
        //option -> personnaliser couleurs et donner un nom
        //faire un affichage par machine
        //afficher les listes non placées comme pour une machine?
        //calculer le temps sur une machine et prévenir en cas de problème
        //afficher quantité dans fiche machine
        //choisir id creation fiche?
        //afficher les fiches sans date de livraison
        //afficher machine pour day, week et simple

        //faire code démo


        //modifier le menu pour un meilleur affichage (en haut de l'écran)
        //rendre plus beau

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
