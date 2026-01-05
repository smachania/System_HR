using Zabawka;

internal class Program
{
    private static void Main(string[] args)
    {
        TestID();
    }
    static void TestID()
    {
        Toy t1 = new(EnumToyKind.Doll);
        Toy t2 = new(EnumToyKind.Car);
        Console.WriteLine(t1);//abyfaktycznie przetestwoac te metode musze dodac ToString, w sensie overrride, inaczejnie pojdzie
        Console.WriteLine(t2);
    }
}