using System;
using System.Collections.Generic;

namespace HandMadeShop.Infrastructure.Messaging
{
    public static class MessageBusHelper
    {
        public static readonly Dictionary<Type, Type[]> RegisteredServices = new Dictionary<Type, Type[]>();
    }
}