using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zabawka
{
    class Toy : Thing
    {
        public static readonly decimal minimalPrice;
        private string toyID;
        private EnumToyKind toyKind;
        private string name;
        private decimal price;

        public string ToyID { get => toyID; }
        public EnumToyKind ToyKind { get => toyKind; }
        public decimal Price
        {
            get => price;
            private set
            {
                if (value < minimalPrice)
                {
                    throw new InvalidThingDataException("Nieprawidłowa cena.");
                }
                price = value;
            }
        }
        public Toy(string name, EnumToyKind toyKind, decimal price) : base()
        {
            this.toyID = GenerateID();
            this.name = name;
            this.toyKind = toyKind;
            this.Price = price;// używam dużej litery dla walidacji
        }
        static Toy()
        {
            minimalPrice = 25.99m;
        }
        private string GenerateID()
        {
            string prefix = toyKind switch
            {
                EnumToyKind.Doll => "BA",
                EnumToyKind.Blocks => "BL",
                EnumToyKind.TeddyBear => "TB",
                EnumToyKind.Car => "CA",
                EnumToyKind.Other => "OT",
                _ => "XX"
            };
            return $"{prefix}\\{creationDate.Year}\\{thingID:D6}";
        }

 
        public virtual decimal SellingPrice()
        {
            int roznica = (int)(DateTime.Now - creationDate).TotalDays;
            return roznica > 30 ? 0.8m * price : price;
        }
        public override string ToString()
        {
            return $"Toy: {toyKind}, ID: {toyID}";
        }
    }
}
