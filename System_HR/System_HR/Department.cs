using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System_hr.System_HR;

namespace System_hr
{
    class Department
    {
        string name;
        Employee manager;
        List<Employee> employees;

        public string Name { get; private set; }
        public Employee Manager { get; private set; }
        public List<Employee> Employess { get; }

        public Department(string name)
        {
            this.Name = name;
            employees = new List<Employee>();
        }
        public void AddEmployee(Employee emp)
        {
            if (emp is null) return;
            foreach(var e in employees)
            {
                if (e.Equals(emp)) //wykorzystanie funkcji Equals
                {
                    return;
                }
            }
            employees.Add(emp);
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
            bool removed = employees.Remove(emp);
            if(Manager!= null && Manager.Equals(emp))
            {
                Manager = null;
            }
            return removed;
        }
        public int NumberOfEmployeesByDepart()
        {
            return employees.Count();
        }
        public decimal TotalDepartmentSalary()
        {
            return (decimal)employees.Sum(e => e.Contract.CalculateSalary());
        }
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Department name: {Name} | Employees Number: {NumberOfEmployeesByDepart()} | Total Department Salary: {TotalDepartmentSalary()}");
            foreach(var employ in employees)
            {
                sb.AppendLine(employ.ToString());
            }
            return sb.ToString();
        }
    }
}
