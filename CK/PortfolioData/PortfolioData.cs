using CK.EF;
using CK.Entities;
using Action = CK.Entities.Action;
using Currency = CK.EF.Currency;

namespace CK.PortfolioData
{
    public class PortfolioData : IPortfolioData
    {
        private readonly CKContext _context;

        public PortfolioData(CKContext context)
        {
            _context = context; 
        }

        //MOCK
        //private static readonly User userPort = new User()
        //{
        //    UserId = Guid.Parse("aa43d7ed-a03b-478d-a061-7411ddca000f"),
        //    Created = DateTime.Now,
        //    Email =  "nunomiranda.esaf@gmail.com",
        //    Name = "Nuno Miranda",
        //    Username = "nunomiranda",
        //    Password = "xSubEpwq3r0KGpXfoq05ylY6dDfT/HgBUrqL0JMsXy4=",
        //    Token = "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJodHRwOi8vc2"
        //};
        //private static readonly List<Trade> trades = new List<Trade>()
        //{
        //    new Trade()
        //    {
        //        TradeId = Guid.NewGuid(),
        //        UserId = userPort.UserId,
        //        Created = DateTime.Now,
        //        PortfolioId = Guid.Parse("6df1c3a3-3f0a-4612-a2a6-0ffca4a3f495"),
        //        Date = DateTime.Today.ToString("yyyy-MM-dd"),
        //        NumberOfShares = 10,
        //        Price = 1,
        //        Currency = Currency.EUR,
        //        Action = (EF.Action)Action.Buy,
        //        Asset = "XPT30"
        //    },
        //    new Trade()
        //    {
        //        TradeId = Guid.NewGuid(),
        //        UserId = userPort.UserId,
        //        Created = DateTime.Now,
        //        PortfolioId = Guid.Parse("6df1c3a3-3f0a-4612-a2a6-0ffca4a3f495"),
        //        Date = DateTime.Today.ToString("yyyy-MM-dd"),
        //        NumberOfShares = 10,
        //        Price = 2.2M,
        //        Currency = Currency.EUR,
        //        Action = (EF.Action)Action.Sell,
        //        Asset = "XPT30"
        //    }
        //};
        //private static readonly Portfolio portfolio = new Portfolio()
        //{
        //    PortfolioId = Guid.Parse("6df1c3a3-3f0a-4612-a2a6-0ffca4a3f495"),
        //    UserId = userPort.UserId,
        //    Trades = trades
        //};
        //public List<Portfolio> pf = new List<Portfolio>();

        public Portfolio AddPortfolio(PortfolioPostModel model)
        {
            Portfolio portfolio = new Portfolio()
            {
                PortfolioId = Guid.NewGuid(),
                UserId = model.UserId,
                //User = GetUser
            };
            _context.Portfolios.Add(portfolio);
            _context.SaveChanges();
            return portfolio;
        }

        public void DeletePortfolio(Portfolio model)
        {
            _context.Portfolios.Remove(model);
            _context.SaveChanges();
        }

        public Portfolio GetPortfolioById(Guid portfolioId)
        {
            return _context.Portfolios.Find(portfolioId);
        }

        public List<Portfolio> GetPortfoliosByUserId(Guid userId)
        {
            return _context.Portfolios.Where(p => p.UserId == userId).ToList();
        }
    }
}
