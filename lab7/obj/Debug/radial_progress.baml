   M S B A M L   `   `   `  ����?  ;lab7, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:lab7lab7  5          lab7.radial_progress   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      $localclr-namespace:lab7     5        � 	Resources  5	         ProgressBarAnimation �� 
TargetName �� TargetProperty g� Duration )� PathGeometry �� KeyTime �� Value��%�  &	        �� 5   
   -   5        $	 arc��5      .��5      )� $ Point�6&   $ 0:0:20D�6H    5      B� 5      $o��iM 0 -100 A 100 100 0 0 1 0 100                                                     A 100 100 0 0 1 0 -100C�6#   5      �� 5      $ 
IsLargeArc�6-   $ 0:0:20D�5   -   .p�5      s� $ 0:0:0��6*    .  5   *   s� 5      $ 0:0:10��6*    . 5   *   5      5      5      .��5      � .+�5"   
   �� .+�5#      F� -   5         F�Name$ progressPath��5#      
������ ���#FEF200$��20��5&       �� StrokeStartLineCap$
 Flat=�5'      	 �� StrokeEndLineCap$
	 Flat=�5(      
 �� StrokeLineJoin$
 Round=�5)      ��5*      B� 5+      .��5,      E�  E� 
StartPoint$ 0 -100&�6%    E� IsClosed .  .��5.      ��  �� Point$ 0 -100&�6*   �� 5/      -   5        arc�� �� Size$ 100 100��50   )    �� 
IsLargeArc .  �� SweepDirection$ 	Clockwise=�52   )   53      54       J� Effect 56      3  -System.Windows.Media.Effects.DropShadowEffect  57         
BlurRadius$ 50Q�6'      ShadowDepth$ 2Q�58   '      	Direction$	 -90Q�59   '      Color$ #FEF200��5:   '   5<      5=      5?      5@      