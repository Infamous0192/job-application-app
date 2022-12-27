namespace JobApplication.Shared.Data
{
  public class JobForm
  {
    public string Title { get; set; } = default!;
    public string Description { get; set; } = default!;
    public string Field { get; set; } = default!;
    public int Salary { get; set; }
    public string Location { get; set; } = default!;
    public string Link { get; set; } = default!;
    public string Company { get; set; } = default!;
  }
}