   M S B A M L   `   `   `  ����L  HGiamSatDucNhomApp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null-clr-namespace:DemoPhucThinhDemoPhucThinh  5      Q MEasyScada.Wpf.Controls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null_Dclr-namespace:EasyScada.Wpf.Controls;assembly=EasyScada.Wpf.ControlsEasyScada.Wpf.Controls 5          DemoPhucThinh.ucSettings   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      -localclr-namespace:DemoPhucThinh     5      YcontrolsDclr-namespace:EasyScada.Wpf.Controls;assembly=EasyScada.Wpf.Controls     5      $	��880��5	      $
��1920��6   .��5      � 
����� �  � ColumnDefinitions  5   
   �� 5      $	��100 �6   �� 5      $��3* �6   �� 5      $��* �6   �� 5      $	��400 �6    � RowDefinitions 5   
   �� 5      $��* �6   �� 5      $��* �6   �� 5      $��* �6   �� 5      $��* �6   �� 5      $��* �6   �� 5      $��* �6   .+�5   
   �� $��3q�6   $��1��6   $.��(NHIỆT ĐỘ NƯỚC MẶT GIẾNG (oC)��6+   $��40(�6R   $��Times New Roman)�6`   $
��Bold"�6}   
���   �$��Stretch=�5      $��Stretch=�66   $��Right=�6R   $��Center=�6u   (  "EasyScada.Wpf.Controls.EasyTextBox  5   
   -   5          Name$ labNDMatGieng��5         TagPathI EEasyScada.Core, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null%  EasyScada.Core.TagPathConverter$- 'Local Station/Channel1/TNuocMatGieng/Sv 66   $��3q�6h   $��2��6s   $
��0000��5      $��Stretch=�6)   $��Right=�6H   $��Center=�5      $	��100(�6?   $��Times New Roman)�6N   $
��Bold"�6k   
���  ��
�������$��1��6�   �� 5!   
   $��3q�6   $��1��6   $��1��6(   $4��.NHIỆT ĐỘ NƯỚC GIẢI NHIỆT MÂM (oC)��68   $��40(�6d   $��Times New Roman)�6r   $
��Bold"�6�   
���   �$��Stretch=�5"      $��Stretch=�66   $��Right=�6R   $��Center=�6u     5#   
   -   5        $ labNDNuocGiaiNhietMam��5#      $1 +Local Station/Channel1/TNuocGiaiNhietMam/Sv 6>   $��1q�6t   $��1��6   $��2��6�   $
��0000��5$      $��Stretch=�6)   $��Right=�6H   $��Center=�5%      $	��100(�6?   $��Times New Roman)�6N   $
��Bold"�6k   
���  ��
�������$��2��6�   �� 5'   
   $��3q�6   $��2��6   $��1��6(   $.��(NHIỆT ĐỘ KHÔNG KHÍ TRONG LÒ (oC)��68   $��40(�6c   $��Times New Roman)�6q   $
��Bold"�6�   
���   �$��Stretch=�5(      $��Stretch=�66   $��Right=�6R   $��Center=�6u     5)   
   -   5        $ labNDKhongKhiTrongLo��5)      $0 *Local Station/Channel1/TKhongKhiTrongLo/Sv 6=   $��3q�6r   $��2��6}   $��2��6�   $
��0000��5*      $��Stretch=�6+   $��Right=�6J   $��Center=�5+      $	��100(�6?   $��Times New Roman)�6N   $
��Bold"�6k   
���  ��
�������$��3��6�   �� 5-   
   $��3q�6   $��3��6   $��1��6(   $0��*NHIỆT ĐỘ NƯỚC NHÔM TRONG LÒ (oC)��68   $��40(�6c   $��Times New Roman)�6q   $
��Bold"�6�   
���   �$��Stretch=�5.      $��Stretch=�66   $��Right=�6R   $��Center=�6u     5/   
   -   5        $ labNDNuocNhomTrongLo��5/      $0 *Local Station/Channel1/TNuocNhomTrongLo/Sv 6=   $��3q�6r   $��3��6}   $��2��6�   $
��0000��50      $��Stretch=�6+   $��Right=�6J   $��Center=�51      $	��100(�6?   $��Times New Roman)�6N   $
��Bold"�6k   
���  ��
�������$��4��6�   �� 53   
   $��3q�6   $��4��6   $��1��6(   $-��'NHIỆT ĐỘ NHÔM TRƯƠC KHUÔN (oC)��68   $��40(�6a   $��Times New Roman)�6o   $
��Bold"�6�   
���   �$��Stretch=�54      $��Stretch=�66   $��Right=�6R   $��Center=�6u     55   
   -   5        $ labNDNhomTaiMiengLo��55      $/ )Local Station/Channel1/TNhomTruocKhuon/Sv 6<   $��3q�6p   $��4��6{   $��2��6�   $
��0000��56      $��Stretch=�6)   $��Right=�6H   $��Center=�57      $	��100(�6?   $��Times New Roman)�6N   $
��Bold"�6k   
���  ��
�������$��5��6�   �� 59   
   $��3q�6   $��5��6   $��1��6(   $0��*NHIỆT ĐỘ NHÔM TẠI MIỆNG LÒ (oC)��68   $��40(�6b   $��Times New Roman)�6p   $
��Bold"�6�   
���   �$��Stretch=�5:      $��Stretch=�66   $��Right=�6R   $��Center=�6u     5;   
   -   5        $ labNDNhomTruocKhuon��5;      $/ )Local Station/Channel1/TNhomTaiMiengLo/Sv 6<   $��3q�6p   $��5��6{   $��2��6�   $
��0000��5<      $��Stretch=�6)   $��Right=�6H   $��Center=�5=      $	��100(�6?   $��Times New Roman)�6N   $
��Bold"�6k   
���  ��
�������$��6��6�   5?      5@      