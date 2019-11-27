using System.Threading.Tasks;

namespace HandMadeShop.Logic.Interfaces
{
    public interface IQueryHandler<TQuery, TResult>
        where TQuery : IQuery<TResult>
    {
        Task<TResult> Handle(TQuery query);
    }
}