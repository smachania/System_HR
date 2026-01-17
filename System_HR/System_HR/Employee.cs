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
    public class WrongPeselException : Exception //własny wyjątek
    {
        public WrongPeselException() : base() { }
        public WrongPeselException(string message) : base(message) { }
    }
    public enum EnumPlec { K, M };
    public class Employee:IEquatable<Employee>
    {
        string pesel;

        static int counter;
        [JsonInclude]
        public int Id { get; private set; } //zmiana na private, aby nikt z zewnatrz nie mogl tego zmienic
        [JsonInclude]
        public string Name { get; private set; }
        [JsonInclude]
        public string Surname { get; private set; }
        [JsonInclude]
        public EnumPlec Plec { get; private set; }
        [JsonInclude]
        public string Pesel //hermetyzacja
        {
            get => pesel;
            set
            {
                if (string.IsNullOrWhiteSpace(value))//walidacja ull
                {
                    throw new WrongPeselException("Pesel nie może być pusty"); //dzięki temu mamy wieększą walidację oraz czytelniejsze komunikaty
                }
                Regex r = new Regex(@"^\d{11}$"); // przy pomocy regex sprawdzamy poprawność wpisanego peselu
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
        public Employee(string name, string surname, EnumPlec plec, string pesel, DateTime hireDate)// z parametrów wyrzucam id i isactive, dlatego, że będzie się to automatycznie tworzyć
        {
            Id = counter++;
            Name = name;
            Surname = surname;
            Plec = plec;
            Pesel = pesel;
            HireDate = hireDate;
            IsActive = true; //po przyjęciu nowego pracownika zakładmy, że jest aktywny
        }

        public void Terminate()
        {
            IsActive = false;
            Contract?.EndContract(DateTime.Now); 
        }
        public void ChangeContract(Contract newContract)
        {
            if (newContract == null) return; // jeśli ktoś prześle null to nic nie rób
            Contract?.EndContract(DateTime.Now); //sprawdzamy czy obecnie istnieje jakis kontrakt i jesli tak to go konczymy
            Contract = newContract;
        }
        public bool Equals(Employee? other)
        {
            if (other is null) return false;
            return this.Pesel == other.Pesel;
        }
        public override bool Equals(object? obj)
        {
            return Equals(obj as Employee);
        }
        public override int GetHashCode()
        {
            return Pesel.GetHashCode();
        }

        //wyświetlanie danych pracownika w konsoli
        public override string ToString()
        {
            string status = IsActive ? "Aktywny" : "Zwolniony";
            string contractInfo = Contract != null ? Contract.ToString() : "Brak umowy";
            return $"[ID: {Id}] {Name} {Surname} | PESEL: {Pesel} | Płeć: {Plec} | Status: {status} | Umowa: {contractInfo}";
        }


    }
}
    
