using CK.EF;
using CK.Entities;
using CK.PortfolioData;
using Microsoft.AspNetCore.Mvc;

namespace CK.Controllers
{
    [ApiController]
    public class PortfolioController : Controller
    {
        private readonly IPortfolioData _portfolioData;
        public PortfolioController(IPortfolioData portfolioData)
        {
            _portfolioData = portfolioData;
        }

        [HttpGet, Route("portfolios/byUserId/{userId}")]
        public IActionResult GetPortfoliosByUserId(Guid userId)
        {
            var portfolios = _portfolioData.GetPortfoliosByUserId(userId);
            if (portfolios.Any())
                return Ok(portfolios);

            return NotFound("Error: Portfolios not found.");

        }

        [HttpGet, Route("portfolios/byPortfolioId/{portfolioId}")]

        public IActionResult GetPortfolioById(Guid portfolioId)
        {
            var portfolio = _portfolioData.GetPortfolioById(portfolioId);
            if (portfolio != null)
                return Ok(portfolio);

            return NotFound("Error: Portfolio not found.");

        }


        [HttpPost, Route("api/portfolio")]
        public IActionResult AddPortfolio(PortfolioPostModel portfolio)
        {
            //Get User

            //Compare if User exists
                //return BadRequest("Error: Portfolio must have a valid User.");

            if (portfolio != null)
            {
                Portfolio newPortfolio = _portfolioData.AddPortfolio(portfolio);

                return Created(HttpContext.Request.Scheme + "://" + HttpContext.Request.Host + HttpContext.Request.Path + "/" + newPortfolio.PortfolioId, newPortfolio);
            }

            return NotFound("Error: Portfolio cannot be empty");
        }

        [HttpDelete, Route("portfolios/delete/{id}")]
        public IActionResult DeletePortfolio(Guid id)
        {
            var portfolio = _portfolioData.GetPortfolioById(id);

            if (portfolio != null)
            {
                _portfolioData.DeletePortfolio(portfolio);
                return Ok("Result: Portfolio deleted with success");
            }

            return NotFound("Error: No portfolio to delete;");
        }
    }
}
