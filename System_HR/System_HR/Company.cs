using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace System_hr.System_HR
{
    public class Company
    {
        string name;
        List<Department> departments;

        public string Name { get; set; }
        public List<Department> Departments { get; set; }
        public Company() 
        {
            Departments = new List<Department>();
        }
        public Company(string name) : this()
        {
            Name = name;
            Departments = new List<Department>();
        }
        public void SaveToJSON(string fname)
        {
            var options = new JsonSerializerOptions { WriteIndented = true };
            string jsonString = JsonSerializer.Serialize(this, options);
            File.WriteAllText(fname, jsonString);
        }
    }
}
