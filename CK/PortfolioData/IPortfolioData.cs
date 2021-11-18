using CK.EF;
using CK.Entities;

namespace CK.PortfolioData
{
    public interface IPortfolioData
    {
        List<Portfolio> GetPortfoliosByUserId(Guid userId);

        Portfolio GetPortfolioById(Guid portfolioId);

        Portfolio AddPortfolio(PortfolioPostModel portfolio);

        void DeletePortfolio(Portfolio portfolio);
    }
}
