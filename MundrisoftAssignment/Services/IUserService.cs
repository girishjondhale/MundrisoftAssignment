using MundrisoftAssignment.Models;

namespace MundrisoftAssignment.Services
{
    public interface IUserService
    {
        int RegisterUser(Users user);
        Users Authenticate(Users user);
        int UpdatePassword(Users users);
    }
}
