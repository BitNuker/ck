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
        public IActionResult GetPortfolioByUserId(Guid userId)
        {
            var portfolios = _portfolioData.GetPortfoliosByUserId(userId);
            if (portfolios.Any())
                return Ok(portfolios);

            return NotFound("Error: Portfolios not found.");

        }

        [HttpGet, Route("portfolios/byPortfolioId/{portfolioid}")]

        public IActionResult GetPortfolioById(Guid portfolioid)
        {
            var portfolio = _portfolioData.GetPortfolioById(portfolioid);
            if (portfolio != null)
                return Ok(portfolio);

            return NotFound("Error: Portfolio not found.");

        }


        [HttpPost, Route("api/portfolio")]
        public IActionResult AddPortfolio(Portfolio portfolio)
        {
            //Get User
            //Compare if User exists
                //return BadRequest("Error: Portfolio must have a valid User.");

            if (portfolio != null)
            {
                _portfolioData.AddPortfolio(portfolio);

                return Created(HttpContext.Request.Scheme + "://" + HttpContext.Request.Host + HttpContext.Request.Path + "/" + portfolio.Id, portfolio);
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
