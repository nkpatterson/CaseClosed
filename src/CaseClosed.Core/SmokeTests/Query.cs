using MediatR;

namespace CaseClosed.Core.SmokeTests
{
    public class Query : IRequest<Result>
    {
        public string SortBy { get; set; }
        public string SortDirection { get; set; }
        public int? Page { get; set; }
    }
}
