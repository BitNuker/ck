using System;
using System.Collections.Generic;

namespace CK.EF
{
    public partial class Portfolio
    {
        public Portfolio()
        {
            Trades = new HashSet<Trade>();
        }

        public Guid PortfolioId { get; set; }

        public Guid UserId { get; set; }

        public decimal Balance => Trades.Where(t => t.Action == Action.Sell).Sum(t => t.MarketValue) -
            Trades.Where(t => t.Action == Action.Buy).Sum(t => t.MarketValue);

        public virtual ICollection<Trade> Trades { get; set; }
    }
}
