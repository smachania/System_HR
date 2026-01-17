using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace System_hr.System_HR
{
    public class Company
    {

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
        public static Company ReadFromJson(string fname)
        {
            if (!File.Exists(fname)) { throw new FileNotFoundException("The file does not exist."); }
            string jsonString = File.ReadAllText(fname);
            var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true }; //zwracanie uwagi na właściwości a pola
            return JsonSerializer.Deserialize<Company>(jsonString);
        }
    }
}
