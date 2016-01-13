using System;

namespace CaseClosed.Web.Models.Layout
{
    [Serializable]
    public class FlashViewModel
    {
        public string Message { get; set; }
        public FlashMessageType MessageType { get; set; }
        public string CssClass
        {
            get
            {
                if (MessageType == FlashMessageType.Success)
                    return "panel-success";
                if (MessageType == FlashMessageType.Warn)
                    return "panel-warning";
                if (MessageType == FlashMessageType.Error)
                    return "panel-danger";
                if (MessageType == FlashMessageType.Info)
                    return "panel-info";

                return "panel-primary";
            }
        }
    }

    public enum FlashMessageType
    {
        Default = 0,
        Success,
        Info,
        Warn,
        Error
    }
}