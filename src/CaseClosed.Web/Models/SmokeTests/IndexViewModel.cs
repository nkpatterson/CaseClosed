using Abp.Application.Services.Dto;
using CaseClosed.SmokeTests.Dto;

namespace CaseClosed.Web.Models.SmokeTests
{
    public class IndexViewModel
    {
        public bool CanCreateSmokeTest { get; set; }
        public ListResultOutput<SmokeTestListDto> Items { get; set; }
    }
}