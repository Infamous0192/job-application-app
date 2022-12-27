using JobApplication.Shared.Models;
using JobApplication.Shared.Data;
using JobApplication.Api.Authorization;

namespace JobApplication.Api.Models
{
  public interface IUserRepository
  {
    AuthenticateResponse Authenticate(AuthenticateRequest request);
    PagedResult<User> GetUsers(int page);
    Task<User?> GetUser(int Id);
    Task<User> AddUser(User user);
    Task<User?> UpdateUser(User user);
    Task<User?> DeleteUser(int id);
  }
}