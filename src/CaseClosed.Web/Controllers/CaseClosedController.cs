using System.Web.Mvc;
using StructureMap.Attributes;
using MediatR;
using CaseClosed.Web.Models;

namespace CaseClosed.Web.Controllers
{
    public class CaseClosedController : Controller
    {
        [SetterProperty]
        public IMediator Mediator { get; set; }

        public void Flash(string message, FlashMessageType messageType = FlashMessageType.Success)
        {
            TempData.Add("Flash", new FlashMessage { Message = message, MessageType = messageType });
        }
    }
}