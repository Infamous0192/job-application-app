namespace JobApplication.Shared.Models
{
  public class File
  {
    public int ID { get; set; }
    public string FileName { get; set; } = default!;
    public DateTime UploadTimestamp { get; set; } = default!;
    public DateTime? ProcessedTimestamp { get; set; } = default!;
    public string FileContent { get; set; } = default!;
  }
}
