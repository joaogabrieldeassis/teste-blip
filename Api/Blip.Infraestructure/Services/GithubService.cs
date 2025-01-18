using Blip.Core.Configurations;
using Blip.Core.Interfaces.Infreastructure.Services;
using Blip.Core.Interfaces.Notifications;
using Blip.Core.Models;
using Blip.Core.Responses;
using Microsoft.Extensions.Options;

namespace Blip.Infraestructure.Services;

public class GithubService : IGithubService
{
    private readonly HttpClient _httpClient;
    private readonly INotifier _notifier;
    private readonly Apis _apis;

    public GithubService(HttpClient httpClient, INotifier notifier, IOptions<Apis> apis)
    {
        httpClient.DefaultRequestHeaders.Add("user-agent", "C#");
        _httpClient = httpClient;
        _notifier = notifier;
        _apis = apis.Value;
    }

    public async Task<IEnumerable<GithubResponse>?> GetTheFiveOldestRepositoriesWrittenInCsharp()
    {
        var response = await _httpClient.GetAsync(_apis.UrlGithubBlip);
        var githubResponses = await HandlerResponseAsync<GithubResponse>(response)!;

        var getCsharpOnlyRepositories = GetCsharpOnlyRepositories(githubResponses);
        var tetOldestRepositories = GetOldestRepositories(getCsharpOnlyRepositories);

        return GetTopFiveRepositories(tetOldestRepositories);
    }

    private async Task<IEnumerable<T>>? HandlerResponseAsync<T>(HttpResponseMessage response)
    {
        if (!response.IsSuccessStatusCode)
        {
            _notifier.Handle(new Notification($"Não foi possivel ler os dados do github: {response.Content.ReadAsStream()}"));
            return [];
        }

        return await DeserializeAsync<T>(response);
    }

    private static async Task<IEnumerable<T>> DeserializeAsync<T>(HttpResponseMessage response)
    {
        var readString = await response.Content.ReadAsStringAsync();
        if (string.IsNullOrEmpty(readString)) throw new Exception("Não foi possível desserializar o objeto de resposta.");

        return System.Text.Json.JsonSerializer.Deserialize<IEnumerable<T>>(readString)
            ?? throw new Exception("Não foi possível desserializar o objeto de resposta.");
    }

    private static IEnumerable<GithubResponse> GetCsharpOnlyRepositories(IEnumerable<GithubResponse> githubResponses)
    {
        return githubResponses.Where(c => !string.IsNullOrEmpty(c.Language) && c.Language!.Equals("C#"));
    }

    private static IEnumerable<GithubResponse> GetOldestRepositories(IEnumerable<GithubResponse> githubResponses)
    {
        return githubResponses.OrderBy(c => c.CreatedAt);
    }

    private static IEnumerable<GithubResponse> GetTopFiveRepositories(IEnumerable<GithubResponse> githubResponses)
    {
        return githubResponses.Take(5);
    }
}