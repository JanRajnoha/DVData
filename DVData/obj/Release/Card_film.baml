   M S B A M L   `   `   `  ���� 
  DVData    DVData.Card_film   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml       � Title$  Karta filmu��$��627.85��$	��829�� � WindowStartupLocation$ CenterScreen=� � Icon$ Data/DVData.ico��$	��829��$��627.85��$	��829��.��� .+��� $��Karta filmu��$
��Left=�$��	10,10,0,0q�$	��Top=�$��38��$	��146��$��20(�$
��Bold"� � ToolTip$ Karta filmu���� -    ��Name$ poster��$
��Left=�$	��180��$��	10,53,0,0q�$	��Top=�$	��136��$ Obrázek filmu��$<��6http://img.csfd.cz/assets/b1197/images/poster-free.png��$
��Fill=��� $��Název filmu��$
��Left=�$��
151,48,0,0q�$	��Top=�$ Název filmu���� -    ��Name$
 name��$
��Left=�$
��Auto��$��
230,53,0,0q� �� TextWrapping$
 Wrap=�$	��Top=�$	��568��
���   � �� 
IsReadOnly . $ Název filmu���� $��	Typ filmu��$
��Left=�$��
151,79,0,0q�$	��Top=�$ Typ (žánr) filmu�� J� RenderTransformOrigin$ 0.548,4.654&��� -   $
 type��$
��Left=�$
��Auto��$��
230,84,0,0q�$
 Wrap=�$	��Top=�$	��568��
���   � . $ Typ (žánr) filmu���� $��Země vzniku��$
��Left=�$��151,110,0,0q�$	��Top=�$ Země vzniku filmu��$ 0.548,4.654&��� -   $ state��$
��Left=�$
��Auto��$��230,115,0,0q�$
 Wrap=�$	��Top=�$	��568��
���   � . $ Země vzniku filmu���� $��
Rok vzniku��$
��Left=�$��151,141,0,0q�$	��Top=�$ Rok vzniku Filmu��$ 0.548,4.654&��� -   $
 year��$
��Left=�$
��Auto��$��230,146,0,0q�$
 Wrap=�$	��Top=�$	��105��
���   � . $ Rok vzniku Filmu���� $��Délka filmu��$
��Left=�$��340,141,0,0q�$	��Top=�$ Délka filmu��$ 0.548,4.654&��� -   $ length��$
��Left=�$
��Auto��$��415,146,0,0q�$
 Wrap=�$	��Top=�$	��383��
���   � . $ Délka filmu���� $��
Hodnocení��$
��Left=�$��151,172,0,0q�$	��Top=�$% Hodnocení filmu podle ČSFD.cz��$ 0.548,4.654&��� -   $ rating��$
��Left=�$
��Auto��$��230,177,0,0q�$
 Wrap=�$	��Top=�$	��105��
���   � . $% Hodnocení filmu podle ČSFD.cz���� $��Žebříček��$
��Left=�$��340,172,0,0q�$	��Top=�$F @Umístění v žebříčku podle hodnocení uživatelů ČSFD.cz��$ 0.548,4.654&��� -   $ chart��$
��Left=�$
��Auto��$��415,177,0,0q�$
 Wrap=�$	��Top=�$	��383��
���   � . $F @Umístění v žebříčku podle hodnocení uživatelů ČSFD.cz���� -	   	 ��Name$	 Accept��$��Přidat film do databáze��$
��Left=�$��	10,0,0,19q�$	��146��$ Přidat film do databáze��
 �� 	IsDefault
 . $��35��$��Bottom=��� -
   $	 Cancel��$��Zrušit��$
��Left=�$��
161,0,0,19q�$	��146��$ Zavře okno Karta filmu�� �� IsCancel . $��35��$��Bottom=��� -    ��Name$
 seen��$��Film jsem viděl��$
��Left=�$��
324,0,0,28q� d� 	IsChecked$
 TrueY�$# Určuje, zda jste film viděl��$��15��$��Bottom=��� -   $	 DVD��$4��.Film mám na DVD (CD, Blu-Ray, uložený v PC)��$
��Left=�$��
440,0,0,28q�$" Určuje, zda film vlastníte��$��15��$��Bottom=��� $��10,248,362,59q�$
��Auto=�.��� $
��Left=�$
��Auto��$	��Top=�$	��441��$
��Auto=� � RowDefinitions �� $
��Auto ��� $
��Auto ��� $
��Auto ��� $
��Auto �.+��� $��Tvůrci, děj a obsazení��$��
10,10,10,0q�$	��Top=�$��38��$
��Auto��$��18(�$
��Bold"�$ Tvůrci a obsazení��9� $��
Děj filmu��$��
10,10,10,0q�$��1��$	��Top=�$
��Auto��.��� ���	#FFE5E5E5$	��167��.+��� -   $	 dej��$
��Left=�$	��147��$��	10,10,0,0q�$
 Wrap=�$��TextBox��$	��Top=�$	��399��" �� VerticalScrollBarVisibility$
 Auto=� . 9� $��Tvůrci filmu��$��
10,10,10,0q�$��2��$	��Top=�$
��Auto��.��� ���	#FFE5E5E5$	��167��.+��� $��Režie��$
��Left=�$��	10,10,0,0q�$	��Top=�$ Režisér filmu���� -   $ Rezie��$
��Auto��$��
72,15,10,0q�$
 Wrap=�$	��Top=�
���   � . $ Řežisér filmu���� $��	Scénář��$
��Left=�$��	10,41,0,0q�$	��Top=�$ Autor scénaře k filmu���� -   $ Scenar��$
��Auto��$��
72,46,10,0q�$
 Wrap=�$	��Top=�
���   � . $ Autor scénaře k filmu���� $��Kamera��$
��Left=�$��	10,73,0,0q�$	��Top=�$ Kameraman filmu���� -   $ Kamera��$
��Auto��$��
72,78,10,0q�$
 Wrap=�$	��Top=�
���   � . $ Kameraman filmu���� $��Hudba��$
��Left=�$��
10,104,0,0q�$	��Top=�$ Autor hudby k filmu��$ 
0.54,1.885&��� -   $ Hudba��$
��Auto��$��72,109,10,0q�$
 Wrap=�$	��Top=�
���   � . $ Autor hudby k filmu���� $��	Předloha��$
��Left=�$��
10,135,0,0q�$	��Top=�$ Autor předlohy k filmu��$ 
0.54,1.885&��� -   $ Predloha��$
��Auto��$��72,140,10,0q�$
 Wrap=�$	��Top=�
���   � . $ Autor předlohy k filmu��9� $��Obsazení filmu��$��
10,10,10,0q�$	��Top=�$
��Auto��$��3��.��� $
��Left=�$��0,0,-2,0q����	#FFE5E5E5$	��421��$	��160��.+�&   System.Windows.Controls.DataGrid  -     Name$ Actors��$��10q�$ Seznam herců��   AreRowDetailsFrozen .    
IsReadOnly .    Columns 0  *System.Windows.Controls.DataGridTextColumn  -   IDActor��,  &System.Windows.Controls.DataGridColumn   Header$ ID��   
Visibility$ 	Collapsed=�1  +System.Windows.Controls.DataGridBoundColumn   ClipboardContentBinding Z�   -   	Actor��$ Herec�� Z�   -   Link��$ Odkaz��$ 	Collapsed=� Z� � $��464,224,15,59q�.+��� $��Galerie k filmu��$��0,0,0,0q�$	��Top=�$��38��$
��Auto��$��18(�$
��Bold"�$ Galerie k filmu��$
��Left=�9� $��Galerie��$��0,46,0,0q�$
��Auto��$	��340��.���� $
��Auto=�$��1,0,8,0q�.��� -    �Name$
 Pics�����	#FFE5E5E5$
��Auto=�$
��Auto��$	��329��$
��Left=�.+��� -   $	 LoadGallery��$E��?Načíst galerii (tato operace může být časově náročná)��$
��Left=�$��	10,10,0,0q�$	��Top=�$	��300��$��34��$f `Po kliknutí na tlačítko se načte galerie k filmu. Tato akce může být časově náročná.�� . 