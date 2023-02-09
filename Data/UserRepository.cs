using mapping_dto.Models;

namespace mapping_dto.Data
{
    public class UserRepository : IUserRepository
    {
        private readonly DbContextClass context;

        public UserRepository(DbContextClass context)
        {
            this.context = context;
        }
        public User create(User user)
        {
            context.Users.Add(user);
            context.SaveChanges();
            return user;
        }

        public void delete(int id)
        {
            var user = context.Users.Find(id);
            context.Users.Remove(user);
        }

        public IEnumerable<User> getAll()
        {
            return context.Users.ToList();
        }

        public User getUserById(int id)
        {
            return context.Users.Find(id);
        }

        public bool saveChanges()
        {
            return (context.SaveChanges() >= 0);
        }

        public void update(User user)
        {
        }
    }
}