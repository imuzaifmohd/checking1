using customerDemoWebApiPart2_withEntityFramework.Models;

namespace customerDemoWebApiPart2_withEntityFramework.Services
{
    public interface IAdminService
    {
        Task<Admin> CreateAdmin(Admin admin);

        Task<List<Admin>> GetAllAdmins();
    }
}
