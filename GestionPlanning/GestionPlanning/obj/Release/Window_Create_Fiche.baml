   M S B A M L   `   `   `  ���� J  FGestionPlanning, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null1clr-namespace:GestionPlanningGestionPlanning  )    #GestionPlanning.Window_Create_Fiche   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     /localclr-namespace:GestionPlanning       � Title$  Window_Create_Fiche��$	��645��$	��400��.��� .+��� $
��Left=�$��
156,10,0,0q�$
��Wrap=�$	��Top=��� $�	Création���� $� fiche ���� $
��Left=�$��
33,210,0,0q�$
��Wrap=�$	��Top=��� $�Date livraison���� $� :���� $
��Left=�$��
33,244,0,0q�$
��Wrap=�$	��Top=��� $�Date fabrication���� $� :���� $
��Left=�$��
33,356,0,0q�$
��Wrap=�$	��Top=��� $�Quantité élements���� $� :���� $
��Left=�$��
33,434,0,0q�$
��Wrap=�$��Note : ��$	��Top=��� $
��Left=�$��
33,392,0,0q�$
��Wrap=�$	��Top=��� $�N���� $�om���� $� machine���� $� :���� $
��Left=�$��
33,316,0,0q�$
��Wrap=�$	��Top=��� $�Temps���� $� fabrication���� $�(min) :���� $
��Left=�$��
33,278,0,0q�$
��Wrap=�$	��Top=��� $�Heure fabrication���� $� :���� $
��Left=�$��	37,73,0,0q�$
��Wrap=�$	��Top=��� $	�Nom���� $� :���� -    ��Name$ textId_Copy��$
��Left=�$��	38,38,0,0q�$
��Wrap=�$��ID : ��$	��Top=��� -    ��Name$ 	textBoxID��$
��Left=�$��22��$��	59,38,0,0q� �� TextWrapping$
 Wrap=�$��id��$	��Top=�$	��120���� -   $ textBoxName��$
��Left=�$��22��$��	83,72,0,0q�$
 Wrap=�$
��nom ��$	��Top=�$	��120���� $��Type d'opération��$
��Left=�$��59��$��
28,109,0,0q�$	��Top=�$	��262��.��� $
��Left=�$��37��$	��Top=�$	��239��.+�	� -    	�Name$ radioButtonOpFabrication��$��Fabrication��$
��Left=�$	��Top=�$��	10,10,0,0q�	� -   $ RadioButtonOpAffutage��$��Affutage��$
��Left=�$��
104,10,0,0q�$	��Top=�	� -   $ RadioButtonOpNA��$��NA��$
��Left=�$��
185,10,0,0q�$	��Top=��� -   $ textBoxDateLivraison��$
��Left=�$��22��$��121,210,0,0q�$
 Wrap=�$��TextBox��$	��Top=�$	��120���� -   $ textBoxDateFabrication��$
��Left=�$��24��$��131,242,0,0q�$
 Wrap=�$��TextBox��$	��Top=�$	��120���� -	   $ textBoxHeureFabrication��$
��Left=�$��24��$��131,276,0,0q�$
 Wrap=�$	��0:0��$	��Top=�$	��120���� -
   $ textBoxTempsFabrication��$
��Left=�$��24��$��165,314,0,0q�$
 Wrap=�$��temps��$	��Top=�$	��120���� -   $ 
TextBoxQty��$
��Left=�$��22��$��141,354,0,0q�$
 Wrap=�$
��qté��$	��Top=�$	��120���� -   $ textBoxNumMachine��$
��Left=�$��24��$��121,390,0,0q�$
 Wrap=�$	��nom��$	��Top=�$	��120���� -   $ textBoxTextFiche��$
��Left=�$��78��$��
33,454,0,0q�$
 Wrap=�$
��text��$	��Top=�$	��272���� -   $��Valider��$
��Left=�$��107,544,0,0q�$	��Top=�$��76���� -   $��Annuler��$
��Left=�$��261,544,0,0q�$	��Top=�$��74���� -    ��Name$ imageAttention_dateLiv��$
��Left=�$��34��$��245,204,0,0q�$	��Top=�$��30��$ ��Images/Icone_Attention.png���� -   $ imageAttention_dateFab��$
��Left=�$��34��$��255,238,0,0q�$	��Top=�$��32��$ ��Images/Icone_Attention.png���� -   $ imageAttention_heureFab��$
��Left=�$��34��$��255,272,0,0q�$	��Top=�$��32��$ ��Images/Icone_Attention.png���� -   $ imageAttention_TempsFab��$
��Left=�$��34��$��285,310,0,0q�$	��Top=�$��30��$ ��Images/Icone_Attention.png���� -   $ imageAttention_QtyEl��$
��Left=�$��34��$��261,350,0,0q�$	��Top=�$��30��$ ��Images/Icone_Attention.png���� -   $ imageAttention_NumMach��$
��Left=�$��34��$��204,390,0,0q�$	��Top=�$��30��$ ��Images/Icone_Attention.png���� -   $ imageAttention_SizeText��$
��Left=�$��34��$��
83,420,0,0q�$	��Top=�$��32��$ ��Images/Icone_Attention.png���� -   $ imageAttention_ID��$
��Left=�$��34��$��
184,33,0,0q�$	��Top=�$��30��$ ��Images/Icone_Attention.png���� $
��Left=�$��
33,184,0,0q�$
��Wrap=�$��Revêtement :��$	��Top=��� -    ��Name$ comboBoxRevetement��$
��Left=�$��110,178,0,0q�$	��Top=�$	��120��