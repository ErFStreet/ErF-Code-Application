namespace ClientApplication.Instructure.Helpers;

public static class HttpHelper<TResponse>
{
	private static HttpClient HttpClient;

	private static readonly string BaseUrl = $"https://localhost:44389/";


	static HttpHelper()
	{
		HttpClient = new HttpClient();
	}

	public static async Task<TResponse?> Get(string url)
	{
		var response =
			await HttpClient.GetFromJsonAsync<TResponse>($"{BaseUrl}{url}");

		return response;
	}

	public static async Task<TResponse?> Delete(string url)
	{
		var response =
			await HttpClient.DeleteFromJsonAsync<TResponse>($"{BaseUrl}{url}");

		return response;
	}

	public static async Task<Response> Post(string url, object data)
	{
		var responseRequest =
			await HttpClient.PostAsJsonAsync($"{BaseUrl}{url}", data);

		var response = new Response
		{
			StatusCode = (int)responseRequest.StatusCode,
		};

		return response;
	}
}
