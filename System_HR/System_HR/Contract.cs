using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace System_hr.System_HR
{
    [JsonDerivedType(typeof(B2BContract), typeDiscriminator: "b2b")]
    [JsonDerivedType(typeof(EmployeeContract), typeDiscriminator: "emp")]
    [JsonDerivedType(typeof(InternshipContract), typeDiscriminator: "intern")]

    public abstract class Contract : ICloneable
    {
        DateTime startDate;
        DateTime endDate;
        decimal baseSalary;
        [JsonInclude]
        public DateTime StartDate { get; protected set; }
        [JsonInclude]
        public DateTime? EndDate { get; protected set; }
        [JsonInclude]
        public decimal BaseSalary { get; protected set; }

        public Contract(DateTime startDate, decimal baseSalary)
        {
            StartDate = startDate;
            BaseSalary = baseSalary;
            EndDate = null;
        }

        public abstract decimal CalculateSalary();

        public abstract object Clone();

        public virtual string GetContractType()
        {
            return "Generic Contract";
        }

        public void EndContract(DateTime endDate)
        {
            EndDate = endDate;
        }
        public override string ToString()
        {
            return $"{GetContractType()}";
        }



        
        public void IncreaseSalary(decimal percentage)
        {
            BaseSalary *= (1 + percentage / 100);
        }
    }
}
