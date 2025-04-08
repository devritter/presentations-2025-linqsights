<Query Kind="Program">
  <NuGetReference>BlazingDev.BlazingExtensions</NuGetReference>
  <Namespace>BlazingDev.BlazingExtensions</Namespace>
  <Namespace>BlazingDev.BlazingExtensions.BlazingUtilities</Namespace>
</Query>

void Main()
{
	int[] someNumbers = [1, 5, 10];
	
	someNumbers.All(x => x > 0).Dump("expect true");
	someNumbers.All(x => x > 10).Dump("expect false");
	//someNumbers.Where(x => x > 100).Dump("items left").All(x => x > 0).Dump("expect ???");
	
	
	
	
	
	
	
	return;
	var kids = new List<Kid>();
	var allKidsInBed = kids.All(x => x.IsInBed);
	//allKidsInBed.Dump("expect ???");
	//kids.BzAll(x => x.IsInBed).Dump("bzall");
}

public record Kid(string Name, bool IsInBed);
// You can define other methods, fields, classes and namespaces here
