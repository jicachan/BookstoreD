# BookstoreD
I detta projektet har jag testat på olika approach för frontend (allt från Console, HTML till WebForms och MVC). Att jag fastnade för MVC beror bl.a. på att man ganska enkelt kan generera dynamiska html-element med Razor och att det är en tydlig mapp-struktur samt att det finns förinställda webbsidor med gränssnitt att använda. Frontend-biten ska i projektet vara utbytbart, så jag har inte lagt så mycket arbete på den, utan mest på att få det att fungera mellan serversidan och klientsidan, med att skicka data.

Objektklasserna i Models är IBooks, Books, BookCollection, ShoppingCart och Order. BookCollection används för att kunna mappa data från den externa json-filen.

BookstoreService som implementerar interfacet IBookstoreService agerar som en hjälpklass med metoderna som hämtar jsondata och söker efter böcker. 

Eftersom det är en liten applikation finns bara en Controller-klass där de olika metoderna för View finns.  

