   M S B A M L   `   `   `  ����B  >WpfApp1, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null!clr-namespace:WpfApp1WpfApp1  5   	       WpfApp1.Robot   5   	   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      5   	   R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   'localclr-namespace:WpfApp1     5   	     � Title$  Выбор робота��5   	   $	��800��6   $	��900��6+   .��5	      � .+�5
   
   �� .+�5      ��  �� Orientation$ 
Horizontal=�6   .+�5      �� $��Название:��6   �� 5      $��70��62   ��6   �� *Name+62   �� 5      $��ВЫБРАТЬ��6   $��Right=�6Q   $��70��6m   ��6+   ��  �� Path$ RobotCommand�6m   5      &   System.Windows.Controls.DataGrid  5      -   5          Name$ dataGridLog��5         AutoGenerateColumns$ False��6N      
IsReadOnly$
 True��6j   $	��900��6|   $
��Left=�6�   ��6,   �� *	RobotList+ �� SelectedItem 6�   �� $ SelectR� �� Mode$ TwoWay=�   Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn	   Header$		 №��6)   
   Width5  /System.Windows.Controls.DataGridLengthConverter$

 0.5* 64   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6A   �� $ Id�6_     5      $	 Название��6)   $
 * 6;    6E   �� $
 Name�6e     5      $	 Механизм��6)   $
 * 6;    6E   �� $ 	Mechanism�6j     5      $,	 &Грузоподъемность, кг��6)   $
 * 6G    6Q   �� $ G�6n     5      $+	 %Степени подвижности��6)   $
 * 6F    6P   �� $ N�6m     5      $<	 6Рабочее давнение воздуха, МПа��6)   $
 * 6P    6Z   �� $ P�6w     5      $"	 Погрешность, мм��6)   $
 * 6B    6L   �� $ Delta�6m     5      $-	 'Макс. УП ротации, град��6)   $
 * 6I    6S   �� $	 R_c�6r     5      $)	 #Макс. УП сгиба, град��6)   $
 * 6G    6Q   �� $	 R_s�6p     5      $/	 )Макс. УП поворота, град��6)   $
 * 6J    6T   �� $	 R_p�6s     5      $6	 0Макс. верт. перемещение, мм��6)   $
 * 6N    6X   �� $	 L_v�6w     5      $4	 .Макс. гор. перемещение, мм��6)   $
 * 6M    6W   �� $	 L_h�6v     5      $2	 ,Масса стойки управления��6)   $
 * 6J    6T   �� $	 W_s�6s     5      $)	 #Масса манипулятора��6)   $
 * 6E    6O   �� $	 W_m�6n   5"      5$      5%      5&      