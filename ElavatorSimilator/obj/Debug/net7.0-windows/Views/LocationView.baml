   M S B A M L   `   `   `  ����L  HElavatorSimilator, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullA%clr-namespace:ElavatorSimilator.ViewsElavatorSimilator.Views  5      *    $ElavatorSimilator.Views.LocationView   5      W SPresentationCore, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      7local%clr-namespace:ElavatorSimilator.Views     5      .��5
      �   � RowDefinitions  5   
   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   .+�5   
   �� $��0��6    �� Orientation$ 
Horizontal=�6#   .+�5      �� $��Ferq = ��6   6)   �� 5      ��6   �� *Ferq+60   �� 5      $��Loc = ��6   6(   �� 5      ��6   �� *
LocInMeter+66   5      �� 5   
   $��1��6   $ 
Horizontal=�6"   .+�5      �� -   5         ��Name$ 
SelectMode��5      $
��AUTO��6,   $��5q�69   @�5      �� 5      $
{�True��6#    �� 
IsSelected$
 True��64   .��6F   Logic6M   �� 5       $
{�True��6#   .��65   	Encoder6>   5"      �� 5$      -   5        
��� ���$
��Read��5$   7   $
��AUTO��6F   $��5q�6T   6b   5&      �� 5(   
   -   5         ��Name$ Elevator��5(      $��2��6#   $	��400��60   $	��200��6=   
�������$
��Left=�6a   .+�5*      �� $��90��6   $
��12.5��6#   
���  ��
���   �$��1��5+       �� Left$ 55��5,      
 �� Top 5-      �� *Y+�� 5/      $	��100��6   $��50��6$   $ 50��50      
����  �$��4��51       52      �� *Y_Goal+�� 54      $	��100��6   $��50��6$   $ 50��55      
��� � �$��4��56       57      �� *	Y_PreGoal+�� 5;      ��6   �� *
_ENC_1CFUP+��5<      �� 5=      .R�5>      �� 5?      ��5B      �� 5C      .R�5E      �� 	 �� X1$ 50��6   	 �� X2$	 180��5F      
���  ��$��1��5G   (   		 �� Y1	 5E   '   �� *	Y_1CFUP+	
 �� Y2
 5F   $   �� *	Y_1CFUP+5G   (   5I      5K      �� 5M      ��6   �� *
_ENC_Floor+��5N      �� 5O      .R�5P      �� 5Q      ��5T      �� 5U      .R�5W      �� $ 30��6   $	 150��5X      
���   �$��2��5Y   *   	 5W   '   �� *	Y_Floor+
 5X   $   �� *	Y_Floor+5Y   *   5[      5]      �� 5b      ��6   �� *_ENC_Floor_Marker+��5c      �� 5d      .R�5e      �� 5f      ��5i      �� 5j       �� 
TargetType" ��6   .�5k      ��  �� Property �@��Left �� Value$ 20��68   �� 5l       �@��Top 67   �� *Y_Floor_Marker+5m      ��5p      �� 5q      .R�5r      �� $��10(�6E   ��6    �� *STR_Floor_Marker+6E   5s      5u      �� 5x      ��6   �� *_ENC_1CFUP_Marker+��5y      �� 5z      .R�5{      �� 5|      ��5      �� 5�      " ��6   .�5�      ��  �@��Left$	 160��68   �� 5�       �@��Top 67   �� *Y_1CFUP_Marker+5�      ��5�      �� 5�      .R�5�      �� 
���  ��$��10(�6V   ��61   �� *STR_1CFUP_Marker+6V   5�      5�      5�      5�      5�      