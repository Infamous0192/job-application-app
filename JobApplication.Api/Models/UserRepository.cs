using JobApplication.Api.Authorization;
using JobApplication.Api.Helpers;
using JobApplication.Shared.Data;
using JobApplication.Shared.Models;
using Microsoft.EntityFrameworkCore;

namespace JobApplication.Api.Models
{
  public class UserRepository : IUserRepository
  {
    private readonly AppDbContext _appDbContext;
    private IJwtUtils _jwtUtils;

    public UserRepository(AppDbContext appDbContext, IJwtUtils jwtUtils)
    {
      _appDbContext = appDbContext;
      _jwtUtils = jwtUtils;
    }

    public AuthenticateResponse Authenticate(AuthenticateRequest request)
    {
      var user = _appDbContext.Users.FirstOrDefault(u => u.Username == request.Username);

      if (user == null || !BCrypt.Net.BCrypt.Verify(request.Password, user.Password))
        throw new AppException("Username or password is incorrect");


      // authentication successful
      AuthenticateResponse response = new AuthenticateResponse();
      response.ID = user.ID;
      response.Name = user.Name;
      response.Username = user.Username;
      response.Token = _jwtUtils.GenerateToken(user);
      return response;
    }

    public PagedResult<User> GetUsers(int page)
    {
      int pageSize = 5;

      return _appDbContext.Users.OrderBy(u => u.Username).GetPaged(page, pageSize);
    }

    public async Task<User?> GetUser(int userID)
    {
      var result = await _appDbContext.Users.FirstOrDefaultAsync(user => user.ID == userID);
      if (result == null) throw new KeyNotFoundException("User not found");

      return result;
    }

    public async Task<User> AddUser(User user)
    {
      // validate unique
      if (_appDbContext.Users.Any(u => u.Username == user.Username))
        throw new AppException("Username '" + user.Username + "' is already taken");

      user.Password = BCrypt.Net.BCrypt.HashPassword(user.Password);

      var result = await _appDbContext.Users.AddAsync(user);
      await _appDbContext.SaveChangesAsync();
      return result.Entity;
    }

    public async Task<User?> UpdateUser(User user)
    {
      var result = await this.GetUser(user.ID);

      if (result!.Username == "admin") throw new AppException("Admin may not be updated");

      // validate unique
      if (user.Username != result.Username && _appDbContext.Users.Any(u => u.Username == user.Username))
        throw new AppException("Username '" + user.Username + "' is already taken");

      // hash password if entered
      if (!string.IsNullOrEmpty(user.Password) && user.Password != result.Password)
      {
        user.Password = BCrypt.Net.BCrypt.HashPassword(user.Password);
      }

      _appDbContext.Entry(result).CurrentValues.SetValues(user);
      await _appDbContext.SaveChangesAsync();

      return result;
    }

    public async Task<User?> DeleteUser(int userID)
    {
      var result = await this.GetUser(userID);

      // cannot delete admin
      if (result!.Username == "admin") throw new AppException("Admin may not be deleted");

      _appDbContext.Users.Remove(result);
      await _appDbContext.SaveChangesAsync();

      return result;
    }
  }
}