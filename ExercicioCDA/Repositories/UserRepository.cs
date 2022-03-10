using ExercicioCDA.Models;

namespace ExercicioCDA.Repositories
{
    public interface IUserRepository
    {
        public Users Get(string Username, string Password);
    }

    public class UserRepository
    {
        private readonly _DbContext db;

        public UserRepository(_DbContext _db)
        {
            db = _db;
        }

        public Users Get(string username, string password)
        {
            try
            {
                var user_db = db.Users.FirstOrDefault(x => x.Username == username && x.Password == password);
                return user_db;

            }
            catch
            {
                return new Users();
            }
        }
    }
}
