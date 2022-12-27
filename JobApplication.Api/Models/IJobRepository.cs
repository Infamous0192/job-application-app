using JobApplication.Shared.Models;
using JobApplication.Shared.Data;

namespace JobApplication.Api.Models
{
  public interface IJobRepository
  {
    Task<Job> GetJob(int id);
    PagedResult<Job> GetJobs(JobQuery query);
    Task<Job> AddJob(Job job);
    Task<Job?> UpdateJob(Job job);
    Task<Job?> DeleteJob(int id);
  }
}
