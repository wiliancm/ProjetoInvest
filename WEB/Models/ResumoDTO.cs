namespace WEB.Models
{
    public class ResumoDTO
    {
        public ResumoDTO()
        {
            Ticker = new TickerDTO();
            Fii = new FundoImobiliarioDTO();
            Etf = new TickerDTO();
            Carteira = new List<CarteiraDTO>();
            DataAtualizado = DateTime.Now;
            Iniciado = false;
        }

        public TickerDTO Ticker { get; set; }
        public FundoImobiliarioDTO Fii { get; set; }
        public TickerDTO Etf { get; set; }
        public ProventosDTO Proventos { get; set; }
        public ProventosDTO ProventosInfo { get; set; }
        public List<CarteiraDTO> Carteira { get; set; }
        public LancamentosDTO Lancamentos { get; set; }
        public string Resumo { get; set; }
        public DateTime DataAtualizado { get; set; }
        public bool Iniciado { get; set; }
    }
}
