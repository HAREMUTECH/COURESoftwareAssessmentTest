namespace COURESoftwareAssessmentTest.WebApi.Data
{

    public class Country : BaseEntity
    {
       
        public int CountryCode { get; set; }
        public string Name { get; set; }
        public string CountryIso { get; set; }
        public List<CountryDetail> CountryDetails { get; set; } = new List<CountryDetail>();
    }
}
