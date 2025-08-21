// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");

var person = new Person("TEst") as IPerson;
person.Hello();


interface IPerson
{
    void Hello();
}

public class Person : IPerson
{
    public Person(string name)
    {
        Name = name;
    }
   public string Name { get; private set; }

     void IPerson.Hello()
    {
        Console.WriteLine($"Hello - My name is {Name}");
    }
}