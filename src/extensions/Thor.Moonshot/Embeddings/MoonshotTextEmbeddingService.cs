﻿using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using Thor.Abstractions;
using Thor.Abstractions.Embeddings;
using Thor.Abstractions.Extensions;
using Thor.Abstractions.ObjectModels.ObjectModels.RequestModels;
using Thor.Abstractions.ObjectModels.ObjectModels.ResponseModels;

namespace Thor.Moonshot.Embeddings;

public sealed class MoonshotTextEmbeddingService(IHttpClientFactory httpClientFactory)
    : IThorTextEmbeddingService
{
    public async Task<EmbeddingCreateResponse> EmbeddingAsync(EmbeddingCreateRequest createEmbeddingModel,
        ThorPlatformOptions? options = null,
        CancellationToken cancellationToken = default)
    {
        var client = httpClientFactory.CreateClient(MoonshotPlatformOptions.PlatformCode);

        var response = await client.PostJsonAsync(options?.Address.TrimEnd('/') + "/v1/embeddings",
            createEmbeddingModel, options!.ApiKey);

        var result =
            await response.Content.ReadFromJsonAsync<EmbeddingCreateResponse>(cancellationToken: cancellationToken);

        return result;
    }
}