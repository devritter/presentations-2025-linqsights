---
marp: true
class: invert
paginate: true
_paginate: skip
backgroundImage: "linear-gradient(to top right,rgb(11, 24, 31),rgb(10, 93, 138))"
---

![bg opacity](img/vs-screenshot-enumerable.jpg)
# <!--fit-->LINQsights
## Deep-Dives, Performanceanalysen und Tipps gegen Stolperfallen

<br/>

by David Ritter 
[devritter](https://www.github.com/devritter) @github

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

<!-- Question upfront: who uses "query syntax", who "Method syntax"? -->

---

# <!-- fit --> First some basics!

---

# Before LINQ

* Nested loops
* Queries against data sources with strings
* Different APIs for different data sources

# With LINQ

* Query syntax integrated into the C# language => __L__-anguage __IN__-tegrated __Q__-uery
* Same query and transformation pattern against differerent data sources
* Type checking
* Expression Trees
* Lazy Evaluation

---

# Scope of This Presentation

* :x: LINQ to Objects / SQL / Entities
* :x: IQueryable
* :x: Expression<>
* :x: PLINQ
* :white_check_mark: IEnumerable and :white_check_mark: item streaming
* :white_check_mark: performance considerations
* :white_check_mark: pitfalls
* :white_check_mark: tips and tricks
* :white_check_mark: LINQPad

---

# LINQPad / NetPad (free)

* Super tools for C# scripting!
* no need for `.sln`, `.csproj`
* easily connect to databases and query data the LINQ-way!
* or just write some console apps :)
* `.Dump()` takes everything and displays it nicely!
* [LINQPad](https://www.linqpad.net)
* [NetPad](https://github.com/tareqimbasher/NetPad)

<!-- _footer: 00-meetup-description-verification.netpad -->

---

# Technical Basis

* `IEnumerable<T>`
* Extension methods
* Object Initializers `new SomeClass { PropA = x.Name }`
* Anonymouse Types `new { x.Name }`
* Local variable type inference `var`
* Lambda expressions `x => x.Size > 10`
* Expression Trees (for `IQueryable<T>`)

<!-- most of it with the release of C# 3.0, .NET Framework 3.5, 2007 -->

---

# What is an `IEnumerable<T>`?

* An interface, implemented by:
* `List<T>`
* `T[]`
* `Dictionary<TKey, TValue>`
* `HashSet<T>`
* `string` => `IEnumerable<char>`

---

# Can I create `IEnumerable<T>`s myself?

Of course!

```csharp
public static IEnumerable<string> MyItemFactory()
{
	yield return "I will";
	yield return "always return";
	yield return "the same starting text";
	
	if (DateTime.Now.DayOfWeek is DayOfWeek.Saturday or DayOfWeek.Sunday)
	{
		yield return "Did you know it's weekend?";
	}
	if (DateTime.Now.Year == 2012)
	{
		yield return "the end is near!!!";
		yield break;
	}

	yield return "thanks for iterating!";
}



// extra lines to fix slide rendering glitch
```

<!-- yield keyword is from C# 2.0 -->
<!-- _footer: 05-yield.linq -->

---

# What if I don't have `IEnumerable<T>` :scream:?

```csharp
var myString = "Hello Meetup people!";
var matches = Regex.Matches(myString, "Meetup");
matches.First(); // <-- compile error! 
```

# Fixes

* `matches.OfType<Match>()`
* `matches.Cast<Match>()`

---

<!-- _backgroundImage: linear-gradient(to right, gray, gray) -->
![bg fit](img/i-always-use-lists.jpg)

---

# I use Lists / `.ToList()` always - that's ok, right?

Let's parse a CSV file
- Warehouse and retail sales
- 26 MB
- ~300k Lines

Question 1: How many items of type "WINE" are inside of this file?
Question 2: What's the RAM usage for that application?

<!-- start with File.ReadAllLines => +50MB memory, why? -->
<!-- replace with File.ReadAllLines -->
<!-- possibility to do "early exit" -->
<!-- Split(char) is faster than Split(string) -->

<!-- _footer: 10-csv-reading-bad.linq -->

---

# I use Lists / `.ToList()` always - that's ok, right?

* depends on what you will do with your data
* if you need to iterate over it multiple times
	* do you always need ALL data?
	* how FAST is your data source? (e.g. disk speed)
	* do some benchmarking!

---

![bg left fit](img/tolist-toarray.jpeg)
# .ToList() or .ToArray()?

Which is faster?

<br />

* Check if that's really your performance bottleneck ;)
* If your source is an `ICollection` already, it does not really make a big difference
* Do you really need everything in memory?
* depends on how you will modify the resulting collection

<!-- dig into .ToList() and .ToArray() -->
<!-- check out, why they are so fast -->
<!-- question your performance measurements! twist execution order, check computer load... -->
<!-- _footer: 20-tolist-toarray.linq, 21-tolist-toarray-wheretrue.linq -->

---

![bg right fit](./img/icollection.drawio.svg)

# So I make methods for `List<T>` AND `T[]` to be performant?

No, there is a better option!

`ICollection<T>`

---

# Don't know if `.Count()` could be expensive?
e.g. for Pagination controls
<br />

* use `TryGetNonEnumeratedCount(out int count)`
* even works with some other LINQ methods in place, like `.Reverse()` or `.Take()`

<!-- _footer: 30-count-if-cheap.linq -->

---

# <!-- fit --> `.Count() > 0` :shit:

Problems:

* reading all lines / files / ...
* to count every item ...
* just to say "oh yeah, there is something!"

---

# <!-- fit --> `.Count() > 0` :shit:

OK-ish :see_no_evil: (from performance perspective):
* `.Count > 0`
* `.Length > 0`

But more expressive:
* `.Any()`
* `.HasContent()` => **BlazingExtensions**

<!-- "Any()" uses Count internally or just pulls one item -->

---

# Checking for empty collections

Difficult to read:
* `myItems.Count() == 0`
* `myItems.Count == 0`
* `!myItems.Any()`
* `!myItems?.Any() ?? false`

Solution:
* `myItems.LacksContent()` => **BlazingExtensions**

---

# Should I use `.Where(x => ...).Count()` or `.Count(x => ...)`?

TODO

---

# Beware of empty lists!

Which problems can occur here?

```csharp
someNumbers.Min();
someNumbers.Max();
someNumbers.Average();
someNumbers.Sum();
```

Solution:
```csharp
someNumbers = someNumbers.DefaultIfEmpty();
someNumbers.Min();
someNumbers.Max();
someNumbers.Average();
someNumbers.Sum();
```

<!-- no problem with `.Sum()` ;) -->
<!-- but beware of using `.Count()` ! -->
<!-- _footer: 40-min-max-avg-empty-list.linq -->

---

# Everything `All()`-right?

```csharp
int[] someNumbers = [1,5,10];

someNumbers.All(x => x > 0); 
// returns true

someNumbers.All(x => x > 10);
// returns false

someNumbers.Where(x => x > 100).All(x => x > 0);
// returns ?
```

* => `.BzAll()` from **BlazingExtensions**

<!-- _footer: 50-all.linq -->

---

# Use `for`-loop features in LINQ

Your tasks:
1) only take every 10th element of a list
2) select ViewModel objects and set their ListIndex property

<!-- names.Where((item, index) => index % 3 == 0).Dump(); -->
<!-- names.Index().Dump().Where(x => x.Index % 3 == 0).Dump(); -->
<!-- _footer: 60-linq-with-index.linq -->
