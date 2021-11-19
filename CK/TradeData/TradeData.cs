using CK.EF;
using CK.EF.Enum;
using CK.Entities;
using Action = CK.EF.Enum.Action;
using Currency = CK.EF.Enum.Currency;

namespace CK.TradeData
{
    public class TradeData : ITradeData
    {
        private readonly CKContext _context;

        public TradeData(CKContext context)
        {
            _context = context;
        }

        public Trade AddTrade(TradePostModel model)
        {
            try
            {
                Trade trade = new Trade()
                {
                    TradeId = Guid.NewGuid(),
                    UserId = model.UserId,
                    PortfolioId = model.PortfolioId,
                    Created = DateTime.Now,
                    Price = model.Price,
                    NumberOfShares = model.NumberOfShares,
                    Action = (Action)Enum.Parse(typeof(Action), model.Action, true),
                    Asset = model.Asset,
                    Date = DateTime.Now.ToString("yyyy/MM/dd"),
                    Notes = model.Notes,    
                    Currency = (Currency)Enum.Parse(typeof(Currency), model.Currency, true),
                    MarketValue = model.NumberOfShares * model.Price
            };

                _context.Trades.Add(trade);
                _context.SaveChanges();
                return trade;
            }
            catch (Exception e )
            {
                
                return null;
            }
            
        }

        public void DeleteTrade(Trade model)
        {
            _context.Trades.Remove(model);
            _context.SaveChanges();
        }

        public Trade GetTradeById(Guid tradeId)
        {
            return _context.Trades.Find(tradeId);
        }

        public List<Trade> GetTradesByUserId(Guid userId)
        {
            return _context.Trades.Where(p => p.UserId == userId).ToList();

        }
    }
}
