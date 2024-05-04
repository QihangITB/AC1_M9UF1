using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using AC1_M9UF1.Models;
using AC1_M9UF1.Persistence.DAO;
using AC1_M9UF1.Persistence.Mapping;
using AC1_M9UF1.Persistence.Utils;

namespace AC1_M9UF1.Pages.MyForm
{
    public class FormModel : PageModel
    {
        public FormModel() {}

        public void OnGet()
        {

        }

        public IActionResult OnPost()
        {
            ValidateForm();

            if (!ModelState.IsValid)
            {
                return Page();
            }

            Customer customer = new Customer
            {
                CompanyName = Request.Form["CompanyName"],
                ContactName = Request.Form["ContactName"],
                EmployeesCount = Convert.ToInt32(Request.Form["Employees"]),
            };

            ICustomerDAO customerDAO = new CustomerDAO(NpgsqlUtils.OpenConnection());
            customerDAO.AddCustomer(customer);

            return Page();
        }

        private void ValidateForm()
        {
            if (string.IsNullOrEmpty(Request.Form["CompanyName"]))
            {
                ModelState.AddModelError("CompanyName", "Company Name is required.");
            }

            if (string.IsNullOrEmpty(Request.Form["ContactName"]))
            {
                ModelState.AddModelError("ContactName", "Contact Name is required.");
            }

            if (string.IsNullOrEmpty(Request.Form["Employees"]))
            {
                ModelState.AddModelError("Employees", "Employee Count is required.");
            }

            if (!int.TryParse(Request.Form["Employees"], out int value))
            {
                ModelState.AddModelError("Employees", "Employee Count must be a number.");
            }
            else
            {
                if (value <= 0)
                {
                    ModelState.AddModelError("Employees", "Employee Count must be a natural number.");
                }
            }
        }
    }
}
