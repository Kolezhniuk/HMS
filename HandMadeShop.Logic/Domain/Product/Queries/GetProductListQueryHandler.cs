using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HandMadeShop.Dtos.Product;
using HandMadeShop.Logic.Interfaces;
using Raven.Client.Documents;
using Raven.Client.Documents.Session;

namespace HandMadeShop.Logic.Domain.Product.Queries
{
    public class GetProductListQueryHandler : IQueryHandler<GetProductListQuery, IEnumerable<ProductListDto>>
    {
        private readonly IAsyncDocumentSession _dbSession;

        public GetProductListQueryHandler(IAsyncDocumentSession dbSession)
        {
            _dbSession = dbSession;
        }

        public async Task<IEnumerable<ProductListDto>> Handle(GetProductListQuery query)
        {
            return (await _dbSession.Query<Core.Models.Product>().ToListAsync()).Select(product => new ProductListDto()
            {
                Name = product.Name,
                Id = product.Id,
                Category = product.Category
            });
        }
    }
}