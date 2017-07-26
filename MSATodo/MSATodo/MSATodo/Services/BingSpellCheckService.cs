using MSATodo.Models;
using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace MSATodo.Services
{
    public class BingSpellCheckService : IBingSCService
    {
        public readonly string SpellCheckAPIKey = "9639737d054946d9aa226cec6b010197";
        public readonly string APIURLEndPoint = "https://api.cognitive.microsoft.com/bing/v5.0/spellcheck/";

        public async Task<SpellCheckResult> CheckSpelling(string text)
        {
            string requestUri = GenerateReqUri(APIURLEndPoint, text, SpellCheckMode.Spell);
            var resp = await SendReq(requestUri, SpellCheckAPIKey);
            var scResult = JsonConvert.DeserializeObject<SpellCheckResult>(resp);

            return scResult;
        }

        string GenerateReqUri(string sCEndPoint, string text, SpellCheckMode mode)
        {
            string reqUri = sCEndPoint;
            reqUri += string.Format("?text={0}", text);
            reqUri += string.Format("&mode={0}", mode.ToString().ToLower());

            return reqUri;
        }

        public async Task<string> SendReq(string url, string key)
        {
            using (var httpClient = new HttpClient())
            {
                httpClient.DefaultRequestHeaders.Add("Ocp-Apim-Subscription-Key", key);
                var response = await httpClient.GetAsync(url);

                return await response.Content.ReadAsStringAsync();
            }
        }
    }
}
