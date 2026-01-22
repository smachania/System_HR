using System;
using System.Text.Json.Serialization;


namespace System_hr.System_HR
{
	public class B2BContract : Contract
	{
        decimal hourlyRate;
        int monthlyHours;
        decimal vatRate = 0.23m; 

        [JsonInclude]
        public decimal HourlyRate { get; private set; }
        [JsonInclude]
        public int MonthlyHours { get; private set; }
        [JsonInclude]
        public decimal VatRate { get; private set; } 


        public B2BContract(DateTime startDate, decimal hourlyRate, int monthlyHours,
            decimal vatRate = 0.23m)
            : base(startDate, hourlyRate * monthlyHours)
        {
            HourlyRate = hourlyRate;
            MonthlyHours = monthlyHours;
        }
        
        
        public override decimal CalculateSalary() 
        {
            return HourlyRate * MonthlyHours;
        }


        public decimal CalculateVat()
        {
            return CalculateSalary() * VatRate;
        }
        

        public decimal CalculateTotalSalary()  
        {
            return CalculateSalary() + CalculateVat();
        }


        public override string GetContractType()
        {
            return "B2B Contract";
        }

        public override object Clone()
        {
            return new B2BContract(this.StartDate, this.HourlyRate, this.MonthlyHours, this.VatRate)
            {
                EndDate = this.EndDate
            };
        }
    }
}