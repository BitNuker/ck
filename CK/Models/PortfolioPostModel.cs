using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace CK.Entities
{
    public class PortfolioPostModel
    {
        [Required]
        public Guid Id { get; set; }
        [Required]
        public Guid UserId { get; set; }

    }
}
