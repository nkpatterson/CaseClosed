using Abp.Application.Services.Dto;

namespace CaseClosed.SmokeTests.Dto
{
    public class CreateSmokeTestInput : IInputDto
    {
        public string Message { get; set; }
    }
}
