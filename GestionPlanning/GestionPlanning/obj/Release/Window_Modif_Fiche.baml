   M S B A M L   `   `   `  ���� J  FGestionPlanning, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null1clr-namespace:GestionPlanningGestionPlanning  (    "GestionPlanning.Window_Modif_Fiche   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     /localclr-namespace:GestionPlanning       � Title$  Window_Modif_Fiche��$	��590��$	��400��.��� .+��� $
��Left=�$��
156,10,0,0q�$
��Wrap=�$	��Top=��� $�M���� $�odification fiche ���� $
��Left=�$��
31,178,0,0q�$
��Wrap=�$	��Top=��� $�Date livraison���� $� :���� $
��Left=�$��
31,212,0,0q�$
��Wrap=�$	��Top=��� $�Date fabrication���� $� :���� $
��Left=�$��
29,322,0,0q�$
��Wrap=�$	��Top=��� $�Quantité élements���� $� :���� $
��Left=�$��
41,402,0,0q�$
��Wrap=�$��Note : ��$	��Top=��� $
��Left=�$��
31,246,0,0q�$
��Wrap=�$	��Top=��� $�Heure fabrication���� $� :���� $
��Left=�$��
33,360,0,0q�$
��Wrap=�$	��Top=��� $�Numéro machine���� $� :���� $
��Left=�$��
29,290,0,0q�$
��Wrap=�$	��Top=��� $�Temps���� $� fabrication���� $�(min) :���� $
��Left=�$��
156,10,0,0q�$
��Wrap=�$��modification fiche ��$	��Top=��� -    ��Name$ textId��$
��Left=�$��	36,35,0,0q�$
��Wrap=�$��	ID : 1234��$	��Top=��� -   $ textDateLivraison��$
��Left=�$��
107,35,0,0q�$
��Wrap=�$	��Top=��� $�Date livraison���� $	� : ���� $� 24/12/2017���� -   $ textName��$
��Left=�$��
276,35,0,0q�$
��Wrap=�$��	Nom : AOS��$	��Top=��� $��Type d'opération��$
��Left=�$��59��$��	24,64,0,0q�$	��Top=�$	��262��.��� $
��Left=�$��37��$	��Top=�$	��239��.+�	� -    	�Name$ radioButtonOpFabrication��$��Fabrication��$
��Left=�$	��Top=�$��	10,10,0,0q�	� -   $ RadioButtonOpAffutage��$��Affutage��$
��Left=�$��
104,10,0,0q�$	��Top=�	� -   $ RadioButtonOpNA��$��NA��$
��Left=�$��
185,10,0,0q�$	��Top=��� -    ��Name$ textBoxDateLivraison��$
��Left=�$��22��$��119,178,0,0q� �� TextWrapping$
 Wrap=�$��TextBox��$	��Top=�$	��120���� -   $ textBoxDateFabrication��$
��Left=�$��24��$��129,210,0,0q�$
 Wrap=�$��TextBox��$	��Top=�$	��120���� -	   $ textBoxHeureFabrication��$
��Left=�$��24��$��129,244,0,0q�$
 Wrap=�$��TextBox��$	��Top=�$	��120���� -
   $ textBoxTempsFabrication��$
��Left=�$��24��$��163,282,0,0q�$
 Wrap=�$��TextBox��$	��Top=�$	��120���� -   $ 
TextBoxQty��$
��Left=�$��22��$��139,322,0,0q�$
 Wrap=�$��TextBox��$	��Top=�$	��120���� -   $ TextBoxNumMachine��$
��Left=�$��24��$��139,358,0,0q�$
 Wrap=�$��TextBox��$	��Top=�$��78���� -   $ textBoxTextFiche��$
��Left=�$��78��$��
41,422,0,0q�$
 Wrap=�$��TextBox��$	��Top=�$	��262���� -   $��Valider��$
��Left=�$��105,512,0,0q�$	��Top=�$��76���� -   $��Annuler��$
��Left=�$��259,512,0,0q�$	��Top=�$��74���� -    ��Name$ imageAttention_dateLiv��$
��Left=�$��34��$��243,172,0,0q�$	��Top=�$��30��$ ��Images/Icone_Attention.png���� -   $ imageAttention_dateFab��$
��Left=�$��34��$��253,206,0,0q�$	��Top=�$��32��$ ��Images/Icone_Attention.png���� -   $ imageAttention_heureFab��$
��Left=�$��34��$��253,240,0,0q�$	��Top=�$��32��$ ��Images/Icone_Attention.png���� -   $ imageAttention_TempsFab��$
��Left=�$��34��$��283,278,0,0q�$	��Top=�$��30��$ ��Images/Icone_Attention.png���� -   $ imageAttention_QtyEl��$
��Left=�$��34��$��259,318,0,0q�$	��Top=�$��30��$ ��Images/Icone_Attention.png���� -   $ imageAttention_NumMach��$
��Left=�$��34��$��217,350,0,0q�$	��Top=�$��30��$ ��Images/Icone_Attention.png���� -   $ imageAttention_SizeText��$
��Left=�$��34��$��
81,388,0,0q�$	��Top=�$��32��$ ��Images/Icone_Attention.png���� -    ��Name$ comboBoxRevetement��$
��Left=�$��107,138,0,0q�$	��Top=�$	��120���� $
��Left=�$��
29,138,0,0q�$
��Wrap=�$��Revêtement: ��$	��Top=�