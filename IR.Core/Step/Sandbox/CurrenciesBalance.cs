using IR.Core.Common;

namespace IR.Core.Step.Sandbox
{
    internal sealed class CurrenciesBalance: ApiMethodAsync
    {
        protected override string Method => "sandbox/currencies/balance";

        protected override string MethodData { get; } = @"
        {
          ""currency"": ""RUB"",
          ""balance"": 100000
        }";

        protected override EApiMethodType MethodType => EApiMethodType.POST;

        public CurrenciesBalance(ApiProxy proxy) : base(proxy) { }
    }
}
