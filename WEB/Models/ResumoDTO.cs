namespace WEB.Models
{
    public class ResumoDTO
    {
        public ResumoDTO()
        {
            Ticker = new TickerDTO();
            Fii = new FundoImobiliarioDTO();
        }

        public TickerDTO Ticker { get; set; }
        public FundoImobiliarioDTO Fii { get; set; }
        public ProventosDTO Proventos { get; set; }
        public string Resumo { get; set; }
    }
}
