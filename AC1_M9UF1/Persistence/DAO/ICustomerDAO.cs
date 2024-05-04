using AC1_M9UF1.Models;

namespace AC1_M9UF1.Persistence.DAO
{
    public interface ICustomerDAO
    {
        Customer GetCustomerById(int id);
        public List<Customer> GetAllCustomers();
        void AddCustomer(Customer customer);
        void UpdateCustomer(Customer customer);
        void DeleteCustomer(int id);
    }
}
