using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HandMadeShop.Dtos.Product;
using HandMadeShop.Logic.Interfaces;
using Raven.Client.Documents;
using Raven.Client.Documents.Session;

namespace HandMadeShop.Logic.Domain.Product.Queries
{
    public sealed class GetAllProductsQuery : IQuery<IEnumerable<ProductListDto>>
    {
        public class GetProductListQueryHandler : IQueryHandler<GetAllProductsQuery, IEnumerable<ProductListDto>>
        {
            private readonly IAsyncDocumentSession _dbSession;

            public GetProductListQueryHandler(IAsyncDocumentSession dbSession)
            {
                _dbSession = dbSession;
            }

            public async Task<IEnumerable<ProductListDto>> Handle(GetAllProductsQuery query)
            {
                return (await _dbSession.Query<Core.DomainEntities.Product>().ToListAsync()).Select(product =>
                    new ProductListDto
                    {
                        Name = product.Name,
                        Id = product.Id,
                        Category = product.Category
                    });
            }
        }
    }
}