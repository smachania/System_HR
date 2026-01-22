using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System_hr.System_HR;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace System_hr.System_HR
{
    public class WrongPeselException : Exception 
    {
        public WrongPeselException() : base() { }
        public WrongPeselException(string message) : base(message) { }
    }
    public enum EnumPlec { K, M };
    public class Employee : IIdentifiable, IComparable<Employee>, ICloneable
    {
        string pesel;
 
        static int counter;
        [JsonInclude]
        public int Id { get; private set; } 
        [JsonInclude]
        public string Name { get;  set; }
        [JsonInclude]
        public string Surname { get; set; }
        [JsonInclude]
        public EnumPlec Plec { get;  set; }
        [JsonInclude]
        public string Pesel
        {
            get => pesel;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new WrongPeselException("Pesel nie może być pusty"); 
                }
                Regex r = new Regex(@"^\d{11}$");
                if (r.IsMatch(value))
                {
                    pesel = value;
                }
                else 
                {
                    throw new WrongPeselException("Pesel niepoprawny");
                }
            }
        }
        [JsonInclude]
        public DateTime HireDate { get; private set; }
        [JsonInclude]
        public bool IsActive { get; private set; }
        [JsonInclude]
        public Contract Contract { get; private set; }

        static Employee()
        {
            counter = 1;
        }
        public Employee(string name, string surname, EnumPlec plec, string pesel, DateTime hireDate)
        {
            Id = counter++;
            Name = name;
            Surname = surname;
            Plec = plec;
            Pesel = pesel;
            HireDate = hireDate;
            IsActive = true; 
        }

        public void Terminate()
        {
            IsActive = false;
            Contract?.EndContract(DateTime.Now); 
        }
        public void ChangeContract(Contract newContract)
        {
            if (newContract == null) return; 
            Contract?.EndContract(DateTime.Now); 
            Contract = newContract;
        }

      
        public override string ToString()
        {
            string status = IsActive ? "Aktywny" : "Zwolniony";
            string contractInfo = Contract != null ? Contract.ToString() : "Brak umowy";
            return $"[ID: {Id}] {Name} {Surname} | PESEL: {Pesel} | Płeć: {Plec} | Status: {status} | Umowa: {contractInfo}";
        }


   
        public int CompareTo(Employee other)
        {
            if(other == null) return 1;
            int surnamecompare = Surname.CompareTo(other.Surname);
            if(surnamecompare != 0) 
                return  surnamecompare; 
            return Name.CompareTo(other.Name);

        }

        public object Clone()
        {
      
            Employee clone = (Employee)this.MemberwiseClone();

      
            if (this.Contract != null)
            {
                clone.Contract = (Contract)this.Contract.Clone();
            }

            return clone;
        }
    }
}
    
