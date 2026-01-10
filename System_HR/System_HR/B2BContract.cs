using System;


namespace System_hr.System_HR
{
	public class B2BContract : Contract
	{
        decimal hourlyRate;
        int monthlyHours;

       
        public decimal HourlyRate { get; private set; }
        public int MonthlyHours { get; private set; }
       
        
        public B2BContract(DateTime startDate, decimal hourlyRate, int monthlyHours)
            : base(startDate, hourlyRate * monthlyHours)
        {
            HourlyRate = hourlyRate;
            MonthlyHours = monthlyHours;
        }
        
        
        public override decimal CalculateSalary()
        {
            return HourlyRate * MonthlyHours;
        }
        
        
        public override string GetContractType()
        {
            return "B2B Contract";
        }
    }
}