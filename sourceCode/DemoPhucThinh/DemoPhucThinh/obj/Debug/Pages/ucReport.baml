   M S B A M L   `   `   `  ����L  HGiamSatDucNhomApp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null-clr-namespace:DemoPhucThinhDemoPhucThinh  5          DemoPhucThinh.ucReport   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      b ^MaterialDesignThemes.Wpf, Version=4.0.0.2422, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5      'localclr-namespace:DemoPhucThinh  5         MaterialDesignBody#���   5      $��Regular"�5      $��13(�5	      &   System.Windows.Media.TextOptions    TextFormattingMode$  Ideal=�5
         TextRenderingMode$
 Auto=�5        MaterialDesignPaper#���  5        MaterialDesignFont#���  5      $	��880��5      $
��1920��6   .��5      �  � RowDefinitions 5   
   �� 5      $
��auto �6   �� 5      $��* �6   .+�5   
   �� 
���   �$��2q�6%    �� CornerRadius$ 10��69   $��10q�6K   ._�5      �  � ColumnDefinitions 5      �� 5      $��* �6'   �� 5      $��* �6'   �� 5      $��* �6'   �� 5      $��* �6'   �� 5       $��* �6'    5#      �� 5$      $��* �6$   �� 5%      $��* �6$   .+�5)      �� $��2��6   $��Thời Gian Bắt Đầu��6(   $��30(�6D   $
��Bold"�6R   $��Times New Roman)�6d   
��� d �$��8 0 0 0q�5*   /   (  "System.Windows.Controls.DatePicker  5+      -   5          Name$ datePickerFormDate��5+   :   $��2��6   $��1��6-   $��30(�6V   $
��Bold"�6d   $��Times New Roman)�6v   $��5q�5,         DisplayDate$ 
2021-05-19��6(      SelectedDateFormat$ Short=�6A   �� 5.      $��3��6   $��Thời Gian Kết Thúc��6(   $��30(�6E   $
��Bold"�6S   $��Times New Roman)�6e   
��� d �$��8 0 0 0q�5/   /     50      -   5        $ datePickerToDate��50   :   $��3��6   $��1��6-   $��30(�6T   $
��Bold"�6b   $��Times New Roman)�6t   $��5q�51      �� 53      -   5         ��Name$ 
btnTruyVan��53   )   $��4��6   $��
Truy Vấn��6=   $��25(�6P   $
��Bold"�6^   $��Times New Roman)�6p   
��� d �$��2q�54   ,   $��Stretch=�67   $��Stretch=�6U   $
��Auto��6�   �� 55      -   5        $ 	btnExport��55   6   $��4��6   $��1��6)   $��Xuất Excel��6I   $��25(�6^   $
��Bold"�6l   $��Times New Roman)�6~   
��� d �$��2q�56   ,   $��Stretch=�67   $��Stretch=�6U   $
��Auto��6�   57      58      �� 5:   
   
���   �$��2q�6%   $ 10��69   $��1��6K   $��10q�6X   ._�5;      �� $
��Auto=�6   $
��Auto=�5<      $��10q�6@   .��5=      �� $��10q�6   .+�5>      &   System.Windows.Controls.DataGrid  -   5        	  Name$	 	dataGrid1��5>   ;   $
��Left=�6   $	��Top=�6N   
�������
   RowBackground

 �����   AlternatingRowBackground
 ��ح�$��4q�5@         CanUserResizeColumns . $   HorizontalScrollBarVisibility$ Hidden=�6>   "   VerticalScrollBarVisibility$ Hidden=�5A      $��20(�6=   $
��Bold"�6K   5B      5C      5D      5E      5F      