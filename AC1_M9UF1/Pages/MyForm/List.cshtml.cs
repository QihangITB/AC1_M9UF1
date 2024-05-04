using AC1_M9UF1.Models;
using AC1_M9UF1.Persistence.DAO;
using AC1_M9UF1.Persistence.Mapping;
using AC1_M9UF1.Persistence.Utils;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace AC1_M9UF1.Pages.MyForm
{
    public class ListModel : PageModel
    {

        public IList<Customer> Customer { get; set; } = default!;

        public async Task OnGetAsync()
        {
            ICustomerDAO customerDAO = new CustomerDAO(NpgsqlUtils.OpenConnection());

            var customers = from c in customerDAO.GetAllCustomers()
                            select c;

            Customer = customers.ToList();
        }

        public IActionResult OnGetDeleteData(int id)
        {
            ICustomerDAO customerDAO = new CustomerDAO(NpgsqlUtils.OpenConnection());
            customerDAO.DeleteCustomer(id);

            return RedirectToPage();
        }

        public IActionResult OnGetCleanDatabase()
        {
            ICustomerDAO customerDAO = new CustomerDAO(NpgsqlUtils.OpenConnection());
            foreach (var customer in customerDAO.GetAllCustomers())
            {
                customerDAO.DeleteCustomer(customer.Id);
            }

            return RedirectToPage();
        }
    }
}
