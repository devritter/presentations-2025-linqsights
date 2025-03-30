<Query Kind="Program">
  <Reference>&lt;RuntimeDirectory&gt;\System.Data.dll</Reference>
  <Reference>&lt;RuntimeDirectory&gt;\System.Data.Entity.dll</Reference>
  <Reference>&lt;RuntimeDirectory&gt;\System.Threading.dll</Reference>
  <Reference>&lt;RuntimeDirectory&gt;\System.Threading.Tasks.dll</Reference>
  <Reference>&lt;RuntimeDirectory&gt;\System.Threading.Tasks.Parallel.dll</Reference>
  <Namespace>System.Data.Entity</Namespace>
  <Namespace>System.Threading</Namespace>
  <Namespace>System.Threading.Tasks</Namespace>
</Query>

void Main()
{
	var currentDirectory = Path.GetDirectoryName(Util.CurrentQueryPath);
	var path = Path.Combine(currentDirectory, "../Warehouse_and_Retail_Sales.csv").Dump();
	var lines = File.ReadAllLines(path);
	
	var toListStopwatch = Stopwatch.StartNew();
	
	for (int i = 0; i < 100; i++)
	{
		lines.Where(x => true).ToList();
	}
	
	toListStopwatch.Stop();
	
	var toArrayStopwatch = Stopwatch.StartNew();
	
	for (int i = 0; i < 100; i++)
	{
		lines.Where(x => true).ToArray();
	}
	
	toArrayStopwatch.Stop();
	
	toListStopwatch.Elapsed.Dump("ToList()");
	toArrayStopwatch.Elapsed.Dump("ToArray()");
}

// Define other methods and classes here
private static void PrintRam(string name)
{
	var ramBytes = Process.GetCurrentProcess().WorkingSet64;
	
	var mb = (ramBytes / 1024 / 1024) + " MB";
	mb.Dump(name);
}