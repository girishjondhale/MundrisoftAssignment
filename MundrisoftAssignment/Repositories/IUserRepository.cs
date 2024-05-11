using MundrisoftAssignment.Models;

namespace MundrisoftAssignment.Repositories
{
    public interface IUserRepository
    {
        int RegisterUser(Users user);
        Users Authenticate(Users user);
        int UpdatePassword(Users users);
    }
}
