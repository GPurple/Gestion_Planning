   M S B A M L   `   `   `  ����J  FGestionPlanning, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null1clr-namespace:GestionPlanningGestionPlanning  5      #    GestionPlanning.UC_Fiche_week   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      /localclr-namespace:GestionPlanning     5      $	��130��5      ���	#FF2E2E2E$	��145��6B   .��5      �   � ColumnDefinitions  5	   
   �� 5
      $	��48* �6   �� 5      $	��17* �6   .+�5   
   �� -   5         ��Name$ rectangleLeft_op��5      ���	#FFF4F4F5$��64��6?   $��0��6J   $
��Left=�6^   �� 5   
   -   5        $ rectangleRight_rec��5      ���	#FFF4F4F5$
��Left=�6A   $��66��6\   $��64,0,0,0q�6g   $��0��6y   $��2��6�   �� 5   
   -   5         ��Name$ textIDficheWeek��5      $
��Left=�6-   $��5,3,0,0q�6H   $
��Wrap=�6Y   $��ID : ��6m   $	��Top=�6z   $��91��6�   �� 5   
   -   5        $ textNameFicheWeek��5      $
��Left=�6/   $��5,19,0,0q�6J   $
��Wrap=�6\   $��Nom : ��6p   $	��Top=�6~   $	��122��6�   $��2��6�   $��32��6�   �� 5   
   -   5        $ textDateFicheWeek��5      $
��Left=�6/   $��5,51,0,0q�6J   $
��Wrap=�6\   $��Livraison : ��6p   $	��Top=�6�   $	��122��6�   $��2��6�   �� 5   
   -   5        $ textQtyFicheWeek��5      $
��Left=�6.   $��5,67,0,0q�6I   $
��Wrap=�6[   $��Quantité : ��6o   $	��Top=�6�   $	��122��6�   $��2��6�   �� 5   
   -   5         ��Name$ image_alerte��5      $
��Left=�6&   $��30��6A   $��	3,-1,-2,0q�6M   $	��Top=�6`   $��33��6x   $��1��6�   $8��2/GestionPlanning;component/Images/Icone_Alerte.png��6�   �� 5   
   -   5        $ image_warning��5      $
��Left=�6'   $��30��6B   $��3,-3,0,0q�6N   $	��Top=�6`   $��30��6x    J� RenderTransformOrigin$ 0.533,0.404&�6�   $��1��6�   $;��5/GestionPlanning;component/Images/Icone_Attention.png��6�   �� 5   
   -	   5        $ textHeureFabFicheWeek��5      $
��Left=�63   $��5,83,0,0q�6N   $
��Wrap=�6`   $��
Heure fab:��6t   $	��Top=�6�   $	��122��6�   $��2��6�   �� 5   
   -
   5        $ textTempsFabFicheWeek��5      $
��Left=�63   $��5,99,0,0q�6N   $
��Wrap=�6`   $	��Top=�6t   $	��122��6�   $��2��6�   �� 6�   $�Temps��6�   �� 6�   $� fab:��6�   6�   �� 5   
   ���	#FF232323$
��Left=�6%   $��1��6@   $��	0,144,0,0q�6K   $	��Top=�6^   $	��130��6v   $��2��6�   �� 5   
   -   5        $��Center=�5      $��
94,119,0,0q�6.   $	��Top=�6B   $��36��6Z   $��25��6e   ���	#FF303030$��2��6�   .��5      �� $
��Left=�6   $��22��6/   $	��Top=�6;   $��22��6S   $7��1/GestionPlanning;component/Images/Icone_Modif.png��6^   5      �� 5   
   -   5        $��Center=�5      $��46,119,14,0q�6.   $	��Top=�6C   $��36��6[   $��25��6f   ���	#FF303030.��5      �� $��25��6   $��36��6    $A��;/GestionPlanning;component/Images/Icone_ValidationFiche.png��6+   5      �� 5   
   -   5        $��Center=�5      $��
0,119,60,0q�6.   $	��Top=�6B   $��36��6Z   $��25��6e   ���	#FF303030.��5      �� $��22��6   $��26��6    $;��5/GestionPlanning;component/Images/Icone_Placement.png��6+   5!      5"      5#      