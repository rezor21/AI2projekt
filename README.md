

![enter image description here](https://image.ibb.co/nqjDAy/Bez_tytu_u.png)
Zespół projektowy:
Michał Rembisz  
Jaromir Sarzyński  
Daniel Smolak  
Krystian Pinderski  


**Informatyka, studia stacjonarne I stopnia, semestr 6**

Dokumentacja  
projektu zaliczeniowego z przedmiotu  
Aplikacje Internetowe 2 pt.:

**Aplikacja webowa do zarządzania i generowania (w postaci graficznej i tekstowej) raportów biznesowych.**

**Rzeszów, 2018 r.**

Rozdziały:
1. Cel i zakres projektu.
2. Plan aplikacji.
3. Wykorzystane technologie.

**1.** **Cel i zakres projektu.**

Celem projektu jest stworzenie Aplikacja webowa do zarządzania i generowania (w postaci graficznej i tekstowej) raportów biznesowych.

  
- Poszczególne kroki podjęte w celu stworzenia projektu:
- Stworzenie zarysu i planu projektu,
- Implementacja aplikacji,
- Sporządzenie niezbędnych dokumentów tj. schematy, diagramy,
- Wykonanie dokumentacji projektu,
- Stworzenie przykładowej aplikacji mobilnej

  
Cała struktura powstawania projektu oparta jest o przygotowany na samym początku wykres Gantta, który prawdopodobnie będzie musiał zostać kilka razy zmodyfikowany ze względu na inne terminy zakończenia zadań niż przewidywane. Wykres składa się z następujących po sobie zadań, co pozwoliło na stworzenie projektu w oparciu o wcześniej określone zdania, i łatwe dzielenie się zadaniami w zespole.  



|Nr  | Zadanie: | Data Rozpoczęcia | Data Zakończenia 
|--|--|--|--|
| Zad 1 | Stworzenie zarysu projektu, podział obowiązków, wybór technologii. | 22 marzec | 29 marzec |
| Zad 2 | Stworzenie wstępnej dokumentacji | 29 marzec | 12 kwiecień |
| Zad 3 | Zaprojektowanie serwerowej części aplikacji | 29 marzec | 12 kwiecień |
| Zad 4 | Zaprojektowanie Graficznego Interfejsu Użytkownika | 12 kwiecień | 26 kwiecień |
| Zad 5 | Stworzenie diagramu przypadków użycia | 26 kwiecień | 2 maj |
| Zad 6 | Stworzenie bazy danych | 2 maj | 9 maj |
| Zad 7 | Zaimplementowanie klas modelu bazodanowego w projekcie | 12 kwiecień | 9 maj |
| Zad 8 | Zaimplementowanie wydruku treści raportów | 22 maj | 9 maj |
| Zad 9 | Zaimplementowanie sytemu logowania i rejestracji użytkowników | 12 kwiecień | 16 maj |
| Zad 10 | Zaimplementowanie możliwości generowania raportów | 12 kwiecień | 16 maj |
| Zad 11 | Zaimplementowanie systemu zarządzania raportami | 16 maj |30 maj  |
| Zad 12 | Testowanie aplikacji i poprawki | 1 czerwiec | 4 czerwiec |
| Zad 13 | Stworzenie pełnej dokumentacji  | 1 czerwiec | 4 czerwiec |
| Zad 14 | Testowanie końcowe | 16 maj | 1 czerwiec |
| Zad 15 | Stworzenie aplikacji mobilnej | 1 czerwiec | 4 czerwiec |

**  
2. Plan aplikacji.**

W początkowym planie aplikacji przyjęliśmy następujące założenia

Aplikacja powinna:
- umożliwiać użytkownikowi logowanie się oraz rejestrację
- umożliwiać generowanie raportów
- umożliwiać zapisywanie raportów do plików pdf
- umożliwiać  zarządzanie transakcjami
- •	aplikacja powinna być wieloplatformowa (serwer przynajmniej Windows + Linux i aplikacja mobilna na system android)

**3. Wykorzystane technologie.**

**ASP .NET Core 2.0** – Framework .NET Core w wersji 2.0 technologia ASP . Wybraliśmy tą technologię, ponieważ w prosty sposób można stworzyć w niej aplikację webową zgodną z najnowszymi standardami projektowania aplikacji (np. RESTfull API, Single Page Application) i nie wymaga to dodatkowych narzędzi, technologii, frameworków, ale można ich użyć. W porównaniu do innych technologii i języków tego typu kod programu jest krótszy i prostszy do zrozumienia (od np. frameworka Spring z Javy) i znacznie bardziej czytelny (szczególnie jeśli popatrzymy na  np. PHP nie licząc frameworka Laravel który jest oparty na technologii ASP .NET) oraz co jest dla nas ważne materiały, informacje i wsparcie są bardzo łatwo dostępne (oficjalne strony Microsoftu i wspierane przez nich blogi, fora), a my mamy doświadczenie w tej technologii. Technologia ta zapewnia wieloplatformowość aplikacji (Windows, Linuks, MacOS)

**C#** – język programowania.  Wybraliśmy ten język, ponieważ najlepiej się nam w nim pracuje oraz mamy z nim największe doświadczenie.

**Javascript** – najpopularniejszy język wykonywany w po stronie przeglądarki. Nie używaliśmy go w widoczny sposób ale wykorzystują go używane przez nas frameworki i technologie.

**Silnik Razor** - to silnik renderujący wprowadzony w ASP .NET MVC3, pozwalający na bardzo łatwe oddzielenie kodu HTML od kodu aplikacji. Posiada prostą składnię. W porównaniu do starszych silników renderujących, aby uzyskać taki sam efekt, wymaga napisania mniejszej ilości kodu. Aby wyświetlić wartość zmiennej, wystarczy postawić przed nią znak „@”, analogicznie postępujemy w przypadku pętli oraz innych elementów nienależących do składni języka HTML, czy JavaScript. Dodatkowo RAZOR obsługuje klamry, które są bardzo pomocne, gdy mamy więcej niż jedną linię kodu wymagającego użycia RAZORa.

**Bootstrap** - framework CSS, rozwijany przez programistów Twittera, wydawany na licencji MIT. Zawiera zestaw przydatnych narzędzi ułatwiających tworzenie interfejsu graficznego stron oraz aplikacji internetowych. Bazuje głównie na gotowych rozwiązaniach HTML oraz CSS (kompilowanych z plików Less) i może być stosowany m.in. do stylizacji takich elementów jak teksty, formularze, przyciski, wykresy, nawigacje i innych komponentów wyświetlanych na stronie. Używany przez nas w wersji 4.1.

**Material Design for Bootstrap 4 (MDB)** - framework CSS i JS przystosowywujący Bootstrap’a do standardu Material Design.

**NuGet** – jest rozszerzeniem do Visual Studio ułatwiającym zarządzanie referencjami do bibliotek (tzw. system zarządzania pakietami). Pozwolił nam w  prosty sposób dodawać potrzebne frameworki i biblioteki do projektu.

**Visual Studio 2017** - środowisko programistyczne pozwalające na implementacje aplikacji w między innymi języku C# wybraliśmy najnowszą wersję. Natomiast wybór padł akurat na Visual Studio ponieważ tworzy go akurat firma opowiadająca za język C# oraz ze względu na to że jest prawdopodobnie najpopularniejszym IDE do używanych przez nas technologii.

**Chart.js** to narzędzie do tworzenia wykresów oraz diagramów na stronach internetowych. Zaletami tego skryptu jest szybkość działania i wygląd.

**Xamarin** to framework firmy Microsoft stworzony do tworzenia aplikacji mobilnych (Android, iOS, Windows Phone) w oparciu o ten sam kod, który kompilowany jest dla każdej platformy mobilnej oddzielnie. Wykorzystany do aplikacji mobilnej.

**Microsoft Azure** po prostu chmura publiczna od firmy Microsoft wykorzystaliśmy usługę bazy danych i AppServices do wdrożenia naszej aplikacji webowej.
