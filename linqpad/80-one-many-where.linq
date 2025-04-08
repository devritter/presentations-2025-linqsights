<Query Kind="Statements">
  <NuGetReference>BlazingDev.BlazingExtensions</NuGetReference>
  <Namespace>BlazingDev.BlazingExtensions</Namespace>
  <Namespace>BlazingDev.BlazingExtensions.BlazingUtilities</Namespace>
</Query>

var manyNumbers = Enumerable.Range(1, 10_000_000);
var specialNumbers = manyNumbers.OrderBy(x => Random.Shared.Next()).Take(20).ToList();//.Dump("specialNumbers");


var sw1 = Stopwatch.StartNew();
var result1 = manyNumbers.Where(x =>
	specialNumbers.Contains(x) &&
	specialNumbers.Contains(x) &&
	specialNumbers.Contains(x) &&
	specialNumbers.Contains(x) &&
	specialNumbers.Contains(x) &&
	specialNumbers.Contains(x) &&
	specialNumbers.Contains(x) &&
	specialNumbers.Contains(x) &&
	specialNumbers.Contains(x) &&
	specialNumbers.Contains(x))
	.ToList();
sw1.Stop();

var sw2 = Stopwatch.StartNew();
var result2 = manyNumbers
	.Where(x => specialNumbers.Contains(x))
	.Where(x => specialNumbers.Contains(x))
	.Where(x => specialNumbers.Contains(x))
	.Where(x => specialNumbers.Contains(x))
	.Where(x => specialNumbers.Contains(x))
	.Where(x => specialNumbers.Contains(x))
	.Where(x => specialNumbers.Contains(x))
	.Where(x => specialNumbers.Contains(x))
	.Where(x => specialNumbers.Contains(x))
	.Where(x => specialNumbers.Contains(x))
	.ToList();
sw2.Stop();

Console.WriteLine($"{sw1.Elapsed}\tSingle where");
Console.WriteLine($"{sw2.Elapsed}\tMulti where");
Console.WriteLine($"{(double)sw2.ElapsedMilliseconds / sw1.ElapsedMilliseconds}");