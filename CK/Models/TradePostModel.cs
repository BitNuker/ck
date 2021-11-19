using System.ComponentModel.DataAnnotations;

namespace CK.Entities
{
    public class TradePostModel
    {

        [Required]
        public Guid UserId { get; set; }

        [Required]
        public Guid PortfolioId { get; set; }
       
        [Required]
        public decimal NumberOfShares { get; set; }

        [Required]
        public decimal Price { get; set; }

        [Required]
        public string Currency { get; set; }


        [Required]
        public string Action { get; set; }

        public string Notes { get; set; }

        [Required]
        public string Asset { get; set; }

    }
}
