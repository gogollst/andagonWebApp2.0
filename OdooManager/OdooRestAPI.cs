using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

public class OdooRestAPI
{
    private readonly string url = "https://andagon-holding.cloud/rest";
    private readonly string clientId = "5vUmGafdSuZ6BZ3E9LyVRvbtK6SlLqdphPrk6OiO";
    private readonly string clientSecret = "7N5cVRPRUxZlkTGIzL1CQrSrRayvXAS17RG6kRHj";
    private readonly HttpClient httpClient;
    private string accessToken;

    public OdooRestAPI()
    {
        httpClient = new HttpClient();
    }

    private string Route(string url)
    {
        if (url.StartsWith("/"))
        {
            return $"{this.url}{url}";
        }
        return url;
    }

    public async Task Authenticate()
    {
        var tokenUrl = Route("/api/v1/authentication/oauth2/token");
        var content = new FormUrlEncodedContent(new[]
        {
            new KeyValuePair<string, string>("grant_type", "client_credentials"),
            new KeyValuePair<string, string>("client_id", clientId),
            new KeyValuePair<string, string>("client_secret", clientSecret)
        });

        var response = await httpClient.PostAsync(tokenUrl, content);
        if (!response.IsSuccessStatusCode)
        {
            throw new Exception(await response.Content.ReadAsStringAsync());
        }

        var tokenResponse = JsonSerializer.Deserialize<Dictionary<string, string>>(
            await response.Content.ReadAsStringAsync());
        accessToken = tokenResponse["access_token"];
        httpClient.DefaultRequestHeaders.Authorization =
            new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", accessToken);
    }

    public async Task<T> Execute<T>(string endpoint, string type = "GET", Dictionary<string, string> data = null)
    {
        HttpResponseMessage response;
        var url = Route(endpoint);

        data ??= new Dictionary<string, string>();

        switch (type.ToUpper())
        {
            case "POST":
                response = await httpClient.PostAsync(url, new FormUrlEncodedContent(data));
                break;
            case "PUT":
                response = await httpClient.PutAsync(url, new FormUrlEncodedContent(data));
                break;
            case "DELETE":
                response = await httpClient.DeleteAsync(url);
                break;
            default:
                response = await httpClient.GetAsync(url + "?" + await new FormUrlEncodedContent(data).ReadAsStringAsync());
                break;
        }

        var content = await response.Content.ReadAsStringAsync();
        if (!response.IsSuccessStatusCode)
        {
            throw new Exception(content);
        }

        return JsonSerializer.Deserialize<T>(content);
    }

    public async Task Run()
    {

        // test API
        Console.WriteLine(JsonSerializer.Serialize(await Execute<Dictionary<string, object>>("/api/v1")));
        Console.WriteLine(JsonSerializer.Serialize(await Execute<Dictionary<string, object>>("/api/v1/user")));

        // sample query
        var data = new Dictionary<string, string>
        {
            {"model", "res.partner"},
            {"domain", JsonSerializer.Serialize(new List<object> {
                new List<string> {"parent_id.name", "=", "Azure Interior"} })},
            {"fields", JsonSerializer.Serialize(new List<string> {"name", "image_small"})}
        };
        var response = await Execute<List<Dictionary<string, object>>>("/api/v1/search_read", "GET", data);
        foreach (var entry in response)
        {
            if (entry.ContainsKey("image_small") && entry["image_small"] is string img)
            {
                entry["image_small"] = img.Length > 5 ? img.Substring(0, 5) + "..." : img;
            }
        }
        Console.WriteLine(JsonSerializer.Serialize(response));

        // check customer
        data = new Dictionary<string, string>
        {
            {"model", "res.partner"},
            {"domain", JsonSerializer.Serialize(new List<object> {
                new List<string> {"name", "=", "Sample Customer"} })},
            {"limit", "1"}
        };
        var customerResponse = await Execute<List<int>>("/api/v1/search", "GET", data);
        var customer = customerResponse.Count > 0 ? customerResponse[0] : 0;

        // create customer
        if (customer == 0)
        {
            var values = new Dictionary<string, string> { { "name", "Sample Customer" } };
            data = new Dictionary<string, string>
            {
                {"model", "res.partner"},
                {"values", JsonSerializer.Serialize(values)}
            };
            var createResponse = await Execute<List<int>>("/api/v1/create", "POST", data);
            customer = createResponse[0];
        }

        // create product
        var productValues = new Dictionary<string, string> { { "name", "Sample Product" } };
        data = new Dictionary<string, string>
        {
            {"model", "product.template"},
            {"values", JsonSerializer.Serialize(productValues)}
        };
        var productResponse = await Execute<List<int>>("/api/v1/create", "POST", data);
        var product = productResponse[0];

        // create order
        var orderValues = new Dictionary<string, object>
        {
            {"partner_id", customer},
            {"state", "sale"},
            {"order_line", new List<object> {
                new List<object> { 0, 0, new Dictionary<string, int> { {"product_id", product} } }
            }}
        };
        data = new Dictionary<string, string>
        {
            {"model", "sale.order"},
            {"values", JsonSerializer.Serialize(orderValues)}
        };
        var orderResponse = await Execute<List<int>>("/api/v1/create", "POST", data);
        var order = orderResponse[0];
    }
}