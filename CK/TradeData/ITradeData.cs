using CK.EF;
using CK.Entities;

namespace CK.TradeData
{
    public interface ITradeData
    {
        List<Trade> GetTradesByUserId(Guid userId);

        Trade GetTradeById(Guid tradeId);

        Trade AddTrade(TradePostModel trade);

        void DeleteTrade(Trade trade);
    }
}
