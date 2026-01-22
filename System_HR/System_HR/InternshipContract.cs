using System;
using System.Text.Json.Serialization;

namespace System_hr.System_HR
{
	public class InternshipContract : Contract
    {
		string universityName;
		int internshipMonths;
		bool isPaid;


        [JsonInclude]
        public string UniversityName { get; private set; }
        [JsonInclude]
        public int InternshipMonths { get; private set; }
        [JsonInclude]
        public bool IsPaid { get; private set; }
       
        public InternshipContract(DateTime startDate, string universityName, 
            int internshipMonths, bool isPaid)
            : base(startDate, isPaid ? 1500m : 0m) 
        {
            UniversityName = universityName;
            InternshipMonths = internshipMonths;
            IsPaid = isPaid;
        }
        
        
        public override decimal CalculateSalary()
        {
            return IsPaid ? BaseSalary : 0m;
        }
        
        
        public override string GetContractType()
        {
            return "Internship Contract";
        }

        public override object Clone()
        {
            return new InternshipContract(this.StartDate, this.UniversityName, this.InternshipMonths, this.IsPaid)
            {
                EndDate = this.EndDate  
            };
        }
    }
}