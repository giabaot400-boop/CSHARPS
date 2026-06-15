using UsersApp.Api.Models;

namespace UsersApp.Api.Repositories;

/// <summary>
/// Interface dinh nghia "hop dong" cho Data layer.
/// Service chi phu thuoc vao interface nay
/// --> de thay implementation (List, EF Core, ...) ma khong doi Service.
/// </summary>
public interface IUsersRepository
{
    IList<User> GetAll();
    User? GetById(long id);      // ? = co the null (nullable)
    User Add(User user);
}