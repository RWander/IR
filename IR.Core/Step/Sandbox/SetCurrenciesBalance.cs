using IR.Core.Common;

namespace IR.Core.Step.Sandbox
{
    internal sealed class SetCurrenciesBalance:
        RestMethodAsync<SetCurrenciesBalance.RequestBody, Payload>
    {
        #region [Request, Response]
        public sealed class RequestBody
        {
            public string Currency { get; set; }

            public int Balance { get; set; }
        }
        #endregion

        protected override string Method => "sandbox/currencies/balance";

        protected override ERestMethodType MethodType => ERestMethodType.POST;

        protected override bool EmptyResponsePayload { get; } = true;

        public SetCurrenciesBalance(RestProxy proxy) : base(proxy) { }
    }
}
