<Query Kind="Program">
  <NuGetReference>BlazingDev.BlazingExtensions</NuGetReference>
  <Namespace>BlazingDev.BlazingExtensions</Namespace>
  <Namespace>BlazingDev.BlazingExtensions.BlazingUtilities</Namespace>
</Query>

void Main()
{
	var numbers = Enumerable.Range(1, 100_000_000);
	var doComplexCheck = false;

	var sw = Stopwatch.StartNew();
	var query = numbers
		.Where(x => x.ToString().Length > 4);

	if (doComplexCheck)
	{
		query = query.Where(x => ComplexCheck(x));
	}
		
	var count = query
		.Count()
		.Dump();
	sw.Stop();
	sw.Elapsed.Dump();
}

bool ComplexCheck(int x)
{
	return x.ToString().Length > 4;
}
