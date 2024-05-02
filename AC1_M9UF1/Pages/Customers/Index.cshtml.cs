using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using AC1_M9UF1.Data;
using AC1_M9UF1.Models;

namespace AC1_M9UF1.Pages.Customers
{
    public class IndexModel : PageModel
    {
        private readonly AC1_M9UF1.Data.AC1_M9UF1Context _context;

        public IndexModel(AC1_M9UF1.Data.AC1_M9UF1Context context)
        {
            _context = context;
        }

        public IList<Customer> Customer { get;set; } = default!;

        public async Task OnGetAsync()
        {
            Customer = await _context.Customer.ToListAsync();
        }
    }
}
