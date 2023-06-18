using PocketCinemaAPIService.Models;

namespace PocketCinemaAPIService.Dao
{
    public class UserDao
    {
        private DBContextClass _context;

        public UserDao(DBContextClass _context)
        {
            this._context = _context;
        }

        public List<User>? GetAllUsers()
        {
            return _context.Users.ToList();
        }
    }
}
