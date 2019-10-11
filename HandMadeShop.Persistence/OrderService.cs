using System.Threading.Tasks;
using Raven.Client.Documents;
using Raven.Client.Documents.Session;

namespace HandMadeShop.Persistence
{
    public class OrderService
    {
        private readonly IAsyncDocumentSession _dbSession;

        public OrderService(IAsyncDocumentSession dbSession)
        {
            _dbSession = dbSession;
        }

        public Task<int> GetOrderCount()
        {
            return _dbSession
                .Query<Order>()
                .CountAsync();
        }
    }
}