using System;

namespace IR.Core.Step
{
    internal sealed class ResponseObject
    {
        public string TrackingId { get; }
        public dynamic Payload { get; }
        public string Status { get; }

        public ResponseObject(string status, dynamic payload, string trackingId)
        {
            Status = status;
            Payload = payload;
            TrackingId = trackingId;
        }

        public bool IsOk => string.Compare(Status, "Ok", StringComparison.CurrentCultureIgnoreCase) == 0;

        public override string ToString()
        {
            return $"TrackingId:{TrackingId}; Status:{Status}; Payload:{Payload}";
        }
    }
}