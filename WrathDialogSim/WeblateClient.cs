using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace WrathDialogSim;

internal class WeblateClient
{
    private string ProjectName { get; set; }
    private readonly HttpClient client;
    private string authToken = string.Empty;

    public WeblateClient(string projectName)
    {
        if (string.IsNullOrEmpty(projectName))
            throw new ArgumentNullException(nameof(projectName));

        client = new HttpClient();
        ProjectName = projectName;
    }

    public void SetAuthToken(string key)
    {
        key = key.Trim();
        authToken = key;
        client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("text/javascript"));
        client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Token", key);
    }

    public string TestAuth()
    {
        if (string.IsNullOrWhiteSpace(authToken))
        {
            return "API키가 없음";
        }

        if (!Regex.IsMatch(authToken, pattern: "^[a-zA-Z0-9]{40}$"))
        {
            return "API키가 올바르지 않음";
        }

        var result = client.GetAsync($"{Constants.WEBLATE_API_HOST}/api/projects/{ProjectName}/").Result;

        if (result.IsSuccessStatusCode)
        {
            return "인증 성공";
        }

        return "인증 실패";
    }

    public T Request<T>(string path)
    {
        var response = client.GetAsync($"{Constants.WEBLATE_API_HOST}/api/{path}").Result;
        if (response.IsSuccessStatusCode)
        {
            string content = response.Content.ReadAsStringAsync().Result;
            return JsonSerializer.Deserialize<T>(content);
        }
        return default;
    }

    public bool TryGetTranslation(string key, out TranslationUnit unit)
    {
        unit = Request<TranslationUnit>($"unit/{Constants.PROJECT_SLUG}/ko/{key}/");
        return unit != default;
    }
}

public class TranslationUnit
{
    public int id { get; set; }
    public int position { get; set; }
    public string context { get; set; }
    public string source { get; set; }
    public string target { get; set; }
    public int state { get; set; }
    public string component { get; set; }
    public string checksum { get; set; }

    public bool Fuzzy => state == 10;
    public bool Translated => state == 20;
    public bool Approved => state == 100;
}

public class DialogueUnit
{
    public int id { get; set; }

    public int pos { get; set; }
}
