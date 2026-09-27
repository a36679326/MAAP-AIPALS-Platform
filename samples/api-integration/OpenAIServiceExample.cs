using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace MAAP.AIPALS.Samples.ApiIntegration
{
    /// <summary>
    /// OpenAI Assistant API v2 服務串接範例
    /// 展現使用 C# HttpClient 進行非同步 API 呼叫與 Guardrails 整合
    /// </summary>
    public class OpenAiAssistantService
    {
        private readonly HttpClient _httpClient;
        private readonly string _apiKey;

        public OpenAiAssistantService(HttpClient httpClient, string apiKey)
        {
            _httpClient = httpClient ?? throw new ArgumentNullException(nameof(httpClient));
            _apiKey = apiKey ?? throw new ArgumentNullException(nameof(apiKey));
        }

        /// <summary>
        /// 呼叫 Dynamic Hint Agent 取得蘇格拉底式引導提示
        /// </summary>
        public async Task<string> GetDynamicHintAsync(string studentCode, string errorMessage, string threadId)
        {
            var requestUrl = $"https://api.openai.com/v1/threads/{threadId}/messages";

            var payload = new
            {
                role = "user",
                content = $"學生程式碼：\n{studentCode}\n\n執行結果/錯誤訊息：\n{errorMessage}\n\n請給予引導式提示，切勿直接給出正確解答。"
            };

            var jsonContent = new StringContent(
                JsonConvert.SerializeObject(payload), 
                Encoding.UTF8, 
                "application/json"
            );

            using (var request = new HttpRequestMessage(HttpMethod.Post, requestUrl))
            {
                request.Headers.Add("Authorization", $"Bearer {_apiKey}");
                request.Headers.Add("OpenAI-Beta", "assistants=v2");
                request.Content = jsonContent;

                var response = await _httpClient.SendAsync(request);
                response.EnsureSuccessStatusCode();

                var responseString = await response.Content.ReadAsStringAsync();
                return responseString;
            }
        }
    }
}
