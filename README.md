# Routenwahlverfahren für Fußgängersimulation 

Ziel ist es hier in einer eigenen Datenstruktur ein Routenwahlverfahren für eine Fußgängersimulation in Unity zu implementieren. Wichtig ist es hier zwischen Fußgängermodellen und Routenwahlverfahren zu unterscheiden. Es gibt verschiedene Fußgängermodelle, bei denen der Fokus darauf gelegt ist wie sich die Fußgänger in Bezug auf andere Fußgänger verhalten, z.B. in Hinsicht auf Kollisionsvermeidung. Mein Fokus ist aber das Routenwahlverfahren, heißt wie Fußgänger ihren Weg durch eine Geometrie wählen und begehen. 

# Coding conventions

- Kommentare nutzen
- Sinnvolle Bennenung von Attributen
- Klassen schreibt man groß

# Ordnerstruktur des Repository

- Testprojekt: Unity Projekt
- Assets: Alle Objekt-Dateien des Projekts
- Packages: Sammlungen von Dateien und Daten
- Project Settings: Projekteinstellungen
- docs: Dokumentation des Projektes
- img: Bilder die für die schriftliche Ausarbeitung relevant sein könnten

# Zeitplan
- Woche 1: Geometrie der Umgebung erstellen und Agenten durch Geometrie laufen lassen.
- Woche 2: Agent per A*-Algorithmus zum Ausgang laufen lassen und Zeit anzeigen als auch stoppen.
- Woche 3: Mit Prefabs mehrere Agenten dynamisch zur Laufzeit erzeugen.
- Woche 4: Mit Navigationspunkten cognitive maps oder andere Algorithmen implementieren, z.B. Dijkstra-Algorithmus oder Floyd-Warshall-Algorithmus.
- Woche 5: Puffer zum Programmieren, damit man genug Tests hat um sie in der Ausarbeitung auch zu evaluieren.

# Literatur
- Eine agentenbasierte Fußgängersimulation zur Bewertung der Bewegungs- und Nutzungsmuster eines städtischen Platzes: https://opus.bibliothek.uni-augsburg.de/opus4/frontdoor/deliver/index/docId/49486/file/537622050.pdf
- Fußgängersimulation auf der Basis sechseckiger zellularer Automaten: http://www.martinrose.net/pdf/Hannover2003.pdf
- Routenwahlverhalten von Fußgängern: https://www.th-nuernberg.de/fileadmin/fakultaeten/ar/ar_docs/forschung/st%C3%A4dtebau/Fu%C3%9F_Forsch_Burgs_klein.pdf
