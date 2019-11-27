using System.Collections.Generic;
using System.Threading.Tasks;
using HandMadeShop.Dtos.Category;
using HandMadeShop.Logic.Interfaces;

namespace HandMadeShop.Logic.Domain.Category.Queries
{
    internal sealed class GetCategoriesQueryHandler : IQueryHandler<GetCategoriesQuery, IEnumerable<CategoryDto>>
    {
        public GetCategoriesQueryHandler()
        {
        }

        public async Task<IEnumerable<CategoryDto>> Handle(GetCategoriesQuery query)
        {
            return await Task.FromResult(new List<CategoryDto>());
        }
    }
}