using System.Text.Json.Serialization;

using IR.Core.Common;

namespace IR.Core.Step.Sandbox
{
    internal sealed class SetCurrenciesBalance:
        ApiMethodAsync<SetCurrenciesBalance.RequestBody, SetCurrenciesBalance.ResponsePayload>
    {
        #region [Request, Response]
        public sealed class RequestBody
        {
            [JsonPropertyName("currency")]
            public string Currency { get; set; }

            [JsonPropertyName("balance")]
            public int Balance { get; set; }
        }

        public sealed class ResponsePayload
        {
        }
        #endregion

        protected override string Method => "sandbox/currencies/balance";

        protected override EApiMethodType MethodType => EApiMethodType.POST;

        public SetCurrenciesBalance(ApiProxy proxy) : base(proxy) { }
    }
}
