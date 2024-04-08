namespace WEB.Models
{
    public class ProventosDTO
    {
        public int total { get; set; }
        public List<DatumProvento> data { get; set; }
        public int draw { get; set; }
    }

    // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);
    public class DatumProvento
    {
        public int id { get; set; }
        public string category { get; set; }
        public string ticker { get; set; }
        public int qty { get; set; }
        public string type { get; set; }
        public string date_with { get; set; }
        public string date_with_original { get; set; }
        public string date_payment { get; set; }
        public string date_payment_original { get; set; }
        public string value { get; set; }
        public string total { get; set; }
        public string net_total { get; set; }
        public double net_total_clear { get; set; }
    }
}
