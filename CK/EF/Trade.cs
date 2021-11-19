using CK.EF.Enum;
using Action = CK.EF.Enum.Action;

namespace CK.EF
{
    public partial class Trade
    {
        public Guid TradeId { get; set; }
        public DateTime Created { get; set; }
        public DateTime? Modified { get; set; }
        public Guid UserId { get; set; }
        public Guid PortfolioId { get; set; }
        public string Date { get; set; }
        public decimal NumberOfShares { get; set; }
        public decimal Price { get; set; }
        public Currency Currency { get; set; }

        public decimal MarketValue { get; set; }
        public Action Action { get; set; }
        public string? Notes { get; set; }
        public string Asset { get; set; }

        public virtual Portfolio Portfolio { get; set; } 
        public virtual User User { get; set; }
    }
}
