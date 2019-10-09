﻿using IR.Core.Common;
using IR.Core.Domain;

namespace IR.Core.Step
{
    /// <summary>
    /// Description: https://tinkoffcreditsystems.github.io/invest-openapi/swagger-ui/#/portfolio
    /// </summary>
    internal sealed class GetPortfolio : ApiMethodAsync<object, Portfolio>
    {
        #region [Request]
        // no params
        #endregion

        #region [Response]
        // see IR.Core.Domain.Portfolio
        #endregion

        protected override string Method => "portfolio";

        protected override EApiMethodType MethodType => EApiMethodType.GET;

        protected override bool EmptyResponsePayload { get; } = false;

        public GetPortfolio(ApiProxy proxy) : base(proxy) { }
    }
}