   M S B A M L   `   `   `  ���� J  FGestionPlanning, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null1clr-namespace:GestionPlanningGestionPlanning  $    GestionPlanning.UC_modif_fiche   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     /localclr-namespace:GestionPlanning     $	��595��$	��420��.��� ���	#FFD4D4D4.+��� $
��Left=�$	��594��
�������$	��Top=�$	��421��$��3��}�. �� $
��Left=�$	��589��
���   �$	��Top=�$	��415��$��3��$��3,3,0,0q��� $
��Left=�$��
156,10,0,0q�$
��Wrap=�$��modification fiche ��$	��Top=��� -     ��Name$  textId��$
��Left=�$��	36,35,0,0q�$
��Wrap=�$��	ID : 1234��$	��Top=��� $
��Left=�$��
24,198,0,0q�$
��Wrap=�$	��Top=��� $�Date livraison���� $� :���� $
��Left=�$��
24,232,0,0q�$
��Wrap=�$	��Top=��� $�Date fabrication���� $� :���� $
��Left=�$��
22,342,0,0q�$
��Wrap=�$	��Top=��� $�Quantité élements���� $� :���� -    ��Name$ textBoxDateLivraison��$
��Left=�$��22��$��112,198,0,0q� �� TextWrapping$
 Wrap=�$��TextBox��$	��Top=�$	��120���� -   $ textBoxDateFabrication��$
��Left=�$��24��$��122,230,0,0q�$
 Wrap=�$��TextBox��$	��Top=�$	��120���� -   $ 
TextBoxQty��$
��Left=�$��22��$��132,342,0,0q�$
 Wrap=�$��TextBox��$	��Top=�$	��120���� $
��Left=�$��
34,422,0,0q�$
��Wrap=�$��Note : ��$	��Top=��� -   $ textBoxTextFiche��$
��Left=�$��78��$��
34,442,0,0q�$
 Wrap=�$��TextBox��$	��Top=�$	��262���� -   $��Valider��$
��Left=�$��
98,532,0,0q�$	��Top=�$��76���� -   $��Annuler��$
��Left=�$��252,532,0,0q�$	��Top=�$��74���� $
��Left=�$��
24,266,0,0q�$
��Wrap=�$	��Top=��� $�Heure fabrication���� $� :���� -   $ textBoxHeureFabrication��$
��Left=�$��24��$��122,264,0,0q�$
 Wrap=�$��TextBox��$	��Top=�$	��120���� $
��Left=�$��
26,380,0,0q�$
��Wrap=�$	��Top=��� $�Numéro machine���� $� :���� -	   $ TextBoxNumMachine��$
��Left=�$��24��$��132,378,0,0q�$
 Wrap=�$��TextBox��$	��Top=�$��78���� $
��Left=�$��
22,310,0,0q�$
��Wrap=�$	��Top=��� $�Temps���� $� fabrication���� $�(min) :���� -
   $ textBoxTempsFabrication��$
��Left=�$��24��$��156,302,0,0q�$
 Wrap=�$��TextBox��$	��Top=�$	��120���� -   $  textDateLivraison��$
��Left=�$��
107,35,0,0q�$
��Wrap=�$	��Top=��� $�Date livraison���� $	� : ���� $� 24/12/2017���� -   $  textName��$
��Left=�$��
276,35,0,0q�$
��Wrap=�$��	Nom : AOS��$	��Top=��� -    ��Name$ imageAttention_dateLiv��$
��Left=�$��34��$��236,192,0,0q�$	��Top=�$��30��$;��5/GestionPlanning;component/Images/Icone_Attention.png���� -   $ imageAttention_dateFab��$
��Left=�$��34��$��246,226,0,0q�$	��Top=�$��32��$;��5/GestionPlanning;component/Images/Icone_Attention.png���� -   $ imageAttention_heureFab��$
��Left=�$��34��$��246,260,0,0q�$	��Top=�$��32��$;��5/GestionPlanning;component/Images/Icone_Attention.png���� -   $ imageAttention_TempsFab��$
��Left=�$��34��$��276,298,0,0q�$	��Top=�$��30��$;��5/GestionPlanning;component/Images/Icone_Attention.png���� -   $ imageAttention_QtyEl��$
��Left=�$��34��$��252,338,0,0q�$	��Top=�$��30��$;��5/GestionPlanning;component/Images/Icone_Attention.png���� -   $ imageAttention_NumMach��$
��Left=�$��34��$��210,370,0,0q�$	��Top=�$��30��$;��5/GestionPlanning;component/Images/Icone_Attention.png���� -   $ imageAttention_SizeText��$
��Left=�$��34��$��
74,408,0,0q�$	��Top=�$��32��$;��5/GestionPlanning;component/Images/Icone_Attention.png���� $��Type d'opération��$
��Left=�$��59��$��	19,64,0,0q�$	��Top=�$	��262��.��� $
��Left=�$��37��$	��Top=�$	��239��.+�	� -    	�Name$ radioButtonOpFabrication��$��Fabrication��$
��Left=�$	��Top=�$��	10,10,0,0q�	� -   $ RadioButtonOpAffutage��$��Affutage��$
��Left=�$��
104,10,0,0q�$	��Top=�	� -   $ RadioButtonOpNA��$��NA��$
��Left=�$��
185,10,0,0q�$	��Top=��� $��Recouvrement��$
��Left=�$��52��$��
19,130,0,0q�$	��Top=�$	��145�� J� RenderTransformOrigin$ 0.5,0.5&�z�V� .~��� ��  �� AngleX$ -0.562Q��� T�  T� X$ -0.324Q�� $
��Left=�$��22��$��
22,145,0,0q�$	��Top=�$	��244��.+�	� -   $ RadioButtonRecYes��$	��Oui��$
��Left=�$��
10,10,0,-3q�$	��Top=�	� -   $ RadioButtonRecNo��$	��Non��$
��Left=�$��
79,10,0,-3q�$	��Top=�