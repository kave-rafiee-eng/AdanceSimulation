   M S B A M L   `   `   `  ���� L  HElavatorSimilator, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullA%clr-namespace:ElavatorSimilator.ViewsElavatorSimilator.Views  )    #ElavatorSimilator.Views.ButtonsView   W SPresentationCore, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     7local%clr-namespace:ElavatorSimilator.Views     .���   � RowDefinitions  �� $��2* ��� $	��10* �.+�� $��0��  �� $
��Auto ��� $
��Auto ��� $
��Auto � � ColumnDefinitions �� $��* ��� $��* ��� $��* ��� $��* ��� $��* �.+��� $��0��$��0��$
��From��$��Center=��� $��0��$��1��$��Floor��$��Center=��� $��0��$��2��$��Door1��$��Center=��� $��0��$��3��$��Door2��$��Center=��� $��0��$��4��$��Door3��$��Center=��� -    ��Name$
 From��$��1��$��0��$
��AUTO��$��5q�.@��� $
{�True�� �� 
IsSelected$
 True��.��Main�� .��Cabin�� .��Engine�� -    ��Name$ Floor��$��1��$��1�� �� 	MaxLength$ 5��$
��AUTO��$��5q��� -   $ Door1��$��1��$��2��$
��AUTO��$��5q�.@��� $
{�True��$
 True��.��--�� .��En�� -   $ Door2��$��1��$��3��$
��AUTO��$��5q�.@��� $
{�True��$
 True��.��--�� .��En�� -   $ Door3��$��1��$��4��$
��AUTO��$��5q�.@��� $
{�True��$
 True��.��--�� .��En�� -   $��2��$��0��
��� ���$	��Uni��$��5q�
 � Tag$ 0���� -   $��2��$��1��
��� ���$	��VIP��$��5q�$ 1���� -   $��2��$��2��
��� ���$��UP��$��5q�$ 2���� -	   $��2��$��3��
��� ���$
��Down��$��5q�$ 3���� $��1��$
��Auto=�.���� $��10q�
����İ�.+��� ���� *Floors+���� .R���  �� Orientation$ 
Horizontal=�$��5q�.+��� ���� *Groups+���� .R��� 
���   �$��1q� �� CornerRadius$ 2��	 �� Padding$	 2q�$��2q�
�������._��� $ 
Horizontal=�.+��� ���� *	Buttons+���� .R��� $��1q�$��1q�$��14(����� *Info.Display+���� *ButtonColor+���� *ClickCommand+���� .R��� $ 
Horizontal=����� .R��� $ 
Horizontal=�