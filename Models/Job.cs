namespace Models
{
  public class Job
  {
    public int Id { get; set; }
    public string Title { get; set; } = default!;
    public string Description { get; set; } = default!;
    public string Field { get; set; } = default!;
    public int Salary { get; set; }
    public string Location { get; set; } = default!;

    public int CompanyId { get; set; }
  }
}
