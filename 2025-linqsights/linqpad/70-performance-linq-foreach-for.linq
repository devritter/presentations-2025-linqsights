<Query Kind="Statements">
  <NuGetReference>BlazingDev.BlazingExtensions</NuGetReference>
  <Namespace>BlazingDev.BlazingExtensions</Namespace>
  <Namespace>BlazingDev.BlazingExtensions.BlazingUtilities</Namespace>
</Query>

var values = Enumerable.Range(0, 10_000_000).Select(x => (double)x).ToList();

var sw1 = Stopwatch.StartNew();
var linqSum = values
	.Where(x => x % 2 == 0)
	.Sum();
sw1.Stop();

var sw2 = Stopwatch.StartNew();
var foreachSum = 0d;
foreach (var number in values)
{
	if (number % 2 == 0)
	{
		foreachSum += number;
	}
}
sw2.Stop();

var sw3 = Stopwatch.StartNew();
var forSum = 0d;
for (int i = 0; i < values.Count; i++)
{
	if (values[i] % 2 == 0)
	{
		forSum += values[i];
	}
}
sw3.Stop();

Console.WriteLine($"{sw1.Elapsed}\t{linqSum}\tLINQ");
Console.WriteLine($"{sw2.Elapsed}\t{foreachSum}\tforeach");
Console.WriteLine($"{sw3.Elapsed}\t{forSum}\tfor");