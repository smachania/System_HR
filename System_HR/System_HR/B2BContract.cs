using System;


namespace System_hr.System_HR
{
	public class B2BContract : Contract
	{
        decimal hourlyRate;
        int monthlyHours;
        decimal vatRate = 0.23m; //stawka VAT domyślna 23%

        public decimal HourlyRate { get; private set; }
        public int MonthlyHours { get; private set; }
        public decimal VatRate { get; private set; } 


        public B2BContract(DateTime startDate, decimal hourlyRate, int monthlyHours,
            decimal vatRate = 0.23m)
            : base(startDate, hourlyRate * monthlyHours)
        {
            HourlyRate = hourlyRate;
            MonthlyHours = monthlyHours;
        }
        
        
        public override decimal CalculateSalary() //płaca netto
        {
            return HourlyRate * MonthlyHours;
        }


        public decimal CalculateVat()
        {
            return CalculateSalary() * VatRate;
        }
        

        public decimal CalculateTotalSalary()  //płaca brutto
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