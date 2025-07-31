using Newtonsoft.Json;

namespace Postmonster.Runtime
{
    public class PRBodyOptions
    {
        public PRRawOptions? raw { get; set; }

        public PRTrimOptions? formdata { get; set; }

        public PRTrimOptions? urlencoded{ get; set; }
    }

    public class PRRawOptions
    {
        public string? language { get; set; } // json, text, etc.
    }

    public class PRTrimOptions
    {
        public bool? trimRequestBody { get; set; }
    }
}
