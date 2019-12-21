using System;
using System.Collections.Generic;

namespace HandMadeShop.Infrastrucutre.Messaging
{
    public static class MessageBusHelper
    {
        public static readonly Dictionary<Type, Type[]> RegisteredServices = new Dictionary<Type, Type[]>();
    }
}