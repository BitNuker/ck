using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace CK.Entities
{
    public class Portfolio
    {
        public Portfolio()
        {
            this.Trades = new HashSet<Trade>();
        }

        [Key]
        public Guid Id { get; set; }

        [Required]
        public decimal Balance => Trades.Where(t => t.Action == Action.Sell).Sum(t => t.MarketValue) -
            Trades.Where(t => t.Action == Action.Buy).Sum(t => t.MarketValue);

        [Required]
        public Guid UserId { get; set; }

        public virtual ICollection<Trade> Trades { get; set; }
    }
}
