   M S B A M L   `   `   `  ����
  DVData    DVData.Result   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   -   5          � Title$  Výsledky hledání��5   	   $	��633��6"   $��484.131��6/   $	��650��6?    � WindowStartupLocation$ CenterScreen=�6O    � SizeToContent$ WidthAndHeight=�6t   $	��484��6�   $	��403��6�    � 
ResizeMode$ NoResize=�6�   .��5      � .+�5   
   � -   5         �Name$ Panel��5      $	��600��6   $
��Auto��6+    � RowDefinitions 5      �� 5      $��* �6    �� 5	      $��60 �6    .+�5      � $��0��6   $
��Auto��6    .+�5      �� $��Výsledky hledání��6   $
��Left=�63   $��	10,14,0,0q�6N   $	��Top=�6a   $��38��6y   $	��171��6�   $��20(�6�   $
��Bold"�6�    � ToolTip$ Výsledky hledání��6�   � 5      $
��Auto��6   $��10,57,10,10q�6%   $
��Auto=�6:   $
��Auto��6l    5      �� 5      -   5         ��Name$ Clanek1��5   (   $��* �69   �� 5      -   5        $ Clanek2��5   (   $��* �69   .+�5      9� -   5         9�Name$
 Exp1��5      $��Seznam nalezených filmů��6-   $��10q�6N   $
��Auto��6Z   $ Seznam nalezených filmů��6h   $
��Auto��6�   	 9� 
IsExpanded	 . .��5      � ���	#FFE5E5E5$
��Auto��66   .+�5      &   System.Windows.Controls.DataGrid  -   5        
  Name$
 Films��5   '   $��10q�66   $ Seznam nalezených filmů��6B   $
��Auto��6}      
IsReadOnly . $	��500��6�      Columns 5   "   0  *System.Windows.Controls.DataGridTextColumn  5   &   -   5        
IDfilm��,  &System.Windows.Controls.DataGridColumn   Header$ ID��5   l      
Visibility$ 	Collapsed=�6x   1  +System.Windows.Controls.DataGridBoundColumn   ClipboardContentBinding 6I   Z� 6x     5   &   -   5        	Nazev��$ Název filmu��5   k    6H   Z� 6k     5   &   -	   5        Rok��$ Rok výroby��5   i    6F   Z� 6i    � 	Resources 5   "   )  #System.Windows.Controls.DataGridRow �� 
TargetType��%E   '        �� 5   &   "  6,   .�5   *   -
   5        5   '   5   #   5      5       5!      9� 5"      -   5        $
 Exp2��5"      $!��Seznam nalezených tvůrců��6-   $��10q�6O   $
��Auto��6[   $
��Auto��6h   $��1��6v   $! Seznam nalezených tvůrců��6�   	 . .��5#      � ���	#FFE5E5E5$
��Auto��66   .+�5$        -   5        $
 Actors��5$   '   $��10q�67   $
��Auto��6C   $! Seznam nalezených tvůrců��6i    . $	��500��6�    5%   "     5&   &   -   5        	IDact��$ Rok výroby��5&   k   $ 	Collapsed=�6    6H   Z� 6     5'   &   -   5        	Jmeno��$ Jméno tvůrce��5'   k    6H   Z� 6k     5(   &   -   5        	Prace��$ 
Povolání��5(   k    6H   Z� 6k     5)   &   -   5        Narozen��$ Rok narození��5)   m    6J   Z� 6m   5+      5,      5-      5.      5/      50      �� 51   
   $��Center=�6   $��41��62   $��0,0,0,10q�6>   $��Bottom=�6P   $
��Auto��6k    �� Orientation$ 
Horizontal=�6x   .+�52      �� -   5         ��Name$ Accept��52      $��Vybrat��6%   $
��Left=�66   $��0q�6Q   $��Bottom=�6\   $	��136��6w   $��40��6�   $ Vybrat a zobarzit kartu��6�    �� 	IsDefault . 6�   �� 53      -   5        $��Zrušit��53      $
��Left=�6&   $��Bottom=�6A   $	��136��6\   $��40��6h   $ Zrušit vyhledávání��6t    �� IsCancel . $��15,0,0,0q�6�   6�   54      55      56      