   M S B A M L   `   `   `  ����L  HElavatorSimilator, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5clr-namespace:ElavatorSimilatorElavatorSimilator  5   	   U QLiveCharts.Wpf, Version=0.9.7.0, Culture=neutral, PublicKeyToken=0bc1f845d1ebb8dfG4clr-namespace:LiveCharts.Wpf;assembly=LiveCharts.WpfLiveCharts.Wpf 5   	   A%clr-namespace:ElavatorSimilator.ViewsElavatorSimilator.Views  5
      "    ElavatorSimilator.MainWindow   5   	   8d2http://schemas.microsoft.com/expression/blend/2008  5   	   Bmc;http://schemas.openxmlformats.org/markup-compatibility/2006  5   	   )localclr-namespace:ElavatorSimilator  5   	   <lvc4clr-namespace:LiveCharts.Wpf;assembly=LiveCharts.Wpf  5   	   W SPresentationCore, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5	   	   7Views%clr-namespace:ElavatorSimilator.Views     5
        � Title$  
MainWindow��5   	   $	��600��6   $	��800��6)   .��5      �  � RowDefinitions 5   
   �� 5      $	��20* �6   �� 5      $
��100* �6   .+�5   
   �� $��0��6   $��0��6"    �� Orientation$ 
Horizontal=�62   $��10q�6L   .+�5      d� -   5         d�Name$ MenuToggleButton��5      $��☰ Menu��65   $��80��6F   $
��auto��6Q   $��Center=�6_   $	��Top=�6|   $��10q�6�   �� 5      $��0��6   $��1��6&   $ 
Horizontal=�66   $
��Left=�6O   $��10q�6j   .+�5      ,   &ElavatorSimilator.Views.SerialSelector  -   5          Name$ serialSelector��5   '   $
��Left=�6?   $	��Top=�6Z   5      5       � 5$   
   $��0��6   $��Bottom=�5%       � 	StaysOpen$ False��5&       � PlacementTarget 5$      ��  �� ElementName$ MenuToggleButton����5'      �� *	IsChecked+$ MenuToggleButton�� �� Mode$ TwoWay=�.��5(      �� 
�������
�������$��1q�6;   $	��200��6O   $	��300��6[   ._�5)      R� -   5        $��MenuTreeView��5)      .@�5*      Q� $��Calls��6#   
	 � Tag$	 Calls��62   Q� 5+      $��Location��6#   $	 Location��65   Q� 5,      $	��BTn��6#   $		 BTn��60   Q� 5-      $��بخش تنظیمات��6#   .@�5.      Q� $��تنظیمات عمومی��6'   $	 SettingsPage��6>   Q� 5/      $#��تنظیمات پیشرفته��6'   $	 AdvancedSettingsPage��6@   50      51      52      54       � 57   
   -   5        
  �Name$
 	MainFrame��57      $��1��6     � NavigationUIVisibility$ Hidden=�60   59      5;      