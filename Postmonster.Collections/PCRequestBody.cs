using Newtonsoft.Json;

namespace Postmonster.Collections
{
    public class PCRequestBody
    {
        [JsonProperty("mode")]
        public string Mode { get; set; } = "raw"; // raw, formdata, urlencoded, file, graphql

        [JsonProperty("raw")]
        public string? Raw { get; set; }

        [JsonProperty("options")]
        public PCRequestBodyOptions? Options { get; set; }

        [JsonProperty("formdata")]
        public PCUrlEncodedFieldList? FormData { get; set; }

        [JsonProperty("urlencoded")]
        public PCUrlEncodedFieldList? UrlEncoded { get; set; }

        [JsonProperty("file")]
        public PCFile? File { get; set; }

        [JsonProperty("graphql")]
        public PCGraphQL? GraphQL { get; set; }
    }

    public class PCRequestBodyOptions
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

    public class PCFormDataFieldList : PCKeyedListOf<PCFormDataField>
    {
        public PCFormDataFieldList() : base() { }
        public PCFormDataFieldList(IEnumerable<PCFormDataField> items) : base(items) { }
    }

    public class PCFormDataField : IPCKeyedValueItem
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

    public class PCUrlEncodedFieldList : PCKeyedListOf<PCUrlEncodedField>
    {
        public PCUrlEncodedFieldList() : base() { }
        public PCUrlEncodedFieldList(IEnumerable<PCUrlEncodedField> items) : base(items) { }
    }

    public class PCUrlEncodedField : IPCKeyedValueItem
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
