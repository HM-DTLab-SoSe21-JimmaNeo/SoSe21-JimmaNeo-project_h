# Vorlagenprojekt für ein Blazor WebAssembly Projekt das auf ASP.NET Core gehostet ist

Dieses Projekt ist ein Standard-Vorlageprojekt, das eine funktionierende WebAssembly-Anwendung, die auf .NET Core gehostet ist, zeigt. Die Beispiel-Anwendung enthält einen Zugriff auf APIs.

PressRelease

Pressemitteilung
E-Learning Plattform für medizinisches Fachpersonal in Äthiopien
München/Äthiopien, 14.05.2021
Mittels der neuen digitalen Lernplattform StepUp schult die LMU medizinisches Fachpersonal in Äthiopien um die Sterberate von Neugeborenen zu minimieren.  
Die Corona-Pandemie hat die Welt weiterhin fest im Griff. Reisen sind nur in Ausnahmefällen genehmigt. Eine Reise nach Äthiopien ist kaum möglich. Ein Problem für die Kinderärzte Frau Lieftüchter und Herrn Dr. Reicherzer der LMU (Ludwig-Maximilians-Universität München), die sich zur Aufgabe gemacht haben äthiopisches medizinisches Fachpersonal in der Neonatologie der Jimma University weiterzubilden. Deshalb müssen andere Wege der Kommunikation und des Lernens gefunden werden. Dies gelingt, mit Hilfe der in Kooperation von LMU und Hochschule München, für diesen Zweck neu entwickelten Lernplattform StepUp.  Durch interaktive abwechslungsreiche Inhalte können die Teilnehmer Schritt für Schritt mit Freude dazulernen. „Mit StepUp wurde eine Plattform geschaffen, die inhaltlich, didaktisch und technisch herausragend ist. Durch diese ist es uns möglich das Fachpersonal vor Ort von München aus mit wichtigen Kompetenzen vertraut zu machen, die in Äthiopien die Versorgung von kranken Früh- & Neugeborenen verbessern können“, sagt die Kinderärztin Frau Lieftüchter. Das Besondere an StepUp ist, dass einige der Features auf psychologischen Grundlagen der Lernmotivation basieren. Laut den Psychologen Deci & Ryan ist soziale Eingebundenheit und Kompetenzerleben von zentraler Wichtigkeit für die Lernmotivation. 
Während der Pandemie ist es schwierig in persönlichen Kontakt zu treten. Da soziale Interaktion aber äußerst wichtig für die Freude am Lernen und damit auch für den Lernerfolg ist, wurde die Funktion „helping hand“ entwickelt. Sie ermöglicht den Lernenden sich Unterstützung bei anderen Lernenden zu suchen, wenn sie Hilfe benötigen.  Wenn ein Nutzer sich in einem Kapitel kompetent fühlt, kann er sich als „helping hand“ für dieses Kapitel markieren und von anderen Nutzern angeschrieben und um Hilfe gebeten werden. „Das helping hand feature ist einfach wunderbar“, berichtet die Krankenschwester Frau Tesfaye (34). „Ich fühle mich beim Lernen nie allein und kann blitzschnell nachschauen wen ich fragen kann, wenn ich nicht weiterkomme. Das ist eine große Hilfe für mich.“ 
Um begeistert zu lernen ist es zudem wichtig sich zunehmend kompetent zu fühlen, wofür ein kontinuierlicher Lernfortschritt hilfreich ist. Im hektischen Klinikalltag bleibt an manchen Tagen keine Zeit sich mit längeren Kapiteln zu beschäftigen. Daher ist für die Zukunft die Erweiterung der Plattform durch das Feature „learning in baby steps“ geplant. Dieses ermöglicht, durch ergänzende kurze Inhalte sich auch in stressigen Phasen weiterzubilden.  Je nach Lernfortschritt sollen dies Einführungen zu Lektionen bzw. kurze Wiederholungen bestimmter, wichtiger Aspekte sein. Die Fortschritte der Teilnehmer werden mit „baby-footprints“ visualisiert.   Kinderarzt Herr Abebe (42) ist von der Idee begeistert: „Learning in baby steps klingt einfach genial!  Manchmal sind die Tage so voll, dass ich keine Kraft mehr für das Lernen von einem ganzen Kapitel aufbringen kann. Aber für ein Feature wie Learning mit baby steps wäre die Motivation immer da! Ich kann in meiner Kaffeepause interessante medizinische Fakten hinzulernen und bekomme dann richtig Lust mich mit dem zum Thema passenden Kapitel näher zu beschäftigen. Ich denke das Feature ist eine große Hilfe immer am Ball zu bleiben.“ 
Das LMU-Klinikum und die Hochschule München haben in gemeinsamer Arbeit eine einzigartige digitale Lernplattform geschaffen, durch die das Fachpersonal in Äthiopien dabei unterstützt wird, ihre wichtige Aufgabe der medizinischen Versorgung von Neugeboren nachkommen zu können. Weiterführende Informationen zu StepUp erhalten sie beim studentischen Entwicklerteam der HS München: julia.helmer@hm.edu. 


Überschrift 2 = Anwendungsbeschreibung
Beschreiben Sie die Abläufe Ihrer Anwendung in einer Art Prozess und
unterlegen Sie die Beschreibung mit Screenshots. Die Screenshots sind im Ordner Screenshots in Dokumentation abzulegen.
Hinweis: In MD können Bilder referenziert werden, die im Repository liegen.
Achten Sie darauf, die Abläufe aus den verschiedenen Stakeholdern (Trainer, Lehrnende, Admin, usw.) zu beschreiben.
Sie können zur besseren Erklärung auch Prozessdiagramme verwenden.

Überschrift 3 = Softwarearchitektur
Beschreiben Sie die Softwarearchitektur. Achten Sie insbesondere auf die zwei Komponenten (WebApp und Server bzw. Frontend und Backend). Stellen Sie sich die Frage, was Sie jemanden über die Softwarestruktur erzählen würden, wenn Sie diese jemanden erklären müssten. Z.B. die Verwendung von Services im Frontend und Backend. 

Das Front End wurde als ASP.NET Core Web App mit C#, HTML und CSS realisiert. Hierbei kommen Razor Pages für die Darstellung einzelner Webpages zur Anwendung. Diese bestehen aus einer Mischung aus HTML und C#. C# sorgt hierbei für die Dynamik der Webpage. Icons wurden aus der Bibliothek von Font Awesome verwendet. Für das Styling einiger Elemente auf den Webpages wurde das Open Source Toolkit Bootstrap genutzt. Das Helpinghand-Symbol wurde beispielhaft aus Grafiken von Storyboardthat.com erstellt. Außerdem stammen die Beispielbilder der Personen von storyboardthat.com. Die Rechte sollten vor der Veröffentlichung geklärt werden bzw. für die Veröffentlichung erlaubte Grafiken verwendet werden.

Das Backend ist wie das Frontend mit ASP.NET Core 5.0 in C# realisiert. Es wurden Services registriert und benutzt, welche die Logik kapseln. Dazu zählen ein LessonDefinitionService, ProfilDefinitionService sowie der LessonProfilDefinitionService. Weiterhin wird eine DbContext-Unterklasse mit dem Namen ApplicationDbContext als bereichsbezogener Dienst im ASP.NET Core-Anwendungsdienstanbieter registriert. Der Kontext ist so konfiguriert, dass man sich mit einer MySQL AWS Datenbank verbindet, wo Daten gespeichert werden.  Das Datenbankschema wurde durch die Verwendung von Migrations inkrementell aktualisiert, um es mit dem Datenmodell der Anwendung synchron zu halten und zugleich die vorhandenen Daten in der Datenbank beizubehalten. Für das mappen der Klassen die zum Transfer der Daten und der Klassen, die zum Speichern der Daten in der Datenbank bestimmt sind, ist der AutoMapper zuständig. 

Überschrift 4 = Team und Ansprechpartner
Beschreiben Sie kurz Ihr Team und wer mit einer E-Mail-Adresse als Ansprechpartner fungieren kann (formhalber).

Aufgaben Julia Helmer
Frontend: Design, Erstausarbeitung der Storyboards zur gemeinsamen Fertigstellung, Press-Release, Erstellung der Präsentation für den 11.06., Wireframes: User markiert sich als helping hand und bekommt Anfragen, Erstentwurf FAQ


Überschrift 5 = Anlagen
Name der Dokumente im Order Dokumentation und verweis auf die Dokumente.
Also mindestens Storyboard, FAQ, PressRelease, usw.
(In Md kann man Verlinkungen einfügen, die auf ein Unterverzeichnis im Repository verweisen).
