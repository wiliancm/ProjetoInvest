namespace WEB.Models
{
    public class FundoImobiliarioDTO
    {
        public int total { get; set; }
        public List<DatumFii> data { get; set; }
        public int draw { get; set; }
    }

    // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);
    public class DatumFii
    {
        public int id { get; set; }
        public int quantity { get; set; }
        public string url { get; set; }
        public string ticker { get; set; }
        public double avg_price { get; set; }
        public double current_price { get; set; }
        public Image image { get; set; }
        public string equity_brl { get; set; }
        public double appreciation { get; set; }
        public string ticker_type { get; set; }
        public string rating { get; set; }
        public double percent_wallet { get; set; }
        public double percent_ideal { get; set; }
        public double percent_wallet_type { get; set; }
        public double percent_ideal_type { get; set; }
        public double equity_total { get; set; }
        public string buy { get; set; }
        public string avg_rating { get; set; }
        public int tickerable_id { get; set; }
        public string segment { get; set; }
        public string fii_type { get; set; }
        public string p_vp { get; set; }
        public string dy { get; set; }
        public double yoc { get; set; }
        public string Dividendos { get; set; }
    }
}
