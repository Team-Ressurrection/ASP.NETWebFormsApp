using System.Collections.Generic;

using SalaryCalculator.Data.Models;

namespace SalaryCalculator.Mvp.Models
{
    public class ReportFreelanceModel : IReportFreelanceModel
    {
        public IEnumerable<SelfEmployment> FreelanceContracts { get; set; }
    }
}
