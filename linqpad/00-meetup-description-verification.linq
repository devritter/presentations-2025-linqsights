<Query Kind="Program">
  <NuGetReference>BlazingDev.BlazingExtensions</NuGetReference>
  <Namespace>BlazingDev.BlazingExtensions</Namespace>
  <Namespace>BlazingDev.BlazingExtensions.BlazingUtilities</Namespace>
</Query>

void Main()
{
	var meetup = new
	{
		MaxSlides = 10
	};

	var timer = new MyTimer();

	var data2 =
	(from x in LinqKnowledgeBase.GetAllInsights()
	 where x.IsDeveloperRelevant && !x.IsWellKnown
	 orderby x.Fancyness descending
	 select new MeetupSlide(x.Headline, x.Content, x.DemoCode))
	 .Take(meetup.MaxSlides)
	 .TakeWhile(_ => !timer.IsTimeOver())
	 .ToList();
	 
	 data2.Dump();
}

public static class LinqKnowledgeBase
{
	public static IEnumerable<KbItem> GetAllInsights()
	{
		yield return new KbItem(true, false, 100, "LINQPad", "LINQPad is great", "you see it now");
		yield return new KbItem(true, false, 80, "NetPad", "Also looks quite good", "");
	}
}

public class MyTimer()
{
	public bool IsTimeOver() => false;
}

public record KbItem(bool IsDeveloperRelevant, bool IsWellKnown, int Fancyness, string Headline, string Content, string DemoCode);
public record MeetupSlide(string Headline, string Content, string DemoCode);
// You can define other methods, fields, classes and namespaces here
