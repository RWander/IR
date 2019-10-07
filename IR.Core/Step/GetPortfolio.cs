using IR.Core.Common;
using IR.Core.Domain;

namespace IR.Core.Step
{
    internal sealed class GetPortfolio : ApiMethodAsync<object, object>
    {
        protected override string Method => "portfolio";

        protected override EApiMethodType MethodType => EApiMethodType.GET;

        public Portfolio Portfolio { get; set; }

        public GetPortfolio(ApiProxy proxy) : base(proxy) { }
    }
}