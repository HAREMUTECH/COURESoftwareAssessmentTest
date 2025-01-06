using COURESoftwareAssessmentTest.WebApi.Data;
using COURESoftwareAssessmentTest.WebApi.Dto;

namespace COURESoftwareAssessmentTest.WebApi.Repository
{
    public interface ICountryRepository
    {
        Task<Country?> GetCountryByCountryCode(int countryCode);
    }
}
