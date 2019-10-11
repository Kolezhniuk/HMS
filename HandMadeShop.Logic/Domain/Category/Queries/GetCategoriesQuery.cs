using System.Collections.Generic;
using HandMadeShop.Dtos.Category;
using HandMadeShop.Logic.Interfaces;

namespace HandMadeShop.Logic.Domain.Category.Queries
{
    public class GetCategoriesQuery : IQuery<IEnumerable<CategoryDto>>
    {
    }
}