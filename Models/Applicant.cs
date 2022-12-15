namespace Models
{
  public class Applicant
  {
    public int Id { get; set; }
    public string Name { get; set; } = default!;
    public string Description { get; set; } = default!;
    public string PhoneNumber { get; set; } = default!;
    public Gender Gender { get; set; } = default!;
    public List<Skill> Skill { get; set; } = default!;
    public Address Address { get; set; } = default!;
    public string PhotoUrl { get; set; } = default!;
    public string CVUrl { get; set; } = default!;
  }
}