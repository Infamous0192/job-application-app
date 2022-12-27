using JobApplication.Api.Authorization;
using JobApplication.Api.Models;
using JobApplication.Shared.Models;
using JobApplication.Shared.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace JobApplication.Api.Controllers
{
  [Authorize]
  [ApiController]
  [Route("api/[controller]")]
  public class JobController : ControllerBase
  {
    private readonly IJobRepository _jobRepository;
    private readonly ICompanyRepository _companyRepository;
    private readonly AppSettings _appSettings;

    public JobController(ICompanyRepository companyRepository, IJobRepository jobRepository, IOptions<AppSettings> appSettings)
    {
      _companyRepository = companyRepository;
      _jobRepository = jobRepository;
      _appSettings = appSettings.Value;
    }

    /// <summary>
    /// Gets a all companies
    /// </summary>
    [AllowAnonymous]
    [HttpGet()]
    public ActionResult GetJobs([FromQuery] JobQuery query)
    {
      return Ok(_jobRepository.GetJobs(query));
    }

    /// <summary>
    /// Gets a specific Job by Id.
    /// </summary>
    [AllowAnonymous]
    [HttpGet("{id}")]
    public async Task<ActionResult> GetJob(int id)
    {
      return Ok(await _jobRepository.GetJob(id));
    }

    /// <summary>
    /// Creates a Job
    /// </summary>
    [HttpPost]
    public async Task<ActionResult> AddJob(JobForm form)
    {
      var company = await _companyRepository.GetCompany(Int32.Parse(form.Company));

      Job job = new Job
      {
        Title = form.Title,
        Field = form.Field,
        Salary = form.Salary,
        Link = form.Link,
        Location = form.Location,
        Description = form.Description,
        CreatedAt = new DateTime(),
        Company = company,
      };

      return Ok(await _jobRepository.AddJob(job));
    }

    /// <summary>
    /// Updates a Job with a specific ID
    /// </summary>
    [HttpPut]
    public async Task<ActionResult> UpdateJob(Job job)
    {
      return Ok(await _jobRepository.UpdateJob(job));
    }

    /// <summary>
    /// Deletes a Job with a specific Id.
    /// </summary>
    [HttpDelete("{id}")]
    public async Task<ActionResult> DeleteJob(int id)
    {
      return Ok(await _jobRepository.DeleteJob(id));
    }
  }
}
