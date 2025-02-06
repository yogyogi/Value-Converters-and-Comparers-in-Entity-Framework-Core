namespace VCC.Models
{
    public class Marketing
    {
        public int Id { get; set; }

        public MarketingType Type { get; set; }

        public string Comment { get; set; }
    }

    public enum MarketingType
    {
        Email,
        SMS,
        Digital,
        SearchEngine
    }
}
