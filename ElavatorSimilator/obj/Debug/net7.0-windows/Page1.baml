   M S B A M L   `   `   `  ����L  HElavatorSimilator, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5clr-namespace:ElavatorSimilatorElavatorSimilator  5      U QLiveCharts.Wpf, Version=0.9.7.0, Culture=neutral, PublicKeyToken=0bc1f845d1ebb8dfG4clr-namespace:LiveCharts.Wpf;assembly=LiveCharts.WpfLiveCharts.Wpf 5          ElavatorSimilator.Page1   5      W SPresentationCore, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      1localclr-namespace:ElavatorSimilator     5      Dlvc4clr-namespace:LiveCharts.Wpf;assembly=LiveCharts.Wpf     5        N� Title$  Page1��5
      .��5      �  � RowDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $��* �6    � ColumnDefinitions 5   
   �� 5      $��* �6   �� 5      $��* �6   .+�5   
   �� $��1��6   $��1��6"   .+�5      #  LiveCharts.Wpf.CartesianChart  -   5        $��MyChart��5   !   $	��200��60   �� 5      -   5         ��Name$ textBoxOutput��5      
�������" �� VerticalScrollBarVisibility$
 Auto=�5        �� AcceptsReturn$
 True��5!       �� TextWrapping$
 Wrap=�5"      $	��100��5#      5$      �� 5'   
   -   5        $ conter��5'   /   $��0��6   $��0��6   
����ح�$
 Auto=�5(   
   $
 True��5)   
   $
 Wrap=�5*   
   $	��sss��5+   
   $��20��5,   
   �� 5.   
   $��1��6   $��0��6"   $��10q�62   .+�50      �� $��
Calls Data��6   $��5q�6+   .��51      &   System.Windows.Controls.DataGrid  -   5        $��DataGridCalls��51      $	��150��60   $��5q�6=   52      �� 54      $��Simple Data��6   $��5q�6,   .��55        -   5        $��DataGridSimpleData��55      $	��150��65   $��5q�6B   56      58      5;      5<      