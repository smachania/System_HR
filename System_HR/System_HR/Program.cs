using System_hr.System_HR;

internal class Program
{
    private static void Main(string[] args)
    {
        EmployeeTest();
    }
    static void EmployeeTest()
    {
        Employee e1 = new("Jan", "Mucha", EnumPlec.M, "99876756333", new DateTime(2023, 10, 15));
        Console.WriteLine(e1);
    }
}