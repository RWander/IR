using IR.Core.Common;
using IR.Core.Domain;

namespace IR.Core.Step
{
    /// <summary>
    /// Description: https://tinkoffcreditsystems.github.io/invest-openapi/swagger-ui/#/orders/post_orders_limit_order
    /// </summary>
    internal sealed class CreateLimitOrder:
        ApiMethodAsync<CreateLimitOrder.RequestBody, CreateLimitOrder.ResponsePayload>
    {
        #region [Request params]
        public string Figi { get; set; }
        #endregion

        #region [Request, Response]
        public sealed class RequestBody
        {
            public ushort Lots { get; set; }

            public string Operation { get; set; }
            
            public uint Price { get; set; }
        }

        public sealed class ResponsePayload: Payload
        {
            public string OrderId { get; set; }
            public string Operation { get; set; }
            public string Status { get; set; }
            public string RejectReason { get; set; }
            public uint RequestedLots { get; set; }
            public uint ExecutedLots { get; set; }
            public _Commission Commission { get; set; }

            #region [Nested classes]
            public sealed class _Commission: Payload
            {
                public string Currency { get; set; }
                public float Value { get; set; }
            }
            #endregion
        }
        #endregion

        protected override string Method => $"orders/limit-order?figi={Figi}";

        protected override EApiMethodType MethodType => EApiMethodType.POST;

        protected override bool EmptyResponsePayload { get; } = false;

        public LimitOrder LimitOrder { get; set; }

        public CreateLimitOrder(ApiProxy proxy) : base(proxy) { }
    }
}