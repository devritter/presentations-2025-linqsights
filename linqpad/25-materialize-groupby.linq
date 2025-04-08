<Query Kind="Statements">
  <NuGetReference>BlazingDev.BlazingExtensions</NuGetReference>
  <Namespace>BlazingDev.BlazingExtensions</Namespace>
  <Namespace>BlazingDev.BlazingExtensions.BlazingUtilities</Namespace>
</Query>

var names = new[] { "Alice", "Anna", "Bob", "Bill", "Charlie" };

var groupedList = names
	.GroupBy(name => name[0])
	.ToList()
	.Dump(".ToList()");

var groupedDict = names
	.GroupBy(name => name[0])
	.ToDictionary(
		group => group.Key,            // key = first letter
		group => group.ToList()        // value = list of names
	)
	.Dump(".ToDictionary()");

var groupedLookup = names
	.ToLookup(name => name[0])
	.Dump(".ToLookup()");
