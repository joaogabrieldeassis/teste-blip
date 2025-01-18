using Microsoft.AspNetCore.Mvc;
using Blip.Core.Interfaces.Notifications;
using Blip.Core.Models;

namespace Blip.Api.Controllers;

public abstract class MainController(INotifier notifier) : ControllerBase
{
    private readonly INotifier _notifier = notifier;

    protected bool IsOperationValid()
    {
        return !_notifier.HasNotification();
    }

    protected ActionResult CustomResponse(object? result = null)
    {
        if (IsOperationValid())
        {
            return Ok(new
            {
                success = true,
                data = result
            });
        }
        return BadRequest(new
        {
            success = false,
            errors = _notifier.GetNotifications().Select(x => x.Message)
        });
    }

    protected void NotifyError(string message)
    {
        _notifier.Handle(new Notification(message));
    }
}