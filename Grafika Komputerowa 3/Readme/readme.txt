Projekt numer 1 z trzeciego zestawu projektów - grafika komputerowa

W projekcie przedstawiono algorytmy redukcji kolorów.
Metody ditheringu:
-średnia
-uprządkowanego drżenia (i wybierane losowo lub kolejno)
-propagacji błędu("Floyd - Steinberg", "Burkes", "Stucky")

Algorytm popularnosciowy.

W projekcie załączonych jest 5 przykładowych obrazków które pokazują poprawnosć działania wymienionych wyżej algorytmów.
Szczególnie obrazek 4 ukazuje poprawność działania metody uprządkowanego drżenia oraz algorytmu popularnościowego, a obrazek 5 - metody średniej.

Sposób użytkowania:
Aplikacja pozwala załaczyć swoje własne zdjęcie za pomocą: File -> LoadPicture
Można wybrać również załączone fotografie: Samples(1 - 5)
Aplikacja pozwala wybrać ilość kolorów dla każdego z kanałów RGB (2 - 256) dla algorytmów ditheringu,
oraz ilość najczęsciej występujących kolorów: K (1 - 16777216) dla algorytmu popularnosciowego.
Po wybraniu zadowalajacych ustawień należy nacisnac przycisk "Compute", który powoduje wygenerowanie obrazka wynikowego.

Założenia:
-ilość kolorów dla każdego kanału wynosi 2 - 256 



