namespace JobApplication.Shared.Data
{
  public class JobQuery
  {
    public string? Keyword { get; set; } = default!;
    public int? Page { get; set; } = default!;
    public int? Limit { get; set; } = default!;
  }
}
