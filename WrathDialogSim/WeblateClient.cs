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

namespace WrathDialogSim
{
    internal class WeblateClient
    {
        private const string BASE_URL = "http://akintos.iptime.org";

        private string ProjectName { get; init; }
        private readonly HttpClient client;
        private string authToken = string.Empty;

        internal WeblateData? Data { get; set; }

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
            var result = client.GetAsync($"{BASE_URL}/api/projects/{ProjectName}/").Result;

            if (result.IsSuccessStatusCode)
            {
                return "인증 성공";
            }

            if (string.IsNullOrWhiteSpace(authToken))
            {
                return "API키가 없음";
            }

            if (!Regex.IsMatch(authToken, pattern: "^[a-zA-Z0-9]{40}$"))
            {
                return "API키가 올바르지 않음";
            }

            return "인증 실패";
        }

        public T? Request<T>(string path)
        {
            var response = client.GetAsync($"{BASE_URL}/api/{path}").Result;
            if (response.IsSuccessStatusCode)
            {
                string content = response.Content.ReadAsStringAsync().Result;
                return JsonSerializer.Deserialize<T>(content);
            }
            return default;
        }

        public bool TryGetTranslation(string key, out TranslationUnit? unit)
        {
            unit = null;
            if (Data?.TryGetValue(key.ToLowerInvariant(), out var value) == true)
            {
                unit = Request<TranslationUnit>($"units/{value.id}/");
                return unit != default;
            }
            return false;
        }

        public string GetDialogueLink(string key)
        {
            if (Data is null) return string.Empty;

            DialogueUnit unitData = Data[key.ToLowerInvariant()];
            return $"{BASE_URL}/translate/{ProjectName}/dialogue/ko/?offset={unitData.pos}";
        }
    }

    public class TranslationUnit
    {
        public string translation { get; set; }
        public string source { get; set; }
        public string target { get; set; }
        public string location { get; set; }
        public string context { get; set; }
        public string comment { get; set; }
        public string flags { get; set; }
        public bool fuzzy { get; set; }
        public bool translated { get; set; }
        public bool approved { get; set; }
        public int position { get; set; }
        public int id { get; set; }
        public string web_url { get; set; }
    }

    public class DialogueUnit
    {
        public int id { get; set; }

        public int pos { get; set; }
    }
}
