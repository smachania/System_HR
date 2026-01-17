using System;

namespace System_hr.System_HR
{
	public class InternshipContract : Contract
    {
		string universityName;
		int internshipMonths;
		bool isPaid;
        
        
        public string UniversityName { get; private set; }
        public int InternshipMonths { get; private set; }
        public bool IsPaid { get; private set; }
       
        
        public InternshipContract(DateTime startDate, string universityName, 
            int internshipMonths, bool isPaid)
            : base(startDate, isPaid ? 1500m : 0m) // Przykładowa stawka bazowa dla płatnych staży
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