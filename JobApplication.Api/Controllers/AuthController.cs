using JobApplication.Api.Authorization;
using JobApplication.Api.Models;
using JobApplication.Shared.Models;
using JobApplication.Shared.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace JobApplication.Api.Controllers
{
  [ApiController]
  [Route("api/[controller]")]
  public class AuthController : ControllerBase
  {
    private readonly IUserRepository _userRepository;
    private readonly AppSettings _appSettings;

    public AuthController(IUserRepository userRepository, IOptions<AppSettings> appSettings)
    {
      _userRepository = userRepository;
      _appSettings = appSettings.Value;
    }

    /// <summary>
    /// Authenticates a user and returns a JWT token and user details
    /// </summary>
    [HttpPost("login")]
    public ActionResult Login(AuthenticateRequest request)
    {
      return Ok(_userRepository.Authenticate(request));
    }

    /// <summary>
    /// Register user as company
    /// </summary>
    [HttpPost("register")]
    public ActionResult Register(RegisterForm form)
    {
      User user = new User { Name = form.Name, Username = form.Username, Password = form.Password, Role = Role.User };
      return Ok(_userRepository.AddUser(user));
    }
  }
}
