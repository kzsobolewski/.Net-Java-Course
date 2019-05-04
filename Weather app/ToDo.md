## Weather app
Aplikacja bedzie pobierać dane o pogodzie dla wybranego miasta co jakis interwał czasu, dane będą zapisywane do bazy danych, dzięki czemu będzie można sporządzić wykres temperatury lub innych parametrów.
To do:
1. znalezienie strony do pobierania danych (najlepiej api zwracające jsona),
2. parsowanie tych danych do jakies klasy (biblioteka json.net),
3. ustawienie aby dane byly pobierane co jakis czas,
4. zapisywanie tych danych do bazy (entity framework, linq), jedna tabelka "dane":
* id - primary key
* kraj - string
* miasto - string
* czas - timestamp
* temperatura w "C - float
* szansa opadów - float
* wilgotność - float
* ciśnienie - float
* itp. w zależności od dostarczonych API przez serwis
5. interfejs uzytkownika (z data binding) :
* lista z informacjami zapisanymi w bazie
* textboxy do ręcznego wprowadzenia danych o pogodzie ( wg mnie bez sensu to jest ale w dokumencie jest napisane, że musi być taka opcja.)
* rozwijane menu do wyboru miasta,
* duży napis z aktualnie wybranym miastem i temperaturą,
* przycisk do ręcznego zaktualizowania informacji,

### Dodatkowe 
* wykres na podstawie ostatnich z bazy (google charts, plotLy),
* ustawienia użytkowanika np. domyslna lokalizacja, interwał pobierania danych, zmiana kolorystyki okna (jasny/ciemny),
* dodanie testów jednostkowych
* edycja danych w bazie z poziomy wyswietlanaj listy

#### wymagania do projektu
<http://andrzej.gnatowski.staff.iiar.pwr.wroc.pl/PlatformyProgramistyczne/DotNet/_Net_and_Java_1.pdf>
