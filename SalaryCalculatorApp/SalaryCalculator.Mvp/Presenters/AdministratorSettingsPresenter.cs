using Bytes2you.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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

        private void GetAllFrelanceContracts(object sender, EventArgs e)
        {
            this.View.Model.FreelanceContracts = this.selfEmploymentService.GetAll();
        }

        private void GetAllNonLaborContracts(object sender, EventArgs e)
        {
            this.View.Model.NonLaborContracts = this.remunerationBillService.GetAll();
        }

        private void GetAllLaborContracts(object sender, EventArgs e)
        {
            this.View.Model.LaborContracts = this.paycheckService.GetAll();
        }
    }
}
