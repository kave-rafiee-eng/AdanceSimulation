   M S B A M L   `   `   `  ����L  HElavatorSimilator, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullA%clr-namespace:ElavatorSimilator.ViewsElavatorSimilator.Views  5      +    %ElavatorSimilator.Views.CallsDataGrid   5      W SPresentationCore, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      7local%clr-namespace:ElavatorSimilator.Views     5      .��5
      � .+�5   
   &   System.Windows.Controls.DataGrid      AutoGenerateColumns$  False��5         HeadersVisibility$ Column=�5         
IsReadOnly$
 True��5      $��10q�5         RowBackground
 �����   AlternatingRowBackground �#F9F9F9   GridLinesVisibility$ 
Horizontal=�5         HorizontalGridLinesBrush �#DDDDDD   ColumnHeaderHeight$ 30Q�5         	RowHeight$ 28Q�5      $��14(�5      $��Segoe UI)�5      ���#CCCCCC$��1q�5      	   SelectionMode$	 Single=�5      
   SelectionUnit$
 FullRow=�5      ��5      �� *Calls+   Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header$ AD��6%   1  +System.Windows.Controls.DataGridBoundColumn   Binding 61   �� *	advance+  5      $
 From��6%    63   �� *From+4  .System.Windows.Controls.DataGridTemplateColumn  5       $ Floor��6)      CellTemplate 5!      �� 5"      .R�5#      �� 
����ح�
����  � �� Padding$	 4,0q�5&      $
��Bold"�5'       �� TextAlignment$ Center=�5(      ��5#   (   �� *Floor+5(      5)      5+        5,      $ D1��6%    61   �� *door1+  5-      $ D2��6%    61   �� *door2+  5.      $ D3��6%    61   �� *door3+  5/      $	 Dir��6)    50      �� 51      .R�52      �� 
�������
���   �$	 4,0q�55      $ Center=�56      ��52   (   �� *dir+56      57      59        5:      $ Timer��6%    64   �� *Timer+5<      5=      5>      