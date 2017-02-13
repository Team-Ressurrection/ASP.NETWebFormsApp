using System.Collections.Generic;

using SalaryCalculator.Data.Models;

namespace SalaryCalculator.Mvp.Models
{
    public interface IReportFreelanceModel
    {
        IEnumerable<SelfEmployment> FreelanceContracts { get; set; }
    }
}
