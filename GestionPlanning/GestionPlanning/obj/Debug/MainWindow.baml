   M S B A M L   `   `   `  ����J  FGestionPlanning, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null1clr-namespace:GestionPlanningGestionPlanning  5   	        GestionPlanning.MainWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   /localclr-namespace:GestionPlanning     5   	   -   5          � Title$  
MainWindow��5   	   $��Stretch=�6   $��Stretch=�6A   $��0,1,0,0q�6d   #��� ��6v   #��� ��6�    � WindowState$ 	Maximized=�6   � WindowStartupLocation$ CenterScreen=�65  .��5	      � $��0,0,0,0q�6   .+�5
   
   �� -   5         ��Name$ image_warningGeneral��5
      $
��Left=�6.   $��56��6I   $��	764,0,0,0q�6U   $	��Top=�6h   $��56��6�   $ ��Images/Icone_Attention.png��6�   �� 5   
   -   5        $ image_alerteGeneral��5      $
��Left=�6-   $��56��6H   $��	820,0,0,0q�6T   $	��Top=�6g   $��53��6   $��Images/Icone_Alerte.png��6�   �� 5   
   $
��Left=�6   $��56��6+   $��	890,0,0,0q�67   $	��Top=�6J   $	��170��6b   $��Images/logos_aos.png��6n   � 5   
   -   5         �Name$ gridUcDisplayPlanning��5      $��Center=�6.   $	��600��6K   $��	39,94,5,0q�6X   $	��Top=�6k   $
��1290��6�   .+�5      '   !GestionPlanning.UC_Display_Simple  -   5          Name$ UC_Disp_Simple��5   &   $��Center=�6>   $	��530��6[   $��Center=�6h   $
��1290��6�   $��Center=�6�   $��Center=�6�   $   GestionPlanning.UC_Disp_modifs  5      -   5          Name$ UC_DispModifs��5   #   $
��Left=�6:   $	��530��6U   $	��Top=�6b   $
��1290��6z   $   GestionPlanning.UC_display_day  5      -   5          Name$ UC_Disp_Day��5   #   $
��Left=�68   $	��530��6S   $	��Top=�6`   $
��1290��6x   #   GestionPlanning.UC_Disp_Month  5      -   5          Name$ UC_Disp_Month��5   "   $
��Left=�69   $	��530��6T   $	��Top=�6a   $
��1290��6y   %   GestionPlanning.UC_Display_week  5      -	   5        	  Name$	 UC_Disp_Week��5   $   $
��Left=�6:   $	��530��6U   $	��Top=�6b   $
��1290��6z   %   GestionPlanning.UC_Disp_Machine  5      -
   5        
  Name$
 UC_Disp_Machines��5   $   $
��Left=�6>   $��0,0,0,0q�6Y   $	��Top=�6j   $	��531��6�   $
��1290��6�   5      &    GestionPlanning.UC_Disp_Controls  5   
   $
��Left=�6!   $	��124��6<   $��	10,10,0,0q�6I   $	��Top=�6\   $	��740��6t   5      5      