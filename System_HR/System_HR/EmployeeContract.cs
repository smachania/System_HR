using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace System_hr.System_HR
{
    public class EmployeeContract : Contract
    {
        decimal bonus;
        int overtimeHours;
        private const decimal overtimeRate = 50m;

        public decimal Bonus
        {
            get => bonus;
            set
            {
                if (value < 0)
                    throw new ArgumentException("Bonus cannot be negative.");
                bonus = value;
            }
        }
        public int OvertimeHours
        {
            get => overtimeHours;
            set => overtimeHours = value;
        }
        public EmployeeContract(DateTime startDate, decimal baseSalary, decimal bonus = 0, int overtimeHours = 0)
            : base(startDate, baseSalary)
        {
            if (baseSalary < 0)
                throw new ArgumentException("Base salary cannot be negative.");
            Bonus = bonus;
            OvertimeHours = overtimeHours;
        }

        public override decimal CalculateSalary()
        {
            return BaseSalary + Bonus + (OvertimeHours * overtimeRate);
        }

        public override string GetContractType()
        {
            return "Employee Contract";
        }

      
    }
}
