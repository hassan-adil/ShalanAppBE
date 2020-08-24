using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ShalanAppBE.Database.Entities
{
    public class EmployeeEmployment
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("User")]
        public String EmployeeId { get; set; }

        public string EmployeeName { get; set; }

        public DateTime ContractStart { get; set; }

        public DateTime ContractEnd { get; set; }

        public double Accomodition { get; set; }

        public double Transport { get; set; }

        public double OtherExpense { get; set; }

        public double TotalSalary { get; set; }

        public DateTime CrtDate { get; set; }

        public virtual User User { get; set; }
    }
}
