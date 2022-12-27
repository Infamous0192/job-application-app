namespace JobApplication.Api.Authorization;

public class AuthenticateResponse
{
  public int ID { get; set; }
  public string Name { get; set; } = default!;
  public string Username { get; set; } = default!;
  public string Token { get; set; } = default!;
}