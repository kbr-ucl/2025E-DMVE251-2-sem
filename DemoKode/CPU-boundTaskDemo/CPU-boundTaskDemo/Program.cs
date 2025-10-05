using CPU_boundTaskDemo;

var maxNumber = 100000000;

Console.WriteLine("Prime number parallel calculation");
var tplVersion = new TPLversion();
var asyncVersion = new AsyncAwaitVersion();

tplVersion.CalculatePrimenumbers(maxNumber);
asyncVersion.CalculatePrimenumbers(maxNumber);

//asyncVersion.CalculatePrimenumbers(maxNumber);
//tplVersion.CalculatePrimenumbers(maxNumber);

Console.WriteLine("Press any key to output");
Console.Read();