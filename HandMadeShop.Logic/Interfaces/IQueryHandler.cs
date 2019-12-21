using System.Threading.Tasks;

namespace HandMadeShop.Infrastrucutre.Interfaces
{
    public interface IQueryHandler<in TQuery, TResult>
        where TQuery : IQuery<TResult>
    {
        Task<TResult> Handle(TQuery query);
    }
}