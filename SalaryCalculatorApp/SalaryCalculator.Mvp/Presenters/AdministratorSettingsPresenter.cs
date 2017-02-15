using System;

using Bytes2you.Validation;

using WebFormsMvp;

using SalaryCalculator.Data.Services.Contracts;
using SalaryCalculator.Mvp.Views;

namespace SalaryCalculator.Mvp.Presenters
{
    public class AdministratorSettingsPresenter : Presenter<IAdministratorSettingsView>, IAdministratorSettingsPresenter
    {
        private readonly IEmployeePaycheckService paycheckService;
        private readonly IRemunerationBillService remunerationBillService;
        private readonly ISelfEmploymentService selfEmploymentService;

        public AdministratorSettingsPresenter(IAdministratorSettingsView view, IEmployeePaycheckService paycheckService, IRemunerationBillService remunerationBillService, ISelfEmploymentService selfEmploymentService) 
            : base(view)
        {
            Guard.WhenArgument<IEmployeePaycheckService>(paycheckService, "paycheckService")
                 .IsNull()
                 .Throw();

            Guard.WhenArgument<IRemunerationBillService>(remunerationBillService, "remunerationBillService")
                 .IsNull()
                 .Throw();

            Guard.WhenArgument<ISelfEmploymentService>(selfEmploymentService, "selfEmploymentService")
                 .IsNull()
                 .Throw();

            this.paycheckService = paycheckService;
            this.remunerationBillService = remunerationBillService;
            this.selfEmploymentService = selfEmploymentService;

            this.View.GetAllFreelanceContracts += GetAllFrelanceContracts; ;
            this.View.GetAllLaborContracts += GetAllLaborContracts;
            this.View.GetAllNonLaborContracts += GetAllNonLaborContracts;
        }

        public void GetAllFrelanceContracts(object sender, EventArgs e)
        {
            this.View.Model.FreelanceContracts = this.selfEmploymentService.GetAll();
        }

        public void GetAllNonLaborContracts(object sender, EventArgs e)
        {
            this.View.Model.NonLaborContracts = this.remunerationBillService.GetAll();
        }

        public void GetAllLaborContracts(object sender, EventArgs e)
        {
            this.View.Model.LaborContracts = this.paycheckService.GetAll();
        }
    }
}
