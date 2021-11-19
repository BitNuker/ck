using System;
using System.Collections.Generic;
using CK.EF.Enum;
using System.ComponentModel.DataAnnotations.Schema;
using Action = CK.EF.Enum.Action;

namespace CK.EF
{
    public partial class Portfolio
    {
        public Portfolio()
        {
            this.Balance = this.Trades == null ? 0 : this.Trades.Where(t => t.Action == Action.Sell).Sum(t => t.MarketValue) -
Trades.Where(t => t.Action == Action.Buy).Sum(t => t.MarketValue);

            Trades = new HashSet<Trade>();
        }

        public Guid PortfolioId { get; set; }

        public Guid UserId { get; set; }

        public decimal Balance { get; set; }

        public virtual ICollection<Trade> Trades { get; set; }

        [ForeignKey("UserID")]
        public virtual User User { get; set; } = null!;
    }
}
