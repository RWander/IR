namespace IR.Core.Domain
{
    public sealed class ResponseObject
    {
        public string TrackingId { get; set; }
        public dynamic Payload { get; set; }
        public  string Status { get; set; }

        public override string ToString()
        {
            return $"TrackingId:{TrackingId}; Status:{Status}; Payload:{Payload}";
        }
    }
}