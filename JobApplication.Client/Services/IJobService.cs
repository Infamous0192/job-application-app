using JobApplication.Shared.Models;
using JobApplication.Shared.Data;

namespace JobApplication.Client.Services
{
  public interface IJobService
  {
    User User { get; }
    Task Initialize();
    Task Login(LoginForm model);
    Task Logout();
    Task<PagedResult<User>> GetUsers(string? name, string page);
    Task<User> GetUser(int id);
    Task DeleteUser(int id);
    Task AddUser(User user);
    Task UpdateUser(User user);
  }
}