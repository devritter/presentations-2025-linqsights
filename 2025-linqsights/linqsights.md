---
marp: true
class: invert
paginate: true
_paginate: skip
backgroundImage: "linear-gradient(to top right,rgb(11, 24, 31),rgb(10, 93, 138))"
---

# <!--fit-->LINQsights
## Deep-Dives, Performanceanalysen und Tipps gegen Stolperfallen

<br/>

by David Ritter 
[devritter](https://www.github.com/devritter) @github

---

# Before LINQ

* Queries against data with strings
* Different APIs for different data sources

# With LINQ

* Query syntax integrated into the C# language
* => Language INtegrated Query
* Same query and transformation pattern against differerent data sources
* Type checking
* Expression Trees

---

# Query Syntax or Method Syntax?

```csharp
(from x in LinqKnowledgeBase.GetAllInsights()
 where x.IsDeveloperRelevant && !x.IsWellKnown
 order by x.Fancyness descending
 select new MeetupSlide(x.Headline, x.Content, x.DemoCode))
.Take(meetup.MaxSlides)
.TakeWhile(_ => !timer.IsTimeOver())
.ToList(); // or ToArray()?
```

<!-- Wer nimmt die "language embedded syntax", wer "Method / Extension method syntax"? -->

---

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


---

# Abgrenzung

~LINQ to Objects~
~LINQ to SQL~
~LINQ to Entities~
~Expression<>~
IEnumerable
~IQueryable~
~PLINQ~

---

# Basics - LINQPad / NetPad

* Super tools for C# scripting!
* no need for `.sln`, `.csproj`
* easily connect to databases and query data the LINQ-way!
* or just write some console apps :)

[LINQPad](https://www.linqpad.net)
[NetPad](https://github.com/tareqimbasher/NetPad)

> 00-meetup-description-verification.netpad

---

# Basics - IEnumerable

> Wie viel Speicher brauchen wir, um ohne Enumerable eine 10GB-Datei einzulesen?

---

# .ToList() or .ToArray()?

```csharp
public static List<TSource> ToList<TSource>(this IEnumerable<TSource> source)
{
	if (source == null)
	{
		ThrowHelper.ThrowArgumentNullException(ExceptionArgument.source);
	}

	return source is IIListProvider<TSource> listProvider ? listProvider.ToList() : new List<TSource>(source);
}
```

```csharp
public static TSource[] ToArray<TSource>(this IEnumerable<TSource> source)
{
	if (source == null)
	{
		ThrowHelper.ThrowArgumentNullException(ExceptionArgument.source);
	}

	return source is IIListProvider<TSource> arrayProvider
		? arrayProvider.ToArray()
		: EnumerableHelpers.ToArray(source);
}
```

---

# .ToArray() --> EnumerableHelper.ToArray()

```csharp
internal static T[] ToArray<T>(IEnumerable<T> source)
{
	Debug.Assert(source != null);

	if (source is ICollection<T> collection)
	{
		int count = collection.Count;
		if (count == 0)
		{
			return Array.Empty<T>();
		}

		var result = new T[count];
		collection.CopyTo(result, arrayIndex: 0);
		return result;
	}

	LargeArrayBuilder<T> builder = new();
	builder.AddRange(source);
	return builder.ToArray();
}
```

---

# .ToList() --> new List<T>(collection)

```csharp
public List(IEnumerable<T> collection)
{
	if (collection == null)
		ThrowHelper.ThrowArgumentNullException(ExceptionArgument.collection);

	if (collection is ICollection<T> c)
	{
		int count = c.Count;
		if (count == 0)
		{
			_items = s_emptyArray;
		}
		else
		{
			_items = new T[count];
			c.CopyTo(_items, 0);
			_size = count;
		}
	}
	else
	{
		_items = s_emptyArray;
		using (IEnumerator<T> en = collection!.GetEnumerator())
		{
			while (en.MoveNext())
			{
				Add(en.Current);
			}
		}
	}
}
```

---

# Performanceprobleme

allFiles.ToList().Count > 0

