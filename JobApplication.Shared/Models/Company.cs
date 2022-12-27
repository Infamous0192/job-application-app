using System.Text.Json.Serialization;

namespace JobApplication.Shared.Models
{
  public class Company
  {
    public int ID { get; set; }
    public string Name { get; set; } = default!;
    public string Description { get; set; } = default!;
    public string Address { get; set; } = default!;

    [JsonIgnore]
    public int UserID { get; set; } = default!;
    public User User { get; set; } = default!;
  }
}
