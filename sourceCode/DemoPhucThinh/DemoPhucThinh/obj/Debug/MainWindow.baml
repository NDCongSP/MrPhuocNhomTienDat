   M S B A M L   `   `   `  ����L  HGiamSatDucNhomApp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null-clr-namespace:DemoPhucThinhDemoPhucThinh  5   	       DemoPhucThinh.MainWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   -localclr-namespace:DemoPhucThinh     5   	     � Title$  GIÁM SÁT SẢN XUẤT��5   	   $
��1080��6#   $
��1920��61    � WindowStartupLocation$ CenterScreen=�6>    � WindowState$ 	Maximized=�6c    � WindowStyle$
 None=�6{    � 
ResizeMode$ CanMinimize=�6�    � 	Resources 5	       �� 	UriSource 
  pumpOn  pumpOff  	pumpFault��%�   &	        &	 0     &	 a     �� 5
   
   $ Images/PumpOn.png?�6   6E   �� 5   
   $ Images/PumpOff.png?�6   6G   �� 5   
   $ Images/PumpFault.png?�6   6K   5      .��5      �  � RowDefinitions 5   
   �� 5      $	��150 �6   �� 5      $��* �6   �� 5      $��50 �6   .+�5   
   � 
������� � ColumnDefinitions 5      �� 5      $	��150 �6#   �� 5      $
��533* �6#   �� 5      $	��57* �6#   .+�5      �� $��/Untitled1.png��6   $
��Fill=�6,   �� 5      -   5        	 ��Name$	 	labTittle��5   $   $��1��6   $!��GIÁM SÁT MÁY ĐÚC PHÔI��67   $��60(�6X   $��Times New Roman)�6f   $
��Bold"�6�   
��� ���$��Center=�5      $��Center=�65   $��335,-25,164.333,-25q�6P   $	��200��5      $
��1100��6!   $��Center=�6.   $��Center=�6R   �� 5      -   5        
 ��Name$
 imgMinimize��5   $   $��2��6   $
��Left=�69   $��30��6T   $��	141,0,0,0q�6`   $	��Top=�6s   $��30��6�    K� ZIndex$ 1��5       $"��Images/minimize_box_blue.png��6%   6K   5!      � 5#   
   $��1��6   .+�5$          DemoPhucThinh.ucParametter  -   5          Name$ 
parametter��5$   !   $��Stretch=�65   $��Stretch=�6S   $y�Hidden=�6o   6�      DemoPhucThinh.ucReport  5%      -   5          Name$ 	frmReport��5%      $y�Hidden=�60   6G      DemoPhucThinh.ucSettings  5&      -   5          Name$ frmSettings��5&      $y�Hidden=�64      DemoPhucThinh.ucScreen1  5'      -   5          Name$ 
frmScreen1��5'      $y�Visible=�62   $   DemoPhucThinh.ucSettingsNguong  5(      -   5          Name$ frmSettingsNguong��5(   %   $y�Hidden=�6@   5)      � 5+   
   $��2��6   
���   � 5,      �� 5-      $	��300 �6#   �� 5.      $��* �6#   �� 5/      $
��1000 �6#   .+�52      �� $��0��6    �� Orientation$ 
Horizontal=�6)   .+�53      �� -   5        $	 labTime��53      $��23/03/2021 08:30:25��6)   $��25(�6G   $��Times New Roman)�6U   $
��Bold"�6r   
�������$��3q�6�   $��Stretch=�54      $��Stretch=�66   $��Center=�6R   $��Center=�6v   55      �� 57      $��2��6   $ 
Horizontal=�6)   $��Right=�6B   .+�58      �� -	   5         ��Name$ btnFrmParametter��58      $��Thông số��63   $��3q�6F   $	��150��6Q   $��25(�6]   $
��Bold"�6k   $��Times New Roman)�6}   6�   �� 59      -
   5        $ btnFrmSettings��59      $��Cài đặt��61   $��3q�6C   $	��150��6N   $��25(�6Z   $
��Bold"�6h   $��Times New Roman)�6z   6�   �� 5:      -   5        $ btnFrmReport��5:      $��	Báo cáo��6/   $��3q�6A   $	��150��6L   $��25(�6X   $
��Bold"�6f   $��Times New Roman)�6x   6�   �� 5;      -   5        $ btnCaiDatNguong��5;      $��Cài đặt ngưỡng��62   $��3q�6K   $	��200��6V   $��25(�6b   $
��Bold"�6p   $��Times New Roman)�6�   6�   �� 5<      -   5        $ btnExit��5<      $��Thoát��6*   $��3q�6:   $	��150��6E   $��25(�6Q   $
��Bold"�6_   $��Times New Roman)�6q   6�   5=      5>      5?      5@      