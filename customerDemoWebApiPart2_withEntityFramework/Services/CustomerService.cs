using customerDemoWebApiPart2_withEntityFramework.Data;
using customerDemoWebApiPart2_withEntityFramework.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;

namespace customerDemoWebApiPart2_withEntityFramework.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly CustomerDbContext _customerDbContext;

        public CustomerService(CustomerDbContext customerDbContext)
        {
            _customerDbContext = customerDbContext;
        }



        public async Task<List<Customer>> GetAllCustomers()
        {
            var customers = await _customerDbContext.Customers.ToListAsync();
            return customers;
        }

        public async Task<Customer> GetCustomerById(int id)
        {
            var customer = await _customerDbContext.Customers.FirstOrDefaultAsync(x => x.Id == id);
            //if (customer == null)         // For now not implementing this check, but it can be added later.
            //{
            //    return NotFound();
            //}
            return customer;
        }

        public async Task<Customer> CreateCustomer(Customer customer)
        {
            await _customerDbContext.Customers.AddAsync(customer);
            await _customerDbContext.SaveChangesAsync();

            return customer;
        }

        public async Task<Customer> UpdateCustomer(Customer customer)
        {
            var customerInList = await _customerDbContext.Customers.FindAsync(customer.Id);
            if (customerInList != null)
            {
                customerInList.FirstName = customer.FirstName;
                customerInList.lastName = customer.lastName;
                customerInList.City = customer.City;

                await _customerDbContext.SaveChangesAsync();
            }
            return customerInList;
        }


        public async Task<Customer> DeleteCustomer(int id)
        {
            var customer = await _customerDbContext.Customers.FindAsync(id);
            if (customer != null)
            {
                _customerDbContext.Customers.Remove(customer);
                await _customerDbContext.SaveChangesAsync();
            }

            return customer;
        }
    }
}
