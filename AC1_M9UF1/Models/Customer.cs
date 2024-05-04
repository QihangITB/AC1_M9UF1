using System.ComponentModel.DataAnnotations;

namespace AC1_M9UF1.Models
{

    public class Customer
    {
        public int Id { get; set; }
        [Required(ErrorMessage ="The company name field requiere a value")]
        public string CompanyName { get; set; }
        [Required(ErrorMessage = "The contact name field requiere a value")]
        public string ContactName { get; set; }
        [Required(ErrorMessage = "The employees count field requiere a value")]
        [Range(1, int.MaxValue, ErrorMessage = "The employees count field must be a natural number")]
        public int EmployeesCount { get; set; }
    }
}
