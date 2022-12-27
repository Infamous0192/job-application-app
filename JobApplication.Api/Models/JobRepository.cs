using Microsoft.EntityFrameworkCore;
using JobApplication.Shared.Data;
using JobApplication.Shared.Models;

namespace JobApplication.Api.Models
{
  public class JobRepository : IJobRepository
  {
    private readonly AppDbContext _appDbContext;

    public JobRepository(AppDbContext appDbContext)
    {
      _appDbContext = appDbContext;
    }

    public async Task<Job> AddJob(Job job)
    {
      var result = await _appDbContext.Jobs.AddAsync(job);
      await _appDbContext.SaveChangesAsync();
      return result.Entity;
    }

    public async Task<Job?> DeleteJob(int jobID)
    {
      var result = await this.GetJob(jobID);

      _appDbContext.Jobs.Remove(result!);
      await _appDbContext.SaveChangesAsync();

      return result;
    }

    public async Task<Job> GetJob(int jobID)
    {
      var result = await _appDbContext.Jobs.FirstOrDefaultAsync(job => job.ID == jobID);
      if (result == null) throw new KeyNotFoundException("Job not found");

      return result!;
    }

    public PagedResult<Job> GetJobs(JobQuery query)
    {
      var builder = _appDbContext.Jobs;

      if (query.Keyword != null) builder.Where(j => j.Title.Contains(query.Keyword));

      return builder
        .OrderBy(i => i.CreatedAt)
        .GetPaged(query.Page ?? 1, query.Limit ?? 5);
    }

    public async Task<Job?> UpdateJob(Job job)
    {
      var result = await this.GetJob(job.ID);

      _appDbContext.Entry(result!).CurrentValues.SetValues(job);
      await _appDbContext.SaveChangesAsync();

      return result;
    }
  }
}