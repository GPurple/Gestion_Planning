   M S B A M L   `   `   `  ���� J  FGestionPlanning, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null1clr-namespace:GestionPlanningGestionPlanning  #    GestionPlanning.UC_Fiche_week   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     /localclr-namespace:GestionPlanning     $	��130�����	#FF2E2E2E$	��145��.���   � ColumnDefinitions  �� $	��48* ��� $	��17* �.+��� -    ��Name$ rectangleLeft_op�����	#FFF4F4F5$��64��$��0��$
��Left=��� -   $ rectangleRight_rec�����	#FFF4F4F5$
��Left=�$��66��$��64,0,0,0q�$��0��$��2���� -    ��Name$ textIDficheWeek��$
��Left=�$��5,3,0,0q�$
��Wrap=�$��ID : ��$	��Top=�$��91���� -   $ textNameFicheWeek��$
��Left=�$��5,19,0,0q�$
��Wrap=�$��Nom : ��$	��Top=�$	��122��$��2��$��32���� -   $ textDateFicheWeek��$
��Left=�$��5,51,0,0q�$
��Wrap=�$��Livraison : ��$	��Top=�$	��122��$��2���� -   $ textQtyFicheWeek��$
��Left=�$��5,67,0,0q�$
��Wrap=�$��Quantité : ��$	��Top=�$	��122��$��2���� -    ��Name$ image_alerte��$
��Left=�$��30��$��	3,-1,-2,0q�$	��Top=�$��33��$��1��$8��2/GestionPlanning;component/Images/Icone_Alerte.png���� -   $ image_warning��$
��Left=�$��30��$��3,-3,0,0q�$	��Top=�$��30�� J� RenderTransformOrigin$ 0.533,0.404&�$��1��$;��5/GestionPlanning;component/Images/Icone_Attention.png���� -	   $ textHeureFabFicheWeek��$
��Left=�$��5,83,0,0q�$
��Wrap=�$��
Heure fab:��$	��Top=�$	��122��$��2���� -
   $ textTempsFabFicheWeek��$
��Left=�$��5,99,0,0q�$
��Wrap=�$	��Top=�$	��122��$��2���� $�Temps���� $� fab:���� ���	#FF232323$
��Left=�$��1��$��	0,144,0,0q�$	��Top=�$	��130��$��2���� -   $��Center=�$��
94,119,0,0q�$	��Top=�$��36��$��25�����	#FF303030$��2��.���� $
��Left=�$��22��$	��Top=�$��22��$7��1/GestionPlanning;component/Images/Icone_Modif.png���� -   $��Center=�$��46,119,14,0q�$	��Top=�$��36��$��25�����	#FF303030.���� $��25��$��36��$A��;/GestionPlanning;component/Images/Icone_ValidationFiche.png���� -   $��Center=�$��
0,119,60,0q�$	��Top=�$��36��$��25�����	#FF303030.���� $��22��$��26��$;��5/GestionPlanning;component/Images/Icone_Placement.png��