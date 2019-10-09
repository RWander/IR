using IR.Core.Common;

namespace IR.Core.Step.Sandbox
{
    internal sealed class Clear: ApiMethodAsync<object, Payload>
    {
        protected override string Method => "sandbox/clear";

        protected override EApiMethodType MethodType => EApiMethodType.POST;

        protected override bool EmptyResponsePayload { get; } = true;

        public Clear(ApiProxy proxy) : base(proxy) { }
    }
}
