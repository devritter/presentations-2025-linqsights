<Query Kind="Statements">
  <NuGetReference>BlazingDev.BlazingExtensions</NuGetReference>
  <Namespace>BlazingDev.BlazingExtensions</Namespace>
  <Namespace>BlazingDev.BlazingExtensions.BlazingUtilities</Namespace>
</Query>

var names = "Anna,Bert,Clara,Daniel,Elisa,Franz,Gerlinde,Hans,Ida,Julian,Kathrin,Lukas".Split(',').Dump();

var result = new List<string>();
for (int i = 0; i < names.Length; i++)
{
	if (i % 3 == 0)
	{
		result.Add(names[i]);
	}
}
result.Dump();
