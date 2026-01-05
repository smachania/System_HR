using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace System_hr.System_HR
{
    public abstract class Contract
    {
        DateTime startDate;
        DateTime endDate;
        decimal baseSalary;

        public DateTime StartDate { get; protected set; }
        public DateTime? EndDate { get; protected set; }
        public decimal BaseSalary { get; protected set; }

        public Contract(DateTime startDate, decimal baseSalary)
        {
            StartDate = startDate;
            BaseSalary = baseSalary;
            EndDate = null;
        }

        public abstract decimal CalculateSalary();

        public virtual string GetContractType()
        {
            return "Generic Contract";
        }

        public void EndContract(DateTime endDate)
        {
            EndDate = endDate;
        }
    }
}
