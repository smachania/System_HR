using System_hr;
using System_hr.System_HR;

internal class Program
{
    private static void Main(string[] args)
    {
        EmployeeTest();
        SurnameSort();
        SalaryRaise_Test();
        ReadFileTest();
    }
    static void EmployeeTest()
    {
        Company comp = new Company("IT Company");
        Employee e1 = new("Robert", "Lewandowski", EnumPlec.M, "82010112345", new DateTime(2015, 5, 10));
        Employee e2 = new("Anna", "Zielińska", EnumPlec.K, "88051255667", new DateTime(2018, 3, 20));
        Employee e3 = new("Maria", "Mazur", EnumPlec.K, "03251211223", new DateTime(2023, 12, 01));

        Employee e4 = new("Karolina", "Krawczyk", EnumPlec.K, "90060677889", new DateTime(2019, 1, 15));
        Employee e5 = new("Julia", "Nowakowska", EnumPlec.K, "95022833441", new DateTime(2021, 8, 10));

        Employee e6 = new("Barbara", "Jankowska", EnumPlec.K, "75081522334", new DateTime(2010, 4, 12));
        Employee e7 = new("Jan", "Wójcik", EnumPlec.M, "81041266778", new DateTime(2016, 2, 28));

        Employee e8 = new("Michał", "Wiśniewski", EnumPlec.M, "89030311223", new DateTime(2018, 11, 12));
        Employee e9 = new("Adam", "Dudek", EnumPlec.M, "96070755443", new DateTime(2022, 05, 20));
        e1.ChangeContract(new B2BContract(new DateTime(2024, 1, 1), 200m, 160));
        e2.ChangeContract(new B2BContract(new DateTime(2024, 1, 1), 160m, 160));
        e3.ChangeContract(new InternshipContract(new DateTime(2023, 12, 1), "Politechnika", 3, true));
        e4.ChangeContract(new EmployeeContract(new DateTime(2024, 1, 1), 9000m, 2000m));
        e5.ChangeContract(new EmployeeContract(new DateTime(2024, 1, 1), 6000m, 500m, 10));
        e6.ChangeContract(new EmployeeContract(new DateTime(2024, 1, 1), 11000m));
        e7.ChangeContract(new B2BContract(new DateTime(2024, 1, 1), 100m, 160));
        e8.ChangeContract(new EmployeeContract(new DateTime(2024, 1, 1), 7500m));
        e9.ChangeContract(new EmployeeContract(new DateTime(2024, 1, 1), 4500m, 200m, 25));

        Department it = new Department("Software development");
        it.SetManager(e1);
        it.AddEmployee(e2);
        it.AddEmployee(e3);
        comp.Departments.Add(it);

        Department marketing = new Department("Marketing & Sales");
        marketing.SetManager(e4);
        marketing.AddEmployee(e5);
        comp.Departments.Add(marketing);

        Department admin = new Department("Administration");
        admin.SetManager(e6);
        admin.AddEmployee(e7);
        comp.Departments.Add(admin);

        Department services = new Department("Customer Service");
        services.SetManager(e8);
        services.AddEmployee(e9);
        comp.Departments.Add(services);

        Console.WriteLine(it);
        Console.WriteLine($"Salary of 1 employee: {((B2BContract)e1.Contract).CalculateTotalSalary()}");
        Console.WriteLine($"Salary of 2 employee: {((B2BContract)e2.Contract).CalculateTotalSalary()}");
        Console.WriteLine($"Salary of 3 employee: {e3.Contract.CalculateSalary()}");

        comp.SaveToJSON("company.json");

    }


    static void SurnameSort()
    {
        Console.WriteLine("\n-------------------------------");
        Console.WriteLine("\nSortowanie listy pracownikow");
        Department d1 = new("IT");
        d1.AddEmployee(new Employee("Robert", "Lewandowski", EnumPlec.M, "82010112345", new DateTime(2015, 5, 10)));
        d1.AddEmployee(new Employee("Anna", "Zielińska", EnumPlec.K, "88051255667", new DateTime(2018, 3, 20)));
        d1.AddEmployee(new Employee("Maria", "Mazur", EnumPlec.K, "03251211223", new DateTime(2023, 12, 01)));
        d1.AddEmployee(new Employee("Mariusz", "Lewandowski", EnumPlec.M, "82010112345", new DateTime(2015, 5, 10)));

        Console.WriteLine("--- Przed sortowaniem: ---");
        d1.ShowEmployees();

        d1.SortEmployees();

        Console.WriteLine("\n--- Po sortowaniu ---");
        d1.ShowEmployees();
    }


    static void SalaryRaise_Test()
    {
        Console.WriteLine("\n-------------------------------");
        Console.WriteLine("\nTestowanie symulacji podwyżki");

        Employee e1 = new("Robert", "Lewandowski", EnumPlec.M, "82010112345", new DateTime(2015, 5, 10));
        Employee e2 = new("Anna", "Zielińska", EnumPlec.K, "88051255667", new DateTime(2018, 3, 20));
        Employee e3 = new("Maria", "Mazur", EnumPlec.K, "03251211223", new DateTime(2023, 12, 01));

        e1.ChangeContract(new EmployeeContract(new DateTime(2024, 1, 1), 9000m, 2000m));
        e2.ChangeContract(new EmployeeContract(new DateTime(2024, 1, 1), 6000m));
        e3.ChangeContract(new InternshipContract(new DateTime(2023, 12, 1), "Politechnika", 3, true));

        Department d1 = new Department("IT");
        d1.AddEmployee(e1);
        d1.AddEmployee(e2);
        d1.AddEmployee(e3);
        d1.SetManager(e2);

        Console.WriteLine($"Koszt działu przed podwyżką: {d1.TotalDepartmentSalary()} zł");

        Console.WriteLine($"Koszt działu po symulacji 10% podwyżki: {d1.SimulationSalaryRaise(10)} zł");
        Console.WriteLine($"\n-----------------------------");
    }


    static void ReadFileTest()
    {
        string path = "company.json";
        Company loadedCompany = Company.ReadFromJson(path);
        Console.WriteLine($"Name of the company: {loadedCompany.Name}");
        Console.WriteLine($"Number of departments: {loadedCompany.Departments.Count}");
        string check = loadedCompany.GetTotalCostsMadeByDepartment();
        Console.WriteLine(check);
    }

}