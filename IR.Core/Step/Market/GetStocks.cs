using IR.Core.Common;
using IR.Core.Domain;

namespace IR.Core.Step.Market
{
    /// <summary>
    /// Description: https://tinkoffcreditsystems.github.io/invest-openapi/swagger-ui/#/market/get_market_stocks
    /// </summary>
    internal sealed class GetStocks : ApiMethodAsync<object, MarketInstrumentList>
    {
        #region [Request]
        // no params
        #endregion

        #region [Response]
        // See IR.Core.Domain.MarketInstrumentList
        #endregion

        protected override string Method => "market/stocks";

        protected override EApiMethodType MethodType => EApiMethodType.GET;

        protected override bool EmptyResponsePayload { get; } = false;

        public GetStocks(ApiProxy proxy) : base(proxy) { }
    }
}