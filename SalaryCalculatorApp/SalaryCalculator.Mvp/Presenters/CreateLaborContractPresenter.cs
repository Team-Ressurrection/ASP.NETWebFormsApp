using Bytes2you.Validation;
using SalaryCalculator.Data.Models;
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
    public class CreateLaborContractPresenter : Presenter<ICreateLaborContractView>, ICreateLaborContractPresenter
    {
        private readonly IEmployeePaycheckService paycheckService;

        public CreateLaborContractPresenter(ICreateLaborContractView view, IEmployeePaycheckService paycheckService)
            : base(view)
        {
            Guard.WhenArgument<IEmployeePaycheckService>(paycheckService, "paycheckService").IsNull().Throw();

            this.paycheckService = paycheckService;

            this.View.CreatePaycheck += CreatePaycheck;
        }

        public void CreatePaycheck(object sender, EventArgs e)
        {
            var bill = sender as EmployeePaycheck;

            this.paycheckService.Create(bill);
        }
    }
}
