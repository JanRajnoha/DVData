   M S B A M L   `   `   `  ���� 
  DVData    DVData.Result   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     -     � Title$  Výsledky hledání��$	��633��$��484.131��$	��650�� � WindowStartupLocation$ CenterScreen=� � SizeToContent$ WidthAndHeight=�$	��484��$	��403�� � 
ResizeMode$ NoResize=�.��� .+�� -    �Name$ Panel��$	��600��$
��Auto�� � RowDefinitions �� $��* ��� $��60 �.+�� $��0��$
��Auto��.+��� $��Výsledky hledání��$
��Left=�$��	10,14,0,0q�$	��Top=�$��38��$	��171��$��20(�$
��Bold"� � ToolTip$ Výsledky hledání��� $
��Auto��$��10,57,10,10q�$
��Auto=�$
��Auto�� �� -    ��Name$ Clanek1��$��* ��� -   $ Clanek2��$��* �.+�9� -    9�Name$
 Exp1��$��Seznam nalezených filmů��$��10q�$
��Auto��$ Seznam nalezených filmů��$
��Auto��	 9� 
IsExpanded	 . .��� ���	#FFE5E5E5$
��Auto��.+�&   System.Windows.Controls.DataGrid  -   
  Name$
 Films��$��10q�$ Seznam nalezených filmů��$
��Auto��   
IsReadOnly . $	��500��   Columns 0  *System.Windows.Controls.DataGridTextColumn  -   
IDfilm��,  &System.Windows.Controls.DataGridColumn   Header$ ID��   
Visibility$ 	Collapsed=�1  +System.Windows.Controls.DataGridBoundColumn   ClipboardContentBinding Z�   -   	Nazev��$ Název filmu�� Z�   -	   Rok��$ Rok výroby�� Z�  � 	Resources )  #System.Windows.Controls.DataGridRow �� 
TargetType��%   '        �� "  .�-
   9� -   $
 Exp2��$!��Seznam nalezených tvůrců��$��10q�$
��Auto��$
��Auto��$��1��$! Seznam nalezených tvůrců��	 . .��� ���	#FFE5E5E5$
��Auto��.+�  -   $
 Actors��$��10q�$
��Auto��$! Seznam nalezených tvůrců�� . $	��500��   -   	IDact��$ Rok výroby��$ 	Collapsed=� Z�   -   	Jmeno��$ Jméno tvůrce�� Z�   -   	Prace��$ 
Povolání�� Z�   -   Narozen��$ Rok narození�� Z� �� $��Center=�$��41��$��0,0,0,10q�$��Bottom=�$
��Auto�� �� Orientation$ 
Horizontal=�.+��� -    ��Name$ Accept��$��Vybrat��$
��Left=�$��0q�$��Bottom=�$	��136��$��40��$ Vybrat a zobarzit kartu�� �� 	IsDefault . �� -   $��Zrušit��$
��Left=�$��Bottom=�$	��136��$��40��$ Zrušit vyhledávání�� �� IsCancel . $��15,0,0,0q�