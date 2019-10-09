using IR.Core.Common;
using IR.Core.Domain;

namespace IR.Core.Step
{
    internal sealed class GetPortfolio : ApiMethodAsync<object, Payload>
    {
        protected override string Method => "portfolio";

        protected override EApiMethodType MethodType => EApiMethodType.GET;

        protected override bool EmptyResponsePayload { get; } = true; // TODO: false

        public Portfolio Portfolio { get; set; }

        public GetPortfolio(ApiProxy proxy) : base(proxy) { }
    }
}