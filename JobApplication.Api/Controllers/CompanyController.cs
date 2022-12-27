using JobApplication.Api.Authorization;
using JobApplication.Api.Models;
using JobApplication.Shared.Models;
using JobApplication.Shared.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace JobApplication.Api.Controllers
{
  [ApiController]
  [Route("api/[controller]")]
  public class CompanyController : ControllerBase
  {
    private readonly ICompanyRepository _companyRepository;
    private readonly AppSettings _appSettings;

    public CompanyController(ICompanyRepository companyRepository, IOptions<AppSettings> appSettings)
    {
      _companyRepository = companyRepository;
      _appSettings = appSettings.Value;
    }

    /// <summary>
    /// Gets a all companies
    /// </summary>
    [AllowAnonymous]
    [HttpGet()]
    public ActionResult GetCompanies([FromQuery] int page)
    {
      return Ok(_companyRepository.GetCompanies(page));
    }

    /// <summary>
    /// Gets a specific Company by Id.
    /// </summary>
    [AllowAnonymous]
    [HttpGet("{id}")]
    public async Task<ActionResult> GetCompany(int id)
    {
      return Ok(await _companyRepository.GetCompany(id));
    }

    /// <summary>
    /// Creates a Company
    /// </summary>
    [HttpPost]
    public async Task<ActionResult> AddCompany(CompanyForm form)
    {
      var user = (User)HttpContext.Items["User"]!;
      Company company = new Company
      {
        Name = form.Name,
        Description = form.Description,
        Address = form.Description,
        User = user,
      };

      return Ok(await _companyRepository.AddCompany(company));
    }

    /// <summary>
    /// Updates a Company with a specific ID
    /// </summary>
    [HttpPut]
    public async Task<ActionResult> UpdateCompany(Company company)
    {
      return Ok(await _companyRepository.UpdateCompany(company));
    }

    /// <summary>
    /// Deletes a Company with a specific Id.
    /// </summary>
    [HttpDelete("{id}")]
    public async Task<ActionResult> DeleteCompany(int id)
    {
      return Ok(await _companyRepository.DeleteCompany(id));
    }
  }
}
