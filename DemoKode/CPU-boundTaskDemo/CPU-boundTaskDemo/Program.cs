using CPU_boundTaskDemo;

var maxNumber = 100000000;

Console.WriteLine("Prime number parallel calculation");
var tplVersion = new TPLversion();
var asyncVersion = new AsyncAwaitVersion();

Console.WriteLine("TPL starts first");
tplVersion.CalculatePrimenumbers(maxNumber);
var asyncTask = asyncVersion.CalculatePrimenumbers(maxNumber);

await asyncTask;
Console.WriteLine();
Console.WriteLine("Async/Await starts first");

var asyncTask1 = asyncVersion.CalculatePrimenumbers(maxNumber);
tplVersion.CalculatePrimenumbers(maxNumber);

await asyncTask1;
Console.WriteLine();
Console.WriteLine();
Console.WriteLine("Press any key to output");
Console.Read();