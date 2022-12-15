namespace Models
{
  public class JobApplication
  {
    public int Id { get; set; }

    public int CompanyId { get; set; }
    public int ApplicantId { get; set; }
    public ApplicationStatus Status { get; set; }
  }
}
