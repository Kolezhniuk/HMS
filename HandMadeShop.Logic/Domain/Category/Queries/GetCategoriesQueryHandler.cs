using System.Collections.Generic;
using System.Threading.Tasks;
using HandMadeShop.Dtos.Category;
using HandMadeShop.Infrastrucutre.Interfaces;

namespace HandMadeShop.Infrastrucutre.Domain.Category.Queries
{
    internal sealed class GetCategoriesQueryHandler : IQueryHandler<GetCategoriesQuery, IEnumerable<CategoryDto>>
    {
        public async Task<IEnumerable<CategoryDto>> Handle(GetCategoriesQuery query)
        {
            return await Task.FromResult(new List<CategoryDto>());
        }
    }
}