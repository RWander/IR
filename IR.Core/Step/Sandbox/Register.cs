using IR.Core.Common;

namespace IR.Core.Step.Sandbox
{
    internal sealed class Register: RestMethodAsync<object, Payload>
    {
        protected override string Method => "sandbox/register";

        protected override ERestMethodType MethodType => ERestMethodType.POST;

        protected override bool EmptyResponsePayload { get; } = true;

        public Register(RestProxy proxy) : base(proxy) { }
    }
}
