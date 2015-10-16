using CaseClosed.Model.SmokeTests;
using MediatR;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Threading.Tasks;

namespace CaseClosed.Web.Features.SmokeTests
{
    public class Index
    {
        public class Query : IAsyncRequest<Result>
        {
            public string SortBy { get; set; } = "Created";
            public int? PagedNumber { get; set; } = 1;
            public int? PageSize { get; set; } = 10;
        }

        public class Result
        {
            public string CurrentSortBy { get; set; }
            public IPagedList<SmokeTest> Items { get; set; }
        }

        public class InMemoryQueryHandler : IAsyncRequestHandler<Query, Result>
        {
            public async Task<Result> Handle(Query message)
            {
                return new Result
                {
                    CurrentSortBy = message.SortBy,
                    Items = InMemorySmokeTests.Tests.OrderByDescending(x => x.Created)
                                                    .ToPagedList(message.PagedNumber.Value, message.PageSize.Value)
                };
            }
        }
    }
}