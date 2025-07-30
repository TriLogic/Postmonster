using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Postmonster.Collections
{
    public class PCRequest
    {
        [JsonProperty("url")]
        public string Url { get; set; } = string.Empty;

        [JsonProperty("method")]
        public string Method { get; set; } = "GET";

        [JsonProperty("header")]
        public Dictionary<string, string>? Header { get; set; }

        [JsonProperty("body")]
        public PCRequestBody? Body { get; set; }
    }

    public class PCRequestBody
    {
        [JsonProperty("mode")]
        public string Mode { get; set; } = "raw"; // raw, formdata, urlencoded, file, graphql

        [JsonProperty("raw")]
        public string? Raw { get; set; }

        [JsonProperty("options")]
        public PCBodyOptions? Options { get; set; }

        [JsonProperty("formdata")]
        public List<PCFormDataField>? FormData { get; set; }

        [JsonProperty("urlencoded")]
        public List<PCUrlEncodedField>? UrlEncoded { get; set; }

        [JsonProperty("file")]
        public PCFile? File { get; set; }

        [JsonProperty("graphql")]
        public PCGraphQL? GraphQL { get; set; }
    }

    public class PCBodyOptions
    {
        [JsonProperty("raw")]
        public PCRawOptions? Raw { get; set; }

        [JsonProperty("formdata")]
        public PCTrimOptions? FormData { get; set; }

        [JsonProperty("urlencoded")]
        public PCTrimOptions? UrlEncoded { get; set; }
    }

    public class PCRawOptions
    {
        [JsonProperty("language")]
        public string? Language { get; set; } // json, text, javascript, xml, etc.
    }

    public class PCTrimOptions
    {
        [JsonProperty("trimRequestBody")]
        public bool? TrimRequestBody { get; set; }
    }

    public class PCFormDataField
    {
        [JsonProperty("key")]
        public string Key { get; set; } = string.Empty;

        [JsonProperty("value")]
        public string? Value { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; } = "text"; // "text" or "file"

        [JsonProperty("src")]
        public string? Src { get; set; } // for file

        [JsonProperty("description")]
        public string? Description { get; set; }

        [JsonProperty("disabled")]
        public bool? Disabled { get; set; }
    }

    public class PCUrlEncodedField
    {
        [JsonProperty("key")]
        public string Key { get; set; } = string.Empty;

        [JsonProperty("value")]
        public string Value { get; set; } = string.Empty;

        [JsonProperty("description")]
        public string? Description { get; set; }

        [JsonProperty("disabled")]
        public bool? Disabled { get; set; }
    }

    public class PCFile
    {
        [JsonProperty("src")]
        public string Src { get; set; } = string.Empty;
    }

    public class PCGraphQL
    {
        [JsonProperty("query")]
        public string Query { get; set; } = string.Empty;

        [JsonProperty("variables")]
        public string Variables { get; set; } = "{}"; // Raw JSON string
    }
}
