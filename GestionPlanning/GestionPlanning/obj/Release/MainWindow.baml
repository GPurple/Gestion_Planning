   M S B A M L   `   `   `  ���� J  FGestionPlanning, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null1clr-namespace:GestionPlanningGestionPlanning       GestionPlanning.MainWindow   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     /localclr-namespace:GestionPlanning     -     � Title$  
MainWindow��$��Stretch=�$��Stretch=�$��0,1,0,0q�#��� ��#��� �� � WindowState$ 	Maximized=� � WindowStartupLocation$ CenterScreen=�.��� $��0,0,0,0q�.+��� -    ��Name$ image_warningGeneral��$
��Left=�$��56��$��	764,0,0,0q�$	��Top=�$��56��$ ��Images/Icone_Attention.png���� -   $ image_alerteGeneral��$
��Left=�$��56��$��	820,0,0,0q�$	��Top=�$��53��$��Images/Icone_Alerte.png���� $
��Left=�$��56��$��	890,0,0,0q�$	��Top=�$	��170��$��Images/logos_aos.png��� -    �Name$ gridUcDisplayPlanning��$��Center=�$	��600��$��	39,94,5,0q�$	��Top=�$
��1290��.+�'   !GestionPlanning.UC_Display_Simple  -     Name$ UC_Disp_Simple��$��Center=�$	��530��$��Center=�$
��1290��$��Center=�$��Center=�$   GestionPlanning.UC_Disp_modifs  -     Name$ UC_DispModifs��$
��Left=�$	��530��$	��Top=�$
��1290��$   GestionPlanning.UC_display_day  -     Name$ UC_Disp_Day��$
��Left=�$	��530��$	��Top=�$
��1290��#   GestionPlanning.UC_Disp_Month  -     Name$ UC_Disp_Month��$
��Left=�$	��530��$	��Top=�$
��1290��%   GestionPlanning.UC_Display_week  -	   	  Name$	 UC_Disp_Week��$
��Left=�$	��530��$	��Top=�$
��1290��%   GestionPlanning.UC_Disp_Machine  -
   
  Name$
 UC_Disp_Machines��$
��Left=�$��0,0,0,0q�$	��Top=�$	��531��$
��1290��&    GestionPlanning.UC_Disp_Controls  $
��Left=�$	��124��$��	10,10,0,0q�$	��Top=�$	��740��