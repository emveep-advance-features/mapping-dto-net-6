using mapping_dto.Models;

namespace mapping_dto.Data
{
    public interface IUserRepository
    {
        IEnumerable<User> getAll();
        User getUserById(int id);
        User create(User user);
        void update(User user);
        void delete(int id);
        bool saveChanges();
    }
}