   M S B A M L   `   `   `  ����C  ?Lab№10, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:Lab_10Lab_10  5   	       Lab_10.WriteMessage   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   &localclr-namespace:Lab_10     5   	     � Title$  WriteMessage��5   	   $	��500��6   $	��300��6+   .��5	      �  � RowDefinitions 5
   
   �� 5      $��80 �6   �� 5      $��* �6   .+�5   
   � $��0��6   .+�5      �� $��Center=�6   $
��Left=�64    �� Orientation$ Vertical=�6O   .+�5      �� -   5        $��Write��5   -   $��50��6=   $��10q�6H   �� 5      -   5         ��Name$ MessageText��5      $	��250��6/   $
��25 0q�6;   5      �� 5      -   5         ��Name$ UserInfo��5      $��Right=�6+   $��Center=�6G   $ 
Horizontal=�6b   .+�5      �� $��50��6   ��6#   ��  �� Path$ Avatar��� 5      $ Vertical=�6   $��10q�64   .+�5      �� ��6    �� $
 Name��� 5      ��6    �� $ Surname�5      5      5      � 5   
   $��1��6   .+�5      &   System.Windows.Controls.DataGrid  -   5          Name$ 	UsersGrid��5         AutoGenerateColumns .     Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn	   Header$	 Id��6)   
   Width5  /System.Windows.Controls.DataGridLengthConverter$
 50 6Q   1  +System.Windows.Controls.DataGridBoundColumn   Binding 65   �� $ Id�6Q     5       $
	 Name��6)   $
 * 6U    67   �� $
 Name�6U     5!      $	 Surname��6)   $
 * 6[    6:   �� $ Surname�6[   5#      5$      5%      5&      