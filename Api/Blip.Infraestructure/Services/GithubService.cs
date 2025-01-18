using Blip.Core.Interfaces.Infreastructure.Services;
using Blip.Core.Responses;

namespace Blip.Infraestructure.Services;

public class GithubService : IGithubService
{
    public Task<IEnumerable<GithubResponse>> GetTheFiveOldestRepositoriesWrittenInCsharp()
    {
        throw new NotImplementedException();
    }    
}