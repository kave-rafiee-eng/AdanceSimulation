   M S B A M L   `   `   `  ���� L  HElavatorSimilator, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5clr-namespace:ElavatorSimilatorElavatorSimilator  U QLiveCharts.Wpf, Version=0.9.8.0, Culture=neutral, PublicKeyToken=0bc1f845d1ebb8dfG4clr-namespace:LiveCharts.Wpf;assembly=LiveCharts.WpfLiveCharts.Wpf "    ElavatorSimilator.MainWindow   8d2http://schemas.microsoft.com/expression/blend/2008  Bmc;http://schemas.openxmlformats.org/markup-compatibility/2006  )localclr-namespace:ElavatorSimilator  <lvc4clr-namespace:LiveCharts.Wpf;assembly=LiveCharts.Wpf  W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089K GUno.Xaml, Version=255.255.255.255, Culture=neutral, PublicKeyToken=null<x,http://schemas.microsoft.com/winfx/2006/xaml        � Title$  
MainWindow��$	��450��$	��800��.���  � RowDefinitions �� $
��200* ��� $
��100* �.+�d� -    d�Name$ MenuToggleButton��$��☰ Menu��$��80��$
��auto��$��Center=�$	��Top=�$��10q��� $��1��$	��300��
�������.+��� $	��100��$��60��
���  ��z�T� �� $��10��$��10��
����iA�
���   �$��2��z���  �� Angle$ 4Q� J� Effect 3  -System.Windows.Media.Effects.DropShadowEffect     ShadowDepth$ 5Q�   Color$ Black��   
BlurRadius$ 10Q�A� -   $��MyCircle��$��60��$��60��
��� E�� �� Left$	 200��
	 �� Top$	 60��
 � Triggers
 :�  :� RoutedEvent$ Ellipse.Loaded��.[��� .���� .��W�  �� TargetProperty$ (Canvas.Left)� W� From 200	 W� To 350 g� Duration$ 0:0:2D� g� AutoReverse$
 True�� g� RepeatBehavior$ Forever��F� 
��� d �$��3��
������$ 80��$		 180��)����        Ӏ�� yl� �� �����	�� $��20(�$
��Bold"�
���  ��$	 120��$		 250��$��WPF Graphics!�� J� RenderTransformOrigin$ 0.5,0.5&�z���  �� ScaleX$ 1Q� �� ScaleY$ 1Q�
 :� $ TextBlock.Loaded��.[��� .���� .��W� $- 'RenderTransform.(ScaleTransform.ScaleX)� 1 1.5$ 0:0:1.5D�$
 True��$ Forever��W� $- 'RenderTransform.(ScaleTransform.ScaleY)� 1 1.5$ 0:0:1.5D�$
 True��$ Forever���� $��0��$��24(�$��10q����� *
PersonName+ �� Mode$ TwoWay=� � -     �Name$ 	MainFrame��$��1��  � NavigationUIVisibility$ Hidden=�