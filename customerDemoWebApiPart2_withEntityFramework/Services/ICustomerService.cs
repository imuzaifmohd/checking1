using customerDemoWebApiPart2_withEntityFramework.Models;

namespace customerDemoWebApiPart2_withEntityFramework.Services
{
    public interface ICustomerService
    {
        Task<List<Customer>> GetAllCustomers();

        Task<Customer> GetCustomerById(int id);

        Task<Customer> CreateCustomer(Customer customer);

        Task<Customer> UpdateCustomer(Customer customer);

        Task<Customer> DeleteCustomer(int id);
    }
}
