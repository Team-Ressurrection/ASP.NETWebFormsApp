using SalaryCalculator.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SalaryCalculator.Mvp.Models.JobContracts
{
    public interface IEmployeeModel
    {
        Employee Employee { get; set; }
    }
}
