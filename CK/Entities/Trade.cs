using System.ComponentModel.DataAnnotations;

namespace CK.Entities
{
    public class Trade
    {
        public Trade()
        {

        }

        [Key]
        public Guid Id { get; set; }

        [Required] 
        public DateTime Created { get; set; }

        public DateTime Modified { get; set; }

        [Required]
        public Guid UserId { get; set; }

        [Required]
        public Guid PortfolioId { get; set; }
        
        [Required]
        public string Date { get; set; }

        [Required]
        public decimal NumberOfShares { get; set; }

        [Required]
        public decimal Price { get; set; }

        [Required]
        public Currency Currency { get; set; }

        [Required]
        public decimal MarketValue { get { return this.NumberOfShares * this.Price;}}

        [Required]
        public Action Action { get; set; }

        public string Notes { get; set; }

        [Required]
        public string Asset { get; set; }

    }

    public enum Action
    {
        Buy,
        Sell
    }

    public enum Currency
    {
        EUR,
        USD,
        BTC
    }
}
