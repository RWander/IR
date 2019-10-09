using IR.Core.Common;

namespace IR.Core.Step.Sandbox
{
    internal sealed class SetCurrenciesBalance:
        ApiMethodAsync<SetCurrenciesBalance.RequestBody, Payload>
    {
        #region [Request, Response]
        public sealed class RequestBody
        {
            public string Currency { get; set; }

            public int Balance { get; set; }
        }
        #endregion

        protected override string Method => "sandbox/currencies/balance";

        protected override EApiMethodType MethodType => EApiMethodType.POST;

        protected override bool EmptyResponsePayload { get; } = true;

        public SetCurrenciesBalance(ApiProxy proxy) : base(proxy) { }
    }
}
