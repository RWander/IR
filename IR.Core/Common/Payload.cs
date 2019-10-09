using System.Text.Json;

namespace IR.Core.Common
{
    public abstract class Payload
    {
        public override string ToString() => this.Serialize();
    }

    internal static class _ext
    {
        private static readonly JsonSerializerOptions SerializeOptions = new JsonSerializerOptions
        {
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase
        };

        private static readonly JsonSerializerOptions DeserializeOptions = new JsonSerializerOptions
        {
            PropertyNamingPolicy = CustomPolicy.Instance
        };

        public static string Serialize(this object payload)
            => JsonSerializer.Serialize(payload, SerializeOptions);

        public static TPayload Deserialize<TPayload>(this string json)
            => JsonSerializer.Deserialize<TPayload>(json, DeserializeOptions);

        #region [Nested classes]
        private sealed class CustomPolicy : JsonNamingPolicy
        {
            public static readonly CustomPolicy Instance = new CustomPolicy();

            private CustomPolicy() { }

            public override string ConvertName(string name)
            {
                return name[..1].ToLower() + name[1..];
            }
        }
        #endregion
    }
}