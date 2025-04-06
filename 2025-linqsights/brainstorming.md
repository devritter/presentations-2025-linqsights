## Themen Brainstorming

- [x] LINQ-Style oder Extension-Method-Style
Unterschiede bzw. Vorteile von LINQ-Style
Grenzen von LINQ-Style

- [x] ToList oder ToArray
- [x] Enumerable Basics, yield
- [x] eine größere Datei einlesen + RAM usage
- [x] .Any() oder .Count() > 0
- [x] .Count() oder .Count oder .Length?
- [x] Sinnloses zeugs, wie
- [x] Aufpassen bei Min()/Max()/Average()/Sum() => .DefaultIfEmpty()
- [x] .Where(x => x.HasValue) Nullable Reference Types Fix mit BzExt
- [x] Wie tun bei untypisierten Listen als Startwert? zB bei Regex.Matches()?
- [x] .Select() mit Indexüberladung
- [x] .Where() mit Indexüberladung
- [x] LINQ-Erweiterungs-NuGets
- [ ] GroupBy mit anonymem Key-Objekt
- [x] .All() wenn die Liste leer ist
- [x] mehrere .Where() oder alles in einem, was ist schneller?
- [ ] PredicateBuilder
- [x] Tipp: eigene Extensions schreiben, zB für SoftDelete
- [x] Query reuse? Specification-Pattern?
- [x] Enumerable.Repeat()
- [x] Enumerable.Empty<T>()
- [x] Enumerable.Range()
- [x] TryNonEnumeratedCount()
- [ ] ExecutionTime
- [ ] Big-O-Notation
- [x] Performance: list.Sum(x => x.SomeNumber) vs. foreach vs. for-Loop
- [x] Materialisierung von .GroupBy()
- [x] Lazy evaluation
- [x] List flattening
- [x] Wie viel Overhead erzeugt es, ein "Where" anzuhängen, dass "global" ein- oder ausgeschaltet ist?
- [ ] eine Liste bearbeiten, während man sie durchläuft --> Exception!

etwas Abschweifend:
- Performanceunterschied List oder Dictionary
- EF-Zeugs, wie "nur das abfragen, was man auch braucht", kein Change Tracking
- wie funktioniert EF Core intern?
- Queryable, Expression<>

