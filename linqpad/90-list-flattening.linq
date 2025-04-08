<Query Kind="Statements">
  <NuGetReference>BlazingDev.BlazingExtensions</NuGetReference>
  <Namespace>BlazingDev.BlazingExtensions</Namespace>
  <Namespace>BlazingDev.BlazingExtensions.BlazingUtilities</Namespace>
</Query>

var peopleWithPets = new[] {
	new { Name = "Anna",   Pets = new[] { "Dog", "Cat", "Parrot" } },
	new { Name = "Ben",    Pets = new[] { "Fish", "Hamster", "Snake" } }
};

peopleWithPets.Select(x => x.Pets).Dump("pets nested");

peopleWithPets.SelectMany(p => p.Pets).Dump("pets flattened");
