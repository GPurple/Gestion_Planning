   M S B A M L   `   `   `  ����J  FGestionPlanning, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null1clr-namespace:GestionPlanningGestionPlanning  5      "    GestionPlanning.UC_fiche_day   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      /localclr-namespace:GestionPlanning     5      $	��650��5      $��50��6+   .��5      � $��50��6   $	��Top=�6     � ColumnDefinitions  5	   
   �� 5
      $
��127* �6   �� 5      .+�5   
   �� -   5         ��Name$ rectangleLeft_op��5      ���	#FFF4F4F5$	��320��6?   $��0��6K   $
��Left=�6_   �� 5   
   -   5        $ rectangleRight_rec��5      ���	#FFF4F4F5$
��Left=�6A   $	��330��6\   $��	320,0,0,0q�6h   $��0��6{   $��2��6�   �� 5   
   -   5         ��Name$ textIDficheDay��5      $
��Left=�6,   $��10,3,0,0q�6G   $
��Wrap=�6Y   $��ID : ��6m   $	��Top=�6z   �� 5   
   -   5        $ textNameFicheDay��5      $
��Left=�6.   $��75,3,0,0q�6I   $
��Wrap=�6[   $��Nom : ��6o   $	��Top=�6}   �� 5   
   -   5        $ textDateLivFicheDay��5      $
��Left=�61   $��	253,3,0,0q�6L   $
��Wrap=�6_   $	��Top=�6s   �� 6�   $�Date l��6�   �� 6�   $�ivraison : ��6�   6�   �� 5   
   -   5        $ textQtyFicheDay��5      $
��Left=�6-   $��
421,21,0,0q�6H   $
��Wrap=�6\   $��Quantité : ��6p   $	��Top=�6�   �� 5   
   -   5         ��Name$ image_alerte��5      $
��Left=�6&   $��30��6A   $��
602,-4,0,0q�6M   $	��Top=�6a   $��33��6y   $8��2/GestionPlanning;component/Images/Icone_Alerte.png��6�   �� 5   
   -   5        $ image_warning��5      $
��Left=�6'   $��30��6B   $��
602,-4,0,0q�6N   $	��Top=�6b   $��30��6z    J� RenderTransformOrigin$ 0.533,0.404&�6�   $;��5/GestionPlanning;component/Images/Icone_Attention.png��6�   �� 5   
   -	   5        $ textHeureFabFicheWeek��5      $
��Left=�63   $��	10,21,0,0q�6N   $
��Wrap=�6a   $	��Top=�6u   $	��136��6�   �� 6�   $�	Heure fab��6�   �� 6�   $� ��6�   �� 6�   $�: ��6�   6�   �� 5   
   -
   5        $ textTempsFabFicheWeek��5      $
��Left=�63   $��
134,21,0,0q�6N   $
��Wrap=�6b   $	��Top=�6v   $	��119��6�   �� 6�   $�	Temps fab��6�   �� 6�   $	� : ��6�   6�   �� 5   
   ���	#FF232323$
��Left=�6%   $��1��6@   $��0,49,0,0q�6K   $	��Top=�6]   $	��650��6u   $��2��6�   �� 5   
   -   5        $��Center=�5      $��
614,24,0,0q�6.   $	��Top=�6B   $��36��6Z   $��25��6e   ���	#FF303030$��2��6�   .��5      �� $
��Left=�6   $��22��6/   $	��Top=�6;   $��22��6S   $7��1/GestionPlanning;component/Images/Icone_Modif.png��6^   5      �� 5   
   -   5        $��Center=�5      $��573,24,36,0q�6.   $	��Top=�6C   $��36��6[   $��25��6f   ���	#FF303030.��5      �� $��22��6   $��36��6    $A��;/GestionPlanning;component/Images/Icone_ValidationFiche.png��6+   5      �� 5   
   -   5        $��Center=�5      $��532,24,77,0q�6.   $	��Top=�6C   $��36��6[   $��25��6f   ���	#FF303030.��5      �� $��22��6   $��26��6    $;��5/GestionPlanning;component/Images/Icone_Placement.png��6+   5       �� 5!   
   -   5        $ textDateFabFicheDay��5!      $
��Left=�61   $��
253,21,0,0q�6L   $
��Wrap=�6`   $��Date fabrication :��6t   $	��Top=�6�   �� 5"   
   -   5        $ textMachineFicheDay��5"      $
��Left=�61   $��	421,3,0,0q�6L   $
��Wrap=�6_   $��	Machine :��6s   $	��Top=�6�   5#      5$      