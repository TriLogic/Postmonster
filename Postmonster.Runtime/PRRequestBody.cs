
namespace Postmonster.Runtime
{
    public class PRRequestBody
    {
        public string mode { get; set; } = "raw"; // raw, formdata, urlencoded, file, graphql

        public string? raw { get; set; }

        public List<PRFormField>? formdata { get; set; }

        public List<PRUrlEncodedField>? urlencoded { get; set; }

        public PRFileBody? file { get; set; }

        public PRGraphQLBody? graphql { get; set; }

        public PRBodyOptions? options { get; set; }
    }
}
