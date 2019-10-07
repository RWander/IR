using System;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace IR.Core.Step
{
    internal sealed class ResponseObject<TPayload>
        where TPayload: class, new()
    {
        [JsonPropertyName("trackingId")]
        public string TrackingId { get; private set; }

        [JsonIgnore] // Will be desirialized manually
        public TPayload Payload { get; private set; }

        [JsonPropertyName("status")]
        public string Status { get; set; }

        [Obsolete("Paramless constructor is used only for deserialization.")]
        public ResponseObject() { }

        //public ResponseObject(string status, TPayload payload, string trackingId)
        //{
        //    Status = status;
        //    Payload = payload;
        //    TrackingId = trackingId;
        //}

        public bool IsOk => string.Compare(Status, "Ok", StringComparison.CurrentCultureIgnoreCase) == 0;

        public static ResponseObject<T> Build<T>(string json)
            where T : class, new()
        {
            var resObj = JsonSerializer.Deserialize<ResponseObject<T>>(json);

            // TODO
            // Cut 'payload' string and JsonSerializer.Deserialize it to Payload property
            // ..

            return resObj;
        }

        public override string ToString()
        {
            return $"Status:{Status}; Payload:{Payload}";
        }
    }
}