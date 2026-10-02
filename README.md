# Kunskapskontroll 2: Robust Inköpslista

## Felrapport

### Fel 1: Programmet krashade vid start.

**Vad hände:** Programmet krashade direkt med IndexOutOfRangeException rad 90. i Load(). Namn syntes inte heller i listan och sökning hittade inget.

**Varför:** Load() läste filen med ReadAllText och delade den med Split("\n"). Filen använder "\r \n" som radbrytning så \r blev kvar i slutet av varte namn. Efter sista radbrytningen blev det dessutom en tom rad alltså i items.txt rad 4, som bara gav en bit vid "Split(";"). och då fanns inget parts[1]". 

**Lösning:** Jag bytte till File.ReadAllLines som dela upp filen i rader och tar bort "\r\n". Jag lade också till if (parts.Length !=2) continue; så att tomma eller trasiga rader hoppas över.

### Fel 2: När man skrev bostäver i programmet så krashade det.

**Vad hände:** Om man skrev bostäver i menyn, i priset eller i numret krashade programmet med "FormatException"

**Varför** Koden använde "int.Parse" som kastar ett undantag om texten int eär ett tal.

**Lösning:** Jag bytte till "int.TryParse". Om det inte är ett tal får användaren och ett meddelande och kommer tillbaka till menyn med "continue"

### Fel 3: Borttagning av en vara som inte finns krashade programmet.

**Vad hände:** Om man skrev ett nummer som inte fann till exempel 7 och listan va 5, krashade programmet.

**Varför:** "RemoveAt" kontrolelrade inte att numret fanns i listan.

**Lösning:** Jag lade till if(number < 1  || number > items.Count) som visar ett meddelande och avbryter med "return". Kontrollen skydda under 1 samt över listan antal.

### Fel 4  Programmet krashade om items.txt saknades.

**Vad hände:** då jag ändrade till items2.txt så kunde den inte hitta items.txt så krashade prorammet vid start med FileNotFoundException.

**Varför**  Filen fanns inte, så "ReadAllLines" kunde inte göra sitt jobb. Den kastade då ett "FileNotFoundException", eftersom den inte hittade filen. Då ingen "catch" fångade felet kraschade programmet.

**Lösning** Jag lade ReadAllLine i en try/catch som fångar "FileNotFoundException". Programmet starta då med tom listas.

