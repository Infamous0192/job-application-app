using System.Text.Json.Serialization;

namespace JobApplication.Shared.Models
{
  public class Job
  {
    public int ID { get; set; }
    public string Title { get; set; } = default!;
    public string Description { get; set; } = default!;
    public string Field { get; set; } = default!;
    public int Salary { get; set; }
    public string Location { get; set; } = default!;
    public string Link { get; set; } = default!;
    public DateTime? CreatedAt;
    public DateTime? UpdatedAt;

    [JsonIgnore]
    public int CompanyID { get; set; }
    public Company? Company { get; set; } = default!;
  }
}
