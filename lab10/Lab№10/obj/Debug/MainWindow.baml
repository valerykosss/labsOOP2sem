   M S B A M L   `   `   `  ����C  ?Lab№10, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:Lab_10Lab_10  5   	       Lab_10.MainWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   &localclr-namespace:Lab_10     5   	     � Title$  
MainWindow��5   	   $	��500��6   $	��800��6)   .��5	      �  � RowDefinitions 5
   
   �� 5      $��80 �6   �� 5      $��* �6   .+�5   
   � $��0��6   .+�5      ��  �� Orientation$ 
Horizontal=�6   .+�5      �� $��Center=�6   $
��Left=�68   $ Vertical=�6S   .+�5      �� -   5        $
��Edit��5   0   $��50��6?   $��10q�6J   �� 5      -   5         ��Name$ EditText��5      $	��100��60   5      �� 5      $��Center=�6   .+�5      �� -   5        $��Delete��5   2   $��50��6C   $��10q�6N   5      �� 5      $��Center=�6   .+�5      �� -   5        $��Write��5   1   $��50��6A   $��10q�6L   5      �� 5      $��Center=�6   .+�5      �� -   5        $��Refresh��5   3   $��50��6E   $��10q�6P   5      �� 5      $��Center=�6   $ 
Horizontal=�68   .+�5      �� -   5        $
��Undo��5   0   $��50��6?   $��10 0 0 0q�6J   �� 5      -   5        $
��Redo��5   0   $��50��6?   $��0 0 10 0q�6J   5       5!      �� 5#      -   5         ��Name$ UserInfo��5#      $��Right=�6+   $��Center=�6G   $ 
Horizontal=�6b   .+�5$      �� $��50��6   ��6#   ��  �� Path$ Avatar��� 5%      $ Vertical=�6   $��10q�64   .+�5&      �� ��6    �� $
 Name��� 5'      ��6    �� $ Surname�5(      5)      5*      � 5+   
   $��1��6   .+�5,      &   System.Windows.Controls.DataGrid  -	   5          Name$ MessagesGrid��5,         AutoGenerateColumns .     Columns 52      0  *System.Windows.Controls.DataGridTextColumn  53      ,  &System.Windows.Controls.DataGridColumn	   Header$
	 From��6)   
   Width5  /System.Windows.Controls.DataGridLengthConverter$	
 100 6W   1  +System.Windows.Controls.DataGridBoundColumn   Binding 67   �� $ Sender�6W     54      $	 To��6)   $	
 100 6X    65   �� $ 	Retriever�6X     55      $	 Message��6)   $
 * 6X    6:   �� $
 Text�6X   57      58      59      5:      