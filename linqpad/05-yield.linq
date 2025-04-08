<Query Kind="Program">
  <NuGetReference>BlazingDev.BlazingExtensions</NuGetReference>
  <Namespace>BlazingDev.BlazingExtensions</Namespace>
  <Namespace>BlazingDev.BlazingExtensions.BlazingUtilities</Namespace>
</Query>

void Main()
{
	MyItemFactory().Dump();
}

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
