<Query Kind="Statements">
  <NuGetReference>BlazingDev.BlazingExtensions</NuGetReference>
  <Namespace>BlazingDev.BlazingExtensions</Namespace>
  <Namespace>BlazingDev.BlazingExtensions.BlazingUtilities</Namespace>
</Query>

IEnumerable<int> someNumbers = Enumerable.Empty<int>();

someNumbers.Min().Dump();
someNumbers.Max().Dump();
someNumbers.Average().Dump();
someNumbers.Sum().Dump();
