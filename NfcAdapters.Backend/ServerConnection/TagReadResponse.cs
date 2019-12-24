using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace NfcAdapters.Backend.ServerConnection
{
    public class TagReadResponse<T>
    {
        [JsonPropertyName("method")]
        public string Method { get; set; }
        [JsonPropertyName("data")]
        public T Data { get; set; }
        [JsonPropertyName("success")]
        public bool Success { get; set; }
    }
}
