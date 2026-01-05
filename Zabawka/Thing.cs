using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading.Tasks.Dataflow;

namespace Zabawka
{
    public class InvalidThingDataException : Exception
    {
        public InvalidThingDataException() { }
        public InvalidThingDataException(string? message) : base(message)
        {
        }
     }
    enum EnumToyKind { Doll, Blocks, TeddyBear, Car, Other}
    abstract class Thing
    {
        protected static long thingID;
        protected DateTime creationDate;

        static Thing()
        {
            thingID = 0;
        }
        public Thing()
        {
            thingID++;
            this.creationDate = DateTime.Now;
        }
    }
}
