# LINQsights
## Deep-dives, performance analysis and tips against pitfalls

presented at the [Meetup](https://www.meetup.com/dotnet-user-group/events/305841779/) of the [.NET User Group Rheintal](https://rheintal-dotnet.com/).

This presentation was made with a single markdown file which looks pretty good if you use [marp.app](https://marp.app) to visualize it :)  
But you can also use the exported versions: [PDF](linqsights.pdf) and [HTML](https://html-preview.github.io/?url=https%3A%2F%2Fgithub.com%2Fdevritter%2Fpresentations-2025-linqsights%2Fblob%2Fmain%2Flinqsights.html).

In the footer of each slide you'll find the related LINQPad file found in the [linqpad](./linqpad/) directory.

The performance comparisons have been made with simple `Stopwatch` measurements. To bring this to the next level you should definitely use [BenchmarkDotNet](https://benchmarkdotnet.org/).

What I learned at the Meetup: you can just use LINQPad to implement and run your BenchmarkDotNet methods :tada:.

## MARP
Links:
* [MARP explanation Video on YouTube](https://www.youtube.com/watch?v=EzQ-p41wNEE)
* [MARP VS Code Extension](https://marketplace.visualstudio.com/items?itemName=marp-team.marp-vscode)
* [Icons Cheat Sheet](https://dev.to/nikolab/complete-list-of-github-markdown-emoji-markup-5aia)

Less common documented stuff:
* Use `# <!-- fit --> MyHeader` to make the header as large as possible