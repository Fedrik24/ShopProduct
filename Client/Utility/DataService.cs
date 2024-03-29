﻿using ShopProduct.Shared;
using System.Net;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace ShopProduct.Client.Utility
{
    public class DataService
    {
        private readonly HttpClient _httpClient;

        public DataService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<T> ServiceHeaders<T>(string url, HttpMethod httpMethod, Dictionary<string, string> headers = null)
        {
            var request = new HttpRequestMessage(httpMethod, url);

            if (headers != null)
            {
                foreach (var header in headers)
                {
                    request.Headers.Add(header.Key, header.Value);
                }
            }

            var response = await _httpClient.SendAsync(request);

            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                try
                {
                    return JsonSerializer.Deserialize<T>(content, new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });

                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                    return default;
                }
            }
            else
            {
                Console.WriteLine($"Error: {response.StatusCode} - {response.ReasonPhrase}");
                return default;
            }
        }

        public async Task<T> ServiceBody<T>(string url, HttpMethod httpMethod, object requestBody = null)
        {
            var request = new HttpRequestMessage(httpMethod, url);

            if (requestBody != null)
            {
                var json = JsonSerializer.Serialize(requestBody);
                request.Content = new StringContent(json, Encoding.UTF8, "application/json");
            }

            var response = await _httpClient.SendAsync(request);

            if (response.IsSuccessStatusCode)
            {
                var content = await response.Content.ReadAsStringAsync();
                try
                {
                    return JsonSerializer.Deserialize<T>(content, new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });

                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                    return default;
                }
            }
            else
            {
                Console.WriteLine($"Error: {response.StatusCode} - {response.ReasonPhrase}");
                return default;
            }
        }
    }
}
