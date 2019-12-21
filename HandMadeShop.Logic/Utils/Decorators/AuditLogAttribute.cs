using System;

namespace HandMadeShop.Infrastrucutre.Utils.Decorators
{
    [AttributeUsage(AttributeTargets.Class, Inherited = false, AllowMultiple = true)]
    public sealed class AuditLogAttribute : Attribute
    {
    }
}