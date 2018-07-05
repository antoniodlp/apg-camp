using Nop.Core.Configuration;

namespace Odegi.Nop.Plugin.AuditLog
{
    public class AuditLogSettings : ISettings
    {
        public bool Enabled { get; set; }
    }
}