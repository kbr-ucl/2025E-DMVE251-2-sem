// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");

// Brug
IShape circle = new Circle();
IShape redCircle = new RedBorderDecorator(circle);
redCircle.Draw();


interface IShape
{
    void Draw();
}

class Circle : IShape
{
    public void Draw()
    {
        Console.WriteLine("Drawing Circle");
    }
}

abstract class ShapeDecorator : IShape
{
    protected IShape decoratedShape;
    public ShapeDecorator(IShape shape)
    {
        decoratedShape = shape;
    }
    public virtual void Draw()
    {
        decoratedShape.Draw();
    }
}

class RedBorderDecorator : ShapeDecorator
{
    public RedBorderDecorator(IShape shape) : base(shape) { }
    public override void Draw()
    {
        base.Draw();
        Console.WriteLine("Adding Red Border");
    }
}


