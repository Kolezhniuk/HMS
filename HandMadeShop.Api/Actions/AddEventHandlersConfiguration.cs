using System;
using System.Collections.Generic;
using HandMadeShop.Logic.Domain.Measure;
using Microsoft.Extensions.Configuration;

namespace HandMadeShop.Api.Actions
{
    public class AddEventHandlersConfiguration
    {
        private readonly IConfiguration _configuration;
        private readonly MeasureEventListener _listener;
        private readonly List<IDisposable> _subs;

        public AddEventHandlersConfiguration(MeasureEventListener listener, IConfiguration configuration)
        {
            _listener = listener;
            _configuration = configuration;
            _subs = new List<IDisposable>();
        }

        public void UseListeners()
        {
            if (!_configuration.GetValue<bool>("UseListeners")) return;
            _subs.Add(_listener.HandleProductCreatedEvent());
            _subs.Add(_listener.HandleUserAuthorizedEvent());
        }

        ~AddEventHandlersConfiguration()
        {
            _subs.ForEach(sub => sub.Dispose());
        }
    }
}