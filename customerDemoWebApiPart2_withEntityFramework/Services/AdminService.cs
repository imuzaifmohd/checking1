using customerDemoWebApiPart2_withEntityFramework.Data;
using customerDemoWebApiPart2_withEntityFramework.Models;
using Microsoft.EntityFrameworkCore;

namespace customerDemoWebApiPart2_withEntityFramework.Services
{
    public class AdminService : IAdminService
    {
        private readonly CustomerDbContext _customerDbContext;

        public AdminService(CustomerDbContext customerDbContext)
        {
            _customerDbContext = customerDbContext;
        }

        public async Task<Admin> CreateAdmin(Admin admin)
        {
            await _customerDbContext.Admins.AddAsync(admin);
            await _customerDbContext.SaveChangesAsync();

            return admin;
        }


        public async Task<List<Admin>> GetAllAdmins()
        {
            var admins = await _customerDbContext.Admins.ToListAsync();
            return admins;
        }
    }
}
