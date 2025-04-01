## Themen Brainstorming

- [x] LINQ-Style oder Extension-Method-Style
Unterschiede bzw. Vorteile von LINQ-Style
Grenzen von LINQ-Style

- [x] ToList oder ToArray
- [ ] ToDictionary Überladungen
- [ ] Enumerable Basics, yield
- [x] eine größere Datei einlesen + RAM usage
- [ ] eine Liste bearbeiten, während man sie durchläuft --> Exception!
- [x] .Any() oder .Count() > 0
- [x] .Count() oder .Count oder .Length?
- [ ] Sinnloses zeugs, wie
    - [ ] mehrere OrderBy()
    - [ ] Distinct().Any()
    - [ ] .Distinct().Distinct()
- [x] Aufpassen bei Min()/Max()/Average()/Sum() => .DefaultIfEmpty()
- [ ] .Where(x => x.HasValue) Nullable Reference Types Fix mit BzExt
- [x] Wie tun bei untypisierten Listen als Startwert? zB bei Regex.Matches()?
- [x] .Select() mit Indexüberladung
- [x] .Where() mit Indexüberladung
- [ ] LINQ-Erweiterungs-NuGets
- [ ] GroupBy mit anonymem Key-Objekt
- [x] .All() wenn die Liste leer ist
- [ ] mehrere .Where() oder alles in einem, was ist schneller?
- [ ] PredicateBuilder
- [ ] Tipp: eigene Extensions schreiben, zB für SoftDelete
- [ ] Query reuse? Specification-Pattern?
- [ ] Enumerable.Repeat()
- [ ] Enumerable.Empty<T>()
- [ ] Enumerable.Range()
- [x] TryNonEnumeratedCount()
- [ ] ExecutionTime
- [ ] Big-O-Notation
- [ ] Performance: list.Sum(x => x.SomeNumber) vs. foreach vs. for-Loop
- [ ] Materialisierung von .GroupBy()
- [ ] Lazy evaluation
- [ ] List flattening
- [ ] Wie viel Overhead erzeugt es, ein "Where" anzuhängen, dass "global" ein- oder ausgeschaltet ist?

etwas Abschweifend:
- Performanceunterschied List oder Dictionary
- EF-Zeugs, wie "nur das abfragen, was man auch braucht", kein Change Tracking
- wie funktioniert EF Core intern?
- Queryable, Expression<>

