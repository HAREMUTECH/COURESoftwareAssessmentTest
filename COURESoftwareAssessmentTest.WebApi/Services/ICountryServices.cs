using COURESoftwareAssessmentTest.WebApi.Dto;

namespace COURESoftwareAssessmentTest.WebApi.Services
{
    public interface ICountryServices
    {
        Task<BaseResponse<PhoneDetail>> GetCountryNetworkProviderByPhoneNumberCountryCode(string phoneNumber);
    }
}
