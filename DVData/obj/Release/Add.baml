   M S B A M L   `   `   `  ���� 
  DVData    
DVData.Add   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     -     �Name$  
Add_client�� � Title$ Přidat záznam��$��484.276��$��553.197�� � 
ResizeMode$ NoResize=� � WindowStartupLocation$ CenterScreen=� � SizeToContent$ WidthAndHeight=� � ShowInTaskbar .  � Icon$ Data/DVData.ico��.��� .+��� -    ��Name$ Accept��$��Přidat film do databáze��$
��Left=�$��32��$��	12,0,0,10q�$��Bottom=�$	��197�� � ToolTip$ Přidá film do databáze��	 �� 	IsDefault	 . {�.  $��14���� -   $ Cancel��$��Zrušit akci��$
��Left=�$��32��$��
223,0,0,10q�$��Bottom=�$	��118��$ Zruší akci��
 �� IsCancel
 . $��15���� -   $ Refresh��$��Obnovit hodnocení��$
��Left=�$��32��$��
357,0,0,10q�$��Bottom=�$	��163��$/ )Obnoví hodnocení u upravované položky��$��16��� $
��Left=�$	��Top=�$	��537��$
��Auto�� � RowDefinitions �� $
��Auto ��� $��85 �.+�� -    �Name$
 csfd��$
��Left=�$
��Auto��$	��Top=�$	��527��$��0,0,0,0q�$��0�� � ColumnDefinitions �� $	��39* ��� $
��488* �.+��� -    ��Name$ Nadpis��$��Přidat záznam��$
��Left=�$��	10,10,0,0q�$	��Top=�$��38��$
��Auto��$��20(�$
��Bold"�$ Přídání záznamu��$��2���� -    ��Name$
 name��$��23��$��	60,53,0,0q� �� TextWrapping$
 Wrap=�$	��Top=�$ Zadejte název filmu��$
��Left=�$	��399��$��1��$��Zadejte název filmu�����	#FF999999$��1���� $��Název filmu��$
��Left=�$��	10,50,0,0q�$	��Top=�$��84��$ Název filmu��$��2��� $
��Left=�$
��Auto��$��	10,90,0,0q�$	��Top=�$
��Auto��$��2�� �� $
��Auto ��� $
��Auto �.+�9� $��Ruční zadávání��$
��Left=�$	��Top=�$	��510��$
��Auto��$V PRuční zadání hodnot (v případě doplnění přes ČSFD.cz nelze upravovat)�� 9� 
IsExpanded . $��4��$��0,-2,0,0q�.��� -   $ HandMade�����	#FFE5E5E5$	��144��.+��� -	   $	 typ��$��23��$��
99,14,10,0q�$
 Wrap=�$	��Top=�$X RZadejte typ (žánr) filmu (pro více žánrů: [žánr], [žánr], [žánr], ...)�����	#FF999999$X��RZadejte typ (žánr) filmu (pro více žánrů: [žánr], [žánr], [žánr], ...)��$��5���� $��	Typ filmu��$
��Left=�$��	10,10,0,0q�$	��Top=�$��84��$ Typ (žánf) filmu���� -
   $
 zeme��$��23��$��
99,45,10,0q�$
 Wrap=�$	��Top=�$Q KZadejte zemi vzniku filmu (pro více zemí: [země], [země], [země], ...)��$Q��KZadejte zemi vzniku filmu (pro více zemí: [země], [země], [země], ...)�����	#FF999999$��6���� $��Země vzniku��$
��Left=�$��	10,41,0,0q�$	��Top=�$��84��$ Země vzniku filmu���� $��Rok výroby��$
��Left=�$��	10,72,0,0q�$	��Top=�$��84��$ Rok výroby filmu���� -   $	 rok��$��23��$��
99,76,10,0q�$
 Wrap=�$	��Top=�$ Zadejte rok výroby filmu��$��Zadejte rok výroby filmu�����	#FF999999$��7���� $��Délka filmu��$
��Left=�$��
10,103,0,0q�$	��Top=�$��84��$ Délka filmu���� -   $ delka��$��23��$��99,107,10,0q�$
 Wrap=�$	��Top=�$Q KZadejte délku filmu (pouze hodnotou; pokud jde o seriál [dílů]x[minut])��$Q��KZadejte délku filmu (pouze hodnotou; pokud jde o seriál [dílů]x[minut])�����	#FF999999$��8��9� $+��%Doplnění pomocí databáze ČSFD.cz��$
��Left=�$	��Top=�$	��510��$
��Auto��$��1��$: 4Doplnění hodnot pomocí ČSFD.cz (nelze upravovat)��$��9��.��� ���	#FFE5E5E5$��82��.+��� -   $ adresa��$��23��$��116,14,10,0q�$
 Wrap=�$	��Top=�$&  Adresa filmu - odkaz na ČSFD.cz�� �� 
IsReadOnly . ���	#FFE5E5E5$��10���� $��Adresa filmu��$
��Left=�$��	10,10,0,0q�$	��Top=�$	��101��$&  Adresa filmu - odkaz na ČSFD.cz���� -   $ 	hodnoceni��$��23��$��116,45,10,0q�$
 Wrap=�$	��Top=�$% Hodnocení filmu podle ČSFD.cz�� . ���	#FFE5E5E5$��11���� $��Hodnocní filmu��$
��Left=�$��	10,41,0,0q�$	��Top=�$	��101��$% Hodnocení filmu podle ČSFD.cz���� -   $ 	SearchBut��$��1��$
��Left=�$��23��$��
332,53,0,0q�$	��Top=�$	��149�����	#FFABADB3{�.  $) #Vyhledá informace pomocí interntu��.���� $
��Auto��$��19��$
��Left=� �� Orientation$ 
Horizontal=�.+��� $��Vyhledat na internetu��$
��Left=�$	��Top=�$
��Auto��
���   �$��	0,-4,0,-5q�$��28���� $��19��$��Data/search.png��$
��Fill=��� -    ��Name$
 seen��$��Viděli jste tento film?��$
��Left=�$��	14,0,0,50q�$��Bottom=�$ Viděli jste tento film?��$��12���� -   $	 dvd��$0��*Máte tento film na DVD nebo v počítači��$
��Left=�$��
160,0,0,50q�$��Bottom=�$n hMáte tento film na DVD (či jinde zaznamenané) nebo uložené v počítači (či v jiném zařízení)��$��13���� -   $
 more��$��Zadat více filmů��$
��Left=�$��
404,0,0,50q�$��Bottom=�$n hMáte tento film na DVD (či jinde zaznamenané) nebo uložené v počítači (či v jiném zařízení)��$��13��