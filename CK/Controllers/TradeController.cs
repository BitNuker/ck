using CK.EF;
using CK.Entities;
using CK.TradeData;
using Microsoft.AspNetCore.Mvc;

namespace CK.Controllers
{
    [ApiController]
    public class TradeController : Controller
    {
        private readonly ITradeData _tradeData;
        public TradeController(ITradeData tradeData)
        {
            _tradeData = tradeData;
        }

        [HttpGet, Route("trades/byUserId/{userId}")]
        public IActionResult GetTradesByUserId(Guid userId)
        {
            var trades = _tradeData.GetTradesByUserId(userId);
            if (trades.Any())
                return Ok(trades);

            return NotFound("Error: Trades not found.");

        }

        [HttpGet, Route("trades/byTradeId/{tradeId}")]

        public IActionResult GetTradeById(Guid tradeId)
        {
            var trade = _tradeData.GetTradeById(tradeId);
            if (trade != null)
                return Ok(trade);

            return NotFound("Error: Trade not found.");

        }


        [HttpPost, Route("api/trade")]
        public IActionResult AddTrade(TradePostModel trade)
        {
            //Get User

            //Compare if User exists
            //return BadRequest("Error: Trade must have a valid User.");

            //Compare if Portefolio exists
            //return BadRequest("Error: Trade must have a valid Portfolio.");

            if (trade != null)
            {
                Trade newTrade = _tradeData.AddTrade(trade);

                return Created(HttpContext.Request.Scheme + "://" + HttpContext.Request.Host + HttpContext.Request.Path + "/" + newTrade?.TradeId, newTrade);
            }

            return NotFound("Error: Trade cannot be empty");
        }

        [HttpDelete, Route("trades/delete/{id}")]
        public IActionResult DeleteTrade(Guid id)
        {
            var trade = _tradeData.GetTradeById(id);

            if (trade != null)
            {
                _tradeData.DeleteTrade(trade);
                return Ok("Result: Trade deleted with success");
            }

            return NotFound("Error: No trade to delete");
        }
    }
}
