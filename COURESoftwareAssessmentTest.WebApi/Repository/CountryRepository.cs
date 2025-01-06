using System.Linq.Expressions;
using COURESoftwareAssessmentTest.WebApi.Data;
using COURESoftwareAssessmentTest.WebApi.Dto;
using Microsoft.EntityFrameworkCore;

namespace COURESoftwareAssessmentTest.WebApi.Repository
{

    public class CountryRepository : ICountryRepository
    {
        private readonly ApplicationDbContext _dbContext;
        public CountryRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }


        public async Task<Country?> GetCountryByCountryCode(int countryCode)
        {
            return await _dbContext.Countries
              .Include(x => x.CountryDetails)
              .Where(x => x.CountryCode == countryCode)
              .FirstOrDefaultAsync();
        }
    }
}
