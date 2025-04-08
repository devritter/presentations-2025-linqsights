<Query Kind="Statements">
  <NuGetReference>BlazingDev.BlazingExtensions</NuGetReference>
  <Namespace>BlazingDev.BlazingExtensions</Namespace>
  <Namespace>BlazingDev.BlazingExtensions.BlazingUtilities</Namespace>
</Query>

var numbers = Enumerable.Range(1, 10_000_000).Where(x => true);
var sw = Stopwatch.StartNew();

numbers
.OrderBy(x => x)
//.Skip(1)
.Distinct()
//.Where(x => true)
//.Take(100).ToList()
//.Any()
.Count()
;

sw.Stop();
sw.Elapsed.Dump();