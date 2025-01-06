using COURESoftwareAssessmentTest.WebApi.Dto;
using COURESoftwareAssessmentTest.WebApi.Services;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace COURESoftwareAssessmentTest.WebApi.Controllers
{
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    public class CountryController : ControllerBase
    {
        private readonly ILogger<CountryController> _logger;
        private readonly ICountryServices _countryServices;

        public CountryController(ILogger<CountryController> logger, ICountryServices countryServices)
        {
            _logger = logger;
            _countryServices = countryServices;
        }

        [HttpGet("get-country-network-operators")]
        [ProducesResponseType(typeof(BaseResponse<PhoneDetail>), 200)]
        [ProducesResponseType(typeof(BaseResponse<PhoneDetail>), 400)]
        [ProducesResponseType(typeof(BaseResponse<PhoneDetail>), 500)]
        public async Task<IActionResult> GetCountryNetworOperatorsByCountryCode([FromQuery][Required] string phoneNumber)
        {
            return Ok(await _countryServices.GetCountryNetworkProviderByPhoneNumberCountryCode(phoneNumber));
        }
    }
}
