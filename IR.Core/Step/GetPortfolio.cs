using IR.Core.Common;

namespace IR.Core.Step
{
    internal sealed class GetPortfolio : ApiMethodAsync
    {
        protected override string Method => "portfolio";

        protected override EApiMethodType MethodType => EApiMethodType.GET;

        public GetPortfolio(ApiProxy proxy) : base(proxy) { }
    }
}