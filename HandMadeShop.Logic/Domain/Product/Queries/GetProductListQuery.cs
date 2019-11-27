using System.Collections.Generic;
using HandMadeShop.Dtos.Product;
using HandMadeShop.Logic.Interfaces;

namespace HandMadeShop.Logic.Domain.Product.Queries
{
    public class GetProductListQuery : IQuery<IEnumerable<ProductListDto>>
    {
    }
}