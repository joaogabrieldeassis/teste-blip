using Blip.Core.Responses;

namespace Blip.Core.Interfaces.Infreastructure.Services;

public interface IGithubService
{
    public Task<IEnumerable<GithubResponse>> GetTheFiveOldestRepositoriesWrittenInCsharp();
}