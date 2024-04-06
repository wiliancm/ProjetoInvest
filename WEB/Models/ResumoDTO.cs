namespace WEB.Models
{
    public class ResumoDTO
    {
        public ResumoDTO()
        {
            Ticker = new TickerDTO();
        }

        public TickerDTO Ticker { get; set; }        
    }
}
