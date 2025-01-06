namespace COURESoftwareAssessmentTest.WebApi.Data
{
    public class CountryDetail : BaseEntity
    {
        public int CountryId { get; set; }
        public string Operator { get; set; }
        public string OperatorCode { get; set; }
        public Country Country { get; set; }
    }
}
