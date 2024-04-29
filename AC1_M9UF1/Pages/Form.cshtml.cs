using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AC1_M9UF1.Pages
{
    public class FormModel : PageModel
    {
        [BindProperty]
        public bool IsPost { get; set; }

        public FormModel()
        {
            IsPost = false;
        }

        public void OnPost()
        {
            IsPost = true;
        }
        public void OnGet()
        {

        }
    }
}
