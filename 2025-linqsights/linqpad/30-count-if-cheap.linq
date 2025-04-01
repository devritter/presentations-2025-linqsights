<Query Kind="Program">
  <NuGetReference>BlazingDev.BlazingExtensions</NuGetReference>
  <Namespace>BlazingDev.BlazingExtensions</Namespace>
  <Namespace>BlazingDev.BlazingExtensions.BlazingUtilities</Namespace>
  <RuntimeVersion>7.0</RuntimeVersion>
</Query>

void Main()
{
	var daysOfWeek = Enum.GetValues<DayOfWeek>();
	//GenerateMessage(daysOfWeek.ToList());
	//GenerateMessage(daysOfWeek.ToArray());
	//GenerateMessage(daysOfWeek.ToDictionary(x => (int)x, x => x.ToString()));

	//GenerateMessage(daysOfWeek.Where(x => true));
	//GenerateMessage(daysOfWeek.Where(x => false));

	//GenerateMessage(daysOfWeek.Reverse());
	//GenerateMessage(daysOfWeek.Take(2));
	//GenerateMessage(daysOfWeek.Skip(2));
	//GenerateMessage(daysOfWeek.Skip(2).Take(10));
	//GenerateMessage(daysOfWeek.Concat(daysOfWeek));
	//GenerateMessage(daysOfWeek.OrderBy(x => x.ToString()));
}

public void GenerateMessage<T>(IEnumerable<T> items)
{
	if (items.TryGetNonEnumeratedCount(out var count))
	{
		Console.WriteLine($"Got {count} items");
	}
	else
	{
		Console.WriteLine("Should I really count? Could take some time...");
	}
}

// You can define other methods, fields, classes and namespaces here
