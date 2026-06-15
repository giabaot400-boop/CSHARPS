using UsersApp.Api.Models;
using UsersApp.Api.Repositories;

namespace UsersApp.Api.Services;

/// <summary>
/// Service layer -- xu ly business logic.
/// Phu thuoc vao IUsersRepository (interface), khong phu thuoc impl.
/// </summary>
public class UsersService
{
    private readonly IUsersRepository _usersRepository;

    // Constructor Injection -- giong Spring Boot
    public UsersService(IUsersRepository usersRepository)
    {
        _usersRepository = usersRepository;
    }

    /// <summary>Lay danh sach tat ca user.</summary>
    public IList<User> GetUsers()
        => _usersRepository.GetAll();

    /// <summary>
    /// Tim user theo ID.
    /// Nem KeyNotFoundException neu khong tim thay.
    /// </summary>
    public User GetUserById(long id)
    {
        var user = _usersRepository.GetById(id);
        if (user is null)
            throw new KeyNotFoundException($"User not found with id: {id}");
        
        return user;
    }

    /// <summary>
    /// Them user moi.
    /// Validate: ten khong duoc trong hoac chi co khoang trang.
    /// </summary>
    public User AddUser(User user)
    {
        if (string.IsNullOrWhiteSpace(user.Name))
            throw new ArgumentException("Name cannot be empty");
            
        return _usersRepository.Add(user);
    }
}