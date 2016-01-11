using Abp.Domain.Entities.Auditing;

namespace CaseClosed.SmokeTests
{
    public class SmokeTest : AuditedEntity
    {
        public bool IsSuccess { get; set; }
        public string Message { get; set; }
    }
}
