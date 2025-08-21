// See https://aka.ms/new-console-template for more information

Console.WriteLine("Hello, World!");

var person = Factory(1);
person.Hello();
person = Factory(2);
person.Hello();

 IPerson Factory(int type)
 {
     if (type == 1) return new Person("Person");
     return new PersonChild("Child");
 }
    interface IPerson
{
    void Hello();
}

public class PersonChild : IPerson
{
    public string Name { get; }

    public PersonChild(string name)
    {
        Name = name;
    }

    void IPerson.Hello()
    {
        Console.WriteLine($"Hello - My name is {Name} and I am under age");
    }
}

public class Person : IPerson
{
    public string Name { get; }

    public Person(string name)
    {
        Name = name;
    }

    void IPerson.Hello()
    {
        Console.WriteLine($"Hello - My name is {Name}");
    }
}

public class PersonFake : IPerson
{
    void IPerson.Hello()
    {
        Console.WriteLine("I'm a fake");
    }
}