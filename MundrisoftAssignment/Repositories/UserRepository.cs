using MundrisoftAssignment.Data;
using MundrisoftAssignment.Models;

namespace MundrisoftAssignment.Repositories
{
    public class UserRepository:IUserRepository
    {
        private readonly ApplicationDbContext _db;
        public UserRepository(ApplicationDbContext db)
        {
            _db = db;
        }
        public Users Authenticate(Users user)
        {
            Users u = new Users();
            u = _db.users.Where(x => x.Email == user.Email).FirstOrDefault();

            return u;
        }
        public int RegisterUser(Users user)
        {
            user.RoleId = 2;
            _db.users.Add(user);
            int res = _db.SaveChanges();
            return res;
        }

        public int UpdatePassword(Users user)
        {
            int res = 0;
            var u = _db.users.Where(x => x.UserId == user.UserId).FirstOrDefault();
            if (u != null)
            {
                u.Password = user.Password;
                res = _db.SaveChanges();
            }
            return res;
        }
    }
}
