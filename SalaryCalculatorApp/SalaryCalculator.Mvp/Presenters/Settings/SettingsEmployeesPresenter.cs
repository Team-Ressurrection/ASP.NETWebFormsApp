using Bytes2you.Validation;
using SalaryCalculator.Data.Models;
using SalaryCalculator.Data.Services.Contracts;
using SalaryCalculator.Mvp.EventsArguments;
using SalaryCalculator.Mvp.Views.Settings;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebFormsMvp;

namespace SalaryCalculator.Mvp.Presenters.Settings
{
    public class SettingsEmployeesPresenter : Presenter<ISettingsEmployeesView>, ISettingsEmployeesPresenter
    {
        private readonly IEmployeeService employeeService;

        public SettingsEmployeesPresenter(ISettingsEmployeesView view, IEmployeeService employeeService) 
            : base(view)
        {
            Guard.WhenArgument<IEmployeeService>(employeeService, "employeeService")
                 .IsNull()
                 .Throw();

            this.employeeService = employeeService;
            this.View.GetAllEmployees += View_GetAllEmployees;
            this.View.UpdateModel += View_UpdateEmployee;
            this.View.DeleteModel += View_DeleteEmployee;
        }

        private void View_DeleteEmployee(object sender, IModelIdEventArgs e)
        {
            this.employeeService.DeleteById(e.Id);
        }

        private void View_UpdateEmployee(object sender, IModelIdEventArgs e)
        {
            Employee employee = this.employeeService.GetById(e.Id);

            if (employee == null)
            {
                this.View.ModelState.AddModelError("", string.Format("Employee with id {0} was not found", e.UserId));
                return;
            }
            this.View.TryUpdateModel(employee);
            if (this.View.ModelState.IsValid)
            {
                this.employeeService.UpdateById(e.Id, employee);
            }
        }

        private void View_GetAllEmployees(object sender, EventArgs e)
        {
            this.View.Model.Employees = this.employeeService.GetAll();
        }
    }
}
