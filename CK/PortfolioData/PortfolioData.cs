using CK.Entities;
using Action = CK.Entities.Action;

namespace CK.PortfolioData
{
    public class PortfolioData : IPortfolioData
    {
        //MOCK
        private static readonly User userPort = new User()
        {
            Id = Guid.Parse("aa43d7ed-a03b-478d-a061-7411ddca000f"),
            Created = DateTime.Now,
            Email =  "nunomiranda.esaf@gmail.com",
            Name = "Nuno Miranda",
            Username = "nunomiranda",
            Password = "xSubEpwq3r0KGpXfoq05ylY6dDfT/HgBUrqL0JMsXy4=",
            Token = "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJodHRwOi8vc2"
        };

        private List<Portfolio> pf = new List<Portfolio>()
        {
            new Portfolio()
            {
                Id = Guid.Parse("6df1c3a3-3f0a-4612-a2a6-0ffca4a3f495"),
                UserId = userPort.Id,
                Trades = new List<Trade>
                {
                    new Trade()
                    {
                        Id = Guid.NewGuid(),
                        UserId = userPort.Id,
                        Created = DateTime.Now,
                        PortfolioId = Guid.Parse("6df1c3a3-3f0a-4612-a2a6-0ffca4a3f495"),
                        Date = DateTime.Today.ToString("yyyy-MM-dd"),
                        NumberOfShares = 10,
                        Price = 1,
                        Currency = Currency.EUR,
                        Action = Action.Buy,
                        Asset = "XPT30"
                    },
                    new Trade()
                    {
                        Id = Guid.NewGuid(),
                        UserId = userPort.Id,
                        Created = DateTime.Now,
                        PortfolioId = Guid.Parse("6df1c3a3-3f0a-4612-a2a6-0ffca4a3f495"),
                        Date = DateTime.Today.ToString("yyyy-MM-dd"),
                        NumberOfShares = 10,
                        Price = 2.2M,
                        Currency = Currency.EUR,
                        Action = Action.Sell,
                        Asset = "XPT30"
                    }
                }
            }
        };

        public Portfolio AddPortfolio(Portfolio portfolio)
        {
            pf.Add(portfolio);
            return portfolio;
        }

        public void DeletePortfolio(Portfolio portfolio)
        {
            pf.Remove(portfolio);
        }

        public Portfolio GetPortfolioById(Guid portfolioId)
        {
            return pf.SingleOrDefault(p => p.Id == portfolioId);
        }

        public List<Portfolio> GetPortfoliosByUserId(Guid userId)
        {
            return pf.Where(p => p.UserId == userId).ToList();
        }
    }
}
