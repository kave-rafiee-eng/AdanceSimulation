   M S B A M L   `   `   `  ���� L  HElavatorSimilator, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullA%clr-namespace:ElavatorSimilator.ViewsElavatorSimilator.Views  +    %ElavatorSimilator.Views.CallsDataGrid   W SPresentationCore, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     7local%clr-namespace:ElavatorSimilator.Views     .��� .+�&   System.Windows.Controls.DataGrid      AutoGenerateColumns$  False��   HeadersVisibility$ Column=�   
IsReadOnly$
 True��$��10q�   RowBackground
 �����   AlternatingRowBackground �#F9F9F9   GridLinesVisibility$ 
Horizontal=�   HorizontalGridLinesBrush �#DDDDDD   ColumnHeaderHeight$ 30Q�   	RowHeight$ 28Q�$��14(�$��Segoe UI)����#CCCCCC$��1q�	   SelectionMode$	 Single=�
   SelectionUnit$
 FullRow=����� *Calls+   Columns 0  *System.Windows.Controls.DataGridTextColumn  ,  &System.Windows.Controls.DataGridColumn   Header$ AD��1  +System.Windows.Controls.DataGridBoundColumn   Binding �� *	advance+  $
 From�� �� *From+4  .System.Windows.Controls.DataGridTemplateColumn  $ Floor��   CellTemplate �� .R��� 
����ح�
����  � �� Padding$	 4,0q�$
��Bold"� �� TextAlignment$ Center=����� *Floor+  $ D1�� �� *door1+  $ D2�� �� *door2+  $ D3�� �� *door3+  $	 Dir�� �� .R��� 
�������
���   �$	 4,0q�$ Center=����� *dir+  $ Timer�� �� *Timer+