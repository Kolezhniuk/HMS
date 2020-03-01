using System;
using System.Text.Json;
using System.Threading.Tasks;
using HandMadeShop.Logic.Interfaces;
using Microsoft.Extensions.Logging;

namespace HandMadeShop.Logic.Utils.Decorators
{
    public sealed class LoggingQueryDecorator<TQuery, TResult> : IQueryHandler<TQuery, TResult>
        where TQuery : IQuery<TResult>
    {
        private readonly IQueryHandler<TQuery, TResult> _handler;
        private readonly ILogger<IQueryHandler<TQuery, TResult>> _logger;

        public LoggingQueryDecorator(IQueryHandler<TQuery, TResult> handler,
            ILogger<IQueryHandler<TQuery, TResult>> logger)
        {
            _logger = logger;
            _handler = handler;
        }

        public Task<TResult> Handle(TQuery query)
        {
            try
            {
                var queryJson = JsonSerializer.Serialize(query);
                _logger.LogInformation(
                    $"Query handler of type {query.GetType().Name} processing payload: {queryJson}");
                return _handler.Handle(query);
            }
            catch (Exception e)
            {
                _logger.LogError(
                    $"Query handler of type {query.GetType().Name} error. Reason: {JsonSerializer.Serialize(e)}");
                throw;
            }
        }
    }
}