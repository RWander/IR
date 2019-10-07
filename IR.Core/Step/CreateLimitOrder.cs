using System.Text.Json.Serialization;

using IR.Core.Common;
using IR.Core.Domain;

namespace IR.Core.Step
{
    internal sealed class CreateLimitOrder:
        ApiMethodAsync<CreateLimitOrder.RequestBody, CreateLimitOrder.ResponsePayload>
    {
        #region [Request params]
        public string Figi { get; set; }
        #endregion

        #region [Request, Response]
        public sealed class RequestBody
        {
            [JsonPropertyName("lots")]
            public ushort Lots { get; set; }

            [JsonPropertyName("operation")]
            public string Operation { get; set; }
            
            [JsonPropertyName("price")]
            public uint Price { get; set; }
        }

        public sealed class ResponsePayload
        {
        }
        #endregion

        protected override string Method => $"orders/limit-order?figi={Figi}";

        protected override EApiMethodType MethodType => EApiMethodType.POST;

        public LimitOrder LimitOrder { get; set; }

        public CreateLimitOrder(ApiProxy proxy) : base(proxy) { }
    }
}