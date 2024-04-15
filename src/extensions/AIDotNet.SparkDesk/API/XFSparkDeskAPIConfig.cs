﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Text.Json.Serialization;
using System.Text.Json;
using System.Threading.Tasks;

namespace AIDotNet.SparkDesk.API
{
    public class XFSparkDeskChatAPIConfig
    {
        public string HostURL { get; set; } = null!;
        public XFSparkDeskModelType ModeType { get; set; }
        public string AppId { get; set; } = null!;
        public string ApiKey { get; set; } = null!;
        public string ApiSecret { get; set; } = null!;
    }

    public enum XFSparkDeskModelType
    {
        V1_5,
        V2_0,
        V3_0,
        V3_5
    }

    public class XFSparkDeskHostURL
    {
        public const string Chat_V1_5 = "wss://spark-api.xf-yun.com/v1.1/chat";
        public const string Chat_V2_0 = "wss://spark-api.xf-yun.com/v2.1/chat";
        public const string Chat_V3_0 = "wss://spark-api.xf-yun.com/v3.1/chat";
        public const string Chat_V3_5 = "wss://spark-api.xf-yun.com/v3.5/chat";
        public const string ImageGeneration_V2_1 = "https://spark-api.cn-huabei-1.xf-yun.com/v2.1/tti";
        public const string ImageAnalysis_V2_1 = "wss://spark-api.cn-huabei-1.xf-yun.com/v2.1/image";
    }

    public class XFSparkDeskAPIConfig
    {
        public string HostURL { get; set; } = null!;
        public string AppId { get; set; } = null!;
        public string ApiKey { get; set; } = null!;
        public string ApiSecret { get; set; } = null!;
    }

    public static class XFSparkDeskUtils
    {
        public static JsonSerializerOptions JsonSerializerOptions = new JsonSerializerOptions()
        {
            DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull
        };

        public static string GetAuth(string hostUrl, string apiKey, string apiSecret)
        {
            var url = new Uri(hostUrl);

            string dateString = DateTime.UtcNow.ToString("r");

            byte[] signatureBytes = Encoding.ASCII.GetBytes($"host: {url.Host}\ndate: {dateString}\nGET {url.AbsolutePath} HTTP/1.1");

            using HMACSHA256 hmacsha256 = new(Encoding.ASCII.GetBytes(apiSecret));
            byte[] computedHash = hmacsha256.ComputeHash(signatureBytes);
            string signature = Convert.ToBase64String(computedHash);

            string authorizationString = $"api_key=\"{apiKey}\",algorithm=\"hmac-sha256\",headers=\"host date request-line\",signature=\"{signature}\"";
            string authorization = Convert.ToBase64String(Encoding.ASCII.GetBytes(authorizationString));

            string query = $"authorization={authorization}&date={dateString}&host={url.Host}";

            return new UriBuilder(url) { Scheme = url.Scheme, Query = query }.ToString();
        }
    }
}
