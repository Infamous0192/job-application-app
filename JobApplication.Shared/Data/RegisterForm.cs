using System.ComponentModel.DataAnnotations;

namespace JobApplication.Shared.Data
{
  public class RegisterForm
  {
    [Required]
    public string Name { get; set; } = default!;

    [Required]
    public string Username { get; set; } = default!;

    [Required]
    public string Password { get; set; } = default!;
  }
}
