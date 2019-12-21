using System.Collections.Generic;
using HandMadeShop.Dtos.Category;
using HandMadeShop.Infrastrucutre.Interfaces;

namespace HandMadeShop.Infrastrucutre.Domain.Category.Queries
{
    public class GetCategoriesQuery : IQuery<IEnumerable<CategoryDto>>
    {
    }
}