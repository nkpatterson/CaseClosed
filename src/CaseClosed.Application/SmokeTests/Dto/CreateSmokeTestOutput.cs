using Abp.Application.Services.Dto;

namespace CaseClosed.SmokeTests.Dto
{
    public class CreateSmokeTestOutput : IOutputDto
    {
        public bool WasSuccessful { get; set; }
        public string Message { get; set; }
        public int? Id { get; set; }
    }
}
