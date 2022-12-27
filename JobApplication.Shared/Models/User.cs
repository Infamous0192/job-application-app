using System.Text.Json.Serialization;

namespace JobApplication.Shared.Models
{
  public enum Role
  {
    Admin = 1,
    User = 2,
  }

  public class User
  {
    public int ID { get; set; }
    public string Name { get; set; } = default!;
    public string Username { get; set; } = default!;
    [JsonIgnore]
    public string Password { get; set; } = default!;
    public Role Role { get; set; }
  }
}
