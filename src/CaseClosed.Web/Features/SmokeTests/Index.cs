using CaseClosed.Model.SmokeTests;
using CaseClosed.Web.Infrastructure;
using MediatR;
using Newtonsoft.Json;
using PagedList;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace CaseClosed.Web.Features.SmokeTests
{
    public class Index
    {
        public class Query : IAsyncRequest<Result>
        {
            public string SortBy { get; set; } = "Created";
            public int PagedNumber { get; set; } = 1;
            public int PageSize { get; set; } = 10;
        }

        public class Result
        {
            public string CurrentSortBy { get; set; }
            public IPagedList<SmokeTest> Items { get; set; }
        }

        //public class InMemoryQueryHandler : IAsyncRequestHandler<Query, Result>
        //{
        //    public async Task<Result> Handle(Query message)
        //    {
        //        return new Result
        //        {
        //            CurrentSortBy = message.SortBy,
        //            Items = InMemorySmokeTests.Tests.OrderByDescending(x => x.Created)
        //                                            .ToPagedList(message.PagedNumber.Value, message.PageSize.Value)
        //        };
        //    }
        //}

        public class QueryHandler : WebApiCallerBase, IAsyncRequestHandler<Query, Result>
        {
            public QueryHandler(WebApiConfiguration config) : base(config)
            {
            }

            public async Task<Result> Handle(Query message)
            {
                var request = CreateRequest(HttpMethod.Get, "smoketests");
                var response = await Client.SendAsync(request);

                if (response.IsSuccessStatusCode)
                {
                    var json = await response.Content.ReadAsStringAsync();
                    var items = JsonConvert.DeserializeObject<List<SmokeTest>>(json);

                    var result = new Result
                    {
                        CurrentSortBy = message.SortBy,
                        Items = items.ToPagedList(message.PagedNumber, message.PageSize)
                    };

                    return result;
                }
                else
                {
                    // TODO: Handle error appropriately
                    return new Result
                    {
                        CurrentSortBy = message.SortBy,
                        Items = new List<SmokeTest>().ToPagedList(message.PagedNumber, message.PageSize)
                    };
                }
            }
        }
    }
}
