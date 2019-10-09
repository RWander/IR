using System;
using System.Text.Json.Serialization;

namespace IR.Core.Step
{
    internal sealed class ResponseObject<TPayload>
        where TPayload: Payload
    {
        //public string TrackingId { get; private set; }

        [JsonIgnore] // Will be deserialized manually
        public TPayload Payload { get; private set; }

        public string Status { get; set; }

        [Obsolete("Param-less constructor is used only for deserialization.")]
        public ResponseObject() { }

        public bool IsOk => string.Compare(Status, "Ok", StringComparison.CurrentCultureIgnoreCase) == 0;

        public static ResponseObject<T> Build<T>(string json, bool readPayload)
            where T : Payload
        {
            var resObj = json.Deserialize<ResponseObject<T>>();

            if (resObj != null && readPayload)
            {
                const string startToken = ",\"payload\":";
                const string endToken = ",\"status\":";

                // HACK: extract payload
                var iStart = json.IndexOf(startToken, StringComparison.Ordinal) + 11;
                var iEnd = json.LastIndexOf(endToken, StringComparison.Ordinal);
                var payload = json[iStart..iEnd];
                resObj.Payload = payload.Deserialize<T>();
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