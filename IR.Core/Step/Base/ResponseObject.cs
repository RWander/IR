using System;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace IR.Core.Step
{
    internal sealed class ResponseObject<TPayload>
        where TPayload: Payload
    {
        //[JsonPropertyName("trackingId")]
        //public string TrackingId { get; private set; }

        [JsonIgnore] // Will be deserialized manually
        public TPayload Payload { get; private set; }

        [JsonPropertyName("status")]
        public string Status { get; set; }

        [Obsolete("Param-less constructor is used only for deserialization.")]
        public ResponseObject() { }

        //public ResponseObject(string status, TPayload payload, string trackingId)
        //{
        //    Status = status;
        //    Payload = payload;
        //    TrackingId = trackingId;
        //}

        public bool IsOk => string.Compare(Status, "Ok", StringComparison.CurrentCultureIgnoreCase) == 0;

        public static ResponseObject<T> Build<T>(string json, bool readPayload)
            where T : Payload
        {
            var resObj = JsonSerializer.Deserialize<ResponseObject<T>>(json);

            if (resObj != null && readPayload)
            {
                const string startToken = ",\"payload\":";
                const string endToken = ",\"status\":";

                // HACK: extract payload
                var iStart = json.IndexOf(startToken, StringComparison.InvariantCulture) + 11;
                var iEnd = json.LastIndexOf(endToken);
                var payload = json.Substring(iStart, iEnd - iStart);
                resObj.Payload = JsonSerializer.Deserialize<T>(payload);
            }

            return resObj;
        }

        public override string ToString()
        {
            if (IsOk && Payload != null)
            {
                return $"Status:{Status}; Payload:{Payload}";
            }
            return $"Status:{Status};";
        }
    }
}