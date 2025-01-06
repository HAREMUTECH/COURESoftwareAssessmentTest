namespace COURESoftwareAssessmentTest.WebApi.Dto
{
    public class CountryDto
    {
        public string Name { get; set; }
        public int CountryCode { get; set; }
        public string CountryIso { get; set; }
        public List<CountryOperaorDetailDto> countryDetails { get; set; }
    }
}
