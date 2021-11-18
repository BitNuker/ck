using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace CK.Entities
{
    public class PortfolioPostModel
    {
        [Required]
        public Guid UserId { get; set; }

    }
}
