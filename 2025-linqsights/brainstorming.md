## Themen Brainstorming

LINQ-Style oder Extension-Method-Style
Unterschiede bzw. Vorteile von LINQ-Style
Grenzen von LINQ-Style

- [ ] ToList oder ToArray
- [ ] ToDictionary Überladungen
- [ ] Enumerable Basics, yield
- [ ] eine 10GB-Datei einlesen
- [ ] eine Liste bearbeiten, während man sie durchläuft --> Exception!
- [ ] .Any() oder .Count() > 0
- [ ] .Count() oder .Count oder .Length?
- [ ] Sinnloses zeugs, wie mehrere 
- [ ] OrderBy, 
- [ ] Distinct().Any()
- [ ] .Distinct().Distinct()
- [ ] Aufpassen bei Min()/Max()/Average()/Sum() => .DefaultIfEmpty()
- [ ] .Where(x => x.HasValue) Nullable Reference Types Fix mit BzExt
- [ ] Wie tun bei untypisierten Listen als Startwert? zB bei Regex.Matches()?
- [ ] .Select() mit Indexüberladung
- [ ] .Where() mit Indexüberladung
- [ ] LINQ-Erweiterungs-NuGets
- [ ] GroupBy mit anonymem Key-Objekt
- [ ] .All() wenn die Liste leer ist
- [ ] mehrere .Where() oder alles in einem
- [ ] PredicateBuilder
- [ ] Tipp: eigene Extensions schreiben, zB für SoftDelete
- [ ] Query reuse? Specification-Pattern?
- [ ] Enumerable.Repeat()
- [ ] Enumerable.Empty<T>()
- [ ] Enumerable.Range()
- [ ] TryNonEnumeratedCount()
- [ ] ExecutionTime
- [ ] Big-O-Notation
- [ ] Performance: list.Sum(x => x.SomeNumber) vs. foreach vs. for-Loop
- [ ] Materialisierung von .GroupBy()

etwas Abschweifend:
- Performanceunterschied List oder Dictionary
- EF-Zeugs, wie "nur das abfragen, was man auch braucht", kein Change Tracking
- wie funktioniert EF Core intern?
- Queryable, Expression<>

