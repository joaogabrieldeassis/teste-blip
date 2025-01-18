using Blip.Core.Interfaces.Infreastructure.Services;
using Blip.Core.Interfaces.Notifications;
using Microsoft.AspNetCore.Mvc;

namespace Blip.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class GithubController(INotifier notifier, IGithubService githubService) : MainController(notifier)
{
    private readonly IGithubService _githubService = githubService;


    [HttpGet]
    public async Task<ActionResult> GetRepositorys()
    {
        return CustomResponse(await _githubService.GetTheFiveOldestRepositoriesWrittenInCsharp());
    }
}
