using System.Net.Http.Json;

public class ApiService
{
    private readonly HttpClient _http;

    public ApiService(HttpClient http)
    {
        _http = http;
    }

    public async Task<List<Item>> GetItems()
    {
        var result = await _http.GetFromJsonAsync<List<Item>>("api/test");
        return result ?? new List<Item>();
    }
}

public class Item
{
    public int Id { get; set; }
    public string Name { get; set; } = "";
}