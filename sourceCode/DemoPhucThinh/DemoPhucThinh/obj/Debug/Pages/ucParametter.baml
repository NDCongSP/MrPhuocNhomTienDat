   M S B A M L   `   `   `  ����L  HGiamSatDucNhomApp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null-clr-namespace:DemoPhucThinhDemoPhucThinh  5      Q MEasyScada.Wpf.Controls, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null_Dclr-namespace:EasyScada.Wpf.Controls;assembly=EasyScada.Wpf.ControlsEasyScada.Wpf.Controls 5           DemoPhucThinh.ucParametter   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      -localclr-namespace:DemoPhucThinh     5      YcontrolsDclr-namespace:EasyScada.Wpf.Controls;assembly=EasyScada.Wpf.Controls     5      $	��880��5	      $
��1920��6   .��5      � 
����� �  � RowDefinitions  5   
   �� 5      $��* �6   �� 5      $��* �6   �� 5      $��* �6   �� 5      $��* �6   �� 5      $��* �6   �� 5      $��* �6   �� 5      $��* �6    � ColumnDefinitions 5   
   �� 5      $
��3.2* �6   �� 5      $��* �6   �� 5      $
��2.2* �6   �� 5      $��* �6   .+�5   
   �� $��3q�6   $��0��6   $��0��6(   $��
MÁC NHÔM��68   $��40(�6L   $��Times New Roman)�6Z   $
��Bold"�6w   
���  ��$��Stretch=�5      $��Stretch=�66   $��Center=�6R   $��Center=�6v   
����  �6�   (  "EasyScada.Wpf.Controls.EasyTextBox  5   
   -   5          Name$ 
txtMacNhom��5      $��3q�64   $��0��6?   $��1��6L      StringFormat$
 0.00��6\   $
��0000��6p   $��Stretch=�6|   $��Right=�5       $��Center=�5!      $	��100(�6?   $��Times New Roman)�6N   $
��Bold"�6k   
���  ��
�������5"      �� 5$   
   $��3q�6   $��0��6   $��2��6(   $��ĐƯỜNG KÍNH (inch)��68   $��40(�6U   $��Times New Roman)�6c   $
��Bold"�6�   
���  ��$��Stretch=�5%      $��Stretch=�66   $��Center=�6R   $��Center=�6v   
����  �6�     5&   
   -   5        $ txtDuongKinh��5&      $��3q�65   $��0��6@   $��3��6M   $
��0000��6^   $��Stretch=�6j   $��Right=�6�   $��Center=�5'      $	��100(�6?   $��Times New Roman)�6N   $
��Bold"�6k   
���  ��
�������6�   �� 5)   
   $��3q�6   $��1��6   $��0��6(   $.��(NHIỆT ĐỘ NƯỚC MẶT GIẾNG (oC)��68   $��40(�6_   $��Times New Roman)�6m   $
��Bold"�6�   
���   �$��Stretch=�5*      $��Stretch=�66   $��Right=�6R   $��Center=�6u   &   EasyScada.Wpf.Controls.EasyLabel  5+   
   -   5          Name$ labNDMatGieng��5+         TagPathI EEasyScada.Core, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null%  EasyScada.Core.TagPathConverter$- 'Local Station/Channel1/TNuocMatGieng/Pv 64   $��3q�6f   $��1��6q   $��1��6~   $
��0000��6�   $��Stretch=�6�   $��Right=�6�   $��Center=�5,      $	��100(�6?   $��Times New Roman)�6N   $
��Bold"�6k   
���  ��
�������6�   �� 5.   
   $��3q�6   $��2��6   $��0��6(   $4��.NHIỆT ĐỘ NƯỚC GIẢI NHIỆT MÂM (oC)��68   $��40(�6d   $��Times New Roman)�6r   $
��Bold"�6�   
���   �$��Stretch=�5/      $��Stretch=�66   $��Right=�6R   $��Center=�6u     50   
   -   5        $ labNDNuocGiaiNhietMam��50      $1 +Local Station/Channel1/TNuocGiaiNhietMam/Pv 6<   $��3q�6r   $��2��6}   $��1��6�   $
��0000��6�   $��Stretch=�6�   $��Right=�6�   $��Center=�51      $	��100(�6?   $��Times New Roman)�6N   $
��Bold"�6k   
���  ��
�������6�   �� 53   
   $��3q�6   $��3��6   $��0��6(   $.��(NHIỆT ĐỘ KHÔNG KHÍ TRONG LÒ (oC)��68   $��40(�6c   $��Times New Roman)�6q   $
��Bold"�6�   
���   �$��Stretch=�54      $��Stretch=�66   $��Right=�6R   $��Center=�6u     55   
   -   5        $ labNDKhongKhiTrongLo��55      $0 *Local Station/Channel1/TKhongKhiTrongLo/Pv 6;   $��3q�6p   $��3��6{   $��1��6�   $
��0000��6�   $��Stretch=�6�   $��Right=�6�   $��Center=�56      $	��100(�6?   $��Times New Roman)�6N   $
��Bold"�6k   
���  ��
�������6�   �� 58   
   $��3q�6   $��4��6   $��0��6(   $4��.NHIỆT ĐỘ NƯỚC NHÔM SAU LỔ XẢ (oC)��68   $��40(�6d   $��Times New Roman)�6r   $
��Bold"�6�   
���   �$��Stretch=�59      $��Stretch=�66   $��Right=�6R   $��Center=�6u     5:   
   -   5        $ labNDNhomTaiMiengLo��5:      $0 *Local Station/Channel1/TNuocNhomSauLoXa/Pv 6:   $��3q�6o   $��4��6z   $��1��6�   $
��0000��6�   $��Stretch=�6�   $��Right=�6�   $��Center=�5;      $	��100(�6?   $��Times New Roman)�6N   $
��Bold"�6k   
���  ��
�������6�   �� 5=   
   $��3q�6   $��5��6   $��0��6(   $2��,NHIỆT ĐỘ NƯỚC NHÔM SAU MÁY H2 (oC)��68   $��40(�6e   $��Times New Roman)�6s   $
��Bold"�6�   
���   �$��Stretch=�5>      $��Stretch=�66   $��Right=�6R   $��Center=�6u     5?   
   -   5        $ labNDNhomTruocKhuon��5?      $1 +Local Station/Channel1/TNuocNhomSauMayH2/Pv 6:   $��3q�6p   $��5��6{   $��1��6�   $
��0000��6�   $��Stretch=�6�   $��Right=�6�   $��Center=�5@      $	��100(�6?   $��Times New Roman)�6N   $
��Bold"�6k   
���  ��
�������6�   �� 5B   
   $��3q�6   $��6��6   $��0��6(   $,��&NĐ NƯỚC NHÔM TRÊN CỔ MÂM (oC)��68   $��40(�6`   $��Times New Roman)�6n   $
��Bold"�6�   
���   �$��Stretch=�5C      $��Stretch=�66   $��Right=�6R   $��Center=�6u     5D   
   -   5        $ labNDNuocNhomTrongLo��5D      $2 ,Local Station/Channel1/TNuocNhomTrenCoMam/Pv 6;   $��3q�6r   $��6��6}   $��1��6�   $
��0000��6�   $��Stretch=�6�   $��Right=�6�   $��Center=�5E      $	��100(�6?   $��Times New Roman)�6N   $
��Bold"�6k   
���  ��
�������6�   �� 5H   
   $��3q�6   $��1��6   $��2��6(   $$��TỐC ĐỘ CÂY KHUẤY (v/p)��68   $��40(�6Y   $��Times New Roman)�6g   $
��Bold"�6�   
���   �$��Stretch=�5I      $��Stretch=�66   $��Right=�6R   $��Center=�6u     5J   
   -	   5        $ labTocDoCayKhuay��5J         TagPath$2 ,Local Station/Channel1/Device1/TocDoCayKhuay 69   $
 0.00��6p   $��3q�6�   $��1��6�   $��3��6�   $
��0000��6�   $��Stretch=�6�   $��Right=�6�   $��Center=�5K      $	��100(�6?   $��Times New Roman)�6N   $
��Bold"�6k   
���  ��
�������6�   �� 5M   
   $��3q�6   $��2��6   $��2��6(   $��ÁP KHÍ ARGON (bar)��68   $��40(�6U   $��Times New Roman)�6c   $
��Bold"�6�   
���   �$��Stretch=�5N      $��Stretch=�66   $��Right=�6R   $��Center=�6u     5O   
   -
   5        $ labApKhiNito��5O      $/ )Local Station/Channel1/Device1/ApKhiArgon 65   $
 0.00��6i   $��3q�6}   $��2��6�   $��3��6�   $
��0000��6�   $��Stretch=�6�   $��Right=�6�   $��Center=�5P      $	��100(�6?   $��Times New Roman)�6N   $
��Bold"�6k   
���  ��
�������6�   �� 5R   
   $��3q�6   $��3��6   $��2��6(   $��ÁP LỰC NƯỚC (bar)��68   $��40(�6T   $��Times New Roman)�6b   $
��Bold"�6   
���   �$��Stretch=�5S      $��Stretch=�66   $��Right=�6R   $��Center=�6u     5T   
   -   5        $ labApLucNuoc��5T      $. (Local Station/Channel1/Device1/ApLucNuoc 65   $
 0.00��6h   $��3q�6|   $��3��6�   $��3��6�   $
��0000��6�   $��Stretch=�6�   $��Right=�6�   $��Center=�5U      $	��100(�6?   $��Times New Roman)�6N   $
��Bold"�6k   
���  ��
�������6�   �� 5W   
   $��3q�6   $��4��6   $��2��6(   $#��THỜI GIAN ĐÔNG ĐẶC (s)��68   $��40(�6Y   $��Times New Roman)�6g   $
��Bold"�6�   
���   �$��Stretch=�5X      $��Stretch=�66   $��Right=�6R   $��Center=�6u     5Y   
   -   5        $ labThoiGianDongDac��5Y      $4 .Local Station/Channel1/Device1/ThoiGianDongDac 6;   $��3q�6t   $��4��6   $��3��6�   $
��0000��6�   $��Stretch=�6�   $��Right=�6�   $��Center=�5Z      $	��100(�6?   $��Times New Roman)�6N   $
��Bold"�6k   
���  ��
�������6�   �� 5\   
   $��3q�6   $��5��6   $��2��6(   $%��TỐC ĐỘ XUỐNG MÂM (mm/s)��68   $��40(�6Z   $��Times New Roman)�6h   $
��Bold"�6�   
���   �$��Stretch=�5]      $��Stretch=�66   $��Right=�6R   $��Center=�6u     5^   
   -   5        $ labTocDoXuongMam��5^      $2 ,Local Station/Channel1/Device1/TocDoXuongMam 67      StringFormat$
 0.00��6n   $��3q�6�   $��5��6�   $��3��6�   $
��0000��6�   $��Stretch=�6�   $��Right=�6�   $��Center=�5_      $	��100(�6?   $��Times New Roman)�6N   $
��Bold"�6k   
���  ��
�������6�   �� 5a   
   $��3q�6   $��6��6   $��2��6(   $��CHIỀU DÀI PHÔI (mm)��68   $��40(�6V   $��Times New Roman)�6d   $
��Bold"�6�   
���   �$��Stretch=�5b      $��Stretch=�66   $��Right=�6R   $��Center=�6u     5c   
   -   5        $ labChieuDaiPhoi��5c      $1 +Local Station/Channel1/Device1/ChieuDaiPhoi 66   $��3q�6l   $��6��6w   $��3��6�   $
��0000��6�   $��Stretch=�6�   $��Right=�6�   $��Center=�5d      $	��100(�6?   $��Times New Roman)�6N   $
��Bold"�6k   
���  ��
�������6�   5e      5f      