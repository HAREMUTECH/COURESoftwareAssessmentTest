using COURESoftwareAssessmentTest.WebApi.Dto;
using COURESoftwareAssessmentTest.WebApi.Repository;
using Microsoft.EntityFrameworkCore;

namespace COURESoftwareAssessmentTest.WebApi.Services
{
    public class CountryServices : ICountryServices
    {
        private readonly ICountryRepository _countryRepository;
        private readonly ILogger<CountryServices> _logger;

        public CountryServices(ICountryRepository countryRepository, ILogger<CountryServices> logger)
        {
            _countryRepository = countryRepository;
            _logger = logger;
        }

        public async Task<BaseResponse<PhoneDetail>> GetCountryNetworkProviderByPhoneNumberCountryCode(string phoneNumber)
        {
            if (string.IsNullOrWhiteSpace(phoneNumber))
            {
                return new BaseResponse<PhoneDetail>
                {
                    Message = "Invalid input",
                    Status = true
                };
            }
            int countryCode = ExtractFirstThreeDigits(phoneNumber);
            _logger.LogInformation($"Starting {nameof(GetCountryNetworkProviderByPhoneNumberCountryCode)} .");
            try
            {
                var phoneCountrycodeDetail = await _countryRepository.GetCountryByCountryCode(countryCode);
                if (phoneCountrycodeDetail == null)
                {
                    _logger.LogInformation("Country Network Operators not found.");
                    return new BaseResponse<PhoneDetail>
                    {
                        Message = "Record not found",
                        Status = false
                    };
                }

                var data = new CountryDto
                {
                    Name = phoneCountrycodeDetail.Name,
                    CountryCode = phoneCountrycodeDetail.CountryCode,
                    CountryIso = phoneCountrycodeDetail.CountryIso,
                    countryDetails = phoneCountrycodeDetail.CountryDetails.Select(x => new CountryOperaorDetailDto
                    {
                        Operator = x.Operator,
                        OperatorCode = x.OperatorCode,

                    }).ToList(),
                };


                var phoneNumberInformation = new PhoneDetail
                {

                    Number = phoneNumber,
                    Country = data
                };

                _logger.LogInformation("Successfully retrieved Country Network Operators");
                return new BaseResponse<PhoneDetail>
                {
                    Data = phoneNumberInformation,
                    Status = true,
                    Message = "Record retrieved Successfully"
                };
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred while retrieving Country Network Operators.");
                return new BaseResponse<PhoneDetail>
                {
                    Message = $"Failed to retrieve Country Network Operators: {ex.Message}",
                    Status = false
                };
            }
        }


        private static int ExtractFirstThreeDigits(string phoneNumber)
        {
            if (phoneNumber.Length >= 3)
            {
                return int.Parse(phoneNumber.Substring(0, 3));
            }
            return 0;
        }
    }
}
