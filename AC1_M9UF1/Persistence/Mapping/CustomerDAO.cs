using AC1_M9UF1.Models;
using AC1_M9UF1.Persistence.DAO;
using AC1_M9UF1.Persistence.Utils;
using Npgsql;

namespace AC1_M9UF1.Persistence.Mapping
{
    public class CustomerDAO : ICustomerDAO
    {
        private readonly string connectionString;

        public CustomerDAO(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public void AddCustomer(Customer customer)
        {
            using (NpgsqlConnection connection = new NpgsqlConnection(connectionString))
            {
                string query = "INSERT INTO Customer (CompanyName, ContactName, EmployeesCount) " +
                    "VALUES (@CompanyName, @ContactName, @EmployeesCount)";
                NpgsqlCommand command = new NpgsqlCommand(query, connection);
                command.Parameters.AddWithValue("@CompanyName", customer.CompanyName);
                command.Parameters.AddWithValue("@ContactName", customer.ContactName);
                command.Parameters.AddWithValue("@EmployeesCount", customer.EmployeesCount);
                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        public void DeleteCustomer(int id)
        {
            using (NpgsqlConnection connection = new NpgsqlConnection(connectionString))
            {
                string query = "DELETE FROM Customer WHERE Id = @Id";
                NpgsqlCommand command = new NpgsqlCommand(query, connection);
                command.Parameters.AddWithValue("@Id", id);
                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        public void UpdateCustomer(Customer customer)
        {
            using (NpgsqlConnection connection = new NpgsqlConnection(connectionString))
            {
                string query = "UPDATE Customer SET CompanyName = @CompanyName, ContactName = @ContactName, EmployeesCount = @EmployeesCount WHERE Id = @Id";
                NpgsqlCommand command = new NpgsqlCommand(query, connection);
                command.Parameters.AddWithValue("@CompanyName", customer.CompanyName);
                command.Parameters.AddWithValue("@ContactName", customer.ContactName);
                command.Parameters.AddWithValue("@EmployeesCount", customer.EmployeesCount);
                command.Parameters.AddWithValue("@Id", customer.Id);
                connection.Open();
                command.ExecuteNonQuery();
            }
        }

        public Customer GetCustomerById(int id)
        {
            Customer? customer = null;

            using (NpgsqlConnection connection = new NpgsqlConnection(NpgsqlUtils.OpenConnection()))
            {
                string query = "SELECT * FROM Customer WHERE Id = @Id";
                NpgsqlCommand command = new NpgsqlCommand(query, connection);
                command.Parameters.AddWithValue("@Id", id);
                connection.Open();
                NpgsqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    customer = NpgsqlUtils.GetCustomer(reader);
                }
            }

            return customer;
        }

        public List<Customer> GetAllCustomers()
        {
            List<Customer> customers = new List<Customer>();

            using(NpgsqlConnection connection = new NpgsqlConnection(NpgsqlUtils.OpenConnection()))
            {
                string query = "SELECT * FROM Customer";
                NpgsqlCommand command = new NpgsqlCommand(query, connection);
                connection.Open();
                NpgsqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    Customer customer = NpgsqlUtils.GetCustomer(reader);
                    customers.Add(customer);
                }
            }
            
            return customers;
        }
    }
}
