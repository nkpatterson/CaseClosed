using System;

namespace CaseClosed.Web.Models
{
    [Serializable]
    public class FlashMessage
    {
        public string Message { get; set; }
        public FlashMessageType MessageType { get; set; } = FlashMessageType.Information;
    }

    [Serializable]
    public enum FlashMessageType
    {
        Success = 0,
        Information = 1,
        Warning = 2,
        Error = 3
    }
}