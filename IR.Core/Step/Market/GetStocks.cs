using IR.Core.Common;

namespace IR.Core.Step.Market
{
    internal sealed class GetStocks : ApiMethodAsync
    {
        protected override string Method => "market/stocks";

        protected override EApiMethodType MethodType => EApiMethodType.GET;

        public GetStocks(ApiProxy proxy) : base(proxy) { }
    }
}