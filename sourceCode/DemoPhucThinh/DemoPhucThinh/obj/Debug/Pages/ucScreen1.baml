   M S B A M L   `   `   `  ����Q  MEasyScada.Wpf.Controls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null_Dclr-namespace:EasyScada.Wpf.Controls;assembly=EasyScada.Wpf.ControlsEasyScada.Wpf.Controls  5      L HGiamSatDucNhomApp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null-clr-namespace:DemoPhucThinhDemoPhucThinh 5      @ <Gauge, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null,"clr-namespace:Gauge;assembly=GaugeGauge 5	         DemoPhucThinh.ucScreen1   5      b ^MaterialDesignThemes.Wpf, Version=4.0.0.2422, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5      ScontrolsDclr-namespace:EasyScada.Wpf.Controls;assembly=EasyScada.Wpf.Controls  5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      -localclr-namespace:DemoPhucThinh     5      4gauge"clr-namespace:Gauge;assembly=Gauge     5	      $	��880��5      $
��1920��6   .��5      � 
����� �  � RowDefinitions  5   
   �� 5      $	��100 �6   �� 5      $��* �6   .+�5   
   �  � ColumnDefinitions 5      �� 5      $��* �6#   �� 5      $��2* �6#   �� 5      $��* �6#   �� 5      $
��1.7* �6#   .+�5      �� $��3q�6   $��0��6   $��0��6,   $��
MÁC NHÔM��6<   $��35(�6P   $��Times New Roman)�6^   $
��Bold"�6{   
���  ��$��Stretch=�5      $��Stretch=�66   $��Center=�6R   $��Center=�6v   
����  �6�   (   "EasyScada.Wpf.Controls.EasyTextBox  5      -   5          Name$ 
txtMacNhom��5   #   $��3q�68   $��0��6C   $��1��6P      StringFormat$
 0.00��6`   $
��0000��6t   $��Stretch=�6�   $��Right=�5         TagPathI EEasyScada.Core, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null%  EasyScada.Core.TagPathConverter$, &Local Station/Channel1/Device1/MacNhom 6B   $��Stretch=�6s   $��Center=�5       $��70(�6?   $��Times New Roman)�6M   $
��Bold"�6j   
���  ��
�������5!      �� 5#      $��3q�6   $��0��6   $��2��6,   $��ĐƯỜNG KÍNH (mm)��6<   $��35(�6W   $��Times New Roman)�6e   $
��Bold"�6�   
���  ��$��Stretch=�5$      $��Stretch=�66   $��Center=�6R   $��Center=�6v   
����  �6�     5%      -   5        $ txtDuongKinh��5%   #   $��3q�69   $��0��6D   $��3��6Q   $. (Local Station/Channel1/Device1/DuongKinh 6a   $
��0000��6�   $��Stretch=�5&   #   $��Stretch=�6B   $��Right=�6^   $��Center=�5'      $��70(�6?   $��Times New Roman)�6M   $
��Bold"�6j   
���  ��
�������6�   5(      � 5*   
   $��1��6    5+      �� 5,      $	��55* �6#   �� 5-      $	��50* �6#   .+�50      �� .+�51        Gauge.TempGauge  -   5          Name$ gauge1��51   "      MaxValue$ 3Q�62   $	��334��6?   $	��356��6L    �� Left$	 588��6X   
 �� Top$ 7��6j     Gauge.EasyProgressBar  52      -   5        	  Name$	 progBarChieuDaiPhoi��52   (   
   MaxValue$
 13000��53   )      
LabelColor
 �  ��   ProgBarlColor
 ��  �   HorizontalBar$ Right=�6`      TitleBar$ CD PHÔI��6v      FontSizeBar$ 15��54   (      	HeightBar$	 500��69      VisibilityLabel$ Visible=�6I   $
 -378��55   (   $	 355��6;    J� RenderTransformOrigin$ 0.5,0.5&�6L   $	��772��6l   z�56      V� 57      .~�58      �� �� 59      �� 5:       �� Angle$	 -90Q�6.   T� 5;      5<      5>      �� 5?      $��0��6   $ 36��6$   $��15(�65   $��Times New Roman)�6C   $
��Bold"�6`   
���   �$��Stretch=�5@      $��Stretch=�66   $��Center=�6R   $��Center=�6v   $��29��5A      $��30��6$   $ -7��6/    K� ZIndex$ 1��6?   �� 5B      $ 40��6Z   $��15(�6k   $��Times New Roman)�6y   $
��Bold"�6�   
���   �$��Stretch=�5C      $��Stretch=�66   $��Center=�6R   $��Center=�6v   $��28��5D      $��48��6$   $	 756��6/   $ 1��6@   ��5B      ��  �� ElementName$ progBarChieuDaiPhoi�� �� Path$ MaxValue�5D   @   �� 5F      $	 166��6   $ 7��6+   $��Chiều dài phôi (mm)��6:   $��35(�6X   $��Times New Roman)�6f   $
��Bold"�6�   
���   �$��Stretch=�5G      $��Stretch=�66   $��Right=�6R   $��Center=�6u   &    EasyScada.Wpf.Controls.EasyLabel  5H      $	 250��6%   $ 61��68      TagPath$1 +Local Station/Channel1/Device1/ChieuDaiPhoi 6H   $��0��6~   $��1��6�   $��00000��6�   $��Stretch=�5I   %   $��Center=�6C   $��Right=�6^   $��Center=�5J      $��70(�6?   $��Times New Roman)�6M   $
��Bold"�6j   
���  ��
�������6�   �� 5K      $	 201��6   $	 181��6+   $��TG đông đặc (s)��6<   $��35(�6V   $��Times New Roman)�6d   $
��Bold"�6�   
���   �$��Stretch=�5L      $��Stretch=�66   $��Right=�6R   $��Center=�6u     5M      $	 250��6%   $	 235��68   $4 .Local Station/Channel1/Device1/ThoiGianDongDac 6I   $��0��6�   $��1��6�   $
��0000��6�   $��Stretch=�5N   %   $��Center=�6C   $��Right=�6^   $��Center=�5O      $��70(�6?   $��Times New Roman)�6M   $
��Bold"�6j   
���  ��
�������6�     Gauge.easyRealTimeTrend  5S      -   5          Name$ realTimeChart��5S   L   $ 88��6*   $	 346��6;   $	��424��6c   $	��913��6p      	PointNums$ 30��5T   *      Interval$ 60000��69      
StepLabelX$ 1��6J      AxisYMax$ 5Q�6Y   5U      �� 5W      $��1��6   $��2q�6%   
���   � �� CornerRadius$ 3��6M   $��3q�6^   ._�5X      �   5Y      �� 5Z      $��* �6(   �� 5[      $��* �6(   �� 5\      $��* �6(   �� 5]      $��* �6(   �� 5^      $��* �6(   �� 5_      $��* �6(    5a      �� 5b      $
��1.6* �6+   �� 5c      $��* �6+   �� 5d      $
��1.1* �6+   �� 5e      $��* �6+   .+�5h      �� $��0��6!   $��0��6.    �� Orientation$ Vertical=�6>   $��Center=�6U   .+�5i      �� $��NĐ nước mặt��6    $��35(�66   $��Times New Roman)�6D   $
��Bold"�6a   
���   �$��Stretch=�5j      $��Stretch=�66   $��Right=�6R   $��Center=�6u   �� 5k      $��giếng��6    $��35(�60   $��Times New Roman)�6>   $
��Bold"�6[   
���   �$��Stretch=�5l      $��Stretch=�66   $��Right=�6R   $��Center=�6u   5m        5o      -   5          Name$ labNDMatGieng��5o   )   $- 'Local Station/Channel1/TNuocMatGieng/Pv 6@   $��3q�6r   $��0��6}   $��1��6�   $
��0000��6�   $��Stretch=�5p   %   $��Center=�6C   $��Right=�6^   $��Center=�5q      $��70(�6?   $��Times New Roman)�6M   $
��Bold"�6j   
���  ��
�������6�   �� 5s      $��1��6!   $��0��6.   $ Vertical=�6>   $��Center=�6U   .+�5t      �� $��NĐ nước giải��6    $��35(�67   $��Times New Roman)�6E   $
��Bold"�6b   
���   �$��Stretch=�5u      $��Stretch=�66   $��Right=�6R   $��Center=�6u   �� 5v      $��nhiệt mâm��6    $��35(�64   $��Times New Roman)�6B   $
��Bold"�6_   
���   �$��Stretch=�5w      $��Stretch=�66   $��Right=�6R   $��Center=�6u   5x        5z      -   5        $ labNDNuocGiaiNhietMam��5z   )   $1 +Local Station/Channel1/TNuocGiaiNhietMam/Pv 6H   $��3q�6~   $��1��6�   $��1��6�   $
��0000��6�   $��Stretch=�5{   %   $��Center=�6C   $��Right=�6^   $��Center=�5|      $��70(�6?   $��Times New Roman)�6M   $
��Bold"�6j   
���  ��
�������6�   �� 5      $��2��6!   $��0��6.   $ Vertical=�6>   $��Center=�6U   .+�5�      �� $��NĐ không khí��6    $��35(�67   $��Times New Roman)�6E   $
��Bold"�6b   
���   �$��Stretch=�5�      $��Stretch=�66   $��Right=�6R   $��Center=�6u   �� 5�      $��	trong lò��6    $��35(�63   $��Times New Roman)�6A   $
��Bold"�6^   
���   �$��Stretch=�5�      $��Stretch=�66   $��Right=�6R   $��Center=�6u   5�        5�      -   5        $ labNDKhongKhiTrongLo��5�   )   $0 *Local Station/Channel1/TKhongKhiTrongLo/Pv 6G   $��3q�6|   $��2��6�   $��1��6�   $
��0000��6�   $��Stretch=�5�   %   $��Center=�6C   $��Right=�6^   $��Center=�5�      $��70(�6?   $��Times New Roman)�6M   $
��Bold"�6j   
���  ��
�������6�   �� 5�      $��3��6!   $��0��6.   $ Vertical=�6>   $��Center=�6U   .+�5�      �� $��NĐ nước nhôm��6    $��35(�67   $��Times New Roman)�6E   $
��Bold"�6b   
���   �$��Stretch=�5�      $��Stretch=�66   $��Right=�6R   $��Center=�6u   �� 5�      $��	trong lò��6    $��35(�63   $��Times New Roman)�6A   $
��Bold"�6^   
���   �$��Stretch=�5�      $��Stretch=�66   $��Right=�6R   $��Center=�6u   5�        5�      -	   5        $ labNDNhomTaiMiengLo��5�   )   $0 *Local Station/Channel1/TNuocNhomTrongLo/Pv 6F   $��3q�6{   $��3��6�   $��1��6�   $
��0000��5�   %   $��Stretch=�64   $��Center=�6R   $��Right=�6n   $��Center=�5�      $��70(�6?   $��Times New Roman)�6M   $
��Bold"�6j   
���  ��
�������6�   �� 5�      $��4��6!   $��0��6.   $ Vertical=�6>   $��Center=�6U   .+�5�      �� $��NĐ nhôm trước��6    $��35(�68   $��Times New Roman)�6F   $
��Bold"�6c   
���   �$��Stretch=�5�      $��Stretch=�66   $��Right=�6R   $��Center=�6u   �� 5�      $��khuôn��6    $��35(�60   $��Times New Roman)�6>   $
��Bold"�6[   
���   �$��Stretch=�5�      $��Stretch=�66   $��Right=�6R   $��Center=�6u   5�        5�      -
   5        $ labNDNhomTruocKhuon��5�   )   $/ )Local Station/Channel1/TNhomTruocKhuon/Pv 6F   $��3q�6z   $��4��6�   $��1��6�   $
��0000��6�   $��Stretch=�5�   %   $��Center=�6C   $��Right=�6_   $��Center=�5�      $��70(�6?   $��Times New Roman)�6M   $
��Bold"�6j   
���  ��
�������6�   �� 5�      $��5��6!   $��0��6.   $ Vertical=�6>   $��Center=�6U   .+�5�      �� $��NĐ nhôm cuối��6    $��35(�67   $��Times New Roman)�6E   $
��Bold"�6b   
���   �$��Stretch=�5�      $��Stretch=�66   $��Right=�6R   $��Center=�6u   �� 5�      $��khuôn��6    $��35(�60   $��Times New Roman)�6>   $
��Bold"�6[   
���   �$��Stretch=�5�      $��Stretch=�66   $��Right=�6R   $��Center=�6u   5�        5�      -   5        $ labNDNuocNhomTrongLo��5�   )   $/ )Local Station/Channel1/TNhomTaiMiengLo/Pv 6G   $��3q�6{   $��5��6�   $��1��6�   $
��0000��6�   $��Stretch=�5�   %   $��Center=�6C   $��Right=�6_   $��Center=�5�      $��70(�6?   $��Times New Roman)�6M   $
��Bold"�6j   
���  ��
�������6�   �� 5�      $��0��6!   $��2��6.   $ Vertical=�6>   $��Center=�6U   .+�5�      �� $��Tốc độ cây��6    $��35(�65   $��Times New Roman)�6C   $
��Bold"�6`   
���   �$��Stretch=�5�      $��Stretch=�66   $��Right=�6R   $��Center=�6u   �� 5�      $��khuấy (v/p)��6    $��35(�66   $��Times New Roman)�6D   $
��Bold"�6a   
���   �$��Stretch=�5�      $��Stretch=�66   $��Right=�6R   $��Center=�6u   5�        5�      -   5        $ labTocDoCayKhuay��5�   +   $2 ,Local Station/Channel1/Device1/TocDoCayKhuay 6E   $
 0.00��6|   $��3q�6�   $��0��6�   $��3��6�   $
��0000��6�   $��Stretch=�5�   '   $��Center=�6E   $��Right=�6`   $��Center=�5�      $��70(�6?   $��Times New Roman)�6M   $
��Bold"�6j   
���  ��
�������6�   �� 5�      $��1��6!   $��2��6.   $ Vertical=�6>   $��Center=�6U   .+�5�      �� $��Áp lực khí��6    $��35(�65   $��Times New Roman)�6C   $
��Bold"�6`   
���   �$��Stretch=�5�      $��Stretch=�66   $��Right=�6R   $��Center=�6u   �� 5�      $��Argon (bar)��6    $��35(�66   $��Times New Roman)�6D   $
��Bold"�6a   
���   �$��Stretch=�5�      $��Stretch=�66   $��Right=�6S   $��Center=�6v   5�        5�      -   5        $ labApKhiNito��5�   +   $/ )Local Station/Channel1/Device1/ApKhiArgon 6A   $
 0.00��6u   $��3q�6�   $��1��6�   $��3��6�   $
��0000��6�   $��Stretch=�5�   '   $��Center=�6E   $��Right=�6a   $��Center=�5�      $��70(�6?   $��Times New Roman)�6M   $
��Bold"�6j   
���  ��
�������6�   �� 5�      $��2��6!   $��2��6.   $ Vertical=�6>   $��Center=�6U   .+�5�      �� $��Áp lực nước��6    $��35(�66   $��Times New Roman)�6D   $
��Bold"�6a   
���   �$��Stretch=�5�      $��Stretch=�66   $��Right=�6R   $��Center=�6u   �� 5�      $��L1 (bar)��6    $��35(�63   $��Times New Roman)�6A   $
��Bold"�6^   
���   �$��Stretch=�5�      $��Stretch=�66   $��Right=�6R   $��Center=�6u   5�        5�      -   5        $ labApLucNuoc��5�   +   $0 *Local Station/Channel1/Device1/ApLucNuocL1 6A   $
 0.00��6v   $��3q�6�   $��2��6�   $��3��6�   $
��0000��6�   $��Stretch=�5�   '   $��Center=�6E   $��Right=�6a   $��Center=�5�      $��70(�6?   $��Times New Roman)�6M   $
��Bold"�6j   
���  ��
�������6�   �� 5�      $��3��6!   $��2��6.   $ Vertical=�6>   $��Center=�6U   .+�5�      �� $��Vận tốc sợi��6    $��35(�66   $��Times New Roman)�6D   $
��Bold"�6a   
���   �$��Stretch=�5�      $��Stretch=�66   $��Right=�6R   $��Center=�6u   �� 5�      $��titan (mm/s)��6    $��35(�67   $��Times New Roman)�6E   $
��Bold"�6b   
���   �$��Stretch=�5�      $��Stretch=�66   $��Right=�6R   $��Center=�6u   5�        5�      -   5        $ labThoiGianDongDac��5�   +   $3 -Local Station/Channel1/Device1/VanTocSoiTitan 6G   $��3q�6   $��3��6�   $��3��6�   $
��0000��6�   $��Stretch=�5�   '   $��Center=�6E   $��Right=�6a   $��Center=�5�      $��70(�6?   $��Times New Roman)�6M   $
��Bold"�6j   
���  ��
�������6�   �� 5�      $��4��6!   $��2��6.   $ Vertical=�6>   $��Center=�6U   .+�5�      �� $��Tần số xuống��6    $��35(�67   $��Times New Roman)�6E   $
��Bold"�6b   
���   �$��Stretch=�5�      $��Stretch=�66   $��Right=�6R   $��Center=�6u   �� 5�      $��	mâm (Hz)��6    $��35(�63   $��Times New Roman)�6A   $
��Bold"�6^   
���   �$��Stretch=�5�      $��Stretch=�66   $��Right=�6R   $��Center=�6u   5�        5�      -   5        $ labTocDoXuongMam��5�   )   $+ %Local Station/Channel1/InvtXuongMam/f 6C       StringFormat$
  0.00��6s   $��3q�6�   $��4��6�   $��3��6�   $
��0000��5�   )   $��Stretch=�5�   %   $��Center=�6C   $��Right=�6^   $��Center=�5�      $��70(�6?   $��Times New Roman)�6M   $
��Bold"�6j   
���  ��
�������6�   �� 5�      $��5��6!   $��2��6.   $ Vertical=�6>   $��Center=�6U   .+�5�      �� $��Tần số bơm��6    $��35(�65   $��Times New Roman)�6C   $
��Bold"�6`   
���   �$��Stretch=�5�      $��Stretch=�66   $��Right=�6R   $��Center=�6u   �� 5�      $��nước (Hz)��6    $��35(�64   $��Times New Roman)�6B   $
��Bold"�6_   
���   �$��Stretch=�5�      $��Stretch=�66   $��Right=�6R   $��Center=�6u   5�        5�      -   5        $ labChieuDaiPhoi��5�   )   $* $Local Station/Channel1/InvtBomNuoc/f 6B   $��3q�6q   $��5��6|   $��3��6�   $
��0000��6�   $��Stretch=�5�   %   $��Center=�6C   $��Right=�6^   $��Center=�5�      $��70(�6?   $��Times New Roman)�6M   $
��Bold"�6j   
���  ��
�������$
  0.00��6�   5�      5�      5�      5�      5�      