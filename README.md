# Plane_Game

Użyta wersja silnika : 2021.3.12f1  

Sterowanie :  
W S - poruszanie się góra dół  
Spacja lub lewy przycisk myszy, strzelanie  
  
Uwaga: UI jest przystosowane do ascept ratio 16:9  
  
Uzyte addony:  
Input system od Unity  
TextMeshPro  od Unity

Pozostałe sprite'y pochodzą z własnej biblioteki.


Czas:
23.01.2023  
19:30-20:15 ;  
stworzenie projektu, przesuwanie swiata, input system,  
import assetow, baza pod playera i gamemanager  
20:30-21:00 ;  
sterowanie gracza, przeciwnik   
1 godzina 15 minut  
24.01.2023  
12:25-13:30 ;   
strzelanie, wave'y przeciwnikow, kolizja  
15:20-16:00 ;  
UI, zycia, wynik  
16:20-17:30 ;  
UI cd., timer, playtesting, highscore system  
2 godziny 45 minut  
  
==========Wszystko co potrzeba zostalo zaimplementowane===============   
zajeło to równo 4 godziny  
  
==========Dodatkowe zmiany============================================  
24.01.2023  
21:10-21:30 ;  czyszczenie kodu, dodanie miganie gracza podczas iframe'ów  
22:10-22:45 ;  ulepszenie UI, kolorowi przeciwnicy, drobne poprawki   
25.01.2023  
8:20-8:30 finalowe poprawki i czyszczenie kodu  
65 minut  
  
razem 5 godzin i 5 minut  
  
  
Do niektórych skryptów takich jak managerowie czy gracz,  
których powinna istnieć tylko jedna instancja w danym momencie  
został użyty wzorzec projektowy singleton, ułatwi to odnoszenie się do owych skryptów,  
oraz zabezpieczy przed przypadkowym tworzeniem dodatkowej instancji.  
