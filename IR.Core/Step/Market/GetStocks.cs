using System.Collections.Generic;

using IR.Core.Common;
using IR.Core.Domain;

namespace IR.Core.Step.Market
{
    internal sealed class GetStocks : ApiMethodAsync<object, Payload>
    {
        protected override string Method => "market/stocks";

        protected override EApiMethodType MethodType => EApiMethodType.GET;

        protected override bool EmptyResponsePayload { get; } = true; // TODO: false

        public IList<Stock> Stocks { get; set; }

        public GetStocks(ApiProxy proxy) : base(proxy) { }
    }
}