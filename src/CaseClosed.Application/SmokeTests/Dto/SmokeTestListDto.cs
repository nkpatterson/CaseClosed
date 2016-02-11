using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using System;

namespace CaseClosed.SmokeTests.Dto
{
    [AutoMapFrom(typeof(SmokeTest))]
    [Serializable]
    public class SmokeTestListDto : EntityDto
    {
        public DateTime CreationTime { get; set; }
        public string Creator { get; set; }
        public string Message { get; set; }
        public bool IsSuccess { get; set; }
    }
}
