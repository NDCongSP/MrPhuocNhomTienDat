   M S B A M L   `   `   `  ����L  HGiamSatDucNhomApp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null-clr-namespace:DemoPhucThinhDemoPhucThinh  5      @ <Gauge, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null,"clr-namespace:Gauge;assembly=GaugeGauge 5      Q MEasyScada.Wpf.Controls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null_Dclr-namespace:EasyScada.Wpf.Controls;assembly=EasyScada.Wpf.ControlsEasyScada.Wpf.Controls 5
      &     DemoPhucThinh.ucScreenParametter   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      -localclr-namespace:DemoPhucThinh     5      4Gauge"clr-namespace:Gauge;assembly=Gauge     5      YControlsDclr-namespace:EasyScada.Wpf.Controls;assembly=EasyScada.Wpf.Controls     5
      $
��1910��5      $
��3840��6   .��5      �   � ColumnDefinitions  5   
   �� 5      $��2* �6   �� 5      $��* �6   .+�5   
   � $��0��6    � RowDefinitions 5      �� 5      $��* �6    �� 5      $��* �6    .+�5       � $��0��6   .+�5!      ��  �� Orientation$ 
Horizontal=�6   .+�5"        Gauge.TempGauge  -   5          Name$ gaugeNdNuocMatGieng��5"   &   $	��800��6C   $	��800��6P     5#      -   5        $ gaugeNdNuocGiaiNhietMam��5#   &   $	��800��6G   $	��800��6T     5$      -   5        $ gaugeNdKhongKhiTrongLo��5$   &   $	��800��6F   $	��800��6R   5%      5&      � 5'      $��1��6   .+�5(      �� $ 
Horizontal=�6   .+�5)        -   5        $ gaugeNdNuocNhomTrongLo��5)   &   $	��800��6F   $	��800��6S     5*      -   5        $ gaugeNdNhomTaiMiengLo��5*   &   $	��800��6E   $	��800��6R     5+      -   5        $ gaugeNdNhomTruocKhuon��5+   &   $	��800��6E   $	��800��6R   5,      5-      5.      � 50   
   $��1��6   
�������  51      �� 52      $��* �6#   �� 53      $��* �6#    55      �� 56      $��* �6    �� 57      $��* �6    �� 58      $��* �6    �� 59      $��* �6    �� 5:      $��* �6    �� 5;      $��* �6    �� 5<      $��* �6    �� 5=      $��* �6    .+�5@      �� $��2q�6   $��0��6   $��0��6,   $��
MÁC NHÔM��6<   $��50(�6P   $��Times New Roman)�6^   $
��Bold"�6{   
���  ��$��Stretch=�5A      $��Stretch=�66   $��Center=�6R   $��Center=�6v   
��� d �6�   &   EasyScada.Wpf.Controls.EasyLabel  5B      -   5          Name$ 
labMacNhom��5B   !      TagPathI EEasyScada.Core, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null%  EasyScada.Core.TagPathConverter$, &Local Station/Channel1/Device1/MacNhom 65   $��2q�6f   $��0��6q   $��1��6~   $��0��6�   $��Stretch=�6�   $��Right=�6�   $��Center=�5C      $��70(�6?   $��Times New Roman)�6M   $
��Bold"�6j   
���  ��
��� d �6�   �� 5E      $��2q�6   $��1��6   $��0��6,   $��ĐƯỜNG KÍNH (inch)��6<   $��50(�6Y   $��Times New Roman)�6g   $
��Bold"�6�   
���  ��$��Stretch=�5F      $��Stretch=�66   $��Center=�6R   $��Center=�6v   
��� d �6�     5G      -   5        $ labDuongKinh��5G   !   $. (Local Station/Channel1/Device1/DuongKinh 67   $��2q�6j   $��1��6u   $��2��6�   $��0��6�   $��Stretch=�6�   $��Right=�6�   $��Center=�5H      $��70(�6?   $��Times New Roman)�6M   $
��Bold"�6j   
���  ��
��� d �6�   �� 5J      $��2q�6   $��2��6   $��0��6,   $��ÁP LỰC NƯỚC (bar)��6<   $��50(�6Y   $��Times New Roman)�6g   $
��Bold"�6�   
���   �$��Stretch=�5K      $��Stretch=�66   $��Center=�6R   $��Center=�6v   
��� d �6�     5L      -	   5        $ labApLucNuoc��5L   !   $. (Local Station/Channel1/Device1/ApLucNuoc 67   $��2q�6j   $��2��6u   $��1��6�   $��0��6�   $��Stretch=�6�   $��Right=�6�   $��Center=�5M      $��70(�6?   $��Times New Roman)�6M   $
��Bold"�6j   
���  ��
��� d �6�   �� 5O      $��2q�6   $��3��6   $��0��6,   $$��TỐC ĐỘ CÂY KHUẤY (v/p)��6<   $��50(�6^   $��Times New Roman)�6l   $
��Bold"�6�   
���   �$��Stretch=�5P      $��Stretch=�66   $��Center=�6R   $��Center=�6v   
��� d �6�     5Q      -
   5        $ labTocDoCayKhuay��5Q   !   $2 ,Local Station/Channel1/Device1/TocDoCayKhuay 6;   $��2q�6r   $��3��6}   $��1��6�   $��0��6�   $��Stretch=�6�   $��Right=�6�   $��Center=�5R      $��70(�6?   $��Times New Roman)�6M   $
��Bold"�6j   
���  ��
��� d �6�   �� 5T      $��2q�6   $��4��6   $��0��6,   $��ÁP KHÍ NITO (bar)��6<   $��50(�6Y   $��Times New Roman)�6g   $
��Bold"�6�   
���   �$��Stretch=�5U      $��Stretch=�66   $��Center=�6R   $��Center=�6v   
��� d �6�     5V      -   5        $ labApKhiNito��5V   !   $. (Local Station/Channel1/Device1/ApKhiNito 67   $��2q�6j   $��4��6u   $��1��6�   $��0��6�   $��Stretch=�6�   $��Right=�6�   $��Center=�5W      $��70(�6?   $��Times New Roman)�6M   $
��Bold"�6j   
���  ��
��� d �6�   �� 5Y      $��2q�6   $��5��6   $��0��6,   $$��TỐC ĐỘ XUỐNG MÂM (m/p)��6<   $��50(�6^   $��Times New Roman)�6l   $
��Bold"�6�   
���   �$��Stretch=�5Z      $��Stretch=�66   $��Center=�6R   $��Center=�6v   
��� d �6�     5[      -   5        $ labTocDoXuongMam��5[   !   $2 ,Local Station/Channel1/Device1/TocDoXuongMam 6;   $��2q�6r   $��5��6}   $��1��6�   $��0��6�   $��Stretch=�6�   $��Right=�6�   $��Center=�5\      $��70(�6?   $��Times New Roman)�6M   $
��Bold"�6j   
���  ��
��� d �6�   �� 5^      $��2q�6   $��6��6   $��0��6,   $��CHIỀU DÀI PHÔI (mm)��6<   $��50(�6[   $��Times New Roman)�6i   $
��Bold"�6�   
���   �$��Stretch=�5_      $��Stretch=�66   $��Center=�6R   $��Center=�6v   
��� d �6�     5`      -   5        $ labChieuDaiPhoi��5`   !   $1 +Local Station/Channel1/Device1/ChieuDaiPhoi 6:   $��2q�6p   $��6��6{   $��1��6�   $��0��6�   $��Stretch=�6�   $��Right=�6�   $��Center=�5a      $��70(�6?   $��Times New Roman)�6M   $
��Bold"�6j   
���  ��
��� d �6�   �� 5c      $��2q�6   $��7��6   $��0��6,   $#��THỜI GIAN ĐÔNG ĐẶC (s)��6<   $��50(�6^   $��Times New Roman)�6l   $
��Bold"�6�   
���   �$��Stretch=�5d      $��Stretch=�66   $��Center=�6R   $��Center=�6v   
��� d �6�     5e      -   5        $ labThoiGianDongDac��5e   !   $4 .Local Station/Channel1/Device1/ThoiGianDongDac 6=   $��2q�6v   $��7��6�   $��1��6�   $��0��6�   $��Stretch=�6�   $��Right=�6�   $��Center=�5f      $��70(�6?   $��Times New Roman)�6M   $
��Bold"�6j   
���  ��
��� d �6�   5g      5h      5i      