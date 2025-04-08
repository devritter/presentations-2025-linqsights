<Query Kind="Program">
  <Reference>&lt;RuntimeDirectory&gt;\System.Threading.dll</Reference>
  <Reference>&lt;RuntimeDirectory&gt;\System.Threading.Tasks.dll</Reference>
  <Reference>&lt;RuntimeDirectory&gt;\System.Threading.Tasks.Parallel.dll</Reference>
  <Namespace>System.Threading</Namespace>
  <Namespace>System.Threading.Tasks</Namespace>
</Query>

void Main()
{
	PrintRam("start of program");
	
	var currentDirectory = Path.GetDirectoryName(Util.CurrentQueryPath);
	var path = Path.Combine(currentDirectory, "../Warehouse_and_Retail_Sales.csv").Dump();
	
	PrintRam("before reading the file");
	
	//var lines = File.ReadAllLines(path);
	var lines = File.ReadLines(path);
	
	PrintRam("after reading the file");

	var result = 0;
	foreach (var line in lines)
	{		
		if (result >= 1000)
		{
			Console.WriteLine("a lot!");
			break;
		}
		var lineParts = line.Split(',');
		if (lineParts.Contains("WINE"))
		{
			result++;
		}
	}

	result.Dump("wine lines");

	PrintRam("end of program");
}

// Define other methods and classes here
private static void PrintRam(string name)
{
	var ramBytes = Process.GetCurrentProcess().WorkingSet64;
	
	var mb = (ramBytes / 1024 / 1024) + " MB";
	mb.Dump(name);
}