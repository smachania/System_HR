using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace System_hr.System_HR
{
    public class WrongPeselException : Exception //własny wyjątek
    {
        public WrongPeselException() : base() { }
        public WrongPeselException(string message) : base(message) { }
    }
    public enum EnumPlec { K, M };
    public class Employee
    {
        int id;
        string name;
        string surname;
        EnumPlec plec;
        string pesel;
        DateTime hireDate;
        bool isActive;
        static int counter;

        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public EnumPlec Plec { get; set; }
        public string Pesel 
        { 
            get => pesel; 
            set {
                Regex r = new Regex(@"\d{11}$"); // przy pomocy regex sprawdzamy poprawność wpisanego peselu
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
        public DateTime HireDate { get; set; }
        public bool IsActive { get; private set; }

        static Employee()
        {
            counter = 1;
        }
        public Employee(string name, string surname, EnumPlec plec, string pesel, DateTime hireDate)// z parametrów wyrzucam id i isactive, dlatego, że będzie się to automatycznie tworzyć
        {
            Id = counter++;
            Name = name;
            Surname = surname;
            Plec = plec;
            Pesel = pesel;
            HireDate = hireDate;
            IsActive = true; //po przyjęciu nowego pracownika zakłamy, że jest aktywny
        }
        public void Terminate()
        {
            IsActive = false;
            //Contract?.EndContract(DateTime.Now); // End Contract dodamy te metode w Contract
        }
        //public void ChangeContract(Contract newContract)
        //{
        //    Contract = newContract;
        //}
    }
}
