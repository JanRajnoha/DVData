   M S B A M L   `   `   `  ����
  DVData    
DVData.Add   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   -   5          �Name$  
Add_client��5   	    � Title$ Přidat záznam��5   	   $��484.276��6   $��553.197��60    � 
ResizeMode$ NoResize=�6@    � WindowStartupLocation$ CenterScreen=�6V    � SizeToContent$ WidthAndHeight=�6{    � ShowInTaskbar .  � Icon$ Data/DVData.ico��6�   .��5      � .+�5   
   �� -   5         ��Name$ Accept��5      $��Přidat film do databáze��6!   $
��Left=�6C   $��32��6^   $��	12,0,0,10q�6j   $��Bottom=�6}   $	��197��6�    � ToolTip$ Přidá film do databáze��6�   	 �� 	IsDefault	 . {�.  $��14��6�   �� 5   
   -   5        $ Cancel��5      $��Zrušit akci��6!   $
��Left=�67   $��32��6R   $��
223,0,0,10q�6^   $��Bottom=�6r   $	��118��6�   $ Zruší akci��6�   
 �� IsCancel
 . $��15��6�   �� 5   
   -   5        $ Refresh��5      $��Obnovit hodnocení��6"   $
��Left=�6>   $��32��6Y   $��
357,0,0,10q�6e   $��Bottom=�6y   $	��163��6�   $/ )Obnoví hodnocení u upravované položky��6�   $��16��6�   6�   � 5	   
   $
��Left=�6   $	��Top=�6*   $	��537��6B   $
��Auto��6N    � RowDefinitions 5
      �� 5      $
��Auto �6    �� 5      $��85 �6    .+�5      � -   5         �Name$
 csfd��5      $
��Left=�6!   $
��Auto��6<   $	��Top=�6J   $	��527��6b   $��0,0,0,0q�6n   $��0��6    � ColumnDefinitions 5      �� 5      $	��39* �6'   �� 5      $
��488* �6'   .+�5      �� -   5         ��Name$ Nadpis��5      $��Přidat záznam��6(   $
��Left=�6@   $��	10,10,0,0q�6[   $	��Top=�6n   $��38��6�   $
��Auto��6�   $��20(�6�   $
��Bold"�6�   $ Přídání záznamu��6�   $��2��6�   �� 5      -   5         ��Name$
 name��5      $��23��6(   $��	60,53,0,0q�64    �� TextWrapping$
 Wrap=�6G   $	��Top=�6[   $ Zadejte název filmu��6s   $
��Left=�6�   $	��399��6�   $��1��6�   $��Zadejte název filmu��6�   ���	#FF999999$��1��6=  �� 5      $��Název filmu��6   $
��Left=�6.   $��	10,50,0,0q�6I   $	��Top=�6\   $��84��6t   $ Název filmu��6   $��2��6�   � 5      $
��Left=�6   $
��Auto��62   $��	10,90,0,0q�6@   $	��Top=�6S   $
��Auto��6k   $��2��6x    5      �� 5      $
��Auto �6(   �� 5      $
��Auto �6(   .+�5      9� $��Ruční zadávání��6   $
��Left=�67   $	��Top=�6R   $	��510��6j   $
��Auto��6v   $V PRuční zadání hodnot (v případě doplnění přes ČSFD.cz nelze upravovat)��6�    9� 
IsExpanded . $��4��6�   $��0,-2,0,0q�6�   .��5      � -   5        $ HandMade��5      ���	#FFE5E5E5$	��144��6H   .+�5      �� -	   5        $	 typ��5   &   $��23��63   $��
99,14,10,0q�6?   $
 Wrap=�6S   $	��Top=�6g   $X RZadejte typ (žánr) filmu (pro více žánrů: [žánr], [žánr], [žánr], ...)��6   ���	#FF999999$X��RZadejte typ (žánr) filmu (pro více žánrů: [žánr], [žánr], [žánr], ...)��6*  $��5��6x  �� 5      $��	Typ filmu��6$   $
��Left=�68   $��	10,10,0,0q�6S   $	��Top=�6f   $��84��6~   $ Typ (žánf) filmu��6�   �� 5      -
   5        $
 zeme��5   &   $��23��64   $��
99,45,10,0q�6@   $
 Wrap=�6T   $	��Top=�6h   $Q KZadejte zemi vzniku filmu (pro více zemí: [země], [země], [země], ...)��6�   $Q��KZadejte zemi vzniku filmu (pro více zemí: [země], [země], [země], ...)��6  ���	#FF999999$��6��6y  �� 5       $��Země vzniku��6$   $
��Left=�6:   $��	10,41,0,0q�6U   $	��Top=�6h   $��84��6�   $ Země vzniku filmu��6�   �� 5!      $��Rok výroby��6$   $
��Left=�69   $��	10,72,0,0q�6T   $	��Top=�6g   $��84��6   $ Rok výroby filmu��6�   �� 5"      -   5        $	 rok��5"   &   $��23��63   $��
99,76,10,0q�6?   $
 Wrap=�6S   $	��Top=�6g   $ Zadejte rok výroby filmu��6   $��Zadejte rok výroby filmu��6�   ���	#FF999999$��7��6  �� 5#      $��Délka filmu��6$   $
��Left=�6:   $��
10,103,0,0q�6U   $	��Top=�6i   $��84��6�   $ Délka filmu��6�   �� 5$      -   5        $ delka��5$   &   $��23��65   $��99,107,10,0q�6A   $
 Wrap=�6V   $	��Top=�6j   $Q KZadejte délku filmu (pouze hodnotou; pokud jde o seriál [dílů]x[minut])��6�   $Q��KZadejte délku filmu (pouze hodnotou; pokud jde o seriál [dílů]x[minut])��6  ���	#FF999999$��8��6  5&      5'      9� 5(      $+��%Doplnění pomocí databáze ČSFD.cz��6   $
��Left=�6I   $	��Top=�6d   $	��510��6|   $
��Auto��6�   $��1��6�   $: 4Doplnění hodnot pomocí ČSFD.cz (nelze upravovat)��6�   $��9��6�   .��5)      � ���	#FFE5E5E5$��82��66   .+�5*      �� -   5        $ adresa��5*   &   $��23��66   $��116,14,10,0q�6B   $
 Wrap=�6W   $	��Top=�6k   $&  Adresa filmu - odkaz na ČSFD.cz��6�    �� 
IsReadOnly . ���	#FFE5E5E5$��10��6�   �� 5+      $��Adresa filmu��6$   $
��Left=�6;   $��	10,10,0,0q�6V   $	��Top=�6i   $	��101��6�   $&  Adresa filmu - odkaz na ČSFD.cz��6�   �� 5,      -   5        $ 	hodnoceni��5,   &   $��23��69   $��116,45,10,0q�6E   $
 Wrap=�6Z   $	��Top=�6n   $% Hodnocení filmu podle ČSFD.cz��6�    . ���	#FFE5E5E5$��11��6�   �� 5-      $��Hodnocní filmu��6$   $
��Left=�6=   $��	10,41,0,0q�6X   $	��Top=�6k   $	��101��6�   $% Hodnocení filmu podle ČSFD.cz��6�   5/      50      51      �� 52      -   5        $ 	SearchBut��52      $��1��6,   $
��Left=�6<   $��23��6W   $��
332,53,0,0q�6c   $	��Top=�6w   $	��149��6�   ���	#FFABADB3{�.  $) #Vyhledá informace pomocí interntu��6�   .��53      �� $
��Auto��6!   $��19��6.   $
��Left=�6:    �� Orientation$ 
Horizontal=�6U   .+�54      �� $��Vyhledat na internetu��6    $
��Left=�6@   $	��Top=�6[   $
��Auto��6s   
���   �$��	0,-4,0,-5q�6�   $��28��6�   �� 55      $��19��6    $��Data/search.png��6,   $
��Fill=�6E   56      57      58      59      �� 5:   
   -   5         ��Name$
 seen��5:      $��Viděli jste tento film?��6!   $
��Left=�6C   $��	14,0,0,50q�6^   $��Bottom=�6q   $ Viděli jste tento film?��6�   $��12��6�   �� 5;   
   -   5        $	 dvd��5;      $0��*Máte tento film na DVD nebo v počítači��6    $
��Left=�6Q   $��
160,0,0,50q�6l   $��Bottom=�6�   $n hMáte tento film na DVD (či jinde zaznamenané) nebo uložené v počítači (či v jiném zařízení)��6�   $��13��6  �� 5<   
   -   5        $
 more��5<      $��Zadat více filmů��6!   $
��Left=�6<   $��
404,0,0,50q�6W   $��Bottom=�6k   $n hMáte tento film na DVD (či jinde zaznamenané) nebo uložené v počítači (či v jiném zařízení)��6�   $��13��6�   5=      5>      