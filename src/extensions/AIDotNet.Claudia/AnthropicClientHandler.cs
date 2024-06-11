﻿namespace AIDotNet.Claudia;

public class AnthropicClientHandler : HttpClientHandler
{
    private readonly string _uri;

    public AnthropicClientHandler(string uri) => _uri = uri.TrimEnd('/');

    protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request,
        CancellationToken cancellationToken)
    {
        // 替换域名
        request.RequestUri =
            new Uri(request.RequestUri?.OriginalString.Replace("https://api.anthropic.com", _uri.TrimEnd('/')));

        return await base.SendAsync(request, cancellationToken);
    }
}