using JobApplication.Shared.Models;

namespace JobApplication.Shared.Data
{
  public class UserForm
  {
    public string Name { get; set; } = default!;
    public string Username { get; set; } = default!;
    public string Password { get; set; } = default!;
    public Role Role { get; set; }
  }
}
