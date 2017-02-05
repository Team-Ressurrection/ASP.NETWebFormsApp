using Bytes2you.Validation;
using SalaryCalculator.Data.Services.Contracts;
using SalaryCalculator.Mvp.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebFormsMvp;

namespace SalaryCalculator.Mvp.Presenters
{
    public class ReportNonLaborPresenter : Presenter<IReportNonLaborView>, IReportNonLaborPresenter
    {
        private readonly IRemunerationBillService remunerationBillService;

        public ReportNonLaborPresenter(IReportNonLaborView view, IRemunerationBillService remunerationBillService)
            : base(view)
        {
            Guard.WhenArgument<IRemunerationBillService>(remunerationBillService, "remunerationBillService")
                 .IsNull()
                 .Throw();

            this.remunerationBillService = remunerationBillService;
            this.View.Model.NonLaborContracts = this.remunerationBillService.GetAll();
        }
    }
}
