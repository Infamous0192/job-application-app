using JobApplication.Shared.Data;
using JobApplication.Shared.Models;
using Microsoft.EntityFrameworkCore;

namespace JobApplication.Api.Models
{
  public class CompanyRepository : ICompanyRepository
  {
    private readonly AppDbContext _appDbContext;

    public CompanyRepository(AppDbContext appDbContext)
    {
      _appDbContext = appDbContext;
    }

    public async Task<Company> AddCompany(Company company)
    {
      var result = await _appDbContext.Companies.AddAsync(company);
      await _appDbContext.SaveChangesAsync();
      return result.Entity;
    }

    public async Task<Company?> DeleteCompany(int companyID)
    {
      var result = await this.GetCompany(companyID);

      _appDbContext.Companies.Remove(result!);
      await _appDbContext.SaveChangesAsync();

      return result;
    }

    public PagedResult<Company> GetCompanies(int page)
    {
      int pageSize = 5;

      return _appDbContext.Companies.OrderBy(u => u.Name).GetPaged(page, pageSize);
    }

    public async Task<Company?> GetCompany(int companyID)
    {
      var result = await _appDbContext.Companies.FirstOrDefaultAsync(company => company.ID == companyID);
      if (result == null) throw new KeyNotFoundException("Company not found");

      return result;
    }

    public async Task<Company?> UpdateCompany(Company company)
    {
      var result = await this.GetCompany(company.ID);

      _appDbContext.Entry(result!).CurrentValues.SetValues(company);
      await _appDbContext.SaveChangesAsync();

      return result;
    }
  }
}