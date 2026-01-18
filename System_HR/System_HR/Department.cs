using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System_hr.System_HR;

namespace System_hr
{
    public class Department
    {

        [JsonInclude]
        public string Name { get; private set; }
        [JsonInclude]
        public Employee Manager { get; private set; }
        [JsonInclude]
        public List<Employee> Employees { get; private set; }

        public Department(string name)
        {
            this.Name = name;
            Employees = new List<Employee>();
        }
        public void AddEmployee(Employee emp)
        {
            if (emp is null) return;
            foreach(var e in Employees)
            {
                if (e.Equals(emp)) //wykorzystanie funkcji Equals
                {
                    return;
                }
            }
            Employees.Add(emp);
        }
        public void SetManager(Employee manager)
        {
            if(manager is null) { return; }
            if (manager.IsActive)
            {
                this.Manager = manager;
                AddEmployee(manager);
            }
        }
        //wykorzystanie metody Equals z klasy Empolyee
        public bool RemoveEmployee(Employee emp)
        {
            if (emp is null) return false;
            bool removed = Employees.Remove(emp);
            if(Manager!= null && Manager.Equals(emp))
            {
                Manager = null;
            }
            return removed;
        }
        public int NumberOfEmployeesByDepart()
        {
            return Employees.Count();
        }
        public decimal TotalDepartmentSalary()
        {
            return (decimal)Employees.Sum(e => e.Contract.CalculateSalary());
        }
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Department name: {Name} | Employees Number: {NumberOfEmployeesByDepart()} | Total Department Salary: {TotalDepartmentSalary()}");
            foreach(var employ in Employees)
            {
                sb.AppendLine(employ.ToString());
            }
            return sb.ToString();
        }



        public void SortEmployees()
        {
            Employees.Sort();
        }
        public void ShowEmployees()
        {
            foreach (var emp in Employees)
            {
                Console.WriteLine(emp.ToString());
            }
        }


        //Metoda do przeprowadzania symulacji podwyżki o podany procent
        public decimal SimulationSalaryRaise(decimal percentage)
        {
            List<Employee> clones = this.Employees.Select(e => (Employee)e.Clone()).ToList();

            foreach (var clone in clones)
            {
                clone.Contract?.IncreaseSalary(percentage);
            }
            return clones.Sum(c => c.Contract?.CalculateSalary() ?? 0);
        }

    }
}
