namespace UsersApp.Api.Models;

/// <summary>
/// Model dai dien cho mot nguoi dung trong he thong.
/// Luu tru trong List (khong dung database).
/// </summary>
public class User
{
    public long Id { get; set; }
    public string Name { get; set; } = string.Empty;
}