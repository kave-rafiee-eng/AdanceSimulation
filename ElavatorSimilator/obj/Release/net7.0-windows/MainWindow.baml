   M S B A M L   `   `   `  ���� L  HElavatorSimilator, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5clr-namespace:ElavatorSimilatorElavatorSimilator  U QLiveCharts.Wpf, Version=0.9.7.0, Culture=neutral, PublicKeyToken=0bc1f845d1ebb8dfG4clr-namespace:LiveCharts.Wpf;assembly=LiveCharts.WpfLiveCharts.Wpf A%clr-namespace:ElavatorSimilator.ViewsElavatorSimilator.Views  "    ElavatorSimilator.MainWindow   8d2http://schemas.microsoft.com/expression/blend/2008  Bmc;http://schemas.openxmlformats.org/markup-compatibility/2006  )localclr-namespace:ElavatorSimilator  <lvc4clr-namespace:LiveCharts.Wpf;assembly=LiveCharts.Wpf  W SPresentationCore, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     7Views%clr-namespace:ElavatorSimilator.Views       � Title$  
MainWindow��$	��600��$	��800��.���  � RowDefinitions �� $	��20* ��� $
��100* �.+��� $��0��$��0�� �� Orientation$ 
Horizontal=�$��10q�.+�d� -    d�Name$ MenuToggleButton��$��☰ Menu��$��80��$
��auto��$��Center=�$	��Top=�$��10q��� $��0��$��1��$ 
Horizontal=�$
��Left=�$��10q�.+�,   &ElavatorSimilator.Views.SerialSelector  -     Name$ serialSelector��$
��Left=�$	��Top=�� $��0��$��Bottom=� � 	StaysOpen$ False�� � PlacementTarget ��  �� ElementName$ MenuToggleButton������ *	IsChecked+$ MenuToggleButton�� �� Mode$ TwoWay=�.���� 
�������
�������$��1q�$	��200��$	��300��._�R� -   $��MenuTreeView��.@�Q� $��Calls��
	 � Tag$	 Calls��Q� $��Location��$	 Location��Q� $	��BTn��$		 BTn��Q� $��بخش تنظیمات��.@�Q� $��تنظیمات عمومی��$	 SettingsPage��Q� $#��تنظیمات پیشرفته��$	 AdvancedSettingsPage�� � -   
  �Name$
 	MainFrame��$��1��  � NavigationUIVisibility$ Hidden=�