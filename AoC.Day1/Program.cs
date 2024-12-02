// See https://aka.ms/new-console-template for more information

var file = File.ReadAllText("input.txt");
List<int> group1 = new List<int>();
List<int> group2 = new List<int>();

foreach (var line in file.Split(Environment.NewLine))
{
    var parts = line.Split(' ', StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries);
    group1.Add(int.Parse(parts[0]));
    group2.Add(int.Parse(parts[1]));
}

var group1Array = group1.OrderBy(s => s).ToArray();
var group2Array = group2.OrderBy(s => s).ToArray();
int distance = 0;
var similarityScore = 0;

for (int i = 0; i < group1Array.Length; i++)
{
   var value = Math.Abs(group1Array[i] - group2Array[i]);
   int count = 0;
   foreach (var instance in group2Array)
   {
       if (group1Array[i] == instance)
       {
           count++;
       }
   }
   
   similarityScore += count * group1Array[i];
   distance += value;
}

Console.WriteLine($"Distance: {distance}");
Console.WriteLine($"Similarity Score: {similarityScore}");