using System.Collections.Generic;

using SalaryCalculator.Data.Models;

namespace SalaryCalculator.Mvp.Models.Reports
{
    public class ReportFreelanceModel : IReportFreelanceModel
    {
        public virtual IEnumerable<SelfEmployment> FreelanceContracts { get; set; }
    }
}
