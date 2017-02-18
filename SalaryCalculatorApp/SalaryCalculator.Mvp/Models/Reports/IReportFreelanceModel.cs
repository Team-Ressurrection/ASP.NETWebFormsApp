using System.Collections.Generic;

using SalaryCalculator.Data.Models;

namespace SalaryCalculator.Mvp.Models.Reports
{
    public interface IReportFreelanceModel
    {
        IEnumerable<SelfEmployment> FreelanceContracts { get; set; }
    }
}
