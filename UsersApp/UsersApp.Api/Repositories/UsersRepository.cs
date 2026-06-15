using UsersApp.Api.Models;

namespace UsersApp.Api.Repositories;

/// <summary>
/// Implementation: luu du lieu trong List (thay the database).
/// </summary>
public class UsersRepository : IUsersRepository
{
    // Du lieu mau -- luu trong RAM, mat khi restart app
    private readonly List<User> _storage = new()
    {
        new User { Id = 1, Name = "Nguyen Van An" },
        new User { Id = 2, Name = "Tran Thi Binh" },
        new User { Id = 3, Name = "Le Van Cuong" },
    };

    public IList<User> GetAll() => _storage;

    public User? GetById(long id)
        => _storage.FirstOrDefault(u => u.Id == id);

    public User Add(User user)
    {
        // Tu dong gan ID theo kich thuoc hien tai
        user.Id = _storage.Count + 1;
        _storage.Add(user);
        return user;
    }
}