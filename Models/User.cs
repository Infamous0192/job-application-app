namespace Models
{
  using Microsoft.AspNetCore.Identity;

  public class User : IdentityUser
  {
    public User(string email)
        : base(email)
        => this.Email = email;

    public Role Role { get; set; }
  }
}