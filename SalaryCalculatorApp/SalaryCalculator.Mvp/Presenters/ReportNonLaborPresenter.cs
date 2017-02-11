using Bytes2you.Validation;

using WebFormsMvp;

using SalaryCalculator.Data.Services.Contracts;
using SalaryCalculator.Mvp.Views;

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
            this.View.GetAll += GetAll;
        }

        public void GetAll(object sender, System.EventArgs e)
        {
            this.View.Model.NonLaborContracts = this.remunerationBillService.GetAll();
        }
    }
}
