<Query Kind="Statements">
  <NuGetReference>BlazingDev.BlazingExtensions</NuGetReference>
  <Namespace>BlazingDev.BlazingExtensions</Namespace>
  <Namespace>BlazingDev.BlazingExtensions.BlazingUtilities</Namespace>
</Query>

IEnumerable<int?> numbers = [ null, 5, null, 5000 ];
numbers.Sum().Dump("Sum");
numbers.Min().Dump("Min");
numbers.Max().Dump("Max");
numbers.Average().Dump("Average");
numbers.Count().Dump("Count"); // this also contains null items!

// .WhereNotNull() from BlazingExtensions
numbers.WhereNotNull().Dump();