   M S B A M L   `   `   `  ����@  <Gauge, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:GaugeGauge  5      U QLiveCharts.Wpf, Version=0.9.7.0, Culture=neutral, PublicKeyToken=0bc1f845d1ebb8dfG4clr-namespace:LiveCharts.Wpf;assembly=LiveCharts.WpfLiveCharts.Wpf 5          Gauge.easyRealTimeTrend   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      %localclr-namespace:Gauge     5      Dlvc4clr-namespace:LiveCharts.Wpf;assembly=LiveCharts.Wpf     5      .��5
      � .+�5   
   #  LiveCharts.Wpf.CartesianChart  -   5           Name$  realTimeChart��5      $��1��64   $��5q�6A   $��20(�5      
���   �&   LiveCharts.Wpf.Charts.Base.Chart   AnimationsSpeed$ 0:0:0.5h�5         DisableAnimations .    	Hoverable .  
�������   LegendLocation$	 Top=�5   0      ChartLegend 5      "  LiveCharts.Wpf.DefaultLegend  5         
BulletSize$ 20Q�6$   
���  ��64      DataTooltip 5       #  LiveCharts.Wpf.DefaultTooltip  5!         
BulletSize$ 20Q�6%   
�������65   	   AxisX	 5%        LiveCharts.Wpf.Axis  -   5        
  Name$
 xLable��5%         
FontFamily$ Times New Roman)�6+      FontSize$ 20Q�6H      
Foreground
 �   �   LabelsRotation$	 -45Q�5*         Title$
 Time��5+         LabelFormatter 5&      �� *DateTimeFormatter+   MaxValue 5'      �� *	AxisMax+   MinValue 5(      �� *	AxisMin+   Unit 5)      �� *
AxisUnit+   	Separator 5,        LiveCharts.Wpf.Separator  5-         StrokeThickness$ 1Q�6B      StrokeDashArray$ 1R�6V      Step 6(   �� *
AxisStep+   Stroke 5.      �� 5/   "    �� Color$ #404F56��62   51      53         AxisY 57        -   5        $
 yLabel��57      $ Times New Roman)�6+   $ 20Q�6H   
 �   �$ Values��58       6+   �� *ValueFormat+ 6R   �� *
AxisYMax+ 6p   �� *
AxisYMin+ 59        5:      $ 1Q�6(   $ 1R�6<    5;      �� 5<   "   $ #404F56��62   5>      5@      5B      5C      5D      