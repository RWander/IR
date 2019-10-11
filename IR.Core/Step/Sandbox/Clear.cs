using IR.Core.Common;

namespace IR.Core.Step.Sandbox
{
    internal sealed class Clear: RestMethodAsync<object, Payload>
    {
        protected override string Method => "sandbox/clear";

        protected override ERestMethodType MethodType => ERestMethodType.POST;

        protected override bool EmptyResponsePayload { get; } = true;

        public Clear(RestProxy proxy) : base(proxy) { }
    }
}
