using System;
using System.Collections.Generic;

namespace CK.EF
{
    public partial class Trade
    {
        public Guid TradeId { get; set; }
        public DateTime Created { get; set; }
        public DateTime? Modified { get; set; }
        public Guid UserId { get; set; }
        public Guid PortfolioId { get; set; }
        public string Date { get; set; } = null!;
        public decimal NumberOfShares { get; set; }
        public decimal Price { get; set; }
        public Currency Currency { get; set; }

        public decimal MarketValue { get { return this.NumberOfShares * this.Price; } set { MarketValue = value; } }
        public Action Action { get; set; }
        public string? Notes { get; set; }
        public string Asset { get; set; } = null!;

        public virtual Portfolio Portfolio { get; set; } = null!;
        public virtual User User { get; set; } = null!;

        
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
