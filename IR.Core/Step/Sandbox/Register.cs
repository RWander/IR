using IR.Core.Common;

namespace IR.Core.Step.Sandbox
{
    internal sealed class Register: ApiMethodAsync<object, Payload>
    {
        protected override string Method => "sandbox/register";

        protected override EApiMethodType MethodType => EApiMethodType.POST;

        protected override bool EmptyResponsePayload { get; } = true;

        public Register(ApiProxy proxy) : base(proxy) { }
    }
}
