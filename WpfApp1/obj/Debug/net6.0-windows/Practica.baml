   M S B A M L   `   `   `  ����B  >WpfApp1, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null!clr-namespace:WpfApp1WpfApp1  5   	       WpfApp1.Practica   5   	   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      5   	   R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   'localclr-namespace:WpfApp1     5   	     � Title$8  2Выбор практических заданий��5   	   $	��450��6,   $	��500��69   .��5	      � .+�5
   
   �� .+�5      ��  �� Orientation$ 
Horizontal=�6   .+�5      �� $��Название:��6   �� 5      $��70��63   ��6   �� *NameP+63   �� 5      $��ВЫБРАТЬ��6   $��Right=�6N   $��70��6j   ��6+   ��  �� Path$ 	PrCommand�6j   5      &   System.Windows.Controls.DataGrid  5      -   5          Name$ dataGridLog��5         AutoGenerateColumns$ False��6K      
IsReadOnly$
 True��6g   $	��500��6y   $
��Left=�6�   ��6,   �� *PrList+ �� SelectedItem 6�   �� $ SelectP� �� Mode$ TwoWay=�   Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn	   Header$		 №��6)   
   Width5  /System.Windows.Controls.DataGridLengthConverter$

 0.5* 64   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6A   �� $
 IdPr�6a     5      $	 Название��6)   $
 * 6;    6E   �� $
 Name�6e   5      5      5      5      