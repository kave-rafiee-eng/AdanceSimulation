   M S B A M L   `   `   `  ���� L  HElavatorSimilator, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5clr-namespace:ElavatorSimilatorElavatorSimilator  U QLiveCharts.Wpf, Version=0.9.8.0, Culture=neutral, PublicKeyToken=0bc1f845d1ebb8dfG4clr-namespace:LiveCharts.Wpf;assembly=LiveCharts.WpfLiveCharts.Wpf     ElavatorSimilator.Page1   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089K GUno.Xaml, Version=255.255.255.255, Culture=neutral, PublicKeyToken=null<x,http://schemas.microsoft.com/winfx/2006/xaml      Lmc;http://schemas.openxmlformats.org/markup-compatibility/2006      Bd2http://schemas.microsoft.com/expression/blend/2008      3localclr-namespace:ElavatorSimilator      Flvc4clr-namespace:LiveCharts.Wpf;assembly=LiveCharts.Wpf        N� Title$  Page1��.���  � RowDefinitions �� $
��Auto ��� $��* � � ColumnDefinitions �� $��* ��� $��* �.+��� $��1��$��1��.+�#  LiveCharts.Wpf.CartesianChart  -   $��MyChart��$	��200���� -    ��Name$ textBoxOutput��
�������" �� VerticalScrollBarVisibility$
 Auto=� �� AcceptsReturn$
 True�� �� TextWrapping$
 Wrap=�$	��100���� $��0��$��1�� �� Orientation$ 
Horizontal=�$
��Left=�$��10q�.+�-   'ElavatorSimilator.SerialSelectorControl  -     Name$ serialControl��$
��Left=�$	��Top=��� -   $ conter��$��0��$��0��
����ح�$
 Auto=�$
 True��$
 Wrap=�$	��sss��$��20���� $��1��$��0��.+��� $��
Calls Data��$
��Bold"�$��5q�&   System.Windows.Controls.DataGrid  -   $��DataGridCalls��$	��150��$��5q��� $��Simple Data��$
��Bold"�$��5q�  -   $��DataGridSimpleData��$	��150��$��5q�