namespace Models
{
  public class Company
  {
    public int Id { get; set; }
    public string Name { get; set; } = default!;
    public string Description { get; set; } = default!;
    public Address Address { get; set; } = default!;
    public string LogoUrl { get; set; } = default!;
  }
}