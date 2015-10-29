using CaseClosed.Model.SmokeTests;
using CaseClosed.Web.Infrastructure;
using MediatR;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace CaseClosed.Web.Features.SmokeTests
{
    public class Create
    {
        public class Command : IAsyncRequest<SmokeTest>
        {
            public string CreatedBy { get; set; }
        }

        public class CommandHandler : WebApiCallerBase, IAsyncRequestHandler<Command, SmokeTest>
        {

            public CommandHandler(WebApiConfiguration config) : base(config)
            {
            }

            public async Task<SmokeTest> Handle(Command message)
            {
                var request = CreateRequest(HttpMethod.Post, "smoketests");
                var content = new FormUrlEncodedContent(new[] { new KeyValuePair<string, string>("CreatedBy", message.CreatedBy) });
                request.Content = content;

                var response = await Client.SendAsync(request);

                if (response.IsSuccessStatusCode)
                {
                    var json = await response.Content.ReadAsStringAsync();
                    var result = JsonConvert.DeserializeObject<SmokeTest>(json);

                    return result;
                }
                else
                {
                    // TODO: Handle error appropriately
                    return new SmokeTest
                    {
                        Success = false,
                        Messages = new[] { "Error occurred." }
                    };
                }
            }
        }
    }
}