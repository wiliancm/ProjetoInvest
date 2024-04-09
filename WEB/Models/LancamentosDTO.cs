namespace WEB.Models
{
    public class LancamentosDTO
    {
        public int total { get; set; }
        public List<DatumLancamento> data { get; set; }
    }

    // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);
    public class DatumLancamento
    {
        public int id { get; set; }
        public string type_investment { get; set; }
        public string ticker { get; set; }
        public string type { get; set; }
        public string date { get; set; }
        public string qty { get; set; }
        public string qty_adjusted { get; set; }
        public string price { get; set; }
        public string price_adjusted { get; set; }
        public string total { get; set; }
        public string source { get; set; }
        public object source_info { get; set; }
    }
}
