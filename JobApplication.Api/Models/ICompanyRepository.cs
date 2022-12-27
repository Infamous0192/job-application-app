using JobApplication.Shared.Models;
using JobApplication.Shared.Data;

namespace JobApplication.Api.Models
{
  public interface ICompanyRepository
  {
    Task<Company?> GetCompany(int companyID);
    PagedResult<Company> GetCompanies(int page);
    Task<Company> AddCompany(Company company);
    Task<Company?> UpdateCompany(Company company);
    Task<Company?> DeleteCompany(int companyID);
  }
}