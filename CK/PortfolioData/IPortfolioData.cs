using CK.Entities;

namespace CK.PortfolioData
{
    public interface IPortfolioData
    {
        List<Portfolio> GetPortfoliosByUserId(Guid userId);

        Portfolio GetPortfolioById(Guid portfolioId);

        Portfolio AddPortfolio(Portfolio portfolio);

        void DeletePortfolio(Portfolio portfolio);
    }
}
